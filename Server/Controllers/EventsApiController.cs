using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Core;
using MongoDB.Driver;

namespace Server.Controllers
{
	[RoutePrefix("api/events")]
    public class EventsApiController : ApiController
    {
		const string connectionString = "mongodb://127.0.0.1/shared-budget-dev";
		readonly SharedBugdetRepository repo;

		public EventsApiController()
		{
			var mongoUrl = new MongoUrl(connectionString);
			var client = new MongoClient(mongoUrl);
			IMongoDatabase mongoDb = client.GetDatabase(mongoUrl.DatabaseName);
			repo = new SharedBugdetRepository(mongoDb);
		}

		[HttpPost]
		[Route("")]
		public void AddNewEvent(Event newEvent)
		{
			repo.Add(newEvent);
		}
	}
}
