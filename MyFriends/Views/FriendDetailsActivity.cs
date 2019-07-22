using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using System.Collections.Generic;
using System.ComponentModel;
using MyFriends.Adarters;
using MyFriends.Parcelables;
using MyFriends.Core;
using MyFriends.Core.ViewModels;
using Android;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Views;
using Android.Content.PM;

namespace MyFriends.Resources
{
    [Activity(Label = "FriendDetailsActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FriendDetailsActivity : AppCompatActivity
    {
        Android.Support.V7.App.ActionBar ActionBar;
        FriendDetailsPageVM pageVM;
        TextView Name;
        TextView Age;
        RadioButton IsActive;
        TextView Tags;
        RecyclerView InfoList;
        List<BaseItemVM> Info;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.page_friend_details);
            if (SupportActionBar != null)
            {
                ActionBar = SupportActionBar;
                ActionBar.SetDisplayHomeAsUpEnabled(true);
            }

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
                    switch ((e as PropertyChangedEventArgs).PropertyName)
                    {
                        case nameof(pageVM.Name):
                            Name.Text = pageVM.Name;
                            ActionBar.Title = Name.Text;
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
                            var adapter = new FriendDetailsViewAdapter(Info);
                            adapter.ItemClick += OnItemClick;
                            InfoList.SetAdapter(adapter);
                            break;
                    }
                };
                pageVM.LoadingUserInfo(fPO.ToUserDTO());
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        void OnItemClick(object sender, int position)
        {
            var RequestPhoneCall = 1;
            Intent intent;
            if (Info[position] is TitleWithInfoItemVM)
            {
                var cell = Info[position] as TitleWithInfoItemVM;
                switch (cell.Type)
                {
                    case DataPairType.Phone:
                        intent = new Intent(Intent.ActionDial);
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
            else if (Info[position] is FriendItemVM && (Info[position] as FriendItemVM).IsActive)
            {
                var friend = Info[position] as FriendItemVM;
                foreach (var user in CoreContext.Cache)
                    if (user.Id == friend.Id)
                    {
                        var po = new FriendPO(user);
                        intent = new Intent(this, typeof(FriendDetailsActivity));
                        intent.PutExtra(nameof(FriendPO), po);
                        StartActivity(intent);
                        break;
                    }
            }
        }
    }
}
