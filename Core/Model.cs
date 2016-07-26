using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public class Event
	{
		[BsonId]
		[JsonProperty("id")]
		public string Id { get; set; }

		[BsonElement("name")]
		[JsonProperty("name")]
		public string Name { get; set; }

		[BsonElement("people")]
		[JsonProperty("people")]
		public List<People> People { get; set; }
	}

	public class People
	{
		[BsonId]
		[JsonProperty("id")]
		public string Id { get; set; }

		[BsonElement("name")]
		[JsonProperty("name")]
		public string Name { get; set; }

		[BsonElement("expenses")]
		[JsonProperty("expenses")]
		public List<Expense> Expenses { get; set; }
	}

	public class Expense
	{
		[BsonId]
		[JsonProperty("id")]
		public string Id { get; set; }

		[BsonElement("date")]
		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[BsonElement("amount")]
		[JsonProperty("amount")]
		public decimal Amount { get; set; }

		[BsonElement("targets")]
		[JsonProperty("targets")]
		List<string> Targets { get; set; }
	}
}
