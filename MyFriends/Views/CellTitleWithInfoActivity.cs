
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyFriends.Views
{
    [Activity(Label = "CellTitleWithInfoActivity")]
    public class CellTitleWithInfoActivity : Activity
    {
        public TextView Title;
        public TextView Info;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.cell_title_with_info);
        }
    }
}
