using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacknot
{
    public class Folder
    {
        public string name = "";
        public List<Folder> contentFolders;
        public List<string> contentFiles;
    }
}
