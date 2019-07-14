using System;
using System.Collections.Generic;

namespace MyFriends.Core.ViewModels
{
    public class FriendDetailsPageVM : BasePageVM
    {
        private string name;
        //private List<>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

    }
}
