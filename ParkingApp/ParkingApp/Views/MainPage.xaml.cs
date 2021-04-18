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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }

        private async void CitiesListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Location;
            await Navigation.PushAsync(new StreetPage(item.city), true);
        }
    }
}