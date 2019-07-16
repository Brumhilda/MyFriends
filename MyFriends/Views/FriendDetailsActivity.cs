using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V7.Widget;
using System;
using System.ComponentModel;
using System.Linq;
using MyFriends.Adarters;
using MyFriends.Parcelables;
using MyFriends.Core.ViewModels;
using MyFriends.Views;
using MyFriends.Api.DTOs;
using MyFriends.Api;
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
                            var adapter = new CellFriendsViewAdapter(pageVM.UserInfo
                                .Select(pair => (pair.Title, pair.Info).ToTuple())
                                .ToList());
                            adapter.ItemClick += OnItemClick;
                            InfoList.SetAdapter(adapter);
                            break;
                    }
                };
                pageVM.LoadingUserInfo(new UserDTO { Name = fPO.Name, Email = fPO.Email,
                    IsActive = Convert.ToBoolean(fPO.IsActive), Age = fPO.Age, Tags = fPO.Tags,
                    Balance = fPO.Balance, About = fPO.About, Address = fPO.Address, Company = fPO.Company,
                    Guid = fPO.Guid, Id = fPO.Guid, Latitude = fPO.Latitude,
                    Longitude = fPO.Longitude, Phone = fPO.Phone, Registered = fPO.Registered
                });
            }
        }

        void OnItemClick(object sender, int position)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + "+7111111"));
            //StartActivity(intent);

            ActivityCompat.RequestPermissions(this, new []{ Manifest.Permission.CallPhone }, 200);

                // MY_PERMISSIONS_REQUEST_CALL_PHONE is an
                // app-defined int constant. The callback method gets the
                // result of the request.
            }
           
    }
}
