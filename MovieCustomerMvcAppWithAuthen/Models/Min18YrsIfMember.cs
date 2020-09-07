using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMvcAppWithAuthen.Models
{
    public class Min18YrsIfMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer =(Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ? 
                ValidationResult.Success : 
                new ValidationResult("Customer should be at least 18 Yrs old to be a member");
            //return base.IsValid(value, validationContext);
        }
    }
}