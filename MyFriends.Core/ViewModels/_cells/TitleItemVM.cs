namespace MyFriends.Core.ViewModels
{
    public class TitleItemVM : BaseItemVM
    {
        public string Title { get; }

        public TitleItemVM(string title)
        {
            Title = title;
        }
    }
}