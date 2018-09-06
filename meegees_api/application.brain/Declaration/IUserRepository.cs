using application.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.brain.Declaration
{
    public interface IUserRepository
    {
        List<User> SearchUser(string searchVal);
        int ConnectToUser(string userId, string friendId);
        User GetUserDetails(string id);
    }
}
