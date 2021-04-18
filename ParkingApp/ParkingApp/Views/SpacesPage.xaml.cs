﻿using ParkingApp.ViewModels;
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
    public partial class SpacesPage : ContentPage
    {
        public SpacesPage(string street)
        {
            InitializeComponent();

            BindingContext = new SpacesPageViewModel(street);
        }
    }
}