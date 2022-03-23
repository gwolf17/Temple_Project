﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult SignUp(Appointment a)
        {
            Group g = new Group();

            g.Appointment = a;
            
            return View("GroupInfoForm", g);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            DateTime today = DateTime.Now;
            today = Round(today);
            
            List<AppointmentsByDay> allAppointments = new List<AppointmentsByDay>();



            // We can change this to show more hours.
            int numberOfHoursToShow = 500;

            for (int i = 0; i < numberOfHoursToShow; i++)
            {
                if (today.Hour < 20 && today.Hour >=8 )
                {
                    today = today.AddHours(1);
                } else
                {
                    int hour = today.Hour > 20 ? 20 - (today.Hour - 20) : today.Hour;
                    
                    today = today.AddHours(Math.Abs(hour - 8));
                }

                AppointmentsByDay abd = allAppointments.FirstOrDefault(x => x.Date.ToString("dd-MMM-yyyy") == today.ToString("dd-MMM-yyyy"));
                if (abd == null)
                {
                    AppointmentsByDay newAbd = new AppointmentsByDay();
                    newAbd.Day = today.ToString("dddd");
                    newAbd.Index = allAppointments.Count() + 1;
                    newAbd.Date = today;
                    newAbd.Appointments = new List<Appointment>();
                    allAppointments.Add(newAbd);

                    abd = allAppointments.FirstOrDefault(x => x.Date.ToString("dd-MMM-yyyy") == today.ToString("dd-MMM-yyyy"));
                }

                Appointment a = new Appointment();
                a.Date = today;
                a.Time = today.ToString("hh:mm tt");
                a.Available = true;

                abd.Appointments.Add(a);
            }

            return View(allAppointments);
        }

        public IActionResult Appointments()
        {
            var apps = context.Groups
                .Include(x => x.Appointment)
                .ToList();
            return View(apps);
        }

        public static DateTime Round(DateTime dateTime)
        {
            var updated = dateTime.AddMinutes(30);
            return new DateTime(updated.Year, updated.Month, updated.Day,
                                 updated.Hour, 0, 0, dateTime.Kind);
        }
    }
}
