using Android.Views;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;
using MyFriends.Api;
using MyFriends.Core;
using MyFriends.Core.ViewModels;

namespace MyFriends.Adarters
{
    public class FriendDetailsViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public List<BaseItemVM> Info { get; }

        public FriendDetailsViewAdapter(List<BaseItemVM> infoList)
        {
            Info = infoList;
        }

        public override int ItemCount => Info.Count;

        void OnClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override int GetItemViewType(int position)
        {
            return Info[position] is TitleWithIconItemVM
                ? 0
                : Info[position] is TitleWithInfoItemVM
                ? 1
                : Info[position] is TitleItemVM
                ? 2
                : 3;
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
                    titleWithIconVH.Icon.SetImageResource(titleWithIconItem.Info.GetIconId(titleWithIconItem.Type));
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
                    var friendVH = holder as FriendViewHolder;
                    var friendItem = Info[position] as FriendItemVM;
                    friendVH.Name.Text = friendItem.Name;
                    friendVH.Email.Text = friendItem.Email;
                    friendVH.IsActive.Checked = friendItem.IsActive;
                    if (!friendItem.IsActive)
                        friendVH.IsActive.Enabled = false;
                    friendVH.IsActive.SetText(friendItem.IsActive
                        ? Resource.String.isActive
                        : Resource.String.notActive);
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
            return new FriendViewHolder(view, OnClick);
        }
    }
}
