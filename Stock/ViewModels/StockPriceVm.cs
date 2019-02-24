using System;

namespace Stock.Models
{
    /// <summary>
    /// Stock price model that can be used to interact with API
    /// </summary>
    public class StockPriceVm
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
    }
}