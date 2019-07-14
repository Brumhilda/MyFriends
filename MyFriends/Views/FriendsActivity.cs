using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Support.V7.Widget;
using MyFriends.Resources;
using System.ComponentModel;
using MyFriends.Core.ViewModels;

namespace MyFriends
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
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
            pageVM.LoadingFriendsList();
        }

        void OnItemClick(object sender, int position)
        { 
            var intent = new Intent(this, typeof(FriendDetailsActivity));
            intent.PutExtra("text", "Hello \n");
            StartActivity(intent);
        }
    }
}

