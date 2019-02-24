using FluentValidation.Attributes;
using Stock.Valiidator;

namespace Stock.Models
{
    /// <summary>
    /// Company data model that can be used to interact with API
    /// </summary>
    [Validator(typeof(CompanyDetailsValidator))]
    public class CompanyDetailVm
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
    }
}