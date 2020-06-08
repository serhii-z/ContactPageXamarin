using Portable;
using Portable.IViews.Interface;
using Portable.Presenters.Implement;
using System;
using UIKit;

namespace iOSCollection
{
    public partial class UserViewController : UIViewController, IViewUserPage
    {
        private PresenterViewUser _presenterUser;
        public int Index { get; set; }
        public UserViewController (IntPtr handle) : base (handle)
        {
            _presenterUser = new PresenterViewUser(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _presenterUser.GetUserById(Index);
        }

        public void ShowUser(User user)
        {
            userImage1.Image = UIImage.FromFile("Images/" + user.ImageName);
            userName.Text = user.UserName;
            userPhone.Text = user.UserPhone;
        }
    }
}