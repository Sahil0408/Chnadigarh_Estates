using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chandigarh_Estates
{
    public class Registration_Table
    { 
        
        
            public int Id { get; set; }

            [Required(ErrorMessage = "The First Name field is required.")]
            public string Fname { get; set; }

            [Required(ErrorMessage = "The Last Name field is required.")]
            public string Lname { get; set; }

            [Required(ErrorMessage = "The Phone Number field is required.")]
            [RegularExpression(@"^\+\d{1,3}-\d{3}-\d{4}$", ErrorMessage = "The Phone Number must be in the format '+[CountryCode]-[AreaCode]-[Number]'.")]
            public string PhoneNo { get; set; }

            [Required(ErrorMessage = "The City Id field is required.")]
            public int CityId { get; set; }

            [Required(ErrorMessage = "The State Id field is required.")]
            public int StateId { get; set; }

            [Required(ErrorMessage = "The Country Id field is required.")]
            public int CountryId { get; set; }

            [Required(ErrorMessage = "The Email field is required.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "The Password field is required.")]
            [MinLength(6, ErrorMessage = "The Password must be at least 6 characters long.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "The Role Id field is required.")]
            public int RoleId { get; set; }

            [Required(ErrorMessage = "The IsActive field is required.")]
            public bool IsActive { get; set; }

            [Required(ErrorMessage = "The Registration Id field is required.")]
            public string RegId { get; set; }
        }
    }



