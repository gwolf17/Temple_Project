using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temple_Project.Models;

namespace Temple_Project.Controllers
{
    public class HomeController : Controller
    {
        //Connect to context file
        private AppointmentContext context { get; set; }

        //Constructor
        public HomeController(AppointmentContext temp)
        {
            context = temp;
        }

        //Group info page
        [HttpGet]
        public IActionResult GroupInfoForm()
        {
            return View(new Group());  //Return a new Group object when this page is called
        }

        [HttpPost]
        public IActionResult GroupInfoForm(Group group)
        {
            //If the model is valid, add the group and save the changes
            if (ModelState.IsValid)
            {
                context.Add(group);
                context.SaveChanges();

                return View("Index");
            }
            //If not valid, return the GroupInfo page along with the info they already entered so they can see the error messages and correct the errors
            else
            {
                return View("GroupInfoForm", group);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
