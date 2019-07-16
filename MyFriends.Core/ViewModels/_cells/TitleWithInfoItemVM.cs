using System;
namespace MyFriends.Core.ViewModels
{
    public class TitleWithInfoItemVM
    {
        public string Title { get; }
        public string Info { get; }

        public TitleWithInfoItemVM(string title, string info)
        {
            Title = title;
            Info = info;
        }
    }
}
