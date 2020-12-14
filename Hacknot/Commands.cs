using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacknot
{
    class Commands
    {
        public static void AddCommands()
        {
            Dictionary<string, System.Action<string[]>> commandsList = new Dictionary<string, System.Action<string[]>>();
            commandsList.Add("help", helpCommand);
            commandsList.Add("exit", exitApplication);
            //commandsList.Add("echo", echo);
            //commandsList.Add("file", fileSizeCommand);
        }

        internal static void helpCommand(string[] args)
        {
            Console.WriteLine("--- Hack.NET Commands List ---");
            Console.WriteLine("exit               - Exits the session");
            Console.WriteLine("help               - Prints the command list");
            //Console.WriteLine("connect [computer] - Connects to a computer");
            //Console.WriteLine("file [file]        - Prints size of provided file");
        }

        internal static void exitApplication(string[] args)
        {
            Environment.Exit(0);
        }

        internal static void connectCommand(string[] args)
        {
            
        }

        /*internal static void echo(string[] args)
        {
            Console.WriteLine(args);
        }*/

        /*internal static void fileSizeCommand(string[] args)
        {
            if (File.fileNames.Contains(args.ToString()))
            {
                Console.WriteLine($"{File.name}: {File.fileSize}KB");
            }
            else
            {
                Console.WriteLine("Error: file does not exist!");
            }
        }*/
    }
}
