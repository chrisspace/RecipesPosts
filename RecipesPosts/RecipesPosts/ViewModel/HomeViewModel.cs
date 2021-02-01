using RecipesPosts.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesPosts.ViewModel
{
    public class HomeViewModel
    {
        public NavigationCommand NavCommand { get; set; }
        public HomeViewModel()
        {
            NavCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewExperiencePage());
        }
    }
}
