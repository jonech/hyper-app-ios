using Foundation;
using System;
using UIKit;
using hyperios.iOS.ViewControllers.Profile;

namespace hyperios.iOS
{
    public partial class FirstViewController : UIViewController
    {
        public FirstViewController (IntPtr handle) : base (handle)
        {
        }

        partial void NextButton_TouchUpInside(UIButton sender)
        {
			PopupContainerViewController parent = (PopupContainerViewController)ParentViewController;
            parent.PresentSecondAsync();
        }


    }
}