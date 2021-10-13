using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Placid
{
    /// <summary>
    /// Provides hex code validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class HexCodeAttribute : ValidationAttribute
    {
        ///
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if (!string.IsNullOrWhiteSpace(value as string))
            {
                var regex = new Regex("^#([0-9A-F]{3}){1,2}$", RegexOptions.IgnoreCase);

                if (regex != null && regex.IsMatch((string)value))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Invalid hex code.");
        }
    }
}
