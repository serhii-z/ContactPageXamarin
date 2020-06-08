using System;
using UIKit;
using Portable;
using System.Linq;
using System.Collections.Generic;
using Portable.Presenters.Interfaces;
using Portable.IViews.Interface;
using Portable.Presenters.Implement;

namespace iOSCollection
{
    public partial class ViewController : UIViewController, IViewStartPage
    {
        private Action<int> _actionGoTo;
        private Action<int> _actionRemove;
        IRepository _repository;
        private IPresenterViewStart _presenter;
        private TableViewSource _source;

        public ViewController (IntPtr handle) : base (handle){}
        
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            _actionGoTo = GoToUserViewController;
            _actionRemove = RemoveUser;
            _repository = Repository.GetRepository();
            _presenter = new PresenterViewStart(this, _repository);
            _presenter.GetAllUsers();           
            tableView.Source = _source;          
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        public void RemoveUser(int index)
        {
            _presenter.RemoveUser(index);
        }

        public void AddUser(User user)
        {
            _presenter.AddUser(user);
        }

        public void GetAllUsers(List<User> users)
        {
            _source = new TableViewSource(_actionGoTo, _actionRemove, users);
        }

        public void UpdateUsers()
        {
            tableView.ReloadData();
        }

        partial void AddItem_Activated(UIBarButtonItem sender)
        {
            var alert = UIAlertController.Create("Enter name and phone", "Choose from two buttons", UIAlertControllerStyle.Alert);

            CreateAlertButton(alert, placeholder: "Name");
            CreateAlertButton(alert, placeholder: "Phone");

            string nameField = string.Empty;
            string phoneField = string.Empty;

            var saveAction = UIAlertAction.Create("Save", UIAlertActionStyle.Default, (action) =>
            {
                nameField = alert.TextFields.First().Text;
                phoneField = alert.TextFields.Last().Text;

                var user = new User(nameField, phoneField, "image7.jpg");
                AddUser(user);

                UpdateUsers();
            });

            var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => { });

            alert.AddAction(saveAction);
            alert.AddAction(cancelAction);
            PresentViewController(alert, true, null);
        }

        private void CreateAlertButton(UIAlertController alert, string placeholder)
        {
            UITextField field = null;

            alert.AddTextField((name) => {
                field = name;

                field.Placeholder = placeholder;
                field.AutocorrectionType = UITextAutocorrectionType.No;
                field.KeyboardType = UIKeyboardType.Default;
                field.ReturnKeyType = UIReturnKeyType.Done;
                field.ClearButtonMode = UITextFieldViewMode.WhileEditing;
            });
        }

        public void GoToUserViewController(int index)
        {
            var showUser = Storyboard.InstantiateViewController("userView") as UserViewController;           
            showUser.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
            showUser.Index = index;
            NavigationController.PushViewController(showUser, true);
        }
    }
}