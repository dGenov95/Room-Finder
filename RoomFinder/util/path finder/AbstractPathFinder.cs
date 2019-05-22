using System;
using System.Collections.Generic;
using System.Text;

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

        private IBuilding building;

        protected AbstractPathFinder(IBuilding building)
        {
            this.building = building;
        }

        public bool FindPath(int from, int to)
        {
            if (!areRoomsExisting(from, to))
            {
                return false;
            }

            return false;
        }

        private bool areRoomsExisting(int fromRoom, int toRoom)
        {
            return building.FindRoomByRoomNumber(fromRoom) != null && building.FindRoomByRoomNumber(toRoom) != null;
        }
    }
}
