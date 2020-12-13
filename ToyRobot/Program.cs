using System;
using System.IO;
using System.Reflection;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Retrieve commands from text file and run commands
                runCommands(File.ReadAllLines(GetDirectory() + @"\commands.txt"));

            }
            // Catch errors
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                // Buffer to prevent application closing instantly, upon completion
                Console.WriteLine("Press Any Key To Exit...");
                Console.ReadLine();
            }

        }

        // Run commands
        private static void runCommands(String[] commands)
        {
            Commander commander = new Commander(commands);
            try
            {
                commander.StartRun();
            }
            catch (InvalidCommandException e)
            {
                Console.WriteLine("Error: " + e);
            }


        }


        // Retrieve working direction
        private static string GetDirectory()
        {
            try
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

            return string.Empty;

        }
    }
}
