using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandigarhEstates.Model
{
    public class CompanyContactDetail
    {
        
            public int Id { get; set; }

            [Required(ErrorMessage = "The Company Id field is required.")]
            public int CompanyId { get; set; }

            [Required(ErrorMessage = "The Contact Person Name field is required.")]
            [StringLength(50, ErrorMessage = "The Contact Person Name must be between 2 and 50 characters.", MinimumLength = 2)]
            public string ContactPersonName { get; set; }

            [Required(ErrorMessage = "The Contact Person Designation field is required.")]
            public string ContactPersonDesignation { get; set; }

            [Required(ErrorMessage = "The Contact Person Email field is required.")]
            [EmailAddress(ErrorMessage = "The Contact Person Email must be a valid email address.")]
            public string ContactPersonEmail { get; set; }

        [Required(ErrorMessage = "The Contact Person Phone No field is required.")]
        [RegularExpression(@"^\+[1-9]\d{1,3}-\d{3}-\d{4}$", ErrorMessage = "The Contact Person Phone No must be in the format '+[CountryCode]-[AreaCode]-[Number]'.")]
        public string ContactPersonPhoneNo { get; set; }

        [Required(ErrorMessage = "The Status field is required.")]
            public string Status { get; set; }
        }
    }


