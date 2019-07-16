using Android.App;
using Android.OS;
using Android.Widget;
using MyFriends.Core.ViewModels;

namespace MyFriends.Views
{
    [Activity(Label = "CellTitleWithInfoActivity")]
    public class CellTitleWithInfoActivity : Activity
    {
        public TextView TitleView;
        public TextView Info;
        public TitleWithInfoItemVM pageVM;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.cell_title_with_info);
            TitleView = FindViewById<TextView>(Resource.Id.Cell_TitleWithInfo_Title);
            Info = FindViewById<TextView>(Resource.Id.Cell_TitleWithInfo_Info);
        }
    }
}
