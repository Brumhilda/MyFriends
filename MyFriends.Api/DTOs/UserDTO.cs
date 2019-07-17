using System.Collections.Generic;

namespace MyFriends.Api.DTOs
{
    public class UserDTO : BaseDTO
    {
        public bool IsActive { get;  set; }
        public string Balance { get; set; }
        public int Age { get; set; }
        public EyeColorType EyeColor { get; set; }
        public string Name { get;  set; }
        public GenderType Gender { get; set; }
        public string Company { get; set; }
        public string Email { get;  set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public string Registered { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public List<string> Tags { get; set; }
        public List<UserDTO> Friends { get; set; }
        public FruitType FavoriteFruit { get; set; }
    }
}
