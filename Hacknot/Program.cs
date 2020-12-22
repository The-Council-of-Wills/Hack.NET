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
            Console.Write("Enter your username: ");
            Player.name = Console.ReadLine() ?? throw new Exception();
            Computer.createPlayerComputer(Player.name);
            for (int i = 0; i < 5; i++)
            {
                Computer.createComputer();
                Console.WriteLine($"DEBUG: Computer {i} created.");

            }
            while (isRunning)
            {
                Console.Write(">");
                string command = Console.ReadLine() ?? throw new Exception();
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