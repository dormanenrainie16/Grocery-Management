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
        [Route("AddOrUpdate")]
        public async Task<IHttpActionResult> AddOrUpdate([FromBody] Grocery grocery)
        {
            if (grocery != null)
            {
                DbMock.Groceries.Add(grocery);
            }

            return Ok(grocery);
        }
    }
}