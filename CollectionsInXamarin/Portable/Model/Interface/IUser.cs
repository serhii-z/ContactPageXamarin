using System;
using System.Collections.Generic;
using System.Text;

namespace Portable.Model.Interface
{
    public interface IUser
    {
        string UserName { get; set; }
        string UserPhone { get; set; }
        string ImageName { get; set; }
    }
}
