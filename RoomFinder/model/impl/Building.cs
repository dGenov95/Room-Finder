using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomFinder
{
    public class Building : IBuilding
    {

        public ISet<Room> Rooms { get; set; }
        public List<Transition> Transitions { get; set; }

        public Building()
        {
            //default constructor
            Rooms = new HashSet<Room>();
            Transitions = new List<Transition>();
        }

        public Building(ISet<Room> rooms, List<Transition> transitions)
        {
            Rooms = rooms;
            Transitions = transitions;
        }

        public List<Room> FindRoomsByFloorNumber(int floorNumber)
        {
            return Rooms.Where(room => room.FloorNumber == floorNumber).ToList();
        }

        public ISet<Room> GetRooms()
        {
           return Rooms;
        }


        public void AddTransition(Transition transition)
        {
            Transitions.Add(transition);
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public Room FindRoomByRoomNumber(int roomNumber)
        {
           return Rooms.Where(room => room.Number == roomNumber).FirstOrDefault();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("\n|Rooms in the building:|");
            foreach (var room in Rooms)
            {
                result.AppendLine("----------").AppendLine(room.ToString());
            }
            result.AppendLine("\n|Transitions in the building:|");
            foreach (var transition in Transitions)
            {
                result.AppendLine("-----------").AppendLine(transition.ToString());
            }
            return result.ToString();
        }

    }
}
