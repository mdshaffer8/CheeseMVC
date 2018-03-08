using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {
            // Add the new cheese to my existing cheeses
            CheeseData.Add(newCheese);
                     
            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll(); // pass in the list of cheeses
            return View(); //display remove cheese form
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds) //when form is submitted the ids of the checkboxes that they checked
                                                     //will be sent to the server in cheeseIds - the action will receive integer array
                                                     //so when this is posted, the framework will populate this parameter with the integers
                                                     //corresponding to the checkboxes that the user selected
        {
            
            foreach (int cheeseId in cheeseIds)
                //loop over integer ids of cheeses that we want to delete
            {
                CheeseData.Remove(cheeseId);
                //Cheeses.RemoveAll(x => x.CheeseId == cheeseId);
                //for each one we match all items "x" in the cheeses list where the cheeseid of the item is equal to the cheeseid
                //of the item that we are considering within our loop iteration
            }
            
            return Redirect("/");
        }
    }
}
