using Portable.Model.Interface;
using System;

namespace Portable
{
    public class User : IUser
    {
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string ImageName { get; set; }

        public User(string userName, string userPhone, string imageName = "")
        {
            UserName = userName;
            UserPhone = userPhone;
            ImageName = imageName;
        }
    }
}
