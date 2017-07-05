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

namespace hyperios.iOS.ViewControllers
{
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView BaseView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView Header { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BaseView != null) {
                BaseView.Dispose ();
                BaseView = null;
            }

            if (Header != null) {
                Header.Dispose ();
                Header = null;
            }
        }
    }
}