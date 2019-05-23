using System;
using System.Collections.Generic;

namespace RoomFinder.util.path_finder_template
{
    /*
     * This abstract class is an implementation of the IPathFinder interface,
     * providing base fumctionality for finding the path between rooms.
     * It is the base class for a template method design pattern, leaving
     * the finding strategy to its subclasses.
     */
    public abstract class AbstractPathFinder : IPathFinder
    {

        protected IBuilding building;
        protected List<Room> visitedRooms;

        protected AbstractPathFinder(IBuilding building)
        {
            this.building = building;
            visitedRooms = new List<Room>();
        }

        public void PrintPath(int sourceRoomNumber, int destinationRoomNumber)
        {
            if (!IsRoomInBuilding(sourceRoomNumber) || !IsRoomInBuilding(destinationRoomNumber))
            {
                Console.WriteLine("One or both of the rooms do not exist");
                return;
            }

            int lastRoomNumber = FindRoom(sourceRoomNumber, destinationRoomNumber);
            if (lastRoomNumber != destinationRoomNumber)
            {
                Console.WriteLine("Sorry there seems to be no path between those two rooms, using this strategy");
            }
        }

        protected int FindRoom(int sourceRoomNumber, int destinationRoomNumber)
        {
            Room sourceRoom = building.FindRoomByRoomNumber(sourceRoomNumber);
            Room destinationRoom = building.FindRoomByRoomNumber(destinationRoomNumber);
            if (sourceRoom.Equals(destinationRoom))
            {
                Console.WriteLine("You are at your destination: " + destinationRoom);
                visitedRooms.Remove(sourceRoom);
                return destinationRoomNumber;
            }

            TraverseRoomTransitions(sourceRoomNumber, destinationRoomNumber);
            return sourceRoomNumber;
        }

        internal abstract void TraverseRoomTransitions(int sourceRoomNumber, int destinationRoomNumber);

        protected bool IsRoomInBuilding(int roomNumber)
        {
            return building.FindRoomByRoomNumber(roomNumber) != null;
        }
    }
}
