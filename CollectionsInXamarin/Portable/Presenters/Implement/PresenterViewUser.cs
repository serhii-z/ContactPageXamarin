using Portable.Presenters.Interfaces;
using Portable.IViews.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Portable.Presenters.Implement
{
    public class PresenterViewUser : IPresenterViewUser
    {
        private IViewUserPage _viewUser;
        private IRepository _repository;

        public PresenterViewUser(IViewUserPage viewUser)
        {
            _viewUser = viewUser;
            _repository = Repository.GetRepository();
        }
        public void GetUserById(int index)
        {
            IList<User> collection = _repository.GetAllUsers();
            User user = collection.ElementAt(index);
            _viewUser.ShowUser(user);
        }
    }
}
