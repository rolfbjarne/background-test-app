using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace BackgroundFetchApp
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UIViewController viewController;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(2);

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new UIViewController ();
			viewController.View.BackgroundColor = UIColor.Yellow;
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();

			return true;
		}
			
		public override void PerformFetch (UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
		{
			Console.WriteLine ("{0} PerformFetch", DateTime.Now);
			viewController.View.BackgroundColor = UIColor.Green;
			completionHandler(UIBackgroundFetchResult.NewData); // NewData so that iOS doesn't call us less frequently during testing.
		}

		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}

