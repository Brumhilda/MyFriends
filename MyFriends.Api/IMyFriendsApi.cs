using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyFriends.Api.DTOs;

namespace MyFriends.Api
{
    public interface IMyFriendsApi
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(string id);
    }
}
