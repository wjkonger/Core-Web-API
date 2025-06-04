using System;
using System.ComponentModel.DataAnnotations;

namespace Model;

public class UserValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var oUser = validationContext.ObjectInstance as User;


        if (oUser != null && oUser.UserName == "wjkonger")
        {
            return new ValidationResult("somthing wrong");
        }

        return ValidationResult.Success;
       
    }
}
