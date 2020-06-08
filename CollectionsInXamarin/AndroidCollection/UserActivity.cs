using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Portable;
using Portable.IViews.Interface;
using Portable.Presenters.Implement;
using Portable.Presenters.Interfaces;

namespace AndroidCollection
{
    [Activity(Label = "UserActivity")]
    public class UserActivity : Activity, IViewUserPage
    {
        private IPresenterViewUser _presenterUser;
        private ImageView _image;
        private TextView _textName;
        private TextView _textPhone;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.user_activity);

            _presenterUser = new PresenterViewUser(this);
            _image = FindViewById<ImageView>(Resource.Id.ProfileIconImageView);
            _textName = FindViewById<TextView>(Resource.Id.NameTextView);
            _textPhone = FindViewById<TextView>(Resource.Id.PhoneTextView);

            int index = Intent.GetIntExtra("index", 0);
            GetUserById(index);
            //ShowUser();
        }

        private void GetUserById(int index)
        {
            _presenterUser.GetUserById(index);
        }

        private string RemoveExtension(string imageName)
        {
            return imageName.Remove(imageName.IndexOf("."));
        }

        public void ShowUser(User user)
        {
            var imageName = user.ImageName;
            imageName = RemoveExtension(imageName);
            _image.SetImageResource((int)typeof(Resource.Drawable).GetField(imageName).GetValue(null));
            _textName.Text = user.UserName;
            _textPhone.Text = user.UserPhone;
        }
    }
}