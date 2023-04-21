using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    internal static class Extensions
    {
        public static void Myvalidate(this IValidatable validatable)
        {
            ValidationContext Try = new ValidationContext(validatable);
            List<ValidationResult> res=new List<ValidationResult>();
            if (Validator.TryValidateObject(validatable, Try, res, true))
            {
                Console.WriteLine("Требования соблюдены");
            }
            else
            {
                Console.WriteLine("Требования не соблюдены"); 
            }
        }
    }
}
