using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacknot
{
    class File
    {
        public string name;
        public string content;
        public int size;
        public enum type
        {
            Text,
            Executable,
            System
        }
    }
}