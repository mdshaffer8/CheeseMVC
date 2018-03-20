using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using System.Linq;
using CheeseMVC.Data;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        // make private field to use throughout class
        // will be able to reference context and use to interface with database
        private CheeseDbContext context;

        // make a constructor that takes an instance of the CheeseDbContext
        // within constructor, set private field to be equal to the dbContext that was passed in
        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        // what is happening? the framework will create a CheeseController for us
        // we are customizing the way the controller is created by providing a constructor
        // and ask for that constructor to receive an instance of CheeseDbContext
        // we are keeping a handle on it by putting it the private field and use the private field
        // throughout the controller. (now we have a way to use it)

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = context.Cheeses.ToList();
            //Cheeses property is a DbSet that holds on to Cheese objects and it has a
            //ToList method we are using to turn that set into a list

            return View(cheeses); // view receives the list
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost] // Add action that processes the form that will create a new cheese object
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                };

                context.Cheeses.Add(newCheese); // creating a new cheese object and storing that in the cheese data
                // this will add the new cheese to the dbset that is cheeses
                context.SaveChanges(); // save changes after modifying data

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove() //rendering remove form
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList(); //passing in a list of all the cheeses
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds) // when the form is submitted, receiving from the view an array of integers called cheeseIds
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId); //retrieve the cheese you want to remove from dbcontext
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }
    }
}
