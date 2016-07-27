using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SharedBudget.Model
{
	public class Event
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty ("people")]
		public List<People> People { get; set; } = new List<People> ();
	}

	public class People
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("expenses")]
		public List<Expense> Expenses { get; set; }
	}

	public class Expense
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("amount")]
		public decimal Amount { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("targets")]
		List<string> Targets { get; set; }
	}
}
