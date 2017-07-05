using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;

namespace hyperios.iOS.ViewControllers.Profile
{
    public partial class ContainerViewController : UIViewController, ITransitioningViewController
    {
		NSString SegueIdentifierActivity = (NSString)"embedActivity";
		NSString SegueIdentifierConnection = (NSString)"embedConnection";
		NSString SegueIdentifierInterest = (NSString)"embedInterest";

        NSString SegueIdentifierEditInterest = (NSString)"embedEditInterest";

        TaskCompletionSource<bool> viewChanging;

        public ContainerViewController (IntPtr handle) : base (handle)
        {
            
        }

        public TaskCompletionSource<bool> ViewChanging 
        {
            get { return viewChanging; }
            set { viewChanging = value; }
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            //Console.WriteLine(segue.Identifier);
            base.PrepareForSegue(segue, sender);
        }

		public Task<bool> PresentConnectionViewAsync()
		{
			viewChanging = new TaskCompletionSource<bool>();
            PerformSegue(SegueIdentifierConnection, this);
			return viewChanging.Task;
		}

		public Task<bool> PresentInterestViewAsync()
		{
			viewChanging = new TaskCompletionSource<bool>();
            PerformSegue(SegueIdentifierInterest, this);
			return viewChanging.Task;
		}

		public Task<bool> PresentActivityViewAsync()
		{
			viewChanging = new TaskCompletionSource<bool>();
            PerformSegue(SegueIdentifierActivity, this);
			return viewChanging.Task;
		}

        public Task<bool> PresentEditInterestViewAsync()
        {
            viewChanging = new TaskCompletionSource<bool>();
            PerformSegue(SegueIdentifierEditInterest, this);
            return viewChanging.Task;
        }
    }
}