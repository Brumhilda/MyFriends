using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MyFriends
{
    public class TitleWithIconViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title;
        public TextView Info;
        public ImageView Icon;

        public TitleWithIconViewHolder(View cell, Action<int> listener)
            : base(cell)
        {
            Title = cell.FindViewById<TextView>(Resource.Id.Cell_TitleWithIcon_Title);
            Info = cell.FindViewById<TextView>(Resource.Id.Cell_TitleWithIcon_Info);
            Icon = cell.FindViewById<ImageView>(Resource.Id.Cell_TitleWithIcon_Icon);
            cell.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}
