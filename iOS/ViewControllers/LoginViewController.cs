using System;
using UIKit;
using Foundation;
using Firebase.Auth;
using Firebase.Database;
using Facebook.LoginKit;
using Facebook.CoreKit;
using Google.SignIn;

using hyperios.iOS.Helpers;
using System.Collections.Generic;

namespace hyperios.iOS.ViewControllers
{
    public partial class LoginViewController : UIViewController, ISignInDelegate, ISignInUIDelegate
    {
        // for reading user facebook profile
        List<string> readPermissions = new List<string> { "public_profile", "email" };

        public LoginViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoginIndicatorView.Hidden = true;

			// Assign Google SignIn Delegates to receive callbacks
			SignIn.SharedInstance.UIDelegate = this;
			SignIn.SharedInstance.Delegate = this;

            // facebook shit
            FacebookButton.ReadPermissions = readPermissions.ToArray();
			FacebookButton.Completed += (object sender, LoginButtonCompletedEventArgs e) =>
			{
				if (e.Error != null) {
                    return;
				}
				if (e.Result.IsCancelled) {
                    return;
				}

				// Get access token for the signed-in user and exchange it for a Firebase credential
				var credential = FacebookAuthProvider.GetCredential(AccessToken.CurrentAccessToken.TokenString);

				var keys = new object[] { "redirect", "type", "width", "height" };
                var values = new object[] { 0, "large", 250, 250 };
                var param = NSDictionary.FromObjectsAndKeys(values, keys);

                GraphRequest req = new GraphRequest($"{AccessToken.CurrentAccessToken.UserID}/picture", param);

                Console.WriteLine(req);
                req.Start((GraphRequestConnection connection, NSObject result, NSError error) => {
                    if (error != null) {
                        Console.WriteLine(error);
                    }
                    else {
                        Console.WriteLine(result);
                    }
                });
				// Authenticate with Firebase using the credential
				Auth.DefaultInstance.SignIn(credential, (user, error) =>
				{
                    HideIdicator();

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
                        // login success
                        RegisterToFbdb(user.Uid, user.Email, user.DisplayName);
                        //NavigateToHome();
					}
				});
			};
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

		void ActivateIndicator()
		{
			LoginIndicatorView.Hidden = false;
		}
		void HideIdicator()
		{
			LoginIndicatorView.Hidden = true;
		}

        partial void GoogleButton_TouchUpInside(GoogleSignInButton sender) => ActivateIndicator();

        partial void FacebookButton_TouchUpInside(LoginButton sender) => ActivateIndicator();


		public void DidSignIn(SignIn signIn, GoogleUser googleUser, NSError googleError)
		{
			if (googleError == null && googleUser != null) {
				// Get Google ID token and Google access token and exchange them for a Firebase credential
				var authentication = googleUser.Authentication;
				var credential = GoogleAuthProvider.GetCredential(authentication.IdToken, authentication.AccessToken);

				// Authenticate with Firebase using the credential
				// Visit https://firebase.google.com/docs/auth/ios/errors for more information
                Auth.DefaultInstance.SignIn(credential, (user, error) =>
				{
                    HideIdicator();
					if (error != null) {
						var loginWait = UIAlertController.Create("Error", FirebaseError.GetError(error), UIAlertControllerStyle.Alert);
						loginWait.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, handler => {
							Console.WriteLine("Okay was clicked");
						}));
					}
					else {
                        // login success
                        RegisterToFbdb(user.Uid, user.Email, user.DisplayName);
                        NavigateToHome();
					}
				});
			}
			else {
                var loginWait = UIAlertController.Create("Error", FirebaseError.GetError(googleError), UIAlertControllerStyle.Alert);
				loginWait.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, handler => {
					Console.WriteLine("Okay was clicked");
				}));
			}
		}

        void RegisterToFbdb(string uid, string email, string name)
        {
			DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();
            DatabaseReference userNode = rootNode.GetChild("User");

            userNode.GetChild(uid).ObserveSingleEvent(DataEventType.Value, (snapshot) => {
                
                if (!snapshot.HasChildren) {
                    // save user profile to firebase db if not exist

					DatabaseReference newUser = userNode.GetChildByAutoId();
                    string firstname = name.Split(' ')[0];
					string lastname = name.Split(' ')[1];

					object[] userKey = { "firstname", "lastname", "email" };
					object[] userValue = { firstname, lastname, email };
					var data = NSDictionary.FromObjectsAndKeys(userValue, userKey, userKey.Length);

					newUser.SetValue<NSDictionary>(data);
                }
            });
        }

        partial void LogInButton_TouchUpInside(UIButton sender) => LoginWithEmail();

        void LoginWithEmail()
        {
			String email = EmailTextField.Text;
			String pwd = PasswordTextField.Text;

            ActivateIndicator();
			Auth.DefaultInstance.SignIn(email, pwd, (User, error) =>
			{
                HideIdicator();
				if (error != null) {
					FirebaseError.Log(error);
                    Console.WriteLine(email);
					// display pop up error
					var alertViewController = UIAlertController.Create("Error", FirebaseError.GetError(error), UIAlertControllerStyle.Alert);
                    alertViewController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, handler => {
                        Console.WriteLine("Okay was clicked");
                    }));
                    PresentViewController(alertViewController, true, null);
				}
				else {
					NavigateToHome();
				}
			});
        }

		void NavigateToHome()
		{
			InvokeOnMainThread(() =>
			{
				var app = (AppDelegate)UIApplication.SharedApplication.Delegate;
				app.Window.RootViewController = UIStoryboard.FromName("Main", null)
                    .InstantiateViewController("homeTabBarController") as UITabBarController;
			});
		}
    }
}
