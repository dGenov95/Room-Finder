
using RoomFinder.util;
using RoomFinder.util.path_finder;
using System;
using System.IO;
using System.Reflection;

namespace RoomFinder
{
    class App
    {
        private const string FILE_NAME = @"resources/data.txt";

        private IBuilding building;

        public App()
        {
            //default constructor
        }

        public void Run()
        {
            ProcessFile();
            ProcessUserInput();
        }

        private void ProcessFile()
        {
            //get the full file path
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), FILE_NAME);
            if (File.Exists(path))
            {
                //split the file content based on the new line delimeter
                var fileLines = File.ReadAllText(path).Trim().Split(";\r\n");
                this.building = new FileBuildingProcessor(fileLines).GetBuilding();
                Console.WriteLine(building);
            }
            else
            {
                Console.WriteLine("There was a problem processing the building data...");
                this.building = null;
            }
            
        }

        private void ProcessUserInput()
        {
            if(building == null)
            {
                return;
            }

            Console.Write("Enter which room you are currently at: ");
            var roomFromInput = int.TryParse(Console.ReadLine(), out int sourceRoomNumber);
            Console.Write("Enter which room you would like to go to: ");
            var roomInput = int.TryParse(Console.ReadLine(), out int destinationRoomNumber);
            Console.Write("Choose the finding strategy: ");
            var strategyInput = int.TryParse(Console.ReadLine(), out int findingStrategy);
            IPathFinder pathFinder = null;
            switch (findingStrategy)
            {
                case 1:
                    Console.Write("You picked up a transition dependent finding strategy," +
                        " please choose the transition types to avoid, separated by comma and space: ");
                    var avoidedTransitionType = Console.ReadLine().Split(", ");
                    pathFinder = new TransitionDependentPathFinder(building, avoidedTransitionType);
                    break;
                case 2:
                    Console.WriteLine("You picked up a least effort room finding strategy.");
                    pathFinder = new LeastEffortPathFinder(building);
                    break;
                case 3:
                    Console.WriteLine("You picked up a lift based room finding strategy");
                    pathFinder = new LiftMovingPathFinder(building);
                    break;
                default:
                    Console.WriteLine("Finding strategy not supported.");
                    break;
            }

            if(pathFinder == null)
            {
                return;
            }
            pathFinder.PrintPath(sourceRoomNumber,destinationRoomNumber);

        }
    }
}
