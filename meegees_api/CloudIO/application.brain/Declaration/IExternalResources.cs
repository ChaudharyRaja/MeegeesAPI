using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.brain.Declaration
{
   public interface IExternalResources
   {
       SearchListResponse SearchYoutube(string searchQuery);
   }
}
