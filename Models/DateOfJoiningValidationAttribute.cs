using System;
using System.ComponentModel.DataAnnotations;

using personaldetails.Models;
namespace ValidationTask.Attributes
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
public class DateOfJoiningValidationAttribute : ValidationAttribute
{
    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
         if (value is DateTime joiningdate ){
        var register = validationContext.ObjectInstance as Register ;
 
            if (register!=null)
             {
                var dateofbirth=register.empdob;
                if(joiningdate.Date > dateofbirth.Date){
                 return ValidationResult.Success;
                }
                
             }

         }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        public override string FormatErrorMessage(string name){
            return $"The {name} field must be  later than the date of birth";
            
        }

        
        
    }
}
