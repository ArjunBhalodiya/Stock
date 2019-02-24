using System;
using System.Data.Entity.ModelConfiguration;

namespace Stock.Models
{
    /// <summary>
    /// Stock price model that can be used to interact with database
    /// </summary>
    public class StockPriceDm
    {
        /// <summary>
        /// Security Id that will be unique per company
        /// </summary>
        public string SecurityId { get; set; }

        /// <summary>
        /// Date of stock price
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Opening price
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// Closing price
        /// </summary>
        public decimal Close { get; set; }

        /// <summary>
        /// Highest price of stock in a day
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// Lowest price of stock in a day
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// weighted average price
        /// </summary>
        public decimal WAP { get; set; }

        /// <summary>
        /// Total no of shares
        /// </summary>
        public int NoOfShares { get; set; }

        /// <summary>
        /// Total no of shares trades
        /// </summary>
        public int NoOfTrades { get; set; }

        /// <summary>
        /// Company total turnover 
        /// </summary>
        public int TotalTurnOver { get; set; }

        /// <summary>
        /// Deliverable quantity
        /// </summary>
        public int DeliverableQty { get; set; }


        /// <summary>
        /// Company details
        /// </summary>
        public virtual CompanyDetailDm CompanyDetail { get; set; }
    }

    public class StockPriceModelConfig : EntityTypeConfiguration<StockPriceDm>
    {
        public StockPriceModelConfig()
        {
            HasKey(p => new { p.SecurityId, p.Date });

            Property(t => t.SecurityId).IsRequired();
            Property(t => t.Date).IsRequired();
            Property(t => t.Open).IsRequired();
            Property(t => t.Close).IsRequired();
            Property(t => t.High).IsRequired();
            Property(t => t.Low).IsRequired();
            Property(t => t.WAP).IsRequired();
            Property(t => t.NoOfShares).IsRequired();
            Property(t => t.NoOfTrades).IsRequired();
            Property(t => t.WAP).IsRequired();
            Property(t => t.TotalTurnOver).IsRequired();
            Property(t => t.DeliverableQty).IsRequired();

            HasRequired(t => t.CompanyDetail).WithMany(u => u.DailyStockPrice);

            ToTable("StockPrice");
        }
    }
}