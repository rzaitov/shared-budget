using System;
using System.Collections.Generic;
using SharedBudget.Model;

namespace SharedBudget.Logic.Client
{
	public class EventService
	{
		// TODO: replace with persistent storage
		readonly Dictionary<string, Event> eventsMap = new Dictionary<string, Event> ();

		public void AddEvent (Event newEvent)
		{
			if (newEvent == null)
				throw new ArgumentNullException (nameof (newEvent));

			if (string.IsNullOrWhiteSpace (newEvent.Id))
				newEvent.Id = Guid.NewGuid ().ToString();

			// Store localy
			eventsMap.Add (newEvent.Id, newEvent);

			// Push to server
		}

		public IEnumerable<Event> GetAllEvents ()
		{
			return eventsMap.Values;
		}
	}
}
