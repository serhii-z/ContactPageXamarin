// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOSCollection
{
    [Register ("UserViewController")]
    partial class UserViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView userImage1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel userName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel userPhone { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView userView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (userImage1 != null) {
                userImage1.Dispose ();
                userImage1 = null;
            }

            if (userName != null) {
                userName.Dispose ();
                userName = null;
            }

            if (userPhone != null) {
                userPhone.Dispose ();
                userPhone = null;
            }

            if (userView != null) {
                userView.Dispose ();
                userView = null;
            }
        }
    }
}