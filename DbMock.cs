using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSPA.Persistence
{
    public static class DbMock
    {
        public static List<Store> Stores = new List<Store> {
            new Store{Id = 1, Name = "Walmart"},
            new Store{Id = 2, Name = "Target"},
            new Store{Id = 3, Name = "Publix"}
        };

        public static Grocery[] Groceries = new Grocery[500];

    }

    public partial class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class Grocery
    {
        public int StoreId { get; set; }

        public int Id { get; set; }

        public string GroceryItem { get; set; }

        public string Brand { get; set; }

        public string Link { get; set; }

        public int Quantity { get; set; }

        public string Aisle { get; set; }

        public double Price { get; set; }




    }
}