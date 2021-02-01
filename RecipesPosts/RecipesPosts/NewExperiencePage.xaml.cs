using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RecipesPosts.Models;
using RecipesPosts.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipesPosts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExperiencePage : ContentPage
    {
        NewExperienceViewModel viewModel;
        public NewExperiencePage()
        {
            InitializeComponent();
            //progressBar.IsVisible = true;
            //progressBar.IsRunning = true;

            //eduardo gia mvvm
            viewModel = new NewExperienceViewModel();
            BindingContext = viewModel;
        }

        
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if(status != PermissionStatus.Granted)
                {
                    if(await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need permission", "We will have to access your location", "ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];

                }


                if(status == PermissionStatus.Granted)
                {
                    var locator = CrossGeolocator.Current;
                    var position = await locator.GetPositionAsync();

                    var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
                    venueListView.ItemsSource = venues;

                    var timeNow = DateTime.Now;
                    ora.Text = timeNow.ToString();
                }
                
            }
            catch(Exception)
            {

            }

            
        }

    }
}