using Foundation;
using System;
using UIKit;
using Google.SignIn;

namespace hyperios.iOS
{
    public partial class GoogleSignInButton : SignInButton
    {
        public GoogleSignInButton (IntPtr handle) : base (handle)
        {
            BackgroundColor = UIColor.FromRGB(211, 72, 54);
        }
    }
}