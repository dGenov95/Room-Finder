using System;
using System.Collections.Generic;
using System.Text;

namespace RoomFinder
{
    /*
     * The interface defining a Building
     */
    public interface IBuilding
    {
        ISet<Room> GetRooms();
        List<Transition> GetTransitionsForRoom(int roomNumber);
        void AddRoom(Room room);
        void AddTransition(int roomNumber,Transition transition);
        List<Room> FindRoomsByFloorNumber(int floorNumber);
        Room FindRoomByRoomNumber(int roomNumber);
    }
}
