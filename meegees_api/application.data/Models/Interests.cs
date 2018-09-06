using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.data.Models
{
    public class Interest : InterestCategory
    {
        public int InterestId { get; set; }
        public string InterestText { get; set; }
        public string InterestRefPic { get; set; }
        public bool Selected { get; set; }
    }
}
