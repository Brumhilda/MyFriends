using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MyFriends.Adarters;
using MyFriends.Parcelables;
using MyFriends.Core;
using MyFriends.Core.ViewModels;
using MyFriends.Api.DTOs;
using Android;
using Android.Support.V4.Content; 
using Android.Support.V4.App;

namespace MyFriends.Resources
{
    [Activity(Label = "FriendDetailsActivity")]
    public class FriendDetailsActivity : Activity
    {
        FriendDetailsPageVM pageVM;
        TextView Name;
        TextView Age;
        RadioButton IsActive;
        TextView Tags;
        RecyclerView InfoList;
        List<BaseItemVM> Info;

        ISharedPreferences sharedPreferences;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page_friend_details);
            Name = FindViewById<TextView>(Resource.Id.Page_FriendDetails_Name);
            Age = FindViewById<TextView>(Resource.Id.Page_FriendDetails_Age);
            IsActive = FindViewById<RadioButton>(Resource.Id.Page_FriendDetails_IsActive);
            Tags = FindViewById<TextView>(Resource.Id.Page_FriendDetails_Tags);
            InfoList = FindViewById<RecyclerView>(Resource.Id.Page_FriendDetails_InfoList);
            InfoList.HasFixedSize = false;
            InfoList.SetLayoutManager(new LinearLayoutManager(this));

            FriendPO fPO = new FriendPO();
            if (Intent.Extras != null)
            {
                fPO = Intent.GetParcelableExtra(nameof(FriendPO)) as FriendPO;
                pageVM = new FriendDetailsPageVM();
                pageVM.PropertyChanged += (sender, e) =>
                {
                    switch((e as PropertyChangedEventArgs).PropertyName)
                    {
                        case nameof(pageVM.Name):
                            Name.Text = pageVM.Name;
                            break;
                        case nameof(pageVM.IsActive):
                            IsActive.Checked = pageVM.IsActive;
                            break;
                        case nameof(pageVM.Age):
                            Age.Text = pageVM.Age;
                            break;
                        case nameof(pageVM.Tags):
                            Tags.Text = pageVM.Tags;
                            break;
                        case nameof(pageVM.UserInfo):
                            Info = pageVM.UserInfo;
                            var adapter = new CellFriendsViewAdapter(Info);
                            adapter.ItemClick += OnItemClick;
                            InfoList.SetAdapter(adapter);
                            break;
                    }
                };
                pageVM.LoadingUserInfo(new UserDTO
                {
                    Name = fPO.Name,
                    Email = fPO.Email,
                    IsActive = Convert.ToBoolean(fPO.IsActive),
                    Age = fPO.Age,
                    Tags = fPO.Tags,
                    Balance = fPO.Balance,
                    About = fPO.About,
                    Address = fPO.Address,
                    Company = fPO.Company,
                    Guid = fPO.Guid,
                    Id = fPO.Guid,
                    Latitude = fPO.Latitude,
                    Longitude = fPO.Longitude,
                    Phone = fPO.Phone,
                    Registered = fPO.Registered,
                    FavoriteFruit = fPO.FavoriteFruit.ToFruitType(),
                    EyeColor = fPO.EyeColor.ToEyeColorType(),
                    Gender = fPO.Gender.ToGenderType(),
                    Friends = fPO.Friends
                        .Select(id => new UserDTO { Id = id })
                        .ToList()
                    //TODO remake it
                }); 
            }
        }
        
        void OnItemClick(object sender, int position)
        {
            var RequestPhoneCall = 1;
            var intent = new Intent(Intent.ActionDial);
            if (Info[position] is TitleWithInfoItemVM)
            {
                var cell = Info[position] as TitleWithInfoItemVM;
                switch (cell.Type)
                {
                    case DataPairType.Phone:
                        intent.SetData(Android.Net.Uri.Parse("tel:" + cell.Info));
                        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.CallPhone) != Android.Content.PM.Permission.Granted)
                            ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.CallPhone }, RequestPhoneCall);
                        else
                            StartActivity(intent);
                        break;
                    case DataPairType.Email:
                        intent = new Intent(Intent.ActionSendto);
                        intent.SetData(Android.Net.Uri.FromParts("mailto", cell.Info, null));
                        StartActivity(intent);
                        break;
                    case DataPairType.Location:
                        intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("geo:" + cell.Info));
                        StartActivity(intent);
                        break;
                }
            }
        }  
    }
}
