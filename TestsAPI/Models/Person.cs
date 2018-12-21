using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestsAPI.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Interests { get; set; }
    }
}