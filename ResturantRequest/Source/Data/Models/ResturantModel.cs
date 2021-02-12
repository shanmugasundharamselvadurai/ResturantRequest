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
        public string price { get; set; }


    }

    public class ResturantCategory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Category { get; set; }
        public string TotalCount { get; set; }
    }

    //public class ResturantListofProduct
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int ID { get; set; }
    //    public string ProductName { get; set; }
    //    public string Type { get; set; }
    //    public string Image { get; set; }
    //    public string Description { get; set; }
    //    public string Category { get; set; }
    //    public string price { get; set; }
    //}

    public class SaveProduct
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string price { get; set; }
    }

    public class SelectedCategoryProducted
    {
        public string ProductName { get; set; }
        public string Category { get; set; }
    }
}
