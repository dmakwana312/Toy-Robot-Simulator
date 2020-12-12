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
                runCommands(File.ReadAllLines(GetDirectory() + @"\commands.txt"));
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                Console.WriteLine("Press Any Key To Exit...");
                Console.ReadLine();
            }
            
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
            try
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            
            return string.Empty;
            
        }
    }
}
