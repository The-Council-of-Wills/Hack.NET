using System;
using System.Collections.Generic;

namespace Hacknot
{
    class Program
    {
        static void Main(string[] args)
        {
            Commands.AddCommands();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Hack.NET\n(c) 2020 SamCo\n");
                Console.Write(">");
                string command = Console.ReadLine();
                var argv = Arguments.SplitCommandLine(command);
                if (argv != null)
                {
                    if (argv.Length == 0)
                    {
                        continue;
                    }
                    else if (argv[0] == "exit")
                    {
                        Commands.exitApplication(args);
                    }
                    else if (argv[0] == "help")
                    {
                        Commands.helpCommand(args);
                    }
                    /*else if (argv[0] == "file")
                    {
                        Commands.fileSizeCommand(args);
                    }*/
                }                
            }
        }
    }
}