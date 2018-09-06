using application.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.brain.Declaration
{
    public interface IInterests
    {
        List<Interest> GetInterests(int intCategoryId = 0, int intId = 0);
    }
}
