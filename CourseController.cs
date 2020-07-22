using ShoppingSPA.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ShoppingSPA.Controllers.Api
{
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(DbMock.Classes);
        }

        [HttpPost]
        [Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdate([FromBody] Course course)
        {
            if (course != null)
            {
                DbMock.Classes.Add(course);
            }

            return Ok(course);
        }
    }
}