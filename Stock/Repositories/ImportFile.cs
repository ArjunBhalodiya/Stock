using System;
using System.Linq;
using System.Net;
using System.Web;
using LinqToExcel;
using Stock.GlobalClass;
using Stock.Models;

namespace Stock.Repositories
{
    public class ImportFile : IImportFile
    {
        public static string filePath;

        public HttpStatusCode Upload(string securityID, FileUploadType fileType, HttpRequest httpRequest)
        {
            if (httpRequest.Files.Count != 1)
                return HttpStatusCode.BadRequest;
            else
            {
                var postedFile = httpRequest.Files[0];
                if (FileHandling.IsCSV(postedFile.FileName))
                    return HttpStatusCode.BadRequest;

                filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                postedFile.SaveAs(filePath);

                if (ProcessFile(securityID, fileType))
                    return HttpStatusCode.OK;

                return HttpStatusCode.InternalServerError;
            }
        }

        private bool ProcessFile(string securityID, FileUploadType fileType)
        {
            try
            {
                // Create connection to excel file
                ExcelQueryFactory connection = new ExcelQueryFactory(filePath);

                //Query a worksheet with a header row  
                var rows = from row in connection.Worksheet(0)
                           select row;

                // Fill stock list
                foreach (var row in rows)
                {
                    var result = new StockPriceRepository().Add(new StockPriceVm
                    {
                        SecurityId = securityID,
                        Date = Convert.ToDateTime(row[0]),
                        Open = Convert.ToDecimal(row[1]),
                        High = Convert.ToDecimal(row[2]),
                        Low = Convert.ToDecimal(row[3]),
                        Close = Convert.ToDecimal(row[4]),
                        WAP = Convert.ToDecimal(row[5]),
                        NoOfShares = Convert.ToInt32(row[6]),
                        NoOfTrades = Convert.ToInt32(row[7]),
                        TotalTurnOver = Convert.ToInt32(row[8]),
                        DeliverableQty = Convert.ToInt32(row[9])
                    });

                    if (!result)
                        return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}