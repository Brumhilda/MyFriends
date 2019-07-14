using MyFriends.Api;
using MyFriends.Api.Implementations;

namespace MyFriends.Core
{
    public static class CoreContext
    {
        public static IMyFriendsApi Api = new MyFriendsApi();
    }
}
