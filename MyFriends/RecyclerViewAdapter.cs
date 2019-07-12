using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Runtime;
using System;

namespace MyFriends
{
    public class RecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;

        public class RecyclerViewHolder : RecyclerView.ViewHolder
        {
            public TextView Title;

            public RecyclerViewHolder(View cell, Action<int> listener)
                : base(cell)
            {
                Title = cell.FindViewById<TextView>(Resource.Id.Cell_Friend_Title);
                cell.Click += (sender, e) => listener(base.LayoutPosition);
            }
        }

        public override int ItemCount => 5;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_friend, parent, false);
            return new RecyclerViewHolder(view, OnClick);
        }

    }
}
