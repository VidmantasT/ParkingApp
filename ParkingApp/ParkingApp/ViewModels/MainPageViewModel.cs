using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ParkingApp.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Location> AllCities { get; set; }
        public ObservableCollection<Location> allCities { get { return AllCities; } }

        public MainPageViewModel()
        {
            //LocationsDb locationsDb = new LocationsDb();

            var result = LocationsDb.Locations
                .GroupBy(x => x.city)
                .Select(g => g.First());

            AllCities = new ObservableCollection<Location>(result);
        }
    }
}
