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
            // display for picture and success message if answer is answered correctly set to not show in view

            ViewBag.e = "display: none";
            ViewBag.f = "display:inline";
            ViewBag.question = "are you ready";
            ViewBag.ans1 = "no";
            ViewBag.correct = "yes";
            ViewBag.answ = "no";
            ViewBag.answ3 = "no";

            ViewBag.seen = "visibility: hidden";
            ViewBag.showPic = "display: none";
            Session["counter"] = 0;

            return View(); 
        }
      

        [HttpPost]
        public ActionResult SecondGame(SecondGameViewModel vm)
        {
           

            int counter = (int)Session["counter"];

            Session["counter"] = counter++;
            ViewBag.e = "display: inline";
            ViewBag.f = "display: inline";
            if (counter == 7)
            {
                ViewBag.e = "display: none";
                ViewBag.f = "display:none";
            }
            ViewBag.showPic = "display:none";
            ViewBag.message = "Lets DO THIS!";
          
            Random rnd = new Random();

            string[] questions = new string[8];
            string[] pictures = new string[8];

            questions[0] = "What Shape Has 0 Sides?";
            questions[1] = "What Shape Has 3 Sides?";
            questions[2] = "What Shape Has 4 Sides All Equal To Eachother?";
            questions[3] = "What Shape Has 5 sides?";
            questions[4] = "What Shape Has 6 sides?";
            questions[5] = "What Shape Has 7 sides?";
            questions[6] = "What Shape Has 8 sides?";
            questions[7] = "You did it! Now Reggie has some great pics to remember the Parthenon. Press the next level button" +
                " to go see another Wonder Of The World";

            //pictures[0] =  ;
            //pictures[1] =  ;
            //pictures[2] =  ;
            //pictures[3] =  ;
            //pictures[4] =  ;
            //pictures[5] =  ;
            //pictures[6] =  ;
            //pictures[7] =  ;
            string questionString = null;
            //assign question to view and question string so switchcase can assign answer pool
            
                ViewBag.question = questions[counter];

                questionString = ViewBag.question;
            

            // switch case checks questionString to determine answers pool to add to view
            switch (questionString)
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
                    ViewBag.answ = "Triangle";
                    ViewBag.correct = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 5 sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Pentagon";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 6 sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Hexagon";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 7 sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Heptagon";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 8 sides?":
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Octagon";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;
            }
            Session["counter"] = counter++;

            counter++;

            if(counter>= 9)
            {
                ViewBag.showPic = "display:inline";
                ViewBag.seen = "visibility: visible";
            }
            else
            {
                ViewBag.seen = "visibility: hidden";
            }


            return View();
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