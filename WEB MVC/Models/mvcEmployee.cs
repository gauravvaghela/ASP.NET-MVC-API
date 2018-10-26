using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_MVC.Models
{
    public class mvcEmployee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}