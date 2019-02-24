using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Stock.Models;
using Stock.Repositories;
using Swashbuckle.Swagger.Annotations;

namespace Stock.Controllers
{
    /// <summary>
    /// Company details all operations are listed here.
    /// </summary>
    [RoutePrefix("company")]
    public class CompanyDetailsController : ApiController
    { 
        private ICompanyDetailRepository _companyRepo;

        /// <summary>
        /// Constructor where injected all necessary dependency
        /// </summary>
        /// <param name="_companyRepo"></param>
        public CompanyDetailsController(ICompanyDetailRepository _companyRepo)
        {
            this._companyRepo = _companyRepo;
        }

        /// <summary>
        /// Get all companies details
        /// </summary>
        [HttpGet, Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(List<CompanyDetailVm>))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get()
        {
            var companies = _companyRepo.Get();
            if (companies == null)
                return NotFound();

            return Ok(companies);
        }

        /// <summary>
        /// Get all company detail based on passed Security ID
        /// </summary>
        /// <param name="id">Security Id</param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CompanyDetailVm))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(string id)
        {
            var company = _companyRepo.Get(id);
            if (company == null)
                return NotFound();

            return Ok(company);
        }

        /// <summary>
        /// Add company details
        /// </summary>
        /// <param name="model"></param>
        [HttpPost, Route()]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IHttpActionResult Post([FromBody]CompanyDetailVm model)
        {
            try
            {
                if (_companyRepo.Add(model))
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
        public IHttpActionResult Put(string id, [FromBody]CompanyDetailVm model)
        {
            if (string.CompareOrdinal(id, model.SecurityId) != 0)
                return BadRequest();

            try
            {
                if (_companyRepo.Edit(model))
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
        [HttpDelete, Route("{id}")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public IHttpActionResult Delete(string id)
        {
            if (_companyRepo.Get(id) == null)
                return NotFound();

            try
            {
                if (_companyRepo.Delete(id))
                    return Ok();
            }
            catch
            {
            }
            return InternalServerError();
        }
    }
}