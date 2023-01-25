using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MyApp.Models;

namespace MyApp.Models
{
    public class Customers
    {
        public int ID { get; set; }
        [Display(Name ="Customer Name")]
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MemberShipTypes MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }
        [Min18years]
        [Display(Name ="Date of Birth")]
        public DateTime? Birthdate { get; set; }

    }
}