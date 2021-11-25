using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Customer
    {
        public int id { get; set; }

        public string code { get; set; }

        public string name { get; set; }
    }
}
