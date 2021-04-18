using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParkingApp.ViewModels
{
    public class SpacesPageViewModel : INotifyPropertyChanged
    {
        public int CurrentSpaces;
        public bool isEnabled = false;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;

                OnPropertyChanged();
                MyCommand.ChangeCanExecute();
            }
        }
        public Command MyCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<Location> AllSpaces { get; set; }
        public ObservableCollection<Location> allSpaces { get { return AllSpaces; } }
        public int EmptySpaces { get; set; }
        public int emptySpaces
        {
            set
            {
                if(EmptySpaces != value)
                {
                    EmptySpaces = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("emptySpaces"));
                }
            }
            get
            {
                return EmptySpaces;
            }
        }

        public SpacesPageViewModel(string street)
        {
            CalculateEmptySpaces(street);
            MyCommand = new Command(ReduceEmptySpaces, () => IsEnabled);

            if (EmptySpaces == 0)
                IsEnabled = false;
            else if (EmptySpaces > 0)
                IsEnabled = true;
        }

        private void CalculateEmptySpaces(string street)
        {
            var result = LocationsDb.Locations
                .Where(x => x.street == street)
                .Select(g => g.emptySpaces)
                .FirstOrDefault();

            EmptySpaces = result;
            CurrentSpaces = result;
        }

        private void ReduceEmptySpaces()
        {
            foreach (var item in LocationsDb.Locations.Where(x => x.emptySpaces == EmptySpaces))
            {
                if (item.emptySpaces > 0)
                {
                    item.emptySpaces--;
                    emptySpaces = item.emptySpaces;
                    IsEnabled = false;
                    break;
                }
            }
        }
    }
}
