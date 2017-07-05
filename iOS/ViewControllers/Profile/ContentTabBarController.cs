using Foundation;
using System;
using UIKit;

namespace hyperios.iOS.ViewControllers.Profile
{
    public partial class ContentTabBarController : UIViewController
    {
        private ContainerViewController containerViewController;

        public ContentTabBarController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //select the First view
            TransitionToActivity();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
			if (segue.Identifier == "embedContainer") {
                containerViewController =
					segue.DestinationViewController as ContainerViewController;
			}
        }

        partial void ConnectionButton_TouchUpInside(UIButton sender) => TransitionToConnection();

        partial void InterestButton_TouchUpInside(UIButton sender) => TransitionToInterest();

        partial void ActivityButton_TouchUpInside(UIButton sender) => TransitionToActivity();

        async void TransitionToConnection()
        {
			ConnectionButton.BackgroundColor = UIColor.Orange;
            ConnectionText.TextColor = UIColor.White;
            ConnectionNumber.TextColor = UIColor.White;

			InterestButton.BackgroundColor = UIColor.White;
            InterestText.TextColor = UIColor.Orange;
            InterestNumber.TextColor = UIColor.Black;

			ActivityButton.BackgroundColor = UIColor.White;
            ActivityText.TextColor = UIColor.Orange;
            ActivityNumber.TextColor = UIColor.Black;

            await containerViewController.PresentConnectionViewAsync();
        }

        async void TransitionToInterest()
        {
			InterestButton.BackgroundColor = UIColor.Orange;
            InterestText.TextColor = UIColor.White;
            InterestNumber.TextColor = UIColor.White;

			ConnectionButton.BackgroundColor = UIColor.White;
            ConnectionText.TextColor = UIColor.Orange;
            ConnectionNumber.TextColor = UIColor.Black;

			ActivityButton.BackgroundColor = UIColor.White;
            ActivityText.TextColor = UIColor.Orange;
            ActivityNumber.TextColor = UIColor.Black;

            await containerViewController.PresentInterestViewAsync();
        }

        async void TransitionToActivity()
        {
			ActivityButton.BackgroundColor = UIColor.Orange;
            ActivityText.TextColor = UIColor.White;
            ActivityNumber.TextColor = UIColor.White;

			ConnectionButton.BackgroundColor = UIColor.White;
            ConnectionText.TextColor = UIColor.Orange;
            ConnectionNumber.TextColor = UIColor.Black;

			InterestButton.BackgroundColor = UIColor.White;
            InterestText.TextColor = UIColor.Orange;
            InterestNumber.TextColor = UIColor.Black;

            await containerViewController.PresentActivityViewAsync();
        }
    }
}