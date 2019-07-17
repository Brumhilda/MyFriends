using System;

namespace MyFriends.Core.ViewModels
{
    public class TitleWithIconItemVM : TitleWithInfoItemVM
    {
        public TitleWithIconItemVM(string title, string info, DataPairType type)
            :base (title, info, type)
        {
        }
    }
}
