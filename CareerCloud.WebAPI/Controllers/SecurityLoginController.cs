using CareerCloud.BusinessLogicLayer;
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
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginController : ApiController
    {
        private SecurityLoginLogic _logic;
        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> repo =
                new EFGenericRepository<SecurityLoginPoco>();

            _logic = new SecurityLoginLogic(repo);
        }

        // GET
        [HttpGet]
        [Route("login/{securityLoginId}")]
        [ResponseType(typeof(SecurityLoginPoco))]
        public IHttpActionResult GetSecurityLogin(Guid securityLoginId)
        {
            SecurityLoginPoco poco = _logic.Get(securityLoginId);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        // GET ALL
        [HttpGet]
        [Route("login")]
        [ResponseType(typeof(List<SecurityLoginPoco>))]
        public IHttpActionResult GetAllSecurityLogin()
        {
            List<SecurityLoginPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);
        }

        // PUT
        [HttpPut]
        [Route("login")]
        public IHttpActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        // POST
        [HttpPost]
        [Route("login")]
        public IHttpActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        // DELETE
        [HttpDelete]
        [Route("login")]
        public IHttpActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
