using Foundation;
using System;
using UIKit;

namespace hyperios.iOS.ViewControllers.Profile
{
    public partial class ActivityViewController : UIViewController
    {
        public ActivityViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //Console.WriteLine("Activity load");
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            //Console.WriteLine("activity dissapear");
        }

    }
}