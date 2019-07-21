using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Widget;
using Android.Support.V7.Widget;
using MyFriends.Resources;
using System.ComponentModel;
using System.Collections.Generic;
using MyFriends.Core;
using MyFriends.Core.ViewModels;
using MyFriends.Parcelables;
using MyFriends.Api.DTOs;
using Newtonsoft.Json;
using Android.Content.PM;

namespace MyFriends
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class FriendsActivity : AppCompatActivity
    {
        FriendsPageVM pageVM;
        RecyclerView FriendsList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page_friends);
            FriendsList = FindViewById<RecyclerView>(Resource.Id.friendsList);
            FriendsList.HasFixedSize = false;
            FriendsList.SetLayoutManager(new LinearLayoutManager(this));

            pageVM = new FriendsPageVM();
            
            pageVM.PropertyChanged += (sender, e) => {
                if ((e as PropertyChangedEventArgs).PropertyName == nameof(pageVM.FriendsList))
                {
                    var adapter = new RecyclerViewAdapter(pageVM.FriendsList);
                    adapter.ItemClick += OnItemClick;
                    FriendsList.SetAdapter(adapter);
                }
            };
        }

        protected override void OnResume()
        {
            base.OnResume();
            LoadContent();
        }

        void LoadContent()
        {
            var shPref = GetSharedPreferences(nameof(pageVM.FriendsList), FileCreationMode.Private);
            var json = shPref.GetString(nameof(pageVM.FriendsList), "");
            if (json.CompareTo("") != 0)
            {
                var usersList = JsonConvert.DeserializeObject<List<UserDTO>>(json, new JsonSerializerSettings());
                pageVM.FriendsList = usersList;
            }
            else
            {
                pageVM.LoadingFriendsList();
                var jsonFriends = JsonConvert.SerializeObject(pageVM.FriendsList);
                var editor = shPref.Edit();
                editor.PutString(nameof(pageVM.FriendsList), jsonFriends);
                editor.Commit();
            }
        }



        void OnItemClick(object sender, int position)
        {
            var po = new FriendPO(pageVM.FriendsList[position]);
            var intent = new Intent(this, typeof(FriendDetailsActivity));
            intent.PutExtra(nameof(FriendPO), po);
            StartActivity(intent);
        }
    }
}

