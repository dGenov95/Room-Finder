using System;
using System.Collections.Generic;
using System.Text;

namespace RoomFinder
{
    public class Transition
    {
        public int FromRoom { get; set; }
        public int ToRoom { get; set; }
        public string TransitionType { get; set; }
        public int TransitionCost { get; set; }
        public bool IsBidirectional { get; set; }

        public Transition()
        {
            //default constructor
        }

        public Transition(int fromRoom, int toRoom, string transitionType, int transitionCost, bool isBidirectional)
        {
            FromRoom = fromRoom;
            ToRoom = toRoom;
            TransitionType = transitionType;
            TransitionCost = transitionCost;
            IsBidirectional = isBidirectional;
        }

        public override string ToString()
        {
            return "From - " + FromRoom
                + "\nTo - " + ToRoom
                + "\nType - " + TransitionType
                + "\nCost - " + TransitionCost
                + "\nIs Bidirectional - " + IsBidirectional;
                ;
        }
    }
}
