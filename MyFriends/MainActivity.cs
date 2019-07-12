using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Support.V7.Widget;
using MyFriends.Resources;
using MyFriends.Api.Implementations;
using System.Collections.Generic;
using MyFriends.Api.DTOs;

namespace MyFriends
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView FriendsList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page_friends);
            FriendsList = FindViewById<RecyclerView>(Resource.Id.friendsList);
            FriendsList.HasFixedSize = false;

            FriendsList.SetLayoutManager(new LinearLayoutManager(this));
            var adapter = new RecyclerViewAdapter(GetFriendsList());
            adapter.ItemClick += OnItemClick;
            FriendsList.SetAdapter(adapter);

            MyFriendsApi api = new MyFriendsApi();
            //string res = api.GetUsers(new System.Threading.CancellationToken()).Result;
        }

        List<UserDTO> GetFriendsList()
        {
            return new List<UserDTO>
            {
                new UserDTO{ Name = "Liza Glukhova", Email = "lizka030697@gmail.com", IsActive = true},
                new UserDTO{ Name = "Vasya Boolkovsky", Email = "vasya092@gmail.com", IsActive = true},
                new UserDTO{ Name = "Dexter Morgan", Email = "dexter007@gmail.com", IsActive = false},
                new UserDTO{ Name = "Debra Morgan", Email = "fuckingemail@gmail.com", IsActive = false}
            };
        }

        void OnItemClick(object sender, int position)
        { 
            var intent = new Intent(this, typeof(FriendDetailsActivity));
            intent.PutExtra("text", "Hello \n");
            StartActivity(intent);
        }
    }
}

