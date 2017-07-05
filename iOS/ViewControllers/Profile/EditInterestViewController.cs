using Foundation;
using System;
using UIKit;

namespace hyperios.iOS.ViewControllers.Profile
{
    public partial class EditInterestViewController : UIViewController
    {
        public EditInterestViewController (IntPtr handle) : base (handle)
        {
        }

        partial void DoneButton_TouchUpInside(UIButton sender)
        {
            ContainerViewController cvc = (ContainerViewController)ParentViewController;
            cvc.PresentInterestViewAsync();
        }

        partial void AddButton_TouchUpInside(UIButton sender)
        {
            HomeViewController hvc = (HomeViewController)ParentViewController.ParentViewController.ParentViewController;
            hvc.Test();
        }
    }
}