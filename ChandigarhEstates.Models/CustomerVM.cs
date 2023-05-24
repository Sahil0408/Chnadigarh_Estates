using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandigarhEstates.Model
{
    
        public class CustomerVM
        {
            public int CustomerId { get; set; }

            [Required(ErrorMessage = "The Company Name field is required.")]
            public string CompanyName { get; set; }

            [Required(ErrorMessage = "The Customer Name field is required.")]

           public string CustomerName { get; set; }

        [Required(ErrorMessage = "The Parent Name field is required.")]
        public string ParentName { get; set; }

            [Required(ErrorMessage = "The Customer Email field is required.")]
            [EmailAddress(ErrorMessage = "The Customer Email must be a valid email address.")]
            public string CustomerEmail { get; set; }

            [Required(ErrorMessage = "The Contact field is required.")]
            [RegularExpression(@"^\+\d{1,3}-\d{3}-\d{4}$", ErrorMessage = "The Contact must be in the format '+[CountryCode]-[AreaCode]-[Number]'.")]
            public string Contact { get; set; }

            public int Amount { get; set; }

            public int TransactionId { get; set; }

            public int PlotSize { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (Amount <= 0)
                {
                    yield return new ValidationResult("The Amount must be a positive number.", new[] { nameof(Amount) });
                }

                if (PlotSize <= 0)
                {
                    yield return new ValidationResult("The Plot Size must be a positive number.", new[] { nameof(PlotSize) });
                }
            }
        }
    }


