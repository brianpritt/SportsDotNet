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
    public class PlayerController : Controller
    {
        // GET: /<controller>/
        private SportsLeagueContext db = new SportsLeagueContext();
        public IActionResult Index()
        {
            return View(db.Players.Include(players => players.Team).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player team)
        {
            db.Players.Add(team);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            return View(thisPlayer);
        }


        public IActionResult Edit(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            return View(thisPlayer);
        }

        [HttpPost]
        public IActionResult Edit(Player team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            return View(thisPlayer);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            db.Players.Remove(thisPlayer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

