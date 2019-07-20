namespace MyFriends.Core.ViewModels
{
    public class TitleWithInfoItemVM : TitleItemVM
    {
        public string Info { get; }
        public DataPairType Type { get; }

        public TitleWithInfoItemVM(string title, string info, DataPairType type)
            : base(title)
        {
            Info = info;
            Type = type;
        }
    }
}
