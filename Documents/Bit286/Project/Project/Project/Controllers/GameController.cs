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
            ViewBag.backgroundImage = "Game2StartPage1.png";
            ViewBag.e = "display: none";
            ViewBag.f = "display:inline";
            ViewBag.question = "";
            ViewBag.ans1 = "no";
            ViewBag.correct = "START";
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
            ViewBag.backgroundImage = "Game2Background.jpg";
            ViewBag.e = "display: inline";
            ViewBag.f = "display: inline";
            if (counter == 8)
            {
                ViewBag.e = "display: none";
                ViewBag.f = "display:none";
            }
            ViewBag.showPic = "display:none";


            Random rnd = new Random();

            string[] messages = new string[8];
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
                " to see what Wonder Reggie will travel to next.";

            pictures[0] = "pic1c.jpeg";
            pictures[1] = "pic2b.jpg";
            pictures[2] = "pic9b.jpeg";
            pictures[3] = "pic4b.JPG";
            pictures[4] = "pic3b.jpeg";
            pictures[5] = "pic7b.jpg";
            pictures[6] = "airplane1.gif";

            pictures[7] = "PUG.JPG";

            messages[0] = "Thats right! Great Shot!";
            messages[1] = "Reggie is so cute, isn't he!";
            messages[2] = "You' doing great!";
            messages[3] = "It's getting dark, it might";
            messages[4] = "Reggie has his on! Good job!";
            messages[6] = "Wow, you're really good at this!";
            messages[7] = "be time to put on a jacket.";

            string questionString = null;
            //allows program to delay correct answer shots until game has gone through 2nd post
            if (counter >= 2)
            {
                ViewBag.correctAnswerImage = pictures[counter - 2];
            }

            ViewBag.message2 = "";
            //assign question to view and question string so switchcase can assign answer pool

            ViewBag.question = questions[counter - 1];
            //allows correct pic to be seen and isolates until 3rd run using if statement in view
            ViewBag.counter = counter;
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
                    ViewBag.message = messages[0];
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Triangle";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;


                case "What Shape Has 4 Sides All Equal To Eachother?":
                    ViewBag.message = messages[6];
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.answ = "Triangle";
                    ViewBag.correct = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 5 sides?":
                    ViewBag.message = messages[1];
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Pentagon";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 6 sides?":
                    ViewBag.message = messages[2];
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Hexagon";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 7 sides?":
                    ViewBag.message = messages[3];
                    ViewBag.message2 = messages[7];
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Heptagon";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;

                case "What Shape Has 8 sides?":
                    ViewBag.message = messages[4];
                    ViewBag.ans1 = "Rectangle";
                    ViewBag.correct = "Octagon";
                    ViewBag.answ = "Square";
                    ViewBag.answ3 = "Pentagon";
                    break;
            }
            Session["counter"] = counter++;

            counter++;

            if (counter >= 10)
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
            Session["UserId"] = null;

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

           
            Session["UserId"] = us.UserID;

           db.SaveChanges();

            return RedirectToAction("FirstGameInstruction"); 
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
        public ActionResult FirstGameInstruction()
        {
            return View(); 
        }
        public ActionResult FirstGame()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FirstGame(users m)
        {
            int x = (int)Session["UserId"];

             users student = db.users.SingleOrDefault(l => l.UserID == x);

            student.UserName = "One point";
            db.SaveChanges();
          return RedirectToAction("SecondGame");
            

        }

        [HttpGet]
            public ActionResult ThirdGame()
        {
            int x = (int)Session["UserId"];

            users m = db.users.SingleOrDefault(i => i.UserID == x);

            m.UserName = "Three Points";

            db.SaveChanges();

            return View();
        }
        [HttpPost]
        public ActionResult ThirdGame (users m)
        {
            int x = (int)Session["UserId"];

            users d = db.users.SingleOrDefault(l => l.UserID == x);

            d.UserName = "Three Points";
            db.SaveChanges();

            return RedirectToAction("Index", "users");
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