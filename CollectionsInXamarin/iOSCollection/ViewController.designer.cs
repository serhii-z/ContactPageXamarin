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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem addItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIToolbar toolBar { get; set; }

        [Action ("AddItem_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddItem_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (addItem != null) {
                addItem.Dispose ();
                addItem = null;
            }

            if (tableView != null) {
                tableView.Dispose ();
                tableView = null;
            }

            if (toolBar != null) {
                toolBar.Dispose ();
                toolBar = null;
            }
        }
    }
}