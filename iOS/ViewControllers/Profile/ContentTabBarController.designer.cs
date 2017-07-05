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
    [Register ("ContentTabBarController")]
    partial class ContentTabBarController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ActivityButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ActivityNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ActivityText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ConnectionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ConnectionNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ConnectionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton InterestButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel InterestNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel InterestText { get; set; }

        [Action ("ActivityButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActivityButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("ConnectionButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ConnectionButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("InterestButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void InterestButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ActivityButton != null) {
                ActivityButton.Dispose ();
                ActivityButton = null;
            }

            if (ActivityNumber != null) {
                ActivityNumber.Dispose ();
                ActivityNumber = null;
            }

            if (ActivityText != null) {
                ActivityText.Dispose ();
                ActivityText = null;
            }

            if (ConnectionButton != null) {
                ConnectionButton.Dispose ();
                ConnectionButton = null;
            }

            if (ConnectionNumber != null) {
                ConnectionNumber.Dispose ();
                ConnectionNumber = null;
            }

            if (ConnectionText != null) {
                ConnectionText.Dispose ();
                ConnectionText = null;
            }

            if (InterestButton != null) {
                InterestButton.Dispose ();
                InterestButton = null;
            }

            if (InterestNumber != null) {
                InterestNumber.Dispose ();
                InterestNumber = null;
            }

            if (InterestText != null) {
                InterestText.Dispose ();
                InterestText = null;
            }
        }
    }
}