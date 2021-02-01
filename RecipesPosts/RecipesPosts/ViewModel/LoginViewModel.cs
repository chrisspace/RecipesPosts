using RecipesPosts.Models;
using RecipesPosts.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RecipesPosts.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {

        private User _user;
        private string _email;
        private string _password;

        public Venue Venue;

        public LoginCommand LoginCommand { get; set; }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }


        public LoginViewModel()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
        }

        public async void Login()
        {
            bool isEmailEmpty = string.IsNullOrEmpty(User.Email);
            bool isPasswordEmpty = string.IsNullOrEmpty(User.Password);

            if (isEmailEmpty || isPasswordEmpty)
            {
                await App.Current.MainPage.DisplayAlert("Problem", "Please insert your credentials", "ok");
            }
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
        }
    }
}
