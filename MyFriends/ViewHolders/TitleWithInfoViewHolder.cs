using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MyFriends
{
    public class TitleWithInfoViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title;
        public TextView Info;

        public TitleWithInfoViewHolder(View cell, Action<int> listener)
            : base(cell)
        {
            Title = cell.FindViewById<TextView>(Resource.Id.Cell_TitleWithInfo_Title);
            Info = cell.FindViewById<TextView>(Resource.Id.Cell_TitleWithInfo_Info);
            cell.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}
