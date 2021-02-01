using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipesPosts
{
    public partial class App : Application
    {
        //like Eduardo
        public static string DatabaseLocation = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }


        //like eduardo
        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new HomePage());

            DatabaseLocation = databaseLocation;
        }
     

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
