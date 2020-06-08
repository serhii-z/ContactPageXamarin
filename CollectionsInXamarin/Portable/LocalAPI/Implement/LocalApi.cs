using System;
using System.Collections.Generic;
using System.Text;
using Portable.LocalAPI.Interface;

namespace Portable
{
    public class LocalApi : ILocalAPI
    {
        private static LocalApi _instance;
        private List<User> _users;
        private LocalApi()
        {
            _users = new List<User>();
            CreateUsers();
        }

        public static LocalApi GetLocalAPI()
        {
            if(_instance == null)
            {
                _instance = new LocalApi();
            }
            return _instance;
        }
        private void CreateUsers()
        {
            List<User> temp = new List<User>()
            {
                new User("Sara", "+380998887766", "image1.jpg"),
                new User("Helen", "+380687775555", "image2.jpg"),
                new User("Ada", "+3890993339944", "image3.jpg"),
                new User("Roy", "+380971112277", "image4.jpg"),
                new User("Pol", "+380662228822", "image5.jpg"),
                new User("Rachel", "+3830673332255", "image6.jpg"),
                new User("Sara", "+380998886699", "image1.jpg"),
                new User("Helen", "+380667772244", "image2.jpg"),
                new User("Lori", "+3890994449955", "image3.jpg"),
                new User("Roy", "+380981115599", "image4.jpg"),
                new User("Pol", "+380682220022", "image5.jpg"),
                new User("Laura", "+380683337700", "image6.jpg")
            };

            _users.AddRange(temp);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Insert(0, user);
        }

        public void RemoveUser(int index)
        {
            _users.RemoveAt(index);
        }
    }
}
