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

        public static List<Grocery> Groceries = new List<Grocery> {
            new Grocery{StoreId = 1, Id = 0, GrocName = "Apples", Brand = "Gala", Quantity = 120},
            new Grocery{StoreId = 2, Id = 1, GrocName = "Oranges", Brand = "Florida", Quantity = 43},
            new Grocery{StoreId =3, Id = 2, GrocName = "Grapes", Brand = "GrapeBrand", Quantity = 250},
            new Grocery{StoreId = 2, Id = 3, GrocName = "Lemons", Brand = "LemonAid", Quantity = 200}
        };
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

        public string GrocName { get; set; }

        public string Brand { get; set; }

        public int Quantity { get; set; }


    }
}