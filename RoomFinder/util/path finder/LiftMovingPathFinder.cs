using RoomFinder.util.path_finder_template;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomFinder.util.path_finder
{
    public class LiftMovingPathFinder : AbstractPathFinder
    {
        public LiftMovingPathFinder(IBuilding building) : base(building)
        {
        }

        internal override void TraverseRoomTransitions(int sourceRoomNumber, int destinationRoomNumber)
        {
            //TODO
        }
    }
}
