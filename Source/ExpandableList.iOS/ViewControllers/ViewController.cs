using System;
using System.Collections.Generic;

using UIKit;

using ExpandableList.Shared;

namespace ExpandableList.iOS
{
	public partial class ViewController : UITableViewController
	{
		readonly List<ChoreModel> _choreList;

		public ViewController(IntPtr handle) : base(handle)
		{
			Title = "Chore List";

            _choreList = ChoreModel.CreateChoreList();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			TableView.Source = new ChoreTableSource(_choreList);
		}
	}
}

