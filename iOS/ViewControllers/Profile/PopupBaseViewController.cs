using Foundation;
using System;
using UIKit;

namespace hyperios.iOS.ViewControllers.Profile
{
    public partial class PopupBaseViewController : UIViewController
    {
        PopupContainerViewController popupContainer;

        public PopupBaseViewController (IntPtr handle) : base (handle)
        {
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
			if (segue.Identifier == "embedPopupContainer") {
				popupContainer =
					segue.DestinationViewController as PopupContainerViewController;
			}
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Console.WriteLine("Loaded Popupbase");
            // blur background
            BaseView.BackgroundColor = UIColor.FromRGBA(0, 0, 0, (nfloat)0.5);


            popupContainer.PresentAddInterestViewAsync();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Console.WriteLine("bye bye Popupbase");
        }

		public override bool CanPerformUnwind(ObjCRuntime.Selector segueAction, UIViewController fromViewController, NSObject sender)
		{
			bool can = base.CanPerformUnwind(segueAction, fromViewController, sender);
			Console.WriteLine($"popup base here...{can}");
			//return base.CanPerformUnwind(segueAction, fromViewController, sender);
			return true;
		}

		public void Close()
		{
            DismissViewController(true, null);
            //PerformSegue("UnwindPopupBaseView", ParentViewController);
		}


		[Action("UnwindPopupBaseView:")]
		public void UnwindPopupBaseView(UIStoryboardSegue segue)
		{
			Console.WriteLine("We've unwinded to popupbaseview!");
		}
    }
}