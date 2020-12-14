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
            Console.WriteLine("Hack.NET\n(c) 2020 SamCo\n");
            while (isRunning)
            {
                Console.Write(">");
                string command = Console.ReadLine();
                var argv = Arguments.SplitCommandLine(command);
                if (argv != null)
                {
                    if (argv.Length == 0)
                    {
                        continue;
                    }
                    Commands.RunCommand(argv);
                }                
            }
        }
    }
}