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
        /*public bool isAdmin;
        public string username = "";
        public string password = "";*/
        public Login defaultLogin;
        public bool isPasswordKnown;

        private static readonly Random _r = new Random();

        private static readonly Dictionary<string, Computer> _map = new();
        
        // so with this here, I should be able to put this into _map?
        // I mean either inside the constructor itself (ugly imo) or inside the create* methods
        // you have the address you generated and the computer object, so yeah
        protected Computer(string name, string ip,int security, bool isPasswordKnown, Login defaultLogin){
            this.name = name;
            this.ip = ip;
            this.security = security;
            /*this.isAdmin = isAdmin;
            this.username = username;
            this.password= password;*/
            this.isPasswordKnown = isPasswordKnown;
            this.defaultLogin = defaultLogin;
            // yeah, it's not really a "method" per se (at least I don't think it's termed as one)
            // you have a choice to either make a constructor and assign everythng *for sure*
            // or possibly risk missing a field when you do object initialization etc
            // (object initialization is still useful if you've got *extra* things you
            // want to tack on *in addition* to the common set of fields you want to set
            // across player computer, ai computer, blah)
        }

        // TODO: idk but you should be able to see what, you're not dumb (edit: maybe I am)
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
            var random = new Random();
            for (int i = 0; i < nameArr.Length; i++) 
            {   
                nameArr[i] = chars[random.Next(chars.Length)];
            }
            return new(nameArr);
        }

        // so ig it's good for you to have separate pc name vs username generate methods
        // just isolate logic into small bits :*)
        // that works as long as you're sure assets are available
        // external files that you
        // copy to output (which I *have* done and can show you how to set up in the csproj)

        public static string createUser()
        {

            // https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalllines?view=net-5.0
            // ok honestly didn't look at usernames.txt before, I'd suggest using ReadLines instead
            // a fk, see you then
            // this is interesting, if you wnat more help lmkk
            //usernameFile
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
            var random = new Random();
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
            var computer = createComputer(user, address);
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
            var res = new Computer(name, address, security, false, new Login(user, password, true));
            // time to go through hell to figure out how to add this to the dict lmao
            // TODO you still need to register the computer in the dict
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
