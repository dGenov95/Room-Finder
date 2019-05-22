using System;
using System.Collections.Generic;
using System.Text;

namespace RoomFinder
{
    /*
     * A util class, that is used to process the contents of a file and create
     * the corresponding data structures - a building and a list of possible transitions between
     * the rooms of that building.
     * If the file contents valid, for the two types of input, lines the user can receive
     * as a result the structures representing them, otherwise empty structures will be returned.
     */
    public class FileContentProcessor
    {
        public IBuilding Building { get; set; }

        public FileContentProcessor(string[] fileContent)
        {
            Building = new Building();
            ProcessFileContent(fileContent);
        }

        private void ProcessFileContent(string[] fileContent)
        {
            foreach (var line in fileContent)
            {
                if(IsRoom(line))
                {
                    ProcessRoomLine(line);
                }
                else if(IsTransition(line))
                {
                    ProcessTranzitionLine(line);
                }
            }

        }

        private void ProcessRoomLine(string line)
        {
            var roomDetails = line.Split(", ");
            var roomNumber = int.Parse(roomDetails[0]);
            var xCoordinate = int.Parse(roomDetails[1]);
            var yCoordinate = int.Parse(roomDetails[2]);
            var floorNumber = int.Parse(roomDetails[3]);
            var roomType = roomDetails[4];
            Building.AddRoom(new Room(roomNumber, xCoordinate, yCoordinate, floorNumber, roomType));
        }

        private void ProcessTranzitionLine(string line)
        {
            var tranzitionDetails = line.Split(", ");
            var fromRoom = int.Parse(tranzitionDetails[0]);
            var toRoom = int.Parse(tranzitionDetails[1]);
            var transitionType= tranzitionDetails[2];
            var moveCost = int.Parse(tranzitionDetails[3]);
            var isBidirectional = tranzitionDetails[4].Equals("yes") == true ? true : false;
            Building.AddTransition(new Transition(fromRoom, toRoom, transitionType, moveCost, isBidirectional));
        }

        private bool IsRoom(string line)
        {
            return line.Contains("transit") || line.Contains("room");
        }

        private bool IsTransition(string line)
        {
            return line.Contains("walk") || line.Contains("climb") || line.Contains("lift");
        }

    }
}
