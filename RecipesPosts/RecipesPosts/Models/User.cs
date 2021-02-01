using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPosts.Models
{
    public class User: INotifyPropertyChanged
    {
        private int _id;
        private string _email;
        private string _username;
        private string _name;
        private string _password;
        private string _phone;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        [MaxLength(12)]
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        [MaxLength(10)]
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public User()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        //public static async Task<bool> Login(string email, string password)
        //{
        //    bool isemailempty = string.IsNullOrEmpty(email);
        //    bool ispasswordempty = string.IsNullOrEmpty(password);

        //    if (isemailempty || ispasswordempty)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        //return true;
        //    }
        //}

        public static void Register(User user)
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
