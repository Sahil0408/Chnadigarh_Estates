using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandigarhEstates.Model
{
   
        public class Login_Page
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "The Email field is required.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The Password field is required.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "The RoleId field is required.")]
            public int RoleId { get; set; }

            [Required(ErrorMessage = "The IsActive field is required.")]
            public bool IsActive { get; set; }

            [Required(ErrorMessage = "The RegId field is required.")]
            public int RegId { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                // Add custom validation logic if needed
                // Example: Check if the password meets specific criteria
                if (string.IsNullOrEmpty(Password) || Password.Length < 6)
                {
                    yield return new ValidationResult("The Password must be at least 6 characters long.", new[] { nameof(Password) });
                }
            }
        }
    }


