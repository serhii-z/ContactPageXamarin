using System;
using System.Collections.Generic;
using System.Text;

namespace Portable.LocalAPI.Interface
{
    public interface ILocalAPI
    {
        List<User> GetAllUsers();
        void AddUser(User user);
        void RemoveUser(int position);
    }
}
