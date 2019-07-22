using System;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace MyFriends
{
    public class FriendViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name;
        public TextView Email;
        public RadioButton IsActive;

        public FriendViewHolder(View cell, Action<int> listener)
            : base(cell)
        {
            Name = cell.FindViewById<TextView>(Resource.Id.Cell_Friend_Name);
            Email = cell.FindViewById<TextView>(Resource.Id.Cell_Friend_Email);
            IsActive = cell.FindViewById<RadioButton>(Resource.Id.Cell_Friend_IsActive);
            cell.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}
