using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp
{
    public static class LocationsDb
    {
        public static List<Location> Locations = new List<Location>
        {
            new Location("Vilnius", "Ateities g. 91", 5),
            new Location("Vilnius", "S. Nėries g. 91", 10),
            new Location("Vilnius", "Lukiškių g. 6", 1),
            new Location("Vilnius", "Dominikonų g. 4", 0),
            new Location("Kaunas", "Jonavos g. 1", 8),
            new Location("Kaunas", "Vytauto pr. 24", 3),
            new Location("Kaunas", "Žemaičių g. 31B", 0),
            new Location("Kaunas", "Ateities g. 91", 5),
            new Location("Klaipėda", "Smiltelės g. 2A", 13),
            new Location("Klaipėda", "Žvejų g. 27", 7),
            new Location("Klaipėda", "Minijos g. 90", 0),
            new Location("Klaipėda", "Bangų g. 5", 0),
        };
    }
}
