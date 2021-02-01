using RecipesPosts.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPosts.ViewModel
{
    public class HistoryViewModel:BaseViewModel
    {
        public ObservableCollection<Post> Posts { get; set; }

        public HistoryViewModel()
        {
            Posts = new ObservableCollection<Post>();
        }
        public async Task<bool> UpdatePosts()
        {
            try
            {
                var posts = await Post.Read();

                if (posts != null)
                {
                    Posts.Clear();
                    foreach (var post in posts)
                        Posts.Add(post);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
                        
        }

        public async void DeletePost(Post postToDelete)
        {
            await Post.Delete(postToDelete);
        }
    }
}
