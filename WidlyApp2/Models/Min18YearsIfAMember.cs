using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WidlyApp2.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unkown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            { 
                return new ValidationResult("Birthdate is required.");
            }

            int age;

            if(DateTime.Today.Month > customer.BirthDate.Value.Month)
            {
                age = (DateTime.Today.Year - customer.BirthDate.Value.Year);
            }

            else if(DateTime.Today.Month == customer.BirthDate.Value.Month)
            {
                if(DateTime.Today.Day > customer.BirthDate.Value.Day)
                {
                    age = (DateTime.Today.Year - customer.BirthDate.Value.Year);
                }
                else
                {
                    age = (DateTime.Today.Year - customer.BirthDate.Value.Year) - 1;
                }
            }
            else
            {
                age = (DateTime.Today.Year - customer.BirthDate.Value.Year) - 1;
            }

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 old to go on the membership");
        }
    }
}