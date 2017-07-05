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
    [Register ("InterestViewController")]
    partial class InterestViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EditButton { get; set; }

        [Action ("EditButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EditButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (EditButton != null) {
                EditButton.Dispose ();
                EditButton = null;
            }
        }
    }
}