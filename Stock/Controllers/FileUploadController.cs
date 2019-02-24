using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Stock.GlobalClass;
using Stock.Repositories;
using Swashbuckle.Swagger.Annotations;

namespace Stock.Controllers
{
    /// <summary>
    /// To upload file, use this controller
    /// </summary>
    [RoutePrefix("upload")]
    public class FileUploadController : ApiController
    {
        private IImportFile _importFile;

        public FileUploadController(IImportFile _importFile)
        {
            this._importFile = _importFile;
        }

        /// <summary>
        /// Upload CSV file having company stock historical price
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("company/{securityID}/historical-data")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(HttpResponseMessage))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage PostCompanyHistoricalData(string securityID)
        {
            return Request.CreateResponse(_importFile.Upload(securityID, FileUploadType.CompanyHistoricalData,
                                                            HttpContext.Current.Request));
        }

        /// <summary>
        /// Upload CSV file having company stock historical price
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("companies/daily-data")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(HttpResponseMessage))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public HttpResponseMessage PostCompanyDailyData()
        {
            return Request.CreateResponse(_importFile.Upload(string.Empty, FileUploadType.CompanyDailyData,
                                                            HttpContext.Current.Request));
        }
    }
}