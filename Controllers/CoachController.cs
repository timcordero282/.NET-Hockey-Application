using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HockeyProject.Models;

namespace HockeyProject.Controllers
{
    public class CoachController : Controller
    {
        private TeamContext context { get; set; }

        public CoachController(TeamContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var coaches = context.Coaches.OrderByDescending(c => c.CareerWins).ToList();
            return View(coaches);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Coach()); // default coach
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var coa = context.Coaches.Find(id);
            return View(coa);
        }

        [HttpPost]
        public IActionResult Edit(Coach coa)
        {
            if (ModelState.IsValid)
            {
                if (coa.CoachID == 0)
                { // adding
                    context.Coaches.Add(coa);
                }
                else
                {  // updating
                    context.Coaches.Update(coa);
                }
                context.SaveChanges(); // change DB
                return RedirectToAction("Index", "Coach");  // put up list view
            }
            else
            {  // user error
                ViewBag.Action = (coa.CoachID == 0) ? "Add" : "Edit";
                return View(coa); ;
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var coa = context.Coaches.Find(id); // find coach to be deleted
            return View(coa);
        }

        [HttpPost]
        public IActionResult Delete(Coach coa)
        {
            context.Coaches.Remove(coa);
            context.SaveChanges();
            return RedirectToAction("Index", "Coach"); // display list of coaches
        }
    }
}
