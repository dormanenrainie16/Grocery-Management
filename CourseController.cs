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

        public int classCount = 3;
        [HttpPost]
        [Route("AddOrUp")]
        public async Task<IHttpActionResult> AddOrUp([FromBody] Course course)
        {
            if (course != null)
            {
                //classCount++;
                if (course.Id == 6)
                {
                    Array.Resize(ref DbMock.Classes, 40);
                }
                // DbMock.Classes.Add(course);
                DbMock.Classes[course.Id] = course;
            }

            return Ok(course);
        }
    }
}