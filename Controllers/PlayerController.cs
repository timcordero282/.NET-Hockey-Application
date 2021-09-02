using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HockeyProject.Models;

namespace HockeyProject.Controllers
{
    public class PlayerController : Controller
    {
        private TeamContext context { get; set; }

        public PlayerController(TeamContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var players = context.Players.OrderByDescending(p => p.Goals).ToList();
            return View(players);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Player()); // default Player
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var pla = context.Players.Find(id);
            return View(pla);
        }

        [HttpPost]
        public IActionResult Edit(Player pla)
        {
            if (ModelState.IsValid)
            {
                if (pla.PlayerID == 0)
                { // adding
                    context.Players.Add(pla);
                }
                else
                {  // updating
                    context.Players.Update(pla);
                }
                context.SaveChanges(); // change DB
                return RedirectToAction("Index", "Player");  // put up list view
            }
            else
            {  // user error
                ViewBag.Action = (pla.PlayerID == 0) ? "Add" : "Edit";
                return View(pla); ;
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pla = context.Players.Find(id); // find player to be deleted
            return View(pla);
        }

        [HttpPost]
        public IActionResult Delete(Player pla)
        {
            context.Players.Remove(pla);
            context.SaveChanges();
            return RedirectToAction("Index", "Player"); // display list of players
        }
    }
}
