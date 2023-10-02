
#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace formSubmission.Models;

public class User
{
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters!")]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime? Birthday { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters!")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Favorite Odd Number")]
    [OddNumber]
    public int? Number { get; set; }
}


// DATETIME VALIDATION
public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || (DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Birthday must be in the past");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}

// ODD NUMBER VALIDATION
public class OddNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || (int)value % 2 == 0)
        {
            return new ValidationResult("Number must be odd!");
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}



