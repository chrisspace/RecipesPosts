using RecipesPosts.Models;
using RecipesPosts.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RecipesPosts.ViewModel
{
    public class NewExperienceViewModel: BaseViewModel
    {
        private Post _post;
        private string _experience;
        private string _description;
        private Venue _venue;
        private DateTimeOffset _creatinoDate;
        

        public NewExperienceViewModel()
        {
            PostCommand = new PostCommand(this);
            Post = new Post();
            Venue = new Venue();
        }

        public PostCommand PostCommand { get; set; }
        public Post Post
        {
            get { return _post; }
            set
            {
                _post = value;
                OnPropertyChanged("Post");
            }
        }

        public string Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;

                Post = new Post
                {
                    Experience = this.Experience,
                    Description = this.Description,
                    Venue = this.Venue
                };
                OnPropertyChanged("Experience");
            }
        }

        public Venue Venue
        {
            get { return _venue; }
            set
            {
                _venue = value;
                Post = new Post
                {
                    Experience=this.Experience,
                    Description = this.Description,
                    Venue =this.Venue
                };

                OnPropertyChanged("Venue");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                Post = new Post
                {
                    Experience = this.Experience,
                    Description = this.Description,
                    Venue = this.Venue
                };
            }
        }

        //public DateTimeOffset CreationDate
        //{
        //    get { return _creatinoDate; }
        //    set
        //    {
        //        _creatinoDate = value;
        //        Post = new Post
        //        {
        //            Experience = this.Experience,
        //            Description = this.Description,
        //            Venue = this.Venue,
        //            CreationDate = DateTimeOffset.Now
        //        };
        //    }

        //}
  
        public async void PublishPost(Post post)
        {
            try
            {
                Post.Insert(post);
                await App.Current.MainPage.DisplayAlert("Success", "Experience successfully inserted", "Ok");
            }

            catch (NullReferenceException)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted", "ok");
            }

            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Failure", "Experience failed to be inserted", "ok");

            }

            await App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }
    }
}
