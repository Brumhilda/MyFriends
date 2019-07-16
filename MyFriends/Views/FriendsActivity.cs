using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Android.Widget;
using Android.Support.V7.Widget;
using MyFriends.Resources;
using System.ComponentModel;
using System.Linq;
using MyFriends.Core.ViewModels;
using MyFriends.Parcelables;

namespace MyFriends
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class FriendsActivity : AppCompatActivity
    {
        FriendsPageVM pageVM;
        RecyclerView FriendsList;
        //ISharedPreferences sharedPreferences;

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
                    /*pageVM.FriendsList
                        .Select(dto => new FriendPO(dto))
                        .ToList());*/
                }
            };
            pageVM.LoadingFriendsList();

            /*var shPref = GetSharedPreferences("myData", FileCreationMode.Private);
           
            Toast.MakeText(this, shPref.GetString("key", ""), ToastLength.Short).Show();
 
            var editor = shPref.Edit();
            editor.PutString("key","myvalue");
            editor.Commit();

            var h = new FriendPO();
            var code = h.GetHashCode();*/

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

