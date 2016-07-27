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
				Id = GenerateId (),
				Name = "Шерегеш 2016",
				People = new List<People> {
					new People {
						Id = GenerateId (),
						Name = "Rustam",
						Expenses = new List<Expense> {
							new Expense {
								Id = GenerateId (),
								Amount = 100,
								Description = "Продукты"
							},
							new Expense {
								Id = GenerateId (),
								Amount = 200,
								Description = "Кино"
							},
							new Expense {
								Id = GenerateId (),
								Amount = 300,
								Description = "Подъемник"
							}
						}
					}
				}
			},
			new Event {
				Id = GenerateId (),
				Name = "Гудаури 2015"
			},
			new Event {
				Id = GenerateId (),
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

		public Event GetEvent (string eventId)
		{
			return events.Find (e => e.Id == eventId);
		}

		static string GenerateId ()
		{
			return Guid.NewGuid ().ToString ();
		}
	}
}
