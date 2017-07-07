using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;

namespace hyperios.iOS.ViewControllers.Profile
{
    public partial class PopupContainerViewController : UIViewController, ITransitioningViewController
    {
        NSString SegueIdAddInterest = (NSString)"embedAddInterest";
        NSString SegueIdFirst = (NSString)"embedFirst";
        NSString SegueIdSecond = (NSString)"embedSecond";

        TaskCompletionSource<bool> viewChanging;

        public PopupContainerViewController (IntPtr handle) : base (handle)
        {
        }

		public TaskCompletionSource<bool> ViewChanging
		{
			get { return viewChanging; }
			set { viewChanging = value; }
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Console.WriteLine("Loaded Popupcontainer");

        }

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);

			Console.WriteLine("bye bye Popupcontainer");
		}

		public Task<bool> PresentAddInterestViewAsync()
		{
			viewChanging = new TaskCompletionSource<bool>();
            PerformSegue(SegueIdAddInterest, this);
			return viewChanging.Task;
		}

		public Task<bool> PresentFirstAsync()
		{
			viewChanging = new TaskCompletionSource<bool>();
            PerformSegue(SegueIdFirst, this);
			return viewChanging.Task;
		}

		public Task<bool> PresentSecondAsync()
		{
			viewChanging = new TaskCompletionSource<bool>();
            PerformSegue(SegueIdSecond, this);
			return viewChanging.Task;
		}

		public override bool CanPerformUnwind(ObjCRuntime.Selector segueAction, UIViewController fromViewController, NSObject sender)
		{
            bool can = base.CanPerformUnwind(segueAction, fromViewController, sender);
            Console.WriteLine($"popup container here...{can}");
			//return base.CanPerformUnwind(segueAction, fromViewController, sender);
			return true;
		}

        public void Close()
        {
            DismissViewController(true, null);
            //PerformSegue("UnwindPopupContainer", ParentViewController);
        }

		[Action("UnwindPopupContainer:")]
		public void UnwindPopupContainer(UIStoryboardSegue segue)
		{
			Console.WriteLine("We've unwinded popup container!");
		}
    }
}