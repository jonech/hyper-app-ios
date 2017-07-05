using Foundation;
using System;
using UIKit;
using System.Threading.Tasks;

namespace hyperios.iOS.ViewControllers.Profile
{
    public partial class InterestViewController : UIViewController
    {
        ContainerViewController containerViewController;

        public InterestViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
			base.PrepareForSegue(segue, sender);
        }

        partial void EditButton_TouchUpInside(UIButton sender) => TransitionToEditInterest();

        async void TransitionToEditInterest()
        {
			containerViewController = (ContainerViewController)ParentViewController;
			await containerViewController.PresentEditInterestViewAsync();
        }
    }
}