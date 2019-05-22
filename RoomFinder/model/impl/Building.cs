using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomFinder
{
    public class Building : IBuilding
    {

        private ISet<Room> rooms;
        private List<Transition> transitions;

        public Building()
        {
            //default constructor
            rooms = new HashSet<Room>();
            transitions = new List<Transition>();
        }

        public Building(ISet<Room> rooms, List<Transition> transitions)
        {
            this.rooms = rooms;
            this.transitions = transitions;
        }

        public List<Room> FindRoomsByFloorNumber(int floorNumber)
        {
            return rooms.Where(room => room.FloorNumber == floorNumber).ToList();
        }

        public ISet<Room> GetRooms()
        {
           return rooms;
        }

        public List<Transition> GetTransitions()
        {
            return transitions;
        }


        public void AddTransition(Transition transition)
        {
            transitions.Add(transition);
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

        public Room FindRoomByRoomNumber(int roomNumber)
        {
           return rooms.Where(room => room.Number == roomNumber).FirstOrDefault();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("\n|Rooms in the building:|");
            foreach (var room in rooms)
            {
                result.AppendLine("----------").AppendLine(room.ToString());
            }
            result.AppendLine("\n|Transitions in the building:|");
            foreach (var transition in transitions)
            {
                result.AppendLine("-----------").AppendLine(transition.ToString());
            }
            return result.ToString();
        }

    }
}
