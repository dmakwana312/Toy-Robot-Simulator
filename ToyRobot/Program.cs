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

        }

        private static void runCommands(String[] commands)
        {
            Commander commander = new Commander(commands);
            commander.StartRun();
            
        }

        private static string GetDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
