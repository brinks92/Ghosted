using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base() { }
        
        public DbSet<users> users { get; set; }
    }
}