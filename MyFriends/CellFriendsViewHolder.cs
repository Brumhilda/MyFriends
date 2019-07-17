using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;
using MyFriends.Api;
using MyFriends.Core;
using MyFriends.Core.ViewModels;

namespace MyFriends.Adarters
{
    public class CellFriendsViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<TitleWithInfoItemVM> Info { get; }

        public CellFriendsViewAdapter(List<TitleWithInfoItemVM> infoList)
        {
            Info = infoList;
        }

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

        public override int ItemCount => Info.Count;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override int GetItemViewType(int position)
        { //TODO remake
            return position < 3 ? 0 : 1;
        }

        //TODO transfer to own class
        public int GetIconIdByType(DataPairType category, string type)
        {
            switch (category)
            {
                case DataPairType.Fruit:
                    var fruitType = type.ToFruitType();
                    return fruitType == FruitType.Apple
                        ? Resource.Mipmap.ic_fruit_apple
                        : fruitType == FruitType.Banana
                            ? Resource.Mipmap.ic_fruit_banana
                            : fruitType == FruitType.Strawberry
                                ? Resource.Mipmap.ic_fruit_strawberry
                                : 0;
                case DataPairType.Gender:
                    return type.CompareTo(GenderType.Female.ToString()) == 0
                        ? Resource.Mipmap.ic_gender_female
                        : Resource.Mipmap.ic_gender_male;
                case DataPairType.EyeColor:
                    return type.CompareTo(EyeColorType.Blue.ToString()) == 0
                        ? Resource.Mipmap.ic_eye_blue
                        : type.CompareTo(EyeColorType.Brown.ToString()) == 0
                            ? Resource.Mipmap.ic_eye_brown
                            : Resource.Mipmap.ic_eye_green;
                default:
                    return 0;
            }

        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (GetItemViewType(position) == 0)
            {
                var vh = holder as TitleWithIconViewHolder;
                vh.Title.Text = Info[position].Title;
                vh.Info.Text = Info[position].Info;
                vh.Icon.SetImageResource(GetIconIdByType(Info[position].Type, Info[position].Info));
            }
            else
            {
                var vh = holder as TitleWithInfoViewHolder;
                vh.Title.Text = Info[position].Title;
                vh.Info.Text = Info[position].Info;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view;
            if (viewType == 0)
            {
                view = LayoutInflater.From(parent.Context)
                    .Inflate(Resource.Layout.cell_title_with_icon, parent, false);
                return new TitleWithIconViewHolder(view, OnClick);
            }
            view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cell_title_with_info, parent, false);
            return new TitleWithInfoViewHolder(view, OnClick);
        }
    }
}
