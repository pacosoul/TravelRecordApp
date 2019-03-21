using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using SQLite;

using Xamarin.Forms;
using Plugin.Geolocator;
using TravelRecordApp.Logic;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            Console.Write(venues);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int Rows = conn.Insert(post);

                if (Rows > 0)
                    DisplayAlert("Success", "Experience succesful inserted!", "Ok");
                else
                    DisplayAlert("Failiure", "Experiencefailed to be inserted!", "Ok");
            }
        }
    }
}
