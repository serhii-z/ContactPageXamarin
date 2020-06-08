using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace AndroidCollection
{
    public class Card : RecyclerView.ViewHolder
    {
        private Button _deleteButton;
        public TextView UserName { get; set; }
        public TextView UserPhone { get; set; }
        public ImageView Image { get; set; }
        public int Index { get; set; }
        public Action<int> Remove { get; set; }
        public Action<int> Transition { get; set; }
       
        public Card(View userView) : base(userView)
        {
            InitViewItems(userView);
            userView.Click += UserView_Click;
            _deleteButton.Click += _deleteButton_Click;
        }

        private void UserView_Click(object sender, EventArgs e)
        {
            Transition?.Invoke(Index);
        }

        private void _deleteButton_Click(object sender, System.EventArgs e)
        {
            Remove?.Invoke(Index);
        }

        private void InitViewItems(View contactView)
        {
            UserName = contactView.FindViewById<TextView>(Resource.Id.textName);
            UserPhone = contactView.FindViewById<TextView>(Resource.Id.textPhone);
            Image = contactView.FindViewById<ImageView>(Resource.Id.imageView);

            _deleteButton = contactView.FindViewById<Button>(Resource.Id.deleteButton);
        }
    }
}