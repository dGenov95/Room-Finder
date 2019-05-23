using System;
using System.Collections.Generic;
using System.Text;

namespace RoomFinder.util
{
    /*
     * This interface contains the functionality to find a room based on room numbers
     */
    public interface IPathFinder
    {
        void PrintPath(int sourceRoomNumber, int destinationRoomNumber);
    }
}
