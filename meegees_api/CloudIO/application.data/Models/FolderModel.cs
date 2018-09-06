using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.data.Models
{
    public class FolderModel
    {

        public int Id { get; set; }
        public string FolderName { get; set; }
        public string UserId { get; set; }
        public string FolderIcon { get; set; }
        public int ParentFolder { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime Created { get; set; }
        public List<FolderModel> ChildFolders { get; set; }
    }

    public class AddFolderResponse
    {
        public bool Success { get; set; }
        public string ResponseMessage { get; set; }
    }
}
