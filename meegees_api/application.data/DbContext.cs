using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  PetaPoco;

namespace application.data
{
   public  class DbContext
    {
        public static Database DbObject => new Database("DefaultConnection");
    }
}
