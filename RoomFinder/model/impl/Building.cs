using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomFinder
{
    public class Building : IBuilding
    {

        private ISet<Room> rooms;
        private Dictionary<int, List<Transition>> transitions;

        public Building()
        {
            //default constructor
            rooms = new HashSet<Room>();
            transitions = new Dictionary<int, List<Transition>>();
        }

        public Building(ISet<Room> rooms, Dictionary<int, List<Transition>> transitions)
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

        public List<Transition> GetTransitionsForRoom(int roomNumber)
        {
            return transitions.GetValueOrDefault(roomNumber, new List<Transition>());
        }


        public void AddTransition(int roomNumber, Transition transition)
        {
            if (transitions.ContainsKey(roomNumber))
            {
                transitions[roomNumber].Add(transition);
            }
            else
            {
                transitions.Add(roomNumber, new List<Transition> { transition });
            }
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
            return result.ToString();
        }

    }
}
