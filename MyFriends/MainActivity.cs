using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Content;
using Android.Widget;
using Android.Support.V7.Widget;
using MyFriends.Resources;

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
            var adapter = new RecyclerViewAdapter();
            adapter.ItemClick += OnItemClick;
            FriendsList.SetAdapter(adapter);
        }

        void OnItemClick(object sender, int position)
        {
            var intent = new Intent(this, typeof(FriendDetailsActivity));
            intent.PutExtra("text", "Hello"+position);
            StartActivity(intent);
        }
    }
}

