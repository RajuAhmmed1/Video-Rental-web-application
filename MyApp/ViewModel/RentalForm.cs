using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApp.Models;

namespace MyApp.ViewModel
{
    public class RentalForm
    {
        public Rental rental { get; set; }
        public IEnumerable<Customers> Customers { get; set; }
        public IEnumerable<Movies> Movies { get; set; }
    }
}