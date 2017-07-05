// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace hyperios.iOS.ViewControllers
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        Facebook.LoginKit.LoginButton FacebookButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        hyperios.iOS.GoogleSignInButton GoogleButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LogInButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView LoginIndicatorView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RegisterButton { get; set; }

        [Action ("FacebookButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FacebookButton_TouchUpInside (Facebook.LoginKit.LoginButton sender);

        [Action ("GoogleButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GoogleButton_TouchUpInside (hyperios.iOS.GoogleSignInButton sender);

        [Action ("LogInButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LogInButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (EmailTextField != null) {
                EmailTextField.Dispose ();
                EmailTextField = null;
            }

            if (FacebookButton != null) {
                FacebookButton.Dispose ();
                FacebookButton = null;
            }

            if (GoogleButton != null) {
                GoogleButton.Dispose ();
                GoogleButton = null;
            }

            if (LogInButton != null) {
                LogInButton.Dispose ();
                LogInButton = null;
            }

            if (LoginIndicatorView != null) {
                LoginIndicatorView.Dispose ();
                LoginIndicatorView = null;
            }

            if (PasswordTextField != null) {
                PasswordTextField.Dispose ();
                PasswordTextField = null;
            }

            if (RegisterButton != null) {
                RegisterButton.Dispose ();
                RegisterButton = null;
            }
        }
    }
}