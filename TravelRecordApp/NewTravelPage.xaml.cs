using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using SQLite;

using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
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
