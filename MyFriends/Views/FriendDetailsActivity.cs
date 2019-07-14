using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V7.Widget;
using System.ComponentModel;
using MyFriends.Adarters;
using MyFriends.Core.ViewModels;

namespace MyFriends.Resources
{
    [Activity(Label = "FriendDetailsActivity")]
    public class FriendDetailsActivity : Activity
    {
        FriendDetailsPageVM pageVM;
        TextView Name;
        RecyclerView InfoList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page_friend_details);
            Name = FindViewById<TextView>(Resource.Id.Page_FriendDetails_Name);
            InfoList = FindViewById<RecyclerView>(Resource.Id.Page_FriendDetails_InfoList);
            Name.Text = Intent.GetStringExtra("text");

            pageVM = new FriendDetailsPageVM();
            pageVM.PropertyChanged += (sender, e) => {
                if((e as PropertyChangedEventArgs).PropertyName == nameof(pageVM.Name))
                    Name.Text = pageVM.Name;
            };

            InfoList.HasFixedSize = false;
            InfoList.SetLayoutManager(new LinearLayoutManager(this));
            var adapter = new CellFriendsViewAdapter(new System.Collections.Generic.List<Views.CellTitleWithInfoActivity>
            {
                new Views.CellTitleWithInfoActivity(),
                new Views.CellTitleWithInfoActivity(),
                new Views.CellTitleWithInfoActivity(),
                new Views.CellTitleWithInfoActivity(),
            }); 
            InfoList.SetAdapter(adapter);
        }
    }
}
