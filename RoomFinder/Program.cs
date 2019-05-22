using RoomFinder.util;
using System;
using System.IO;
using System.Reflection;

namespace RoomFinder
{
    class Program
    {
        private const string FILE_NAME = @"resources/data.txt";
        

        static void Main(string[] args)
        {
            //get the full file path
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), FILE_NAME);
            var building = ProcessFile(path);
            ProcessUserInput(building);

        }

        private static IBuilding ProcessFile(string path)
        {
            if (File.Exists(path))
            {
                //split the file content based on the new line delimeter
                var fileLines = File.ReadAllText(path).Trim().Split(";\r\n");
                FileContentProcessor fileContentProcessor = new FileContentProcessor(fileLines);
                var building = fileContentProcessor.Building;
                Console.WriteLine(building);
                return building;
            }

            return null;
        }

        private static void ProcessUserInput(IBuilding building)
        {
            Console.Write("Enter which room you are currently at: ");
            var roomFromInput = int.TryParse(Console.ReadLine(), out int roomFrom);
            Console.Write("Enter which room you would like to go to: ");
            var roomInput = int.TryParse(Console.ReadLine(), out int roomToGoTo);
            Console.Write("Choose the finding strategy: ");
            var strategyInput = int.TryParse(Console.ReadLine(), out int findingStrategy);
            IPathFinder pathFinder = null;
            switch (findingStrategy)
            {
                case 1:
                    Console.Write("You picked up a transition dependent finding strategy," +
                        " please choose the transition type to avoid: ");
                    var avoidedTransitionType = Console.ReadLine();
                    pathFinder = new TransitionDependentPathFinder(building,avoidedTransitionType);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Finding strategy not supported.");
                    break;
            }


        }
    }
}
