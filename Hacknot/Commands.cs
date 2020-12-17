using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacknot
{
    class Commands
    {
        private static Dictionary<string, Action<string[]>> commandsList = new Dictionary<string, Action<string[]>>();
        public static void AddCommands()
        {
            commandsList.Add("help", helpCommand);
            commandsList.Add("exit", exitApplication);
            commandsList.Add("echo", echo);
            //commandsList.Add("connect", connectCommand);
            //commandsList.Add("file", fileSizeCommand);
            commandsList.Add("whoami", whoamiCommand);
        }

        public static void RunCommand(string[] args)
        {
            if (!commandsList.ContainsKey(args[0]))
            {
                Console.WriteLine("Unrecognised command.");
            }
            else
            {
                commandsList[args[0]](args);
            }
        }

        internal static void helpCommand(string[] args)
        {
            Console.WriteLine("--- Hack.NET Commands List ---");
            Console.WriteLine("exit               - Exits the session");
            Console.WriteLine("help               - Prints the command list");
            Console.WriteLine("echo               - Prints the arguments after the echo command");
            //Console.WriteLine("connect [computer] - Connects to a computer");
            //Console.WriteLine("file [file]        - Prints size of provided file");
            Console.WriteLine("whoami             - Prints user currently signed into the computer.");
        }

        internal static void exitApplication(string[] args)
        {
            Environment.Exit(0);
        }

        internal static void connectCommand(string[] args)
        {
            
        }

        internal static void echo(string[] args)
        {

            for (int i = 1; i < args.Length; i++)
            {
                Console.Write($"{args[i].ToString()} ");
            }
            Console.WriteLine("");
        }

        /*internal static void fileSizeCommand(string[] args)
        {
            if (Folder.contentFolders.Contains(args))
            {
                Console.WriteLine($"{File.name}: {File.size}KB");
            }
            else
            {
                Console.WriteLine("Error: file does not exist!");
            }
        }*/

        internal static void whoamiCommand(string[] args)
        {
            Console.WriteLine($"Currently signed in as: {Computer.username}");
        }
    }
}
