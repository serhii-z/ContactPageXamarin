using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Portable;

namespace AndroidCollection
{
    public class UserAdapter : RecyclerView.Adapter
    {
        private ICollection<User> _users;
        private View _view;
        private Action<int> _removeUser;
        private Action<int> _transition;

        public UserAdapter(ICollection<User> users, Action<int> removeUser, Action<int> transition)
        {
            _users = users;
            _removeUser = removeUser;
            _transition = transition;
        }

        public override int ItemCount => _users.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            _view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.card_view, parent, false);

            return new Card(_view);
        }

        public override void OnBindViewHolder( RecyclerView.ViewHolder viewHolder, int index)
        {
            var user = _users.ElementAt(index);

            var userActivity = viewHolder as Card;
            userActivity.UserName.Text = user.UserName;
            userActivity.UserPhone.Text = user.UserPhone;
            userActivity.Index = index;

            var imgName = RemoveExtension(user.ImageName);

            userActivity.Image.SetImageResource((int)typeof(Resource.Drawable).GetField(imgName).GetValue(null));

            userActivity.Remove = _removeUser;
            userActivity.Transition = _transition;
        }

        private string RemoveExtension(string imageName)
        {
            return imageName.Remove(imageName.IndexOf("."));
        }
    }
}
