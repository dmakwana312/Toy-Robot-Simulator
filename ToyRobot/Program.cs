using System;
using System.IO;
using System.Reflection;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {

            runCommands(File.ReadAllLines(GetDirectory() + @"\commands.txt"));
            Console.WriteLine("Press Any Key To Exit...");
            Console.ReadLine();
        }

        private static void runCommands(String[] commands)
        {
            Commander commander = new Commander(commands);
            try
            {
                commander.StartRun();
            }
            catch(InvalidCommandException e)
            {
                Console.WriteLine("Error: " + e);
            }
            
            
        }

        private static string GetDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
