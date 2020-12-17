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
        public static string ip;
        public static int security;
        public static bool isAdmin;
        public static string username;
        public static string password;
        public static bool isPasswordKnown;

        // TODO: idk but you should be able to see what, you're not dumb (edit: maybe I am)
        public static bool computerExists()
        {
            return true;
        }

        // TODO: regex that generates four numbers from 0-255 and separates them with a .
        public static void createIP()
        {

        }

        // TODO: decide what security parts get added depending on what number secNum is
        public static void generateSecurity(int secNum)
        {

        }

        public static void createPlayerComputer(string user)
        {
            name = $"{user} PC";
            // ip = createIP();
            // security = generateSecurity();
            isAdmin = true;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_0123456789";
            char[] passwordArr = new char[8];
            var random = new Random();
            for (int i = 0; i < passwordArr.Length; i++)
            {
                passwordArr[i] = chars[random.Next(chars.Length)];
            }
            password = new(passwordArr);
            username = user;
            isPasswordKnown = true;
            Console.WriteLine($"Player computer created with user {user} and password {password}.");
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
