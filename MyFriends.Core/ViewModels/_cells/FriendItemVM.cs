using MyFriends.Api.DTOs;

namespace MyFriends.Core.ViewModels
{
    public class FriendItemVM : BaseItemVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public FriendItemVM(UserDTO dto)
        {
            Name = dto.Name;
            Email = dto.Email;
            IsActive = dto.IsActive;
        }
    }
}
