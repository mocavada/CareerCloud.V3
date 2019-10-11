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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;
        public ApplicantSkillController()
        {
            EFGenericRepository<ApplicantSkillPoco> repo =
                new EFGenericRepository<ApplicantSkillPoco>();

            _logic = new ApplicantSkillLogic(repo);
        }

        // GET
        [HttpGet]
        [Route("skill/{applicantSkillId}")]
        [ResponseType(typeof(ApplicantSkillPoco))]
        public IHttpActionResult GetApplicantSkill(Guid applicantSkillId)
        {
            ApplicantSkillPoco poco = _logic.Get(applicantSkillId);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        // GET ALL
        [HttpGet]
        [Route("skill")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]
        public IHttpActionResult GetAllApplicantSkill()
        {
            List<ApplicantSkillPoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);
        }

        // PUT
        [HttpPut]
        [Route("skill")]
        public IHttpActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        // POST
        [HttpPost]
        [Route("skill")]
        public IHttpActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        // DELETE
        [HttpDelete]
        [Route("skill")]
        public IHttpActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
