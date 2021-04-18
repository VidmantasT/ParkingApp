using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp
{
    public class Location
    {
        public string city { get; set; }
        public string street { get; set; }
        public int emptySpaces { get; set; }

        public Location(string city, string street, int emptySpaces)
        {
            this.city = city;
            this.street = street;
            this.emptySpaces = emptySpaces;
        }
    }
}
