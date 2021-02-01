using RecipesPosts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RecipesPosts.ViewModel.Commands
{
    public class PostCommand : ICommand
    {
        NewExperienceViewModel viewModel;

        public PostCommand(NewExperienceViewModel vm)
        {
            this.viewModel = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var post = (Post)parameter;

            if(post!= null)
            {
                if (string.IsNullOrEmpty(post.Experience))
                    return false;
                if (post.Venue != null)
                    return true;

                return false;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var post = (Post)parameter;
            viewModel.PublishPost(post);
        }
    }
}
