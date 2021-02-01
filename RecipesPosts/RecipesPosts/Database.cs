using RecipesPosts.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RecipesPosts
{   //works with tasks!!
    //public class Database
    //{
    //    readonly SQLiteAsyncConnection _database;
        
    //    public Database(string dbPath)
    //    {
    //        _database = new SQLiteAsyncConnection(dbPath);
    //        _database.CreateTableAsync<Post>().Wait();
    //    }

    //    public Task<List<Post>> GetPostsAsync()
    //    {
    //        return _database.Table<Post>().ToListAsync();
    //    }

    //    public Task<int> SavePostAsync(Post post)
    //    {
    //        return _database.InsertAsync(post);
    //    }

    //    public Task<int> UpdatePostAsync(Post post)
    //    {
    //        return _database.UpdateAsync(post);
    //    }

    //    public Task<int> DeletePostAsync(Post post)
    //    {
    //        return _database.DeleteAsync(post);
    //    }
    //}
}
