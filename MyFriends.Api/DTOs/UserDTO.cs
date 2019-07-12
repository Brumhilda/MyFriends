using System.Collections.Generic;

namespace MyFriends.Api.DTOs
{
    public class UserDTO : BaseDTO
    {
        public bool IsActive { get;  set; }
        public string Balance { get; protected set; }
        public int Age { get; protected set; }
        public EyeColorType EyeColor { get; protected set; }
        public string Name { get;  set; }
        public GenderType Gender { get; protected set; }
        public string Company { get; protected set; }
        public string Email { get;  set; }
        public string Phone { get; protected set; }
        public string Address { get; protected set; }
        public string About { get; protected set; }
        public string Registered { get; protected set; }
        public float Latitude { get; protected set; }
        public float Longitude { get; protected set; }
        public List<string> Tags { get; protected set; }
        public List<string> FriendsIds { get; protected set; }
        public FruitType FavoriteFruit { get; protected set; }
    }
}
