using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Source.Data.Models;
using SQLite;

namespace Source.Data.Helper
{
    public class ResturantDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ResturantDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ResturantModel>().Wait();
        }

        public Task<List<ResturantModel>> GetPeopleAsync()
        {
            return _database.Table<ResturantModel>().ToListAsync();
        }

        public Task<int> SavePersonAsync(ResturantModel person)
        {
            return _database.InsertAsync(person);
        }
    }
}
