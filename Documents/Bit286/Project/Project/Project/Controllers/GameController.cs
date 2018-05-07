using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    public class GameController : Controller
    {
        private MyDbContext db = new MyDbContext();


        public ActionResult SecondGame()
        {
            Random rnd = new Random();

            string[] q = new string[3];

            q[0] = "What has 3 sides?";

            q[1] = "what has 4 sides all equal to eachother?";

            q[2] = "What has zero sides?";



            string x = null;

            for (int i = 0; i < q.Length; i++)
            {
                ViewBag.question = q[rnd.Next(0, 3)];
                x = ViewBag.question;
            }
               
   
            switch (x)
            {
                case "What has 3 sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Triangle";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;
                    

                case "what has 4 sides all equal to eachother?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.answ= "Triangle";
                    ViewBag.correct = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What has zero sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Circle";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;
            }    
            
            return View(); 
        }

        [HttpPost]
        public ActionResult SecondGame(SecondGameViewModel vm)
        {
            return RedirectToAction("Welcome");
        }

        public ActionResult Welcome()
        {
           WelcomeViewModel vm = new WelcomeViewModel();

            vm.kids = new List<users>();

            int times = db.users.Max(m => m.UserID);

            for (int i = 0; i <= times; i++)
            {
                users first = db.users.SingleOrDefault(m => m.UserID == i);

                if (first != null)
                {
                        vm.kids.Add(first);
                }
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Welcome(WelcomeViewModel vm)
        {
            int num = vm.Choice;

            users us = db.users.SingleOrDefault(m => m.UserID == num);

            us.UserName = vm.UserName;

            db.SaveChanges();

            return RedirectToAction("FirstGame"); 
        }

        public ActionResult StudentStart()
        {
            return View();
        
        }

        [HttpPost]
        public ActionResult StudentStart( users m)
        {
            return RedirectToAction("Welcome");
        }
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

        private users GetTempUser()
        {
            if (Session["tempUser"] == null)
            {
                Session["tempUser"] = new users();
            }
            return (users)Session["tempUser"];
        }

        private void FlushTempUser()
        {
            Session.Remove("tempUser");
        }
    }
}