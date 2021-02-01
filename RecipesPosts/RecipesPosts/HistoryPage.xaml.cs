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
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;

        public HistoryPage()
        {
            InitializeComponent();

            viewModel = new HistoryViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListView.SelectedItem as Post;

            if (selectedPost != null)
            {
                await Navigation.PushAsync(new DetailsPage(selectedPost));
            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var post = (Post)((MenuItem)sender).CommandParameter;
            viewModel.DeletePost(post);

            await viewModel.UpdatePosts();
        }

        private async void postListView_Refreshing(object sender, EventArgs e)
        {
            await viewModel.UpdatePosts();
            postListView.IsRefreshing = false;
        }

        //private void postListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var selectedPost = postListView.SelectedItem as Post;

        //    if(selectedPost!= null)
        //    {
        //        Navigation.PushAsync(new DetailsPage(selectedPost));
        //    }
        //}


    }
}