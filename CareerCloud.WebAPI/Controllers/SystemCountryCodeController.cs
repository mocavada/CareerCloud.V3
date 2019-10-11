﻿using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repo =
                new EFGenericRepository<SystemCountryCodePoco>();

            _logic = new SystemCountryCodeLogic(repo);
        }

        // GET
        [HttpGet]
        [Route("countrycode/{systemCountryCodeId}")]
        [ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemCountryCode(string systemCountryCodeId)
        {
            SystemCountryCodePoco poco = _logic.Get(systemCountryCodeId);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        // GET ALL
        [HttpGet]
        [Route("countryCode")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetAllSystemCountryCode()
        {
            var applicants = _logic.GetAll();

            if (applicants == null)
            {
                return NotFound();
            }

            return Ok(applicants);
        }

        // PUT
        [HttpPut]
        [Route("countryCode")]
        public IHttpActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        // POST
        [HttpPost]
        [Route("countryCode")]
        public IHttpActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        // DELETE
        [HttpDelete]
        [Route("countryCode")]
        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}