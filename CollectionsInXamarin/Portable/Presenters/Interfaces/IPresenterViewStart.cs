using System;
using System.Collections.Generic;
using System.Text;

namespace Portable.Presenters.Interfaces
{
    public interface IPresenterViewStart
    {
        void GetAllUsers();
        bool AddUser(User user);
        bool RemoveUser(int position);
    }
}
