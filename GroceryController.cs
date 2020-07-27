using ShoppingSPA.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ShoppingSPA.Controllers.Api
{
    [RoutePrefix("api/Grocery")]
    public class GroceryController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(DbMock.Groceries);
        }


        [HttpPost]
        [Route("AddOrUp")]
        public async Task<IHttpActionResult> AddOrUp([FromBody] Grocery grocery)
        {
            if (grocery != null)
            {
                //classCount++;
                if (grocery.Id == 499)
                {
                    Array.Resize(ref DbMock.Groceries, 1000);
                }
                // DbMock.Groceries.Add(grocery);
                DbMock.Groceries[grocery.Id] = grocery;
            }

            return Ok(grocery);
        }
    }
}