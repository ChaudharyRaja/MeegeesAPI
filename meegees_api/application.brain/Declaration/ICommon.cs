using application.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.brain.Declaration
{
    public interface ICommon
    {
        bool RegisterUserConnection(string connectionId, string userId);
        bool DeleteUserConnection(string userId);
        List<string> GetConnectedUsers(string userId = "");
        User GetConnectionIdForFriendRequest(int id);
        AddFolderResponse AddFolder(FolderModel folderInfo);
        List<FolderModel> GetFolders(string userId);
    }
}
