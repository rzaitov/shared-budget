using System;
using System.Linq;
using System.Collections.Generic;

using MongoDB.Driver;

namespace Core
{
	public class SharedBugdetRepository
	{
		const string eventsCollectionName = "events";

		readonly IMongoDatabase mongoDb;
		readonly IMongoCollection<Event> eventsCollection;

		public SharedBugdetRepository(IMongoDatabase mongoDb)
		{
			if (mongoDb == null)
				throw new ArgumentNullException(nameof(mongoDb));
			this.mongoDb = mongoDb;
			eventsCollection = mongoDb.GetCollection<Event>(eventsCollectionName);
		}

		public void Add(Event newEvent)
		{
			eventsCollection.InsertOne(newEvent);
		}
	}
}
