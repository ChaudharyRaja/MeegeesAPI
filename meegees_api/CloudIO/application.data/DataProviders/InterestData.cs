using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.data.Models;
using PetaPoco;

namespace application.data.DataProviders
{
    public class InterestData
    {

        public List<Interest> GetInterests(int intCategoryId = 0, int intId = 0)
        {
            var query = Sql.Builder.Append(";EXEC GetInterests @@intCategoryId=@0", intCategoryId);
            query.Append(", @@intId=@0", intId);
            return DbContext.DbObject.Fetch<Interest>(query).ToList();
        }
    }
}
