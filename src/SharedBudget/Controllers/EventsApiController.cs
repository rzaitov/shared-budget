using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using Core;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SharedBudget.Controllers
{
    [Route("api/events")]
    public class EventsApiController : Controller
    {
		const string connectionString = "mongodb://127.0.0.1/shared-budget";
		readonly SharedBugdetRepository repo;

		public EventsApiController()
		{
			var mongoUrl = new MongoUrl(connectionString);
			var client = new MongoClient(mongoUrl);
			IMongoDatabase mongoDb = client.GetDatabase(mongoUrl.DatabaseName);
			repo = new SharedBugdetRepository(mongoDb);
		}

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
		[Route("add")]
        public void Post(Eve)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
