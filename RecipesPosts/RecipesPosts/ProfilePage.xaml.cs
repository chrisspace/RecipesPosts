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
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel profileViewModel;
        public ProfilePage()
        {
            InitializeComponent();

            profileViewModel = new ProfileViewModel();
            BindingContext = profileViewModel;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var postTable = await Post.Read();

            var categoriesCount = Post.PostCategories(postTable);

            categoryListView.ItemsSource = categoriesCount;
            postCountLabel.Text = postTable.Count.ToString();
        }
    }
}