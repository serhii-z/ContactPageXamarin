using Portable.Presenters.Interfaces;
using Portable.IViews.Interface;

namespace Portable.Presenters.Implement
{
    public class PresenterViewStart : IPresenterViewStart
    {
        private IViewStartPage _viewStart;
        private IRepository _repository;

        public PresenterViewStart(IViewStartPage view, IRepository repository)
        {
            _viewStart = view;
            _repository = repository;
        }
        public bool AddUser(User user)
        {
            var isAdd = _repository.AddUser(user);
            _viewStart.UpdateUsers();
            return isAdd;
        }

        public void GetAllUsers()
        {
            _viewStart.GetAllUsers(_repository.GetAllUsers());
        }

        public bool RemoveUser(int index)
        {
            var isRemove = _repository.RemoveUser(index);
            _viewStart.UpdateUsers();
            return isRemove;
        }
    }
}
