using System;
using System.Collections.Generic;
using Stock.Models;

namespace Stock.Repositories
{
    public interface IStockPriceRepository
    {
        bool Add(StockPriceVm stockPrice);
        bool Edit(StockPriceVm stockPrice);
        bool Delete(string securityId, DateTime date);
        List<StockPriceVm> Get(string securityId);
        StockPriceVm Get(string securityId, DateTime date);
        List<StockPriceVm> Get(string securityId, DateTime fromDate, DateTime toDate);
        List<StockPriceVm> Get(DateTime fromDate, DateTime toDate);
    }
}