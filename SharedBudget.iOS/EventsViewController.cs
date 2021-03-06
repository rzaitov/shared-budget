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

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return Service.GetAllEvents ().Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("event-cell", indexPath);
			cell.TextLabel.Text = Service.GetAllEvents () [indexPath.Row].Name;

			return cell;
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "GoToExpenses") {
				var ip = TableView.IndexPathForCell ((UITableViewCell)sender);
				var selectedEvent = Service.GetAllEvents () [ip.Row];

				var tabBarController = (TabBarController)segue.DestinationViewController;
				tabBarController.ExpensesController.EventId = selectedEvent.Id;
				tabBarController.Title = selectedEvent.Name;
			}
		}
	}
}
