using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApp.Models;

namespace MyApp.ViewModel
{
    public class CustomerForm
    {
        public IEnumerable<MemberShipTypes> memberShipTypes { get; set; }
        public Customers customers { get; set; }
    }
}