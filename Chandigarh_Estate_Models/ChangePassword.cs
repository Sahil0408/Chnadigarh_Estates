using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chandigarh_Estates
{
    public class ChangePassword

    {
        public int Id { get; set; }
        
        
            [Required(ErrorMessage = "The Old Password field is required.")]
            public string OldPassword { get; set; }

            [Required(ErrorMessage = "The New Password field is required.")]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            public string NewPassword { get; set; }

            [Required(ErrorMessage = "The Confirm Password field is required.")]
            [Compare("NewPassword", ErrorMessage = "The New Password and Confirm Password do not match.")]
            public string ConfirmPassword { get; set; }
        }

    }
    

