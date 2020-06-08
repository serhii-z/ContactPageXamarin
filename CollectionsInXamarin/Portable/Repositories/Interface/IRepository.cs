using System;
using System.Collections.Generic;
using System.Text;

namespace Portable
{
    public interface IRepository
    {
        List<User> GetAllUsers();
        bool AddUser(User user);
        bool RemoveUser(int position);
    }
}
