﻿using System;
using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

using ExpandableList.Shared;

namespace ExpandableList.Droid
{
    public class ExpandableDataAdapter : BaseExpandableListAdapter
    {
        #region Constant Fields
        readonly Activity _context;
        readonly List<Chore> _choreList;
        #endregion

        #region Constructors
        public ExpandableDataAdapter(Activity newContext, List<Chore> newList)
        {
            _context = newContext;
            _choreList = newList;
        }
        #endregion

        #region Properties
        public override bool HasStableIds => true;
		public override int GroupCount => ChoreList.Count;
        protected List<Chore> ChoreList => _choreList;
		#endregion

		#region Methods
		public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var header = convertView;

            if (header == null)
            {
                header = _context.LayoutInflater.Inflate(Resource.Layout.ListGroup, null);
            }

            header.FindViewById<TextView>(Resource.Id.DataHeader).Text = ChoreList[groupPosition].Name;

            return header;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var row = convertView;

            if (row == null)
                row = _context.LayoutInflater.Inflate(Resource.Layout.DataListItem, null);

            var subChores = ChoreList[groupPosition].Subchore;

            row.FindViewById<TextView>(Resource.Id.DataId).Text = subChores[childPosition].Name;

            return row;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            char letter = (char)(65 + groupPosition);
            List<Data> results = ChoreList.FindAll((Data obj) => obj.Id[0].Equals(letter));
            return results.Count;
        }
        #endregion
    }
}

