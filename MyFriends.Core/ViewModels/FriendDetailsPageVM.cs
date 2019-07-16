using System;
using System.Collections.Generic;
using System.Linq;
using MyFriends.Api.DTOs;

namespace MyFriends.Core.ViewModels
{
    public class FriendDetailsPageVM : BasePageVM
    {
        private string name;
        private string age;
        private string tags;
        private bool isActive;
        private List<TitleWithInfoItemVM> userInfo = new List<TitleWithInfoItemVM>();

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string Tags
        {
            get { return tags; }
            set
            {
                tags = value;
                OnPropertyChanged(nameof(Tags));
            }
        }

        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public List<TitleWithInfoItemVM> UserInfo
        {
            get { return userInfo; }
            set
            {
                userInfo = value;
                OnPropertyChanged(nameof(UserInfo));
            }
        }

        public void LoadingUserInfo(UserDTO user)
        {
            Name = user.Name;
            Age = user.Age.ToString() + " y.o.";
            Tags = "#" + string.Join(" #", user.Tags);
            IsActive = user.IsActive;
            UserInfo = new List<TitleWithInfoItemVM>
            {
                new TitleWithInfoItemVM("Location" , user.Latitude+" ,"+ user.Longitude),
                new TitleWithInfoItemVM(nameof(user.Email) , user.Email),
                new TitleWithInfoItemVM(nameof(user.Phone) , user.Phone),
                new TitleWithInfoItemVM(nameof(user.Address) , user.Address),
                new TitleWithInfoItemVM(nameof(user.Balance) , user.Balance),
                new TitleWithInfoItemVM(nameof(user.Company) , user.Company),
                new TitleWithInfoItemVM(nameof(user.About) , user.About),
                new TitleWithInfoItemVM(nameof(user.Registered) , user.Registered)
            };
        }

    }
}
