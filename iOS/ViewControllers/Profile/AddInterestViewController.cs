using Foundation;
using System;
using UIKit;

namespace hyperios.iOS.ViewControllers.Profile
{
    public partial class AddInterestViewController : UIViewController
    {
        public AddInterestViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

		public override bool CanPerformUnwind(ObjCRuntime.Selector segueAction, UIViewController fromViewController, NSObject sender)
		{
			bool can = base.CanPerformUnwind(segueAction, fromViewController, sender);
			Console.WriteLine($"add interest here...{can}");
			//return base.CanPerformUnwind(segueAction, fromViewController, sender);
			return true;
		}

        partial void NextButton_TouchUpInside(UIButton sender)
        {
            PopupContainerViewController parent = (PopupContainerViewController) ParentViewController;
            parent.PresentFirstAsync();
        }

        partial void DoneButton_TouchUpInside(UIButton sender)
        {   
            
            //DismissViewController(true, null);
            //PerformSegue("UnwindAddInterest", ParentViewController);

            //var pcvc = (PopupContainerViewController)ParentViewController;
            //pcvc.Close();

            //var pbvc = (PopupBaseViewController)ParentViewController.ParentViewController;
            //pbvc.Close();

            HomeViewController hvc = (HomeViewController)ParentViewController.ParentViewController.ParentViewController;
			hvc.HidePopUp();

            //PerformSegue("UnwindPopupContainer", this);
            //PerformSegue("UnwindPopupBaseView", this);
            //PerformSegue("UnwindAddInterest", this);

            //PerformSegue("UnwindPopup", this);
        }

		[Action("UnwindAddInterest:")]
		public void UnwindAddInterest(UIStoryboardSegue segue)
		{
			Console.WriteLine("We've unwinded add interest!");
		}

        public override void Unwind(UIStoryboardSegue unwindSegue, UIViewController subsequentVC)
        {
            Console.WriteLine(unwindSegue.Identifier);
            base.Unwind(unwindSegue, subsequentVC);
        }
    }
}