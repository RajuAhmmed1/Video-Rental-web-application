using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyApp.Models;


namespace MyApp.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Display(Name ="Customer")]
        [Required]
        public string CustomerID { get; set; }
        [Display(Name ="Movies")]
        [Required]
        public string MovieID { get; set; }
       
    }
}