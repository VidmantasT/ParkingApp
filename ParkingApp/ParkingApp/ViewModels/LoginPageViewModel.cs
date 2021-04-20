using ParkingApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ParkingApp.ViewModels
{
    public class LoginPageViewModel
    {
        public Command login { get; }
        public Command signUp { get; }
        public LoginPageViewModel()
        {
            login = new Command(async () => await Login());
            signUp = new Command(async () => await SignUp());
        }

        public async Task Login()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginToAppPage());
        }

        public async Task SignUp()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }
    }
}
