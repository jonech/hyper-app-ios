using Foundation;
using System;
using UIKit;
using Firebase.Auth;
using Firebase.Database;
using hyperios.iOS.Helpers;

namespace hyperios.iOS.ViewControllers
{
    public partial class RegisterViewController : UIViewController
    {
        String email, password, firstname, lastname;

        public RegisterViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            RegisterIndicatorView.Hidden = true;
        }

        partial void SubmitButton_TouchUpInside(UIButton sender)
        {
            RegisterIndicatorView.Hidden = false;

            this.email = EmailText.Text;
            this.password = PasswordText.Text;

            this.firstname = FirstNameText.Text;
            this.lastname = LastNameText.Text;

            Auth.DefaultInstance.CreateUser(email, password, (user, error) =>
            {
                if (error != null) {
                    FirebaseError.Log(error);

                    // display pop up error
					var alertViewController = UIAlertController.Create("Error", FirebaseError.GetError(error), UIAlertControllerStyle.Alert);
					alertViewController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, handler =>
					{
						Console.WriteLine("Okay was clicked");
					}));
                    PresentViewController(alertViewController, true, null);
                }
                else {
                    Login();
                }
            });
        }

        void Login()
        {
            Auth.DefaultInstance.SignIn(email, password, (user, error) => 
            {
                if (error != null) {
                    FirebaseError.Log(error);
                }
                else {
                    // save user profile to firebase db
                    DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();

                    DatabaseReference newUser = rootNode.GetChild("User").GetChildByAutoId();

                    object[] userKey = { "firstname", "lastname", "email" };
                    object[] userValue = { firstname, lastname, email };
                    var data = NSDictionary.FromObjectsAndKeys(userValue, userKey, userKey.Length);

                    newUser.SetValue<NSDictionary>(data);

                    NavigateToHome();
                }
            });
        }

        void NavigateToHome()
        {
            InvokeOnMainThread(() => {
                RegisterIndicatorView.Hidden = true;

                var app = (AppDelegate)UIApplication.SharedApplication.Delegate;
                app.Window.RootViewController = UIStoryboard.FromName("Main", null)
                    .InstantiateViewController("homeViewController") as UINavigationController;
            });
        }
    }
}