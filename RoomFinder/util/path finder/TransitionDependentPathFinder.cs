using RoomFinder.util.path_finder_template;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomFinder.util
{
    public class TransitionDependentPathFinder : AbstractPathFinder
    {
        private IBuilding building;
        private string avoidedTransitionType;

        public TransitionDependentPathFinder(IBuilding building, string avoidedTransitionType) : base(building)
        {
            this.avoidedTransitionType = avoidedTransitionType;
        }
      
    }
}
