using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //add this line to access data
namespace Learning_collection.Models
{
    public class LoginContext : DbContext //need to add connectionstring in Web.config
    {
        public DbSet<Logindata> data { get; set; }//this line will get students info
        //from database table named Students

    }
}