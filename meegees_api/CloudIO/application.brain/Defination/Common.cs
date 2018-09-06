using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.brain.Declaration;
using application.data.DataProcessors;
using application.data.Models;

namespace application.brain.Defination
{
    public class Common : ICommon
    {
        private readonly CommonFunctions _common;
        public Common()
        {
            _common = new CommonFunctions();
        }
        public bool RegisterUserConnection(string connectionId, string userId)
        {
            return _common.RegisterUserConnection(connectionId, userId);
        }

        public bool DeleteUserConnection(string userId)
        {
            return _common.DeleteUserConnection(userId);
        }

        public List<string> GetConnectedUsers(string userId = "")
        {
            return _common.GetConnectedUsers(userId);
        }

        public User GetConnectionIdForFriendRequest(int id)
        {
            return _common.GetConnectionIdForFriendRequest(id);
        }

        public AddFolderResponse AddFolder(FolderModel folderInfo)
        {
            return _common.AddFolder(folderInfo);
        }
        public List<FolderModel> GetFolders(string userId)
        {
            return _common.GetFolders(userId);
        }
    }
}
