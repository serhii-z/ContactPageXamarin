using System;
using Foundation;
using Portable;
using UIKit;
using System.Collections.Generic;

namespace iOSCollection
{
    public class TableViewSource : UITableViewSource
    {
        private const string CellIdentifier = "CellIdentifier";
        private List<User>   _collection;
        private Action<int> _actionGoTo;
        private Action<int> _actionRemove;
        public TableViewSource(Action<int> actionGoTo, Action<int> actionRemove, List<User> collection)
        {
            _actionGoTo = actionGoTo;
            _actionRemove = actionRemove;
            _collection = collection;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _collection.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _actionGoTo.Invoke(indexPath.Row);
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    _actionRemove.Invoke(indexPath.Row);
                    //tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
            }
        }

        public override string TitleForDeleteConfirmation(UITableView tableView, NSIndexPath indexPath)
        {
            return "Trash"; // instead of 'Delete'
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier);
            var item = _collection[indexPath.Row];

            var cellStyle = UITableViewCellStyle.Subtitle;

            if (cell == null)
            {
                cell = new UITableViewCell(cellStyle, CellIdentifier);
            }
            if (cellStyle == UITableViewCellStyle.Subtitle
                 || cellStyle == UITableViewCellStyle.Value1
                 || cellStyle == UITableViewCellStyle.Value2)
            {
                cell.DetailTextLabel.Text = item.UserPhone;
            }

            if (cellStyle != UITableViewCellStyle.Value2)
            {
                cell.ImageView.Image = UIImage.FromFile("Images/" + item.ImageName);
            }

            cell.TextLabel.Text = item.UserName;
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }
    }
}