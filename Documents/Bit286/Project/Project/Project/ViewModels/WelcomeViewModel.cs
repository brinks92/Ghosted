using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.ViewModels
{
    public class WelcomeViewModel
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public int Choice { get; set; }

        public List<users> kids { get; set; }
    }
}