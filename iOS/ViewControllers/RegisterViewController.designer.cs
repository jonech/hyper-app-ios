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
    [Register ("RegisterViewController")]
    partial class RegisterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FirstNameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LastNameText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView RegisterIndicatorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitButton { get; set; }

        [Action ("SubmitButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (EmailText != null) {
                EmailText.Dispose ();
                EmailText = null;
            }

            if (FirstNameText != null) {
                FirstNameText.Dispose ();
                FirstNameText = null;
            }

            if (LastNameText != null) {
                LastNameText.Dispose ();
                LastNameText = null;
            }

            if (PasswordText != null) {
                PasswordText.Dispose ();
                PasswordText = null;
            }

            if (RegisterIndicatorView != null) {
                RegisterIndicatorView.Dispose ();
                RegisterIndicatorView = null;
            }

            if (SubmitButton != null) {
                SubmitButton.Dispose ();
                SubmitButton = null;
            }
        }
    }
}