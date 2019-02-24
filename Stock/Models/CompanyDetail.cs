using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Stock.Models
{
    /// <summary>
    /// Company data model that can be used to interact with database
    /// </summary>
    public class CompanyDetailDm
    {
        /// <summary>
        /// Security Id that will be unique per company
        /// </summary>
        public string SecurityId { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Company Benchmark Index
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Face value of company
        /// </summary>
        public decimal FaceValue { get; set; }

        /// <summary>
        /// Registered security code in stock exchange
        /// </summary>
        public long SecurityCode { get; set; }

        /// <summary>
        /// International Securities Identification Number
        /// </summary>
        public string ISIN { get; set; }

        /// <summary>
        /// Industries Type
        /// </summary>
        public string Industries { get; set; }

        /// <summary>
        /// Stock price of Company
        /// </summary>
        public ICollection<StockPriceDm> DailyStockPrice { get; set; }
    }

    public class CompanyDetailModelConfig : EntityTypeConfiguration<CompanyDetailDm>
    {
        public CompanyDetailModelConfig()
        {
            HasKey(t => t.SecurityId);

            Property(t => t.Name).IsRequired();
            Property(t => t.Index).IsRequired();
            Property(t => t.FaceValue).IsRequired();
            Property(t => t.SecurityCode).IsRequired();
            Property(t => t.ISIN).IsRequired();
            Property(t => t.Industries).IsRequired();

            HasMany(t => t.DailyStockPrice).WithRequired(u => u.CompanyDetail);

            ToTable("CompanyDetail");
        }
    }
}