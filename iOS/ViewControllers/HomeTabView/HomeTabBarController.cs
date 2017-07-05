using Foundation;
using System;
using UIKit;

namespace hyperios.iOS.ViewControllers.HomeTabView
{
    public partial class HomeTabBarController : UITabBarController
    {
        public HomeTabBarController (IntPtr handle) : base (handle)
        {
			TabBar.Items[0].Title = "People";
			TabBar.Items[1].Title = "Profile";
        }
    }
}
