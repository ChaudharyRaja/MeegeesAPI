using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.data.DataProcessors
{
    public class UserProcess
    {
        public int ConnectToUser(string userId, string friendId)
        {
            var query = Sql.Builder.Append(";EXEC ConnectToUser  @@UserId=@0", userId);
            query.Append(", @@FriendId=@0", friendId);
            return DbContext.DbObject.Fetch<int>(query).FirstOrDefault();
        }
    }
}
