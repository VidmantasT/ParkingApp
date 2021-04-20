using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParkingApp.ViewModels
{
    public class LoginToAppPageViewModel : INotifyPropertyChanged
    {
        public bool isRunning = false;
        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                isRunning = value;

                OnPropertyChanged();

                login.ChangeCanExecute();
            }
        }

        public string username = "";
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
            }
        }

        public string password = "";
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }

        public Command login { get; }
        public LoginToAppPageViewModel()
        {
            login = new Command(async () => await Login(this.username, this.password), () => !IsRunning);
        }

        public async Task Login(string _username, string _password)
        {
            bool loggedIn = false;

            if (_username == "" || _password == "")
                await Application.Current.MainPage.DisplayAlert("Alert!", "Enter empty fields!", "OK");
            else
            {
                foreach (var item in UsersDb.Users)
                {
                    if (item.GetUsername() == _username && item.GetPassword() == _password)
                    {
                        loggedIn = true;

                        IsRunning = true;
                        OnPropertyChanged(nameof(IsRunning));

                        await Task.Delay(4000);

                        IsRunning = false;
                        OnPropertyChanged(nameof(IsRunning));

                        await Application.Current.MainPage.DisplayAlert("Success!", $"Hi, {_username}!", "OK");
                        await Application.Current.MainPage.Navigation.PushModalAsync(new Tabbed(), true);
                    }
                }

                if (!loggedIn)
                {
                    IsRunning = true;
                    OnPropertyChanged(nameof(IsRunning));

                    await Task.Delay(4000);

                    IsRunning = false;
                    OnPropertyChanged(nameof(IsRunning));

                    await Application.Current.MainPage.DisplayAlert("Alert!", "Invalid Credentials", "OK");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
