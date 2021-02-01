using RecipesPosts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RecipesPosts.ViewModel
{
    public class ProfileViewModel:BaseViewModel
    {
        public ICommand ReadPostCategories { get; }

        public ProfileViewModel()
        {
            ReadPostCategories = new Command(OnReadingPostCategories);
        }

        public async void OnReadingPostCategories()
        {
            //var postTable = await Post.Read();

            //var categoriesCount = Post.PostCategories(postTable);

            //categoryListView.ItemsSource = categoriesCount;
            //postCountLabel.Text = postTable.Count.ToString();
        }

    }
}
