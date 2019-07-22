using System;
using Android.OS;
using Android.Runtime;
using System.Collections.Generic;
using System.Linq;
using MyFriends.Api.DTOs;
using Java.Interop;

namespace MyFriends.Parcelables
{
    public class FriendPO : Java.Lang.Object, IParcelable
    {
        public string Id { get; private set; }
        public string Guid { get; set; }
        public string IsActive { get; set; }
        public string Balance { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string Email { get; private set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string Registered { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public List<string> Friends { get; set; } = new List<string>();
        public string FavoriteFruit { get; set; }

        public FriendPO(UserDTO user)
        {
            Id = user.Id;
            this.Guid = user.Guid;
            Age = user.Age;
            IsActive = user.IsActive.ToString();
            Balance = user.Balance;
            EyeColor = user.EyeColor.ToString();
            Name = user.Name;
            Gender = user.Gender.ToString();
            Company = user.Company;
            Address = user.Address;
            Email = user.Email;
            Phone = user.Phone;
            About = user.About;
            Registered = user.Registered;
            Latitude = user.Latitude;
            Longitude = user.Longitude;
            Tags = user.Tags;
            FavoriteFruit = user.FavoriteFruit.ToString();
            Friends = user.Friends
                .Select(x => x.Id)
                .ToList();
        }

        public FriendPO()
        {
        }

        public FriendPO(Parcel parcel)
        {
            Id = parcel.ReadString();
            this.Guid = parcel.ReadString();
            Age = parcel.ReadInt();
            IsActive = parcel.ReadString();
            Balance = parcel.ReadString();
            EyeColor = parcel.ReadString();
            Name = parcel.ReadString();
            Gender = parcel.ReadString();
            Company = parcel.ReadString();
            Address = parcel.ReadString();
            Email = parcel.ReadString();
            Phone = parcel.ReadString();
            About = parcel.ReadString();
            Registered = parcel.ReadString();
            Latitude = parcel.ReadFloat();
            Longitude = parcel.ReadFloat();
            var tags = new string[parcel.ReadInt()];
            parcel.ReadStringArray(tags);
            Tags = tags.ToList();
            FavoriteFruit = parcel.ReadString();
            var friends = new string[parcel.ReadInt()];
            parcel.ReadStringArray(friends);
            Friends = friends.ToList();
        }

        public UserDTO ToUserDTO()
        {
            return new UserDTO
            {
                Name = Name,
                Email = Email,
                IsActive = Convert.ToBoolean(IsActive),
                Age = Age,
                Tags = Tags,
                Balance = Balance,
                About = About,
                Address = Address,
                Company = Company,
                Guid = Guid,
                Id = Guid,
                Latitude = Latitude,
                Longitude = Longitude,
                Phone = Phone,
                Registered = Registered,
                FavoriteFruit = FavoriteFruit.ToFruitType(),
                EyeColor = EyeColor.ToEyeColorType(),
                Gender = Gender.ToGenderType(),
                Friends = Friends
                        .Select(id => new UserDTO { Id = id })
                        .ToList()
            };
        }

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteString(Id);
            dest.WriteString(this.Guid);
            dest.WriteInt(Age);
            dest.WriteString(IsActive);
            dest.WriteString(Balance);
            dest.WriteString(EyeColor);
            dest.WriteString(Name);
            dest.WriteString(Gender);
            dest.WriteString(Company);
            dest.WriteString(Address);
            dest.WriteString(Email);
            dest.WriteString(Phone);
            dest.WriteString(About);
            dest.WriteString(Registered);
            dest.WriteFloat(Latitude);
            dest.WriteFloat(Longitude);
            dest.WriteInt(Tags.Count);
            dest.WriteStringArray(Tags.ToArray());
            dest.WriteString(FavoriteFruit);
            dest.WriteInt(Friends.Count);
            dest.WriteStringArray(Friends.ToArray());
        }

        private static ParcelableCreator<FriendPO> _creator =
            new ParcelableCreator<FriendPO>((parcel)=> new FriendPO(parcel));

        [ExportField("CREATOR")]
        public static ParcelableCreator<FriendPO> GetCreator()
        {
            return _creator;
        }
    }
}
