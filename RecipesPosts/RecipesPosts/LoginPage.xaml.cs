using RecipesPosts.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipesPosts
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();

            viewModel = new LoginViewModel();
            BindingContext = viewModel;

            var assembly = typeof(LoginPage);

            iconImage.Source= ImageSource.FromResource("RecipesPosts.Assets.Images.athensPhoto.jpg", assembly);
        }

        

        public static Action EmulateBackPressed;
        private bool AcceptBack;

        protected override bool OnBackButtonPressed()
        {
            if (AcceptBack)
                return false;

            PromptForExit();
            return true;
        }
        private async void PromptForExit()
        {
            if (await DisplayAlert("", "Are you sure to exit?", "Yes", "No"))
            {
                AcceptBack = true;
                EmulateBackPressed();
            }
        }


        //private void RegisterButton_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new RegisterPage());
        //}

        //private async void GoToIndicator_Clicked(object sender, EventArgs e)
        //{
        //    // show the loading page...
        //    activityIndicator.IsRunning = true;
        //    DependencyService.Get<ILoadingPageService>().InitLoadingPage(new TsekForIndic());

        //    //DependencyService.Get<ILoadingPageService>().ShowLoadingPage();

        //    // just to showcase a delay...
        //    await Task.Delay(5000);
        //    // navigate to next page...
        //    //DependencyService.Get<ILoadingPageService>().HideLoadingPage();
        //    activityIndicator.IsRunning = false;
        //    await Navigation.PushAsync(new TsekForIndic());
        //}

        //private async void buttonOpenNextPage_OnClicked(object sender, EventArgs e)
        //{
        //    // show the loading page...
        //    DependencyService.Get<ILoadingPageService>().InitLoadingPage(new LoginPage());
        //    DependencyService.Get<ILoadingPageService>().ShowLoadingPage();
        //    // just to showcase a delay...
        //    await Task.Delay(2000);
        //    // navigate to next page...
        //    DependencyService.Get<ILoadingPageService>().HideLoadingPage();
        //    await Navigation.PushAsync(new HomePage());
        //}
    }
}
