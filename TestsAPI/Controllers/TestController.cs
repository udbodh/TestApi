using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestsAPI.Models;

namespace TestsAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        // Datasource
        private static List<Person> Persons => new List<Person>
        {
            new Person { FirstName = "AAA", LastName = "BBB", Interests = new List<string> {"111, 222, 333"}},
            new Person { FirstName = "CCC", LastName = "BBB", Interests = new List<string> {"444, 555, 666"}},
            new Person { FirstName = "DDD", LastName = "EEE", Interests = new List<string> {"777, 888, 999"}},
            new Person { FirstName = "DDD", LastName = "FFF", Interests = new List<string> {"100, 110, 120"}},
            new Person { FirstName = "GGG", LastName = "III", Interests = new List<string> {"130, 140, 150"}},
            new Person { FirstName = "HHH", LastName = "III", Interests = new List<string> {"160, 170, 180"}},
            new Person { FirstName = "JJJ", LastName = "KKK", Interests = new List<string> {"190, 200, 210"}},
            new Person { FirstName = "LLL", LastName = "NNN", Interests = new List<string> {"310, 320, 330"}},
            new Person { FirstName = "MMM", LastName = "LLL", Interests = new List<string> {"340, 350, 360"}},
            new Person { FirstName = "LLL", LastName = "OOO", Interests = new List<string> {"370, 380, 390"}}
        };

        public TestController() { }

        [HttpGet]
        [Route("search/{query}")]
        ///localhost:52146/api/test/search/lll ---Checked in Postman 
        public IHttpActionResult GetLikeFirstNameOrLastname(string query)
        {
            query = (query?.Trim() ?? string.Empty).ToLower();

            try
            {
                var result = Persons.Where(x => x.FirstName.ToLower() == query || x.LastName.ToLower() == query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}