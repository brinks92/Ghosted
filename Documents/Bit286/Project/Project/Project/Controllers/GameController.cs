using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult FirstGame()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FirstGame(users m)
        {
          return RedirectToAction("Startup");
            //this is your brain

        }

    }
}