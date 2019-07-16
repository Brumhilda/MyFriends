﻿using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;
using MyFriends.Views;
using MyFriends.Core.ViewModels;

namespace MyFriends.Adarters
{
    public class CellFriendsViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<Tuple<string, string>> Info { get; }

        public CellFriendsViewAdapter(List<Tuple<string,string>> infoList)
        {
            Info = infoList;
        }

        public class RecyclerViewHolder : RecyclerView.ViewHolder
        {
            public TextView Title;
            public TextView Info;
            public TitleWithInfoItemVM pageVM;

            public RecyclerViewHolder(View cell, Action<int> listener)
                : base(cell)
            {
                Title = cell.FindViewById<TextView>(Resource.Id.Cell_TitleWithInfo_Title);
                Info = cell.FindViewById<TextView>(Resource.Id.Cell_TitleWithInfo_Info);
                cell.Click += (sender, e) => listener(base.LayoutPosition);
            }
        }

        public override int ItemCount => Info.Count;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as RecyclerViewHolder;

            vh.Title.Text = Info[position].Item1;
            vh.Info.Text = Info[position].Item2;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_title_with_info, parent, false);
            return new RecyclerViewHolder(view, OnClick);
        }
    }
}