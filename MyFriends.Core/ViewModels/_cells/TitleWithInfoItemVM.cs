namespace MyFriends.Core.ViewModels
{
    public class TitleWithInfoItemVM : TitleItemVM
    {
        public string Info { get; }
        public UserInfoType Type { get; }

        public TitleWithInfoItemVM(string title, string info, UserInfoType type)
            : base(title)
        {
            Info = info;
            Type = type;
        }
    }
}
