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
        //

        //Group info page
        [HttpGet]
        public IActionResult GroupInfoForm()
        {
            return View(new Group());  //Return a new Group object when this page is called
        }

        [HttpPost]
        public IActionResult GroupInfoForm()
        {
            //Check to see if model state is valid
            if ModelState.IsValid)
            {

            }
        }
    }
}
