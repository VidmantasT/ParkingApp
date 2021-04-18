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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            if (username.Text == null || password.Text == null)
                await DisplayAlert("Alert", "Enter empty fields", "OK");
            else
            {
                User user = new User(username.Text, password.Text);
                UsersDb.Users.Add(user);

                await DisplayAlert("Success", $"User {username.Text} created!", "OK");
                await Navigation.PopToRootAsync();
            }
        }
    }
}