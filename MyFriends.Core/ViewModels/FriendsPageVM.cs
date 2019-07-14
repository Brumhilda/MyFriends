using System.Collections.Generic;
using System.Runtime;
using System.Threading.Tasks;
using MyFriends.Api.Implementations;
using MyFriends.Api.DTOs;

namespace MyFriends.Core.ViewModels
{
    public class FriendsPageVM : BasePageVM
    {
        private List<UserDTO> friendsList;
        public List<UserDTO> FriendsList
        {
            get { return friendsList; }
            set
            {
                friendsList = value;
                OnPropertyChanged(nameof(FriendsList));
            }
        }

        public void LoadingFriendsList()
        {
            FriendsList = Task.Run(() =>
                CoreContext.Api.GetUsers(new System.Threading.CancellationToken())).Result;
        }
    }
}
