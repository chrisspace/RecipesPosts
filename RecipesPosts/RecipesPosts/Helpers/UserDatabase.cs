using RecipesPosts.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace RecipesPosts.Helpers
{
    public class UserDatabase
    {
        private SQLiteConnection _SQLiteConnection;

        public UserDatabase()
        {
            _SQLiteConnection = DependencyService.Get<ISQLiteInterface>().GetSQLiteConnection();
            _SQLiteConnection.CreateTable<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return (from u in _SQLiteConnection.Table<User>()
                    select u).ToList();
        }

        public User GetSpecificUser(int id)
        {
            return _SQLiteConnection.Table<User>().FirstOrDefault(t => t.Id == id);
        }

        public void DeleteUser(int id)
        {
            _SQLiteConnection.Delete<User>(id);
        }

        public string AddUser(User user)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.Name == user.Name && x.Username == user.Username).FirstOrDefault();
            if (d1 == null)
            {
                _SQLiteConnection.Insert(user);
                return "Sucessfully Added";
            }
            else
                return "Already Mail id Exist";
        }

        public bool updateUserValidation(int userid)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = (from values in data
                      where values.Id == userid
                      select values).Single();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool updateUser(string username, string pwd)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = (from values in data
                      where values.Name == username
                      select values).Single();
            if (true)
            {
                d1.Password = pwd;
                _SQLiteConnection.Update(d1);
                return true;
            }
            else
                return false;
        }

        public bool LoginValidate(string userName1, string pwd1)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.Name == userName1 && x.Password == pwd1).FirstOrDefault();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }

    }
}