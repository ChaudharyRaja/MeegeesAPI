using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.data.Models;
using PetaPoco;

namespace application.data.DataProviders
{
    public class UserData
    {
        public List<User> SearchUser(string searchVal)
        {
            var query = Sql.Builder.Append(";EXEC SearchUser  @@SearchValue=@0", searchVal);
            return DbContext.DbObject.Fetch<User>(query).ToList();
        }
        public User GetUserDetails(string id)
        {
            var query = Sql.Builder.Append(";EXEC GetUserDetails  @@id=@0", id);
            return DbContext.DbObject.Fetch<User>(query).FirstOrDefault();
        }
    }
}
