using System;
using System.Collections.Generic;
using System.Text;

namespace RoomFinder
{
    public class Room
    {

        public int Number { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int FloorNumber { get; set; }
        public string RoomType { get; set; }

        public Room()
        {
            //default constructor
        }

        public Room(int number, int xCoordinate, int yCoordinate, int floorNumber, string roomType)
        {
            this.Number = number;
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.FloorNumber = floorNumber;
            this.RoomType = roomType;
        }

        public override string ToString()
        {
            return "Room - "+ Number 
                + "\nX - " + XCoordinate 
                + "\nY - "+ YCoordinate 
                + "\nFloor - " + FloorNumber 
                +"\nType - " + RoomType;
        }
    }
}
