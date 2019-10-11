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
    public class SecurityRoleController : ApiController
    {
        private SecurityRoleLogic _logic;
        public SecurityRoleController()
        {
            EFGenericRepository<SecurityRolePoco> repo =
                new EFGenericRepository<SecurityRolePoco>();

            _logic = new SecurityRoleLogic(repo);
        }

        // GET
        [HttpGet]
        [Route("role/{securityRoleId}")]
        [ResponseType(typeof(SecurityRolePoco))]
        public IHttpActionResult GetSecurityRole(Guid securityRoleId)
        {
            SecurityRolePoco poco = _logic.Get(securityRoleId);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        // GET ALL
        [HttpGet]
        [Route("role")]
        [ResponseType(typeof(List<SecurityRolePoco>))]
        public IHttpActionResult GetAllSecurityRole()
        {
            List<SecurityRolePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);
        }

        // PUT
        [HttpPut]
        [Route("role")]
        public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        // POST
        [HttpPost]
        [Route("role")]
        public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        // DELETE
        [HttpDelete]
        [Route("role")]
        public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
