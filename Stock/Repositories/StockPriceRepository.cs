using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Stock.DataAccess;
using Stock.Models;

namespace Stock.Repositories
{
    /// <summary>
    /// Perform StockPrice related all database operations perform here
    /// </summary>
    public class StockPriceRepository : IStockPriceRepository, IDisposable
    {
        private StockDataContext data;

        public StockPriceRepository()
        {
            data = new StockDataContext();
        }

        /// <summary>
        /// Add Stock price
        /// </summary>
        /// <param name="stockPrice"></param>
        /// <returns></returns>
        public bool Add(StockPriceVm stockPrice)
        {
            var stockPriceDm = Mapper.Map<StockPriceDm>(stockPrice);
            try
            {
                var companyDetail = data.CompanyDetails.FirstOrDefault(p => p.SecurityId == stockPrice.SecurityId);
                if (companyDetail == null)
                    return false;

                if (data.StockPrices.Any(p => p.SecurityId == stockPrice.SecurityId && p.Date == stockPrice.Date))
                    return true;

                data.Entry(stockPriceDm).State = EntityState.Added;
                if (data.SaveChanges() > 0)
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Edit stock price
        /// </summary>
        /// <param name="stockPrice"></param>
        /// <returns></returns>
        public bool Edit(StockPriceVm stockPrice)
        {
            var stockPriceDm = Mapper.Map<StockPriceDm>(stockPrice);
            try
            {
                data.Entry(stockPriceDm).State = EntityState.Modified;
                if (data.SaveChanges() > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// Delete stock price
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool Delete(string securityId, DateTime date)
        {
            var stockPriceVm = Get(securityId, date);
            if (stockPriceVm == null)
                return false;

            var stockPriceDm = Mapper.Map<StockPriceDm>(stockPriceVm);
            try
            {
                data.Entry(stockPriceDm).State = EntityState.Deleted;
                if (data.SaveChanges() > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// Get stock price based of company
        /// </summary>
        /// <param name="securityId"></param>
        /// <returns></returns>
        public List<StockPriceVm> Get(string securityId)
        {
            try
            {
                var companyDetailsDm = data.StockPrices.Where(p => p.SecurityId == securityId).ToList();
                if (companyDetailsDm != null)
                    return Mapper.Map<List<StockPriceVm>>(companyDetailsDm);
            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// Get stock price based of company for specified date
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public StockPriceVm Get(string securityId, DateTime date)
        {
            try
            {
                var companyDetailDm = data.StockPrices.FirstOrDefault(p => p.SecurityId == securityId &&
                                                                            p.Date == date);
                if (companyDetailDm != null)
                    return Mapper.Map<StockPriceVm>(companyDetailDm);
            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// Get stock price based of company between dates
        /// </summary>
        /// <param name="securityId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<StockPriceVm> Get(string securityId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var companyDetailsDm = data.StockPrices.Where(p => p.SecurityId == securityId &&
                                                                   p.Date > fromDate &&
                                                                   p.Date < toDate).ToList();
                if (companyDetailsDm != null)
                    return Mapper.Map<List<StockPriceVm>>(companyDetailsDm);
            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// Get stock price based of all company for between dates
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<StockPriceVm> Get(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var companyDetailsDm = data.StockPrices.Where(p => p.Date > fromDate &&
                                                                   p.Date < toDate).ToList();
                if (companyDetailsDm != null)
                    return Mapper.Map<List<StockPriceVm>>(companyDetailsDm);
            }
            catch
            {

            }
            return null;
        }

        public void Dispose()
        {
            if (data != null)
                data.Dispose();
        }
    }
}