using MyApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.DTOS
{
    public class CustomerDtos
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MemberShipTypeId { get; set; }
        [Min18years]
        public DateTime? Birthdate { get; set; }
        public MemberShipTypeDtos MemberShipType { get; set; }
    }
}