using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CheeseId { get; set; } // Note: NAMING CONVENTION: within a class we will use
                                          // the property name that is the class name followed by "Id"
        private static int nextId = 1;


        // use this class to represent basic piece of data within the controller and elsewhere in the app without having
        // to store these as raw strings

        // need a constructor to create a new cheese class
        // this constructor will ensure that every cheese object has a unique id
        public Cheese()
        {
            CheeseId = nextId; // set cheeseid equal to next available integer
            nextId++; //increment id for the next person
        }
    }
}
