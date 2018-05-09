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

            string[] questions = new string[7];

            questions[0] = "What Shape Has 0 Sides?";
            questions[1] = "What Shape Has 3 Sides?";
            questions[2] = "What Shape Has 4 Sides All Equal To Eachother?";
            questions[3] = "What Shape Has 5 sides?";
            questions[4] = "What Shape Has 6 sides?";
            questions[5] = "What Shape Has 7 sides?";
            questions[6] = "What Shape Has 8 sides?";





            string x = null;

            for (int i = 0; i < questions.Length; i++)
            {
                ViewBag.question = questions[rnd.Next(0, 7)];
                x = ViewBag.question;
            }
               
   
            switch (x)
            {
                case "What Shape Has 0 Sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Circle";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 3 Sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Triangle";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;
                    

                case "What Shape Has 4 Sides All Equal To Eachother?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.answ= "Triangle";
                    ViewBag.correct = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case  "What Shape Has 5 sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Circle";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 6 sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Circle";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 7 sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Circle";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 8 sides?":
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
            return RedirectToAction("SecondGame");
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