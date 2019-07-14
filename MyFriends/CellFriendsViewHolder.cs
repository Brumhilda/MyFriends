using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;
using MyFriends.Views;

namespace MyFriends.Adarters
{
    public class CellFriendsViewAdapter : RecyclerView.Adapter
    {
        public List<CellTitleWithInfoActivity> Info { get; }

        public CellFriendsViewAdapter(List<CellTitleWithInfoActivity> infoList)
        {
            Info = infoList;
        }

        public class RecyclerViewHolder : RecyclerView.ViewHolder
        {
            public TextView Title;
            public TextView Info;

            public RecyclerViewHolder(View cell)
                : base(cell)
            {
                Title = cell.FindViewById<TextView>(Resource.Id.Cell_TitleWithInfo_Title);
                Info = cell.FindViewById<TextView>(Resource.Id.Cell_TitleWithInfo_Info);
            }
        }

        public override int ItemCount => Info.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as RecyclerViewHolder;

            vh.Title = Info[position].Title;
            vh.Info = Info[position].Info;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_title_with_info, parent, false);
            return new RecyclerViewHolder(view);
        }
    }
}
