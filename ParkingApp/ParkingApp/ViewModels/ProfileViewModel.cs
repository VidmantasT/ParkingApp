using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ParkingApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public bool isRunning = false;
        public bool IsRunning
        {
            get { return isRunning; }
            set 
            {
                isRunning = value;
            }
        }

        public bool isToggled = false;
        public bool IsToggled
        {
            get { return isToggled; }
            set
            {
                isToggled = value;
                IsEnabled = value;
            }
        }

        public string brand = "";
        public string Brand
        {
            get { return brand; }
            set 
            { 
                brand = value;
            }
        }

        public string licencePlate = "";
        public string LicencePlate
        {
            get { return licencePlate; }
            set 
            { 
                licencePlate = value;
            }
        }

        public bool isEnabled = false;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;

                OnPropertyChanged();
            }
        }

        public string DisplayBrand
        {
            get { return brand; }
        }

        public string DisplayLicencePlate
        {
            get { return licencePlate; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Command sendEmail { get; }
        public Command saveCar { get; }

        public ProfileViewModel()
        {
            sendEmail = new Command(async() => await SendEmail());
            saveCar = new Command(async () => await SaveCar(this.brand, this.licencePlate));
        }

        public async Task SaveCar(string brand, string licencePlate)
        {
            if (this.brand == "" || this.licencePlate == "")
                await Application.Current.MainPage.DisplayAlert("Alert", "Enter empty fields!", "OK");
            else
            {
                Brand = brand;
                LicencePlate = licencePlate;

                IsRunning = true;
                OnPropertyChanged(nameof(IsRunning));

                await Task.Delay(4000);

                IsRunning = false;
                OnPropertyChanged(nameof(IsRunning));

                OnPropertyChanged(nameof(DisplayBrand));
                OnPropertyChanged(nameof(DisplayLicencePlate));

                IsToggled = false;
                OnPropertyChanged(nameof(IsToggled));
            }
        }

        public async Task SendEmail()
        {
            try
            {
                await Email.ComposeAsync("ParkingApp", "", "vitelksnys@gmail.com");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", $"{ex}", "OK");
            }
        }
    }
}
