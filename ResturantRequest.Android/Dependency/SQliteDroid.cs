using System;
using System.IO;
using Dependency;
using Source.Data.Interface;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQliteDroid))]
namespace Dependency
{
    public class SQliteDroid: Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "ResturantDatabase";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }
    }
}
