using application.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.data.DataProcessors
{
    public class CommonFunctions
    {
        public bool RegisterUserConnection(string connectionId, string userId)
        {
            var query = PetaPoco.Sql.Builder.Append(";EXEC RegisterUserConnection @@ConnectionId=@0", connectionId);
            query.Append(", @@UserId=@0", userId);
            var result = DbContext.DbObject.Execute(query);
            return true;
        }
        public bool DeleteUserConnection(string userId)
        {
            var query = PetaPoco.Sql.Builder.Append(";EXEC DeleteUserConnection @@UserId=@0", userId);
            var result = DbContext.DbObject.Execute(query);
            return true;
        }


        public List<string> GetConnectedUsers(string userId = "")
        {
            var query = PetaPoco.Sql.Builder.Append(";EXEC GetConnectionIds @@UserId=@0", userId);
            var result = DbContext.DbObject.Fetch<string>(query).ToList();
            return result;
        }

        public User GetConnectionIdForFriendRequest(int id)
        {
            var query = PetaPoco.Sql.Builder.Append(";EXEC GetConnectionOfUserConnected @@fRequestId=@0", id);
            var result = DbContext.DbObject.Fetch<User>(query).FirstOrDefault();
            return result;
        }

        public AddFolderResponse AddFolder(FolderModel folderInfo)
        {
            var query = PetaPoco.Sql.Builder.Append(";EXEC AddFolder @@FolderName=@0", folderInfo.FolderName);
            query.Append(", @@UserId=@0", folderInfo.UserId);
            query.Append(", @@FolderIcon=@0", folderInfo.FolderIcon);
            query.Append(", @@ParentFolder=@0", folderInfo.ParentFolder);
            query.Append(", @@IsPrivate=@0", folderInfo.IsPrivate);
            var result = DbContext.DbObject.Fetch<AddFolderResponse>(query).FirstOrDefault();
            return result;
        }

        public List<FolderModel> GetFolders(string userId)
        {
            var query = PetaPoco.Sql.Builder.Append(";EXEC GetFolders @@UserId=@0", userId);
            var result = DbContext.DbObject.Fetch<FolderModel>(query).ToList();
            return result?.Count > 0 ? GetFolders(result, 0) : result;
        }

        private List<FolderModel> GetFolders(List<FolderModel> list, int parent)
        {
            return list.Where(x => x.ParentFolder == parent).Select(x => new FolderModel
            {
                Id = x.Id,
                FolderName = x.FolderName,
                IsPrivate = x.IsPrivate,
                Created = x.Created,
                ParentFolder = x.ParentFolder,
                ChildFolders = x.ParentFolder != x.Id ? GetFolders(list, x.Id) : new List<FolderModel>()
            }).ToList();
        }
    }
}
