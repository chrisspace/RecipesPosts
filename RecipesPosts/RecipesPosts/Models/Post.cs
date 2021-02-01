using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPosts.Models
{
    public class Post:INotifyPropertyChanged
    {
        private int _id;
        private string _experience;
        private string _description;
        private string _venueName;
        private string _categoryId;
        private string _categoryName;
        private string _address;
        private double _longitude;
        private double _latitude;
        private int _distance;
        private Venue _venue;
        private DateTimeOffset _creationDate;



        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return  _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Experience
        {
            get { return _experience; }
            set 
            {
                _experience = value;
                OnPropertyChanged("Experience");
            }
        }

        [MaxLength(200)]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string VenueName
        {
            get { return _venueName; }
            set 
            { 
                _venueName = value;
                OnPropertyChanged("VenueName");
            }
        }

        public string CategoryId
        {
            get { return _categoryId; }
            set 
            {
                _categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        public double Longitude
        {
            get { return _longitude; }
            set 
            {   
                _longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        public int Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged("Distance");
            }
        }

        public DateTimeOffset CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                OnPropertyChanged("CreationDate");
            }
        }

        [Ignore]
        public Venue Venue
        {
            get { return _venue; }
            set
            {
                _venue = value;

                if (_venue.categories != null)
                {
                    var firstCategory = _venue.categories.FirstOrDefault();

                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;
                    }
                }

                if (_venue.location != null)
                {
                    Address = _venue.location.address;
                    Distance = _venue.location.distance;
                    Latitude = _venue.location.lat;
                    Longitude = _venue.location.lng;
                }
                VenueName = _venue.name;
                //UserId = App.user.Id;

                OnPropertyChanged("Venue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static void Insert(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);

                //if (rows > 0)
                //    await DisplayAlert("Success", "Post inserted succesfully", "Ok");
                //else
                //    await DisplayAlert("Failure", "Post failed to insert", "Ok");
            }
        }


        public static async Task<bool> Delete(Post post)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Delete(post);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }


        public static async Task<List<Post>> Read()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                return posts;
            }            
        }

        public static Dictionary<string,int> PostCategories(List<Post> posts)
        {
            //var categories2 = (from p in postTable
            //                  orderby p.Id
            //                  select p.Experience).Distinct().ToList();

            var categories = posts.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                //one syntax Linq
                //var count2 = (from p in postTable
                //             where p.Experience == category
                //             select p).ToList().Count();


                // pure Linq, preferable
                var count = posts.Where(p => p.CategoryName == category)
                                        .ToList()
                                        .Count();

                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged !=null)
                //PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
