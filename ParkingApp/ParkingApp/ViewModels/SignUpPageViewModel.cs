using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParkingApp.ViewModels
{
    public class SignUpPageViewModel: INotifyPropertyChanged
    {
        public bool isRunning = false;
        public bool IsRunning 
        { 
            get { return isRunning; } 
            set
            {
                isRunning = value;

                OnPropertyChanged();

                signUp.ChangeCanExecute();
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

        public Command signUp { get; }
        public SignUpPageViewModel()
        {
            signUp = new Command(async () => await SignUp(this.username, this.password), () => !IsRunning);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async Task SignUp(string _username, string _password)
        {
            if(_username == "" || _password == "")
                await Application.Current.MainPage.DisplayAlert("Alert!", "Enter empty fields!", "OK");
            else
            {
                UsersDb.Users.Add(new User(_username, _password));

                IsRunning = true;
                OnPropertyChanged(nameof(IsRunning));

                await Task.Delay(4000);

                IsRunning = false;
                OnPropertyChanged(nameof(IsRunning));

                await Application.Current.MainPage.DisplayAlert("Success!", $"User {_username} created!", "OK");

                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }

        }
    }
}
