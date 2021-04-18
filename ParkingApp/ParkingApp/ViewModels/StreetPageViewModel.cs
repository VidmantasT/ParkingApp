using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ParkingApp.ViewModels
{
    public class StreetPageViewModel
    {
        public ObservableCollection<Location> AllStreets { get; set; }
        public ObservableCollection<Location> allStreets { get { return AllStreets; } }

        public StreetPageViewModel(string city)
        {
            //LocationsDb locationsDb = new LocationsDb();

            var result = LocationsDb.Locations
                .Where(x => x.city == city);

            AllStreets = new ObservableCollection<Location>(result);
        }
    }
}
