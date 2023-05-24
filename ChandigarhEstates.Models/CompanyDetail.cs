using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandigarhEstates.Model
{


   
        public class CompanyDetail
        {
        [Key]
            public int CompanyId { get; set; }

            [Required(ErrorMessage = "The Company Name field is required.")]
            [StringLength(10, ErrorMessage = "The Company Name must be between 2 and 10 characters.", MinimumLength = 2)]
            public string CompanyName { get; set; }

            [Required(ErrorMessage = "The Address field is required.")]
            public string Address { get; set; }

            [Required(ErrorMessage = "The City Id field is required.")]
            public int CityId { get; set; }

            [Required(ErrorMessage = "The State Id field is required.")]
            public int StateId { get; set; }

            [Required(ErrorMessage = "The Pin field is required.")]
            [RegularExpression(@"^\d{6}$", ErrorMessage = "The Pin must be a 6-digit number.")]
            public string Pin { get; set; }

        [Required(ErrorMessage = "The Contact No field is required.")]
        [RegularExpression(@"^\+[1-9]\d{1,3}-\d{3}-\d{4}$", ErrorMessage = "The Contact No must be in the format '+[CountryCode]-[AreaCode]-[Number]'.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
            [EmailAddress(ErrorMessage = "The Email must be a valid email address.")]
            public string Email { get; set; }
        }
    }


