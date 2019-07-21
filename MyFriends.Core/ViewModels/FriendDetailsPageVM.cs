using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using MyFriends.Api.DTOs;
using System.Threading.Tasks;

namespace MyFriends.Core.ViewModels
{
    public class FriendDetailsPageVM : BasePageVM
    {
        private string name;
        private string age;
        private string tags;
        private bool isActive;
        private List<BaseItemVM> userInfo = new List<BaseItemVM>();

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

        public List<BaseItemVM> UserInfo
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
            
            UserInfo = new List<BaseItemVM>
            {
                new TitleWithIconItemVM(nameof(user.Gender), user.Gender.ToString(), DataPairType.Gender),
                new TitleWithIconItemVM(nameof(user.EyeColor), user.EyeColor.ToString(), DataPairType.EyeColor),
                new TitleWithIconItemVM(nameof(user.FavoriteFruit), user.FavoriteFruit.ToString(), DataPairType.Fruit),
                new TitleWithInfoItemVM("Location" , user.Latitude.ToString(CultureInfo.CreateSpecificCulture("en-CA"))
                +", "+ user.Longitude.ToString(CultureInfo.CreateSpecificCulture("en-CA")), DataPairType.Location),
                new TitleWithInfoItemVM(nameof(user.Email) , user.Email, DataPairType.Email),
                new TitleWithInfoItemVM(nameof(user.Phone) , user.Phone, DataPairType.Phone),
                new TitleWithInfoItemVM(nameof(user.Address) , user.Address, DataPairType.Default),
                new TitleWithInfoItemVM(nameof(user.Balance) , user.Balance, DataPairType.Default),
                new TitleWithInfoItemVM(nameof(user.Company) , user.Company, DataPairType.Default),
                new TitleWithInfoItemVM(nameof(user.About) , user.About, DataPairType.Default),
                new TitleWithInfoItemVM(nameof(user.Registered) , user.Registered, DataPairType.Default),
                new TitleItemVM(nameof(user.Friends))
            };

            if (CoreContext.Cache.Count > 0)
                UserInfo.AddRange(user.Friends.Select(f => new FriendItemVM(CoreContext.Cache
                .Where(u => u.Id == f.Id).First())));
            else
                UserInfo.AddRange(user.Friends
                    .Select(u => new FriendItemVM(CoreContext.Api.GetUserById(u.Id).Result)));
        }

    }
}
