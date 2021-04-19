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
        public bool isEnabled { get; set; }
        public Command sendEmail { get; }
        public ProfileViewModel()
        {
            sendEmail = new Command(async() => await SendEmail());
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
