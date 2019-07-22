using System;

namespace MyFriends.Core.ViewModels
{
    public class TitleWithIconItemVM : TitleWithInfoItemVM
    {
        public TitleWithIconItemVM(string title, string info, UserInfoType type)
            :base (title, info, type)
        {
        }
    }
}
