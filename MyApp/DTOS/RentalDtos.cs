using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.DTOS
{
    public class RentalDtos
    {
        public int CustomerID { get; set; }
        public List<int> MovieID { get; set; }
    }
}