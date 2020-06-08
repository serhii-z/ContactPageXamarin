using System;
using System.Collections.Generic;
using System.Text;

namespace Portable.IViews.Interface
{
    public interface IViewStartPage
    {
        void GetAllUsers(List<User> users);
        void UpdateUsers();
    }
}
