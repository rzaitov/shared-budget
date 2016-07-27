using System;

using UIKit;
using Foundation;

namespace SharedBudget.iOS
{
	public partial class TabBarController : UITabBarController
	{
		public UIViewController ExpensesController {
			get {
				return ViewControllers [0];
			}
		}

		public UIViewController StatisticsController {
			get {
				return ViewControllers [1];
			}
		}

		public TabBarController (IntPtr handle) : base (handle)
		{
		}
	}
}
