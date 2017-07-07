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

namespace hyperios.iOS
{
    [Register ("SecondViewController")]
    partial class SecondViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton OKButton { get; set; }

        [Action ("OKButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OKButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (OKButton != null) {
                OKButton.Dispose ();
                OKButton = null;
            }
        }
    }
}