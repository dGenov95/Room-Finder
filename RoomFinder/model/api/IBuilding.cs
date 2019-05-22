using System;
using System.Collections.Generic;
using System.Text;

namespace RoomFinder
{
    public interface IBuilding
    {
        ISet<Room> GetRooms();
        void AddRoom(Room room);
        void AddTransition(Transition transition);
        List<Room> FindRoomsByFloorNumber(int floorNumber);
        Room FindRoomByRoomNumber(int roomNumber);
    }
}
