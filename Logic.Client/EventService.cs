using System;
using System.Collections.Generic;
using SharedBudget.Model;

namespace SharedBudget.Logic.Client
{
	public class EventService
	{
		// TODO: replace with persistent storage
		readonly List<Event> events = new List<Event> {
			new Event {
				Id = Guid.NewGuid ().ToString(),
				Name = "Шерегеш 2016"
			},
			new Event {
				Id = Guid.NewGuid ().ToString(),
				Name = "Гудаури 2015"
			},
			new Event {
				Id = Guid.NewGuid().ToString(),
				Name = "Маерхофен 2014"
			}
		};

		public void AddEvent (Event newEvent)
		{
			if (newEvent == null)
				throw new ArgumentNullException (nameof (newEvent));

			if (string.IsNullOrWhiteSpace (newEvent.Id))
				newEvent.Id = Guid.NewGuid ().ToString();

			// Store localy
			events.Add (newEvent);

			// Push to server
		}

		public List<Event> GetAllEvents ()
		{
			return events;
		}
	}
}
