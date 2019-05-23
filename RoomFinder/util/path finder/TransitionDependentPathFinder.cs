using RoomFinder.util.path_finder_template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomFinder.util
{
    public class TransitionDependentPathFinder : AbstractPathFinder
    {
        private List<string> avoidedTransitionType;

        public TransitionDependentPathFinder(IBuilding building,params string[] avoidedTransitionType) : base(building)
        {
            this.avoidedTransitionType = avoidedTransitionType.OfType<string>().ToList();
        }

        internal override void TraverseRoomTransitions(int sourceRoomNumber, int destinationRoomNumber)
        {
            foreach(var transition in building.GetTransitionsForRoom(sourceRoomNumber))
            {
                if (!IsRoomInBuilding(transition.ToRoom) || avoidedTransitionType.Contains(transition.TransitionType))
                {
                    continue;
                }

                var transitionDestination = building.FindRoomByRoomNumber(transition.ToRoom);
                if (!visitedRooms.Contains(transitionDestination))
                {
                    Console.WriteLine("Moved to room:\n" + transitionDestination );
                    visitedRooms.Add(transitionDestination);
                    FindRoom(transitionDestination.Number, destinationRoomNumber);
                    visitedRooms.Remove(transitionDestination);
                }
            }
        }
    }
}
