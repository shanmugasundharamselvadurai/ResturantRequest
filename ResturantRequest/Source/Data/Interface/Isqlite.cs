using System;
using SQLite;

namespace Source.Data.Interface
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
