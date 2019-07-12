using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;
using MyFriends.Api.DTOs;

namespace MyFriends
{
    public class RecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<UserDTO> Friends { get; }

        public RecyclerViewAdapter(List<UserDTO> friendsList)
        {
            Friends = friendsList;
        }

        public class RecyclerViewHolder : RecyclerView.ViewHolder
        {
            public TextView Name { get; set; }
            public TextView Email { get; set; }
            public RadioButton IsActive { get; set; }

            public RecyclerViewHolder(View cell, Action<int> listener)
                : base(cell)
            {
                Name = cell.FindViewById<TextView>(Resource.Id.Cell_Friend_Name);
                Email = cell.FindViewById<TextView>(Resource.Id.Cell_Friend_Email);
                IsActive = cell.FindViewById<RadioButton>(Resource.Id.Cell_Friend_IsActive);
                cell.Click += (sender, e) => listener(base.LayoutPosition);
            }
        }

        public override int ItemCount => Friends.Count;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as RecyclerViewHolder;
            vh.Name.Text = Friends[position].Name;
            vh.Email.Text = Friends[position].Email;
            vh.IsActive.Checked = Friends[position].IsActive;
            vh.IsActive.SetText(Friends[position].IsActive
                ?  Resource.String.isActive
                : Resource.String.notActive);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_friend, parent, false);
            return new RecyclerViewHolder(view, OnClick);
        }

    }
}
