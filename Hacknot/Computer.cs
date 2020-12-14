using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacknot
{
    class Computer
    {
        public static string name;
        public string ip;
        public int security;
        public bool isAdmin;
        public string username;
        public string password;

        // TODO: idk but you should be able to see what, you're not dumb
        public static bool computerExists()
        {
            return true;
        }

        public static void createComputer()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_0123456789";
            char[] nameArr = new char[8];
            var random = new Random();
            for (int i = 0; i < nameArr.Length; i++)
            {
                nameArr[i] = chars[random.Next(chars.Length)];
            }
            name = new (nameArr);

            
        }
    }
}
