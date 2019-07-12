using System.Threading;
using System.Threading.Tasks;

namespace MyFriends.Api
{
    public interface IMyFriendsApi
    {
        Task<string> GetUsers(CancellationToken token);
    }
}
