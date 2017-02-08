using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsLeague.Models;



namespace SportsLeague.Controllers
{
    public class TeamsController : Controller
    {
        // GET: /<controller>/
        private SportsLeagueContext db = new SportsLeagueContext();
        public IActionResult Index()
        {
            return View(db.Teams.Include(teams => teams.Division).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisTeam = db.Teams.Include(teams =>teams.Players)
                .Include(teams => teams.Division)
                .FirstOrDefault(teams => teams.TeamId == id);
            return View(thisTeam);
        }


        public IActionResult Edit(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name");
            return View(thisTeam);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            return View(thisTeam);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            db.Teams.Remove(thisTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
