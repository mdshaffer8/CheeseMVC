using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        static private List<Cheese> cheeses = new List<Cheese>(); //private class members and local variables start with lowercase

        // GetAll
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        // Add
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        // Remove
        public static void Remove(int id)
        {
            Cheese cheeseToRemove = GetById(id);
            cheeses.Remove(cheeseToRemove);
        }

        // GetById
        public static Cheese GetById(int id)
        {
            return cheeses.Single(x => x.CheeseId == id);
            // link syntax - from our cheeses list, find a single element. it will be determined by the rule x
            // where x.cheeseid equals the id that is passed
            // the single method will query the given list for a single item where the cheese id equals the id 
        }
    }
}
