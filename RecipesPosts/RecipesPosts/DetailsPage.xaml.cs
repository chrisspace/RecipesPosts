using RecipesPosts.Models;
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
    public partial class DetailsPage : ContentPage
    {
        readonly Post selectedPost;
        public DetailsPage(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            nameEntryUpdate.Text = selectedPost.Experience;
            descriptionEntryUpdate.Text = selectedPost.Description;
        }


        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntryUpdate.Text) && !string.IsNullOrWhiteSpace(descriptionEntryUpdate.Text))
            {
                selectedPost.Experience = nameEntryUpdate.Text;
                selectedPost.Description = descriptionEntryUpdate.Text;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Update(selectedPost);

                    if (rows > 0)
                        await DisplayAlert("Success", "Post updated succesfully", "Ok");
                    else
                        await DisplayAlert("Failure", "Post failed to update", "Ok");
                }

                await Navigation.PushAsync(new HomePage());
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                    await DisplayAlert("Success", "Post deleted succesfully", "Ok");
                else
                    await DisplayAlert("Failure", "Post failed to delete", "Ok");
            }

            await Navigation.PushAsync(new HomePage());
        }
    }
}