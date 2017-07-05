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
    [Register ("EditInterestViewController")]
    partial class EditInterestViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DoneButton { get; set; }

        [Action ("AddButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("DoneButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DoneButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AddButton != null) {
                AddButton.Dispose ();
                AddButton = null;
            }

            if (DoneButton != null) {
                DoneButton.Dispose ();
                DoneButton = null;
            }
        }
    }
}