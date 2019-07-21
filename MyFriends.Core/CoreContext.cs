using System.Collections.Generic;
using MyFriends.Api;
using MyFriends.Api.DTOs;
using MyFriends.Api.Implementations;

namespace MyFriends.Core
{
    public static class CoreContext
    {
        public static IMyFriendsApi Api = new MyFriendsApi();
        public static List<UserDTO> Cache = new List<UserDTO>();
    }
}
