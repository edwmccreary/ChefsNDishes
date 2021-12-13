using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class DateOfBirth : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                DateTime dateValue = (DateTime)value;
                if(dateValue > DateTime.Now)
                {
                    return new ValidationResult("Date of birth cannot be in the future");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Date of birth cannot be in the future");
            }
        }
    }
}