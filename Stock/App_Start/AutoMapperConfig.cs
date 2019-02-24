using AutoMapper;
using Stock.Models;

namespace Stock
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<CompanyDetailDm, CompanyDetailVm>().ReverseMap();
                config.CreateMap<StockPriceDm, StockPriceVm>().ReverseMap();
            });
        }
    }
}