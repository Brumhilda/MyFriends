using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Support.V4.Widget;
using MyFriends.Resources;
using System.ComponentModel;
using System.Collections.Generic;
using MyFriends.Core.ViewModels;
using MyFriends.Parcelables;
using MyFriends.Api.DTOs;
using Newtonsoft.Json;
using Android.Content.PM;
using System;

namespace MyFriends
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class FriendsActivity : AppCompatActivity
    {
        FriendsPageVM pageVM;
        RecyclerView FriendsList;
        SwipeRefreshLayout SRLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page_friends);
            FriendsList = FindViewById<RecyclerView>(Resource.Id.friendsList);
            FriendsList.HasFixedSize = false;
            FriendsList.SetLayoutManager(new LinearLayoutManager(this));
            SRLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.Page_Friends_SRLayout);
            SRLayout.Refresh += OnRefresh;

            pageVM = new FriendsPageVM();
            pageVM.PropertyChanged += (sender, e) => {
                if ((e as PropertyChangedEventArgs).PropertyName == nameof(pageVM.FriendsList))
                {
                    var adapter = new FriendsViewAdapter(pageVM.FriendsList);
                    adapter.ItemClick += OnItemClick;
                    FriendsList.SetAdapter(adapter);
                }
            };
            LoadContent();
        }

        void OnRefresh(object sender, EventArgs e)
        {
            UpdateData();
            SRLayout.Refreshing = false;
        }

        void LoadContent()
        {
            var shPref = GetSharedPreferences(nameof(pageVM.FriendsList), FileCreationMode.Private);
            var json = shPref.GetString(nameof(pageVM.FriendsList), "");
            if (!string.IsNullOrEmpty(json))
            {
                var usersList = JsonConvert.DeserializeObject<List<UserDTO>>(json, new JsonSerializerSettings());
                pageVM.FriendsList = usersList;
            }
            else
                UpdateData();
        }

        void UpdateData()
        {
            var shPref = GetSharedPreferences(nameof(pageVM.FriendsList), FileCreationMode.Private);
            pageVM.LoadingFriendsList();
            var jsonFriends = pageVM.FriendsList != null
                ? JsonConvert.SerializeObject(pageVM.FriendsList)
                : "";
            var editor = shPref.Edit();
            editor.PutString(nameof(pageVM.FriendsList), jsonFriends);
            editor.Commit();
        }

        void OnItemClick(object sender, int position)
        {
            if (pageVM.FriendsList[position].IsActive)
            {
                var po = new FriendPO(pageVM.FriendsList[position]);
                var intent = new Intent(this, typeof(FriendDetailsActivity));
                intent.PutExtra(nameof(FriendPO), po);
                StartActivity(intent);
            }
        }
    }
}

