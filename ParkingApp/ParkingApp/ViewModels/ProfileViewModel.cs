using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ParkingApp.ViewModels
{
    public class ProfileViewModel
    {
        public Command GoToPage { get; }
        public ProfileViewModel()
        {
            GoToPage = new Command(async() => await SendEmail());
        }

        public async Task SendEmail()
        {
            try
            {
                await Email.ComposeAsync("ParkingApp", "", "vitelksnys@gmail.com");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
