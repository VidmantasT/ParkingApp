using ParkingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginToAppPage : ContentPage
    {
        public LoginToAppPage()
        {
            InitializeComponent();
            BindingContext = new LoginToAppPageViewModel();
        }

        //private async void Login_Clicked(object sender, EventArgs e)
        //{
        //    bool loggedIn = false;

        //    if (usernameText.Text == null || PasswordText == null)
        //        await DisplayAlert("Alert", "Enter empty fields", "OK");
        //    else
        //    {
        //        foreach (var item in UsersDb.Users)
        //        {
        //            if(item.GetUsername() == usernameText.Text && item.GetPassword() == PasswordText.Text)
        //            {
        //                loggedIn = true;
        //                await DisplayAlert("Success", $"Hi, {usernameText.Text}!", "OK");
        //                await Navigation.PushModalAsync(new Tabbed(), true);
        //            }
        //        }

        //        if(!loggedIn)
        //            await DisplayAlert("Alert", "Invalid Credentials", "OK");
        //    }
        //}
    }
}