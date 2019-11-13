using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }

    }
}