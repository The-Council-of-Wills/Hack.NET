using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacknot
{
    class Computer
    {
        const string usernameFile = @"Usernames.txt";
        public static IReadOnlyDictionary<string, Computer> Map => _map;

        public string name = "";
        public string ip = "";
        public int security;
        public Login defaultLogin;
        public bool isPasswordKnown;

        private static readonly Random _r = new Random();

        private static readonly Dictionary<string, Computer> _map = new();
        
        protected Computer(string name, string ip,int security, bool isPasswordKnown, Login defaultLogin){
            this.name = name;
            this.ip = ip;
            this.security = security;
            this.isPasswordKnown = isPasswordKnown;
            this.defaultLogin = defaultLogin;
        }

        // TODO: check that the computer exists in Computer.Map, maybe by IP/name/both?
        public bool computerExists()
        {
            return true;
        }

        public static string createIP()=> $"{_r.Next(0, 256)}.{_r.Next(0, 256)}.{_r.Next(0, 256)}.{_r.Next(0, 256)}";


        // TODO: decide what security parts get added depending on what number secNum is
        public static int generateSecurity()
        {
            return 0;
        }

        public static string createName()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_0123456789";
            Span<char> nameArr = stackalloc char[8];
            Random random = new Random();
            for (int i = 0; i < nameArr.Length; i++) 
            {   
                nameArr[i] = chars[random.Next(chars.Length)];
            }
            return new(nameArr);
        }

        public static string createUser()
        {
            string[] readFile = System.IO.File.ReadAllLines(usernameFile);
            Random random = new Random();
            int randomLineNumber = random.Next(0, readFile.Length - 1);
            string user = readFile[randomLineNumber];
            return user;
        }

        public static string createPassword(int length = 8)
        {
            length = Math.Clamp(length, 6, 14);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_0123456789";
            Span<char> passwordArr = stackalloc char[length];
            Random random = new Random();
            for (int i = 0; i < passwordArr.Length; i++)
            {
                passwordArr[i] = chars[random.Next(chars.Length)];
            }
            return new(passwordArr);
        }
        
        /// <Summary>
        /// Creates the user's computer (may overwrite existing user computer).
        /// </Summary>
        /// <param name="user">Optional username.</param>
        /// <param name="address">Optional address.</param>
        /// <returns>The created computer.</returns>
        public static Computer createPlayerComputer(string? user = null, string? address = null) {
            Computer computer = createComputer(user, address);
            Console.WriteLine($"Created player computer with username {computer.defaultLogin.username} and address {computer.ip}");
            // TODO if there's logic you want to do to make this user computer special, do it here?
            return computer;
        }
        
        /// <Summary>
        /// Creates a new computer.
        /// </Summary>
        /// <param name="user">Optional username.</param>
        /// <param name="address">Optional address.</param>
        /// <returns>The created computer.</returns>
        public static Computer createComputer(string? user = null, string? address = null)
        {
            user ??= createUser();
            address ??= createIP();
            string name = $"{user} PC";
            int security = generateSecurity();
            string password = createPassword();
            Computer res = new Computer(name, address, security, false, new Login(user, password, true));
            _map.Add(address, res);
            return res;
        }

        // behold, a record type
        // it's like a class, except it's immutable
        // it's like a struct, except it's by-reference
        // somewhere in between lol
        public record Login(string username, string password, bool isAdmin);
    }
}
