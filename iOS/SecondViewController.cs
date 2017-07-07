using Foundation;
using System;
using UIKit;
using hyperios.iOS.ViewControllers.Profile;
using hyperios.iOS.ViewControllers;

namespace hyperios.iOS
{
    public partial class SecondViewController : UIViewController
    {
        public SecondViewController (IntPtr handle) : base (handle)
        {
        }

        partial void OKButton_TouchUpInside(UIButton sender)
        {
			PopupContainerViewController parent = (PopupContainerViewController)ParentViewController;
            parent.PresentAddInterestViewAsync();

            HomeViewController home = (HomeViewController)ParentViewController.ParentViewController.ParentViewController;
            home.HidePopUp();
        }
    }
}