using System;
namespace MyFriends.Core.ViewModels
{
    public class TitleWithInfoItemVM
    {
        public string Title { get; }
        public string Info { get; }
        public DataPairType Type { get; }

        public TitleWithInfoItemVM(string title, string info, DataPairType type)
        {
            Title = title;
            Info = info;
            Type = type;
        }
    }
}
