using System;
using System.Linq;

using UIKit;
using Foundation;

using SharedBudget.Model;
using SharedBudget.Logic.Client;

namespace SharedBudget.iOS
{
	public partial class EventsViewController : UITableViewController
	{
		EventService Service {
			get {
				return ((AppDelegate)UIApplication.SharedApplication.Delegate).EventService;
			}
		}

		public EventsViewController (IntPtr handle) : base (handle)
		{
		}



		partial void AddEvent (UIBarButtonItem sender)
		{
			Console.WriteLine ("add event");
			var alert = UIAlertController.Create ("Create new event", string.Empty, UIAlertControllerStyle.Alert);
			alert.AddTextField (tf => {
				tf.Placeholder = "event name";
			});

			var okAction = UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, alertAction => {
				AddEvent (new Event { Name = alert.TextFields [0].Text.Trim () });
			});
			alert.AddAction (okAction);

			var cancelAction = UIAlertAction.Create ("Cancel", UIAlertActionStyle.Cancel, UIAlertAction => {
				Console.WriteLine ("cancel");
			});
			alert.AddAction (cancelAction);

			PresentViewController (alert, true, () => {
				Console.WriteLine ("PresentViewController completion handler called");
			});
		}

		void AddEvent (Event newEvent)
		{
			Service.AddEvent (newEvent);
			TableView.ReloadData ();

			foreach (var e in Service.GetAllEvents ())
				Console.WriteLine ($"{e.Id} {e.Name}");
		}
	}
}
