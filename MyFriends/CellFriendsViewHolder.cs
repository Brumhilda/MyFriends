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
        public List<BaseItemVM> Info { get; }

        public CellFriendsViewAdapter(List<BaseItemVM> infoList)
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

        public class TitleViewHolder : RecyclerView.ViewHolder
        {
            public TextView Title;

            public TitleViewHolder(View cell)
                : base(cell)
            {
                Title = cell.FindViewById<TextView>(Resource.Id.Cell_Title_Title);
            }
        }

        public override int ItemCount => Info.Count;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override int GetItemViewType(int position)
        { //TODO remake
            return position < 3 ? 0 : position < 11 ? 1 : position == 11 ? 2 : 3;
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
            switch(GetItemViewType(position))
            {
                case 0:
                    var titleWithIconVH = holder as TitleWithIconViewHolder;
                    var titleWithIconItem = Info[position] as TitleWithIconItemVM;
                    titleWithIconVH.Title.Text = titleWithIconItem.Title;
                    titleWithIconVH.Info.Text = titleWithIconItem.Info;
                    titleWithIconVH.Icon.SetImageResource(GetIconIdByType(titleWithIconItem.Type,
                        titleWithIconItem.Info));
                    break;
                case 1:
                    var titleWithInfoVH = holder as TitleWithInfoViewHolder;
                    var titleWithInfoItem = Info[position] as TitleWithInfoItemVM;
                    titleWithInfoVH.Title.Text = titleWithInfoItem.Title;
                    titleWithInfoVH.Info.Text = titleWithInfoItem.Info;
                    break;
                case 2:
                    var titleVH = holder as TitleViewHolder;
                    var titleItem = Info[position] as TitleItemVM;
                    titleVH.Title.Text = titleItem.Title;
                    break;
                case 3:
                    var friendVH = holder as RecyclerViewHolder;
                    var friendItem = Info[position] as FriendItemVM;
                    friendVH.Name.Text = friendItem.Name;
                    friendVH.Email.Text = friendItem.Email;
                    friendVH.IsActive.Checked = friendItem.IsActive;
                    break;
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
            if (viewType == 1)
            {
                view = LayoutInflater.From(parent.Context)
                    .Inflate(Resource.Layout.cell_title_with_info, parent, false);
                return new TitleWithInfoViewHolder(view, OnClick);
            }
            if(viewType == 2)
            {
                view = LayoutInflater.From(parent.Context)
                    .Inflate(Resource.Layout.cell_title, parent, false);
                return new TitleViewHolder(view);
            }
            view = LayoutInflater.From(parent.Context)
                    .Inflate(Resource.Layout.cell_friend, parent, false);
            return new RecyclerViewHolder(view, OnClick);
        }
    }
}
