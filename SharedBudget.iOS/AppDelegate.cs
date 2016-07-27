using Foundation;
using UIKit;

using SharedBudget.Logic.Client;

namespace SharedBudget.iOS
{
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window {
			get;
			set;
		}

		// This is service a locator.
		public EventService EventService { get; private set; }

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			EventService = new EventService ();
			return true;
		}
	}
}
