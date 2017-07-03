using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning_collection.Models
{
    public class Package
    {
        public List<int> Id { get; set; }

        public List<string> Firstname { get; set; }

        public List<string> Lastname { get; set; }

        public List<string> Email { get; set; }
    }
}