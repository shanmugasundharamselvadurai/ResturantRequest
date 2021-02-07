using System;
using SQLite;

namespace Source.Data.Models
{
    public class ResturantModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
