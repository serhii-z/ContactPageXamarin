using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android.Content;
using Portable;
using System.Collections.Generic;
using Portable.IViews.Interface;
using Portable.Presenters.Interfaces;
using Portable.Presenters.Implement;

namespace AndroidCollection
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IViewStartPage
    {
        private IRepository _repository;
        private IPresenterViewStart _presenter;
        private ImageButton _addContactButton;
        private UserAdapter _userAdapter;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _repository = Repository.GetRepository();
            _presenter = new PresenterViewStart(this, _repository);

            InitUsersView();
            InitAddUserImageButton();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _addContactButton.Click -= AddUserButton_Click;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public void InitAddUserImageButton()
        {
            _addContactButton = FindViewById<ImageButton>(Resource.Id.AddContactButton);
            _addContactButton.SetBackgroundResource(Resource.Drawable.add);
            _addContactButton.Click += AddUserButton_Click;
        }

        public void GetAllUsers(List<User> users)
        {
            _userAdapter = new UserAdapter(users, RemoveUser, GoToUserActivity);
            UpdateUsers();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddUserButton();
        }

        public void AddUserButton()
        {
            var builder = new Android.App.AlertDialog.Builder(this);
            builder.SetTitle("Create new contact");

            var currentContext = Application.Context;
            var alertLayout = new LinearLayout(currentContext)
            {
                Orientation = Orientation.Vertical
            };

            var nameEditText = CreateEditField(currentContext, hint: "UserName");
            var phoneEditText = CreateEditField(currentContext, hint: "UserPhone");
            var addButton = CreateAddAlertButton(currentContext);
            var cancelButton = CreateCancelAlertButton(currentContext);

            alertLayout.AddView(nameEditText);
            alertLayout.AddView(phoneEditText);
            alertLayout.AddView(addButton);
            alertLayout.AddView(cancelButton);

            builder.SetView(alertLayout);
            var dialog = builder.Show();

            addButton.Click += delegate
            {
                if (nameEditText.Text.Equals("") && phoneEditText.Text.Equals(""))
                {
                    Toast.MakeText(Application.Context, "Введите хотя бы одно поле", ToastLength.Short).Show();
                }
                else
                {
                    AddUser(nameEditText.Text, phoneEditText.Text, "image7.jpg");
                    dialog.Dismiss();
                }
            };

            cancelButton.Click += delegate
            {
                dialog.Dismiss();
            };
        }

        private EditText CreateEditField(Context context, string hint)
        {
            var fieldEditText = new EditText(context)
            {
                Hint = hint
            };

            return fieldEditText;
        }

        private Button CreateAddAlertButton(Context context)
        {
            var addButton = new Button(this)
            {
                Text = "Add",
                Background = GetDrawable(Resource.Drawable.abc_btn_colored_material)
            };

            return addButton;
        }

        private Button CreateCancelAlertButton(Context context)
        {
            var cancelButton = new Button(this)
            {
                Text = "Cancel",
                Background = GetDrawable(Resource.Drawable.abc_btn_colored_material)
            };

            return cancelButton;
        }

        public void RemoveUser(int index)
        {
            _presenter.RemoveUser(index);
        }

        public void AddUser(string name, string phone, string imageProfile)
        {
            var user = new User(name, phone, imageProfile);
            _presenter.AddUser(user);
        }

        public void UpdateUsers()
        {
            _userAdapter.NotifyDataSetChanged();
        }

        public void InitUsersView()
        {
            _presenter.GetAllUsers();
            var contactsRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);        
            var contactsLayoutManager = new LinearLayoutManager(this);
            contactsRecyclerView.SetLayoutManager(contactsLayoutManager);
            contactsRecyclerView.SetItemAnimator(new DefaultItemAnimator());
            contactsRecyclerView.AddItemDecoration(new DividerItemDecoration(this, LinearLayoutManager.Vertical));
            contactsRecyclerView.SetAdapter(_userAdapter);
        }

        public void GoToUserActivity(int index)
        {
            Intent intent = new Intent(this, typeof(UserActivity));        
            intent.PutExtra("index", index);
            StartActivity(intent);
        }
    }
}

