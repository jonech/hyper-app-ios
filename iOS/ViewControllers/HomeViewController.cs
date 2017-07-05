using System;
using UIKit;
using Foundation;
using Firebase.Auth;
using Firebase.Database;
using hyperios.iOS.Helpers;


namespace hyperios.iOS.ViewControllers
{
    public partial class HomeViewController : UIViewController
    {
        DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();

        public HomeViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            var currentUser = Auth.DefaultInstance.CurrentUser;
            var user = Database.DefaultInstance.GetRootReference().GetChild("User").GetChild(currentUser.Uid);

            //NameText.Text = currentUser.Email;
            Console.WriteLine(currentUser.Uid);
            Console.WriteLine(currentUser.Email);

            var start = FromObject(20);
            var end = FromObject(30);
            var interest = FromObject("sleep");
            DatabaseQuery hotMatch = rootNode.GetChild("HotMatch").GetQueryOrderedByChild("interest").GetQueryEqualToValue(interest);
            hotMatch.ObserveEvent(DataEventType.ChildAdded, (snapshot) => {
                var data = snapshot.GetValue<NSDictionary>();
				var lats = data["lat"].ToString();
				var longs = data["long"].ToString();
                var interests = data["interest"].ToString();

                Console.WriteLine($"lat:{lats} long:{longs} interest:{interest}");
            });
            //user.get
		}

        //partial void LogOutButton_TouchUpInside(UIButton sender)
        //{
        //    NSError error;
        //    var signedOut = Auth.DefaultInstance.SignOut(out error);

        //    if (!signedOut) {
        //        FirebaseError.Log(error);
        //    }
        //    else {
        //        NavigateToLogin();
        //    }
        //}

        void NavigateToLogin()
        {
            InvokeOnMainThread(() => {
                var app = (AppDelegate)UIApplication.SharedApplication.Delegate;
                app.Window.RootViewController = UIStoryboard.FromName("Main", null)
                    .InstantiateViewController("loginViewController") as UINavigationController;
            });
        }

        partial void DoneButton_TouchUpInside(UIButton sender)
        {
            AddInterestView.Hidden = true;
            BaseView.Hidden = true;
        }

        public void Test()
        {
            Console.WriteLine("TEST!!!");
            AddInterestView.Hidden = false;
            BaseView.Hidden = false;
            BaseView.BackgroundColor = UIColor.FromRGBA(0, 0, 0, (nfloat) 0.7);
            //BaseView.Alpha = (nfloat) 0.7;
            //AddInterestView.Alpha = (nfloat) 1.0;
        }
    }
}