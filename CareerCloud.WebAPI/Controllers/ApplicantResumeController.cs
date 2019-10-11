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
    public class ApplicantResumeController : ApiController
    {
        private ApplicantResumeLogic _logic;
        public ApplicantResumeController()
        {
            EFGenericRepository<ApplicantResumePoco> repo =
                new EFGenericRepository<ApplicantResumePoco>();

            _logic = new ApplicantResumeLogic(repo);
        }

        // GET
        [HttpGet]
        [Route("resume/{applicantResumeId}")]
        [ResponseType(typeof(ApplicantResumePoco))]
        public IHttpActionResult GetApplicantResume(Guid applicantResumeId)
        {
            ApplicantResumePoco poco = _logic.Get(applicantResumeId);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }

        // GET ALL
        [HttpGet]
        [Route("resume")]
        [ResponseType(typeof(List<ApplicantResumePoco>))]
        public IHttpActionResult GetAllApplicantResume()
        {
            List<ApplicantResumePoco> pocos = _logic.GetAll();

            if (pocos == null)
            {
                return NotFound();
            }

            return Ok(pocos);
        }

        // PUT
        [HttpPut]
        [Route("resume")]
        public IHttpActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        // POST
        [HttpPost]
        [Route("resume")]
        public IHttpActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        // DELETE
        [HttpDelete]
        [Route("resume")]
        public IHttpActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
