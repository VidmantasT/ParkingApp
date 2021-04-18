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
    public partial class StreetPage : ContentPage
    {
        public StreetPage(string city)
        {
            InitializeComponent();

            BindingContext = new StreetPageViewModel(city);
        }

        private async void StreetListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Location;
            await Navigation.PushAsync(new SpacesPage(item.street), true);
        }
    }
}