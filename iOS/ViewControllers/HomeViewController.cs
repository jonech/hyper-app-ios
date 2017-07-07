using System;
using UIKit;
using Foundation;
using Firebase.Auth;
using Firebase.Database;
using hyperios.iOS.ViewControllers.Profile;

namespace hyperios.iOS.ViewControllers
{
    public partial class HomeViewController : UIViewController
    {
        NSString SegueIdHeader = (NSString)"embedProfileHeader";
        NSString SegueIdContent = (NSString)"embedProfileContent";
        NSString SegueIdPopup = (NSString)"embedPopUp";
        PopupBaseViewController popupBaseViewCtrl;
        UIStoryboardSegue popupSegue;
        DatabaseReference rootNode = Database.DefaultInstance.GetRootReference();

        public HomeViewController (IntPtr handle) : base (handle)
        {
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            Console.WriteLine(segue.Identifier);
            if (segue.Identifier == SegueIdPopup.ToString()) {
                popupSegue = segue;
                popupBaseViewCtrl = segue.DestinationViewController as PopupBaseViewController;
			}

            base.PrepareForSegue(segue, sender);
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            // don't perform pop up yet!
			if (segueIdentifier == SegueIdPopup.ToString()) {
                //return false;
			}

            return base.ShouldPerformSegue(segueIdentifier, sender);
        }

        public override bool CanPerformUnwind(ObjCRuntime.Selector segueAction, UIViewController fromViewController, NSObject sender)
        {
			bool can = base.CanPerformUnwind(segueAction, fromViewController, sender);
			Console.WriteLine($"homeview here...{can}");
            //return base.CanPerformUnwind(segueAction, fromViewController, sender);
            return true;
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            var currentUser = Auth.DefaultInstance.CurrentUser;
            var user = Database.DefaultInstance.GetRootReference().GetChild("User").GetChild(currentUser.Uid);

            //NameText.Text = currentUser.Email;
            Console.WriteLine(currentUser.Uid);
            Console.WriteLine(currentUser.Email);

    //        var start = FromObject(20);
    //        var end = FromObject(30);
    //        var interest = FromObject("sleep");
    //        DatabaseQuery hotMatch = rootNode.GetChild("HotMatch").GetQueryOrderedByChild("interest").GetQueryEqualToValue(interest);
    //        hotMatch.ObserveEvent(DataEventType.ChildAdded, (snapshot) => {
    //            var data = snapshot.GetValue<NSDictionary>();
				//var lats = data["lat"].ToString();
				//var longs = data["long"].ToString();
            //    var interests = data["interest"].ToString();

            //    Console.WriteLine($"lat:{lats} long:{longs} interest:{interest}");
            //});

		}

        public override void ViewDidDisappear(bool animated)
        {
            Console.WriteLine("WTF YYYY?!");
            base.ViewDidDisappear(animated);
        }

        void NavigateToLogin()
        {
            InvokeOnMainThread(() => {
                var app = (AppDelegate)UIApplication.SharedApplication.Delegate;
                app.Window.RootViewController = UIStoryboard.FromName("Main", null)
                    .InstantiateViewController("loginViewController") as UINavigationController;
            });
        }


        public void HidePopUp()
        {
            //popupBaseViewCtrl.DismissViewController(true, null);
            //Unwind()
            //PerformSegue("UnwindPopup", this);
            //PerformSegue("UnwindPopupBaseView", this);
            PopupBaseView.Hidden = true;

            //UIStoryboardSegue segue = GetSegueForUnwinding(this, popupBaseViewCtrl, SegueIdPopup.ToString());
            //Unwind(segue, this);
        }

        public void ShowPopUp()
        {
            PopupBaseView.Hidden = false;
            //PerformSegue("embedPopUp", this);
        }

		[Action("UnwindPopup:")]
		public void UnwindPopup(UIStoryboardSegue segue)
		{
			Console.WriteLine("We've unwinded popup!");
		}
    }
}