using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Stock.Models;
using Stock.Repositories;
using Swashbuckle.Swagger.Annotations;

namespace Stock.Controllers
{
    /// <summary>
    /// Stock Price all operations are listed here.
    /// </summary>
    [RoutePrefix("stock")]
    public class StockPricesController : ApiController
    {
        private IStockPriceRepository _stockRepo;

        /// <summary>
        /// Constructor where injected all necessary dependency
        /// </summary>
        /// <param name="_stockRepo"></param>
        public StockPricesController(IStockPriceRepository _stockRepo)
        {
            this._stockRepo = _stockRepo;
        }

        /// <summary>
        /// Get all company detail based on passed Security ID
        /// </summary>
        /// <param name="id">Security Id</param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<StockPriceVm>))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(string id)
        {
            var stocks = _stockRepo.Get(id);
            if (stocks == null)
                return NotFound();

            return Ok(stocks);
        }

        /// <summary>
        /// Get all company detail based on passed Security ID and date
        /// </summary>
        /// <param name="id">Security Id</param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/{date}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(StockPriceVm))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(string id, DateTime date)
        {
            var stock = _stockRepo.Get(id, date);
            if (stock == null)
                return NotFound();

            return Ok(stock);
        }

        /// <summary>
        /// Get all company detail based on passed Security ID, from-date and to-date
        /// </summary>
        /// <param name="id">Security Id</param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/{fromDate}/{toDate}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<StockPriceVm>))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(string id, DateTime fromDate, DateTime toDate)
        {
            var stocks = _stockRepo.Get(id, fromDate, toDate);
            if (stocks == null)
                return NotFound();

            return Ok(stocks);
        }

        /// <summary>
        /// Get all company detail based on passed from-date and to-date
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet, Route("{fromDate}/{toDate}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<StockPriceVm>))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(DateTime fromDate, DateTime toDate)
        {
            var stocks = _stockRepo.Get(fromDate, toDate);
            if (stocks == null)
                return NotFound();

            return Ok(stocks);
        }

        /// <summary>
        /// Add company details
        /// </summary>
        /// <param name="model"></param>
        [HttpPost, Route()]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IHttpActionResult Post([FromBody]StockPriceVm model)
        {
            try
            {
                if (_stockRepo.Add(model))
                    return Ok();
            }
            catch
            {
            }
            return InternalServerError();
        }

        /// <summary>
        /// Update company details
        /// </summary>
        /// <param name="id">Security Id</param>
        /// <param name="model"></param>
        [HttpPut, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IHttpActionResult Put(string id, [FromBody]StockPriceVm model)
        {
            if (string.CompareOrdinal(id, model.SecurityId) != 0)
                return BadRequest();

            try
            {
                if (_stockRepo.Edit(model))
                    return Ok();
            }
            catch
            {
            }
            return InternalServerError();
        }

        /// <summary>
        /// Delete company detail
        /// </summary>
        /// <param name="id">Security Id</param>
        /// <param name="date"></param>
        [HttpDelete, Route("{id}/{date}")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IHttpActionResult Delete(string id, DateTime date)
        {
            if (_stockRepo.Get(id, date) == null)
                return NotFound();

            try
            {
                if (_stockRepo.Delete(id, date))
                    return Ok();
            }
            catch
            {
            }
            return InternalServerError();
        }
    }
}
