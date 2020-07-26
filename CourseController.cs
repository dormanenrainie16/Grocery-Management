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
        [Route("AddOrUp")]
        public async Task<IHttpActionResult> AddOrUp([FromBody] Course course)
        {
            if (course != null)
            {
                //classCount++;
                if (course.Id == 499)
                {
                    Array.Resize(ref DbMock.Classes, 1000);
                }
                // DbMock.Classes.Add(course);
                DbMock.Classes[course.Id] = course;
            }

            return Ok(course);
        }
    }
}