using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.brain.Declaration;
using application.data.Models;
using application.data.DataProviders;
using application.data.DataProcessors;

namespace application.brain.Defination
{
    public class UserRepository : IUserRepository
    {
        private readonly UserData _user;
        private readonly UserProcess _userProcess;
        public UserRepository()
        {
            _user = new UserData();
            _userProcess = new UserProcess();
        }
        public List<User> SearchUser(string searchVal)
        {
            return _user.SearchUser(searchVal);
        }

        public int ConnectToUser(string userId, string friendId)
        {
            return _userProcess.ConnectToUser(userId, friendId);
        }

        public User GetUserDetails(string id)
        {
            return _user.GetUserDetails(id);
        }
    }
}
