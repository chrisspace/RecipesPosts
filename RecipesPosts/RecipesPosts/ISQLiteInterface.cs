using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesPosts
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
