using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.brain.Declaration;
using application.data.DataProviders;
using application.data.Models;

namespace application.brain.Defination
{
    public class Interests : IInterests
    {
        private readonly InterestData _interestWharehouse;

        public Interests()
        {
            _interestWharehouse=new InterestData();
        }
        public List<Interest> GetInterests(int intCategoryId = 0, int intId = 0)
        {
            return _interestWharehouse.GetInterests(intCategoryId, intId);
        }
    }
}
