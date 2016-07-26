using MongoDB.Bson.Serialization.Attributes;
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
		public Guid Id { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

		[BsonElement("people")]
		public List<People> People { get; set; }
	}

	public class People
	{
		[BsonId]
		public Guid Id { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

		[BsonElement("expenses")]
		public List<Expense> Expenses { get; set; }
	}

	public class Expense
	{
		[BsonId]
		public Guid Id { get; set; }

		[BsonElement("date")]
		public DateTime Date { get; set; }

		[BsonElement("amount")]
		public decimal Amount { get; set; }

		[BsonElement("targets")]
		List<Guid> Targets { get; set; }
	}
}
