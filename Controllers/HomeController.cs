using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HockeyProject.Models;

namespace HockeyProject.Controllers
{
    public class HomeController : Controller
    {
        
        private TeamContext context { get; set; }
        public HomeController(TeamContext ctx)
        {
            context = ctx;
        }

        
        public IActionResult Index()
        {
            var teams = context.Teams.Include(t => t.PlayerName).OrderBy(t => t.Conference).ToList();
            teams = context.Teams.Include(t => t.CoachName).ToList();
            return View(teams);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
