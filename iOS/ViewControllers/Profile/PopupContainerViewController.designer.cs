// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace hyperios.iOS.ViewControllers.Profile
{
    [Register ("PopupContainerViewController")]
    partial class PopupContainerViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView PopupContainerView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PopupContainerView != null) {
                PopupContainerView.Dispose ();
                PopupContainerView = null;
            }
        }
    }
}