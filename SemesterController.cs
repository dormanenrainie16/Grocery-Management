using ShoppingSPA.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ShoppingSPA.Controllers.Api
{
    [RoutePrefix("api/Semester")]
    public class SemesterController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(DbMock.Semesters);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return Ok(DbMock.Semesters.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        [Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdate([FromBody] Semester semester)
        {
            if(semester != null)
            {
                DbMock.Semesters.Add(semester);
            }

            return Ok(semester);
        }

    }
}