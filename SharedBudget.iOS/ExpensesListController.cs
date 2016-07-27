using System;
using System.Linq;

using UIKit;
using Foundation;

using SharedBudget.Model;
using SharedBudget.Logic.Client;

namespace SharedBudget.iOS
{
	public partial class ExpensesListController : UITableViewController
	{
		EventService Service {
			get {
				return ((AppDelegate)UIApplication.SharedApplication.Delegate).EventService;
			}
		}

		Event currentEvent;
		Expense [] eventExpenses;

		public string EventId { get; set; }

		public ExpensesListController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			currentEvent = Service.GetEvent (EventId);
			eventExpenses = currentEvent.People.SelectMany (p => p.Expenses).ToArray ();

			Title = currentEvent.Name;
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			return eventExpenses.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("expense-cell", indexPath);

			var expense = eventExpenses [indexPath.Row];
			cell.TextLabel.Text = $"{expense.Description} {expense.Amount}";

			return cell;
		}
	}
}
