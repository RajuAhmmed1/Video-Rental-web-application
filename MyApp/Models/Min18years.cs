using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class Min18years:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            if (customer.MemberShipTypeId == 1)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birth Date is Required");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >=18) ? ValidationResult.Success : new ValidationResult("Customer Should be at least 18 Years Old ");

        }
    }
}