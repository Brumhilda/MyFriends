using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MyFriends
{
    public class TitleViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title;

        public TitleViewHolder(View cell)
            : base(cell)
        {
            Title = cell.FindViewById<TextView>(Resource.Id.Cell_Title_Title);
        }
    }
}
