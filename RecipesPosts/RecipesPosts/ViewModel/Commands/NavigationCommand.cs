using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RecipesPosts.ViewModel.Commands
{
    public class NavigationCommand : ICommand
    {
        public HomeViewModel HomeViewModel { get; set; }
        public NavigationCommand(HomeViewModel vm)
        {
            this.HomeViewModel = vm;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeViewModel.Navigate();
        }
    }
}
