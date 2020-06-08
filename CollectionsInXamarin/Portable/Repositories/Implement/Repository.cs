using Portable.LocalAPI.Interface;
using System.Collections.Generic;


namespace Portable
{
    public class Repository : IRepository
    {
        private static Repository _instance;
        private ILocalAPI _localAPI;
        private List<User> _users;

        private Repository()
        {
            _users = new List<User>();
            _localAPI = LocalApi.GetLocalAPI();
            QueryUsers();
        }

        public static  Repository GetRepository()
        {
            if (_instance == null)
            {
                _instance = new Repository();
            }
            return _instance;
        }

        private void QueryUsers()
        {
            if(_users.Count != 0)
            {
                _users.Clear();
            }
            _users.AddRange(_localAPI.GetAllUsers());
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public bool AddUser(User user)
        {
            _localAPI.AddUser(user);
            QueryUsers();
            if (user.Equals(_users[0]))
            {
                return true;
            }
            return false;
        }

        public bool RemoveUser(int position)
        {
            var user = _users[position];
            _localAPI.RemoveUser(position);
            QueryUsers();
            foreach(var item in _users)
            {
                if (user.Equals(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
