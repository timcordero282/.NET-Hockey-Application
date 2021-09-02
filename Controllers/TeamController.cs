using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HockeyProject.Models;

namespace HockeyProject.Controllers
{
    public class TeamController : Controller
    {
        private TeamContext context { get; set; }

        public TeamController(TeamContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Players = context.Players.OrderByDescending(p => p.PlayerName).ToList();
            ViewBag.Coaches = context.Coaches.OrderByDescending(c => c.CoachName).ToList();
            return View("Edit", new Team()); // default team
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Players = context.Players.OrderByDescending(p => p.PlayerName).ToList();
            ViewBag.Coaches = context.Coaches.OrderByDescending(c => c.CoachName).ToList();
            var team = context.Teams.Find(id);
            return View(team);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                if (team.TeamID == 0)
                { // adding
                    context.Teams.Add(team);
                }
                else
                {  // updating
                    context.Teams.Update(team);
                }
                context.SaveChanges(); // change DB
                return RedirectToAction("Index", "Home");  // put up list view
            }
            else
            {  // user error
                ViewBag.Action = (team.TeamID == 0) ? "Add" : "Edit";
                ViewBag.Players = context.Players.OrderByDescending(p => p.PlayerName).ToList();
                ViewBag.Coaches = context.Coaches.OrderByDescending(c => c.CoachName).ToList();
                return View(team);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var team = context.Teams.Find(id); // find team to be deleted
            return View(team);
        }

        [HttpPost]
        public IActionResult Delete(Team team)
        {
            context.Teams.Remove(team);
            context.SaveChanges();
            return RedirectToAction("Index", "Home"); // display list of teams
        }
    }
}
