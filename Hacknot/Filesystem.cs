using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacknot
{
    class Filesystem
    {
        private string root = "/";
    }

    public abstract class FilesystemEntry
    {
        public string name {get; set;}
        public Folder? parent {get; set;}
        protected FilesystemEntry(string name, Folder? parent)
        {
            
        }
    }
}
