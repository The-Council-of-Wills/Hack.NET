using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacknot
{
    class File
    {
        public static string name;
        public static string content;
        public static int size;
        public enum type
        {
            Text,
            Executable,
            System
        }
    }
}