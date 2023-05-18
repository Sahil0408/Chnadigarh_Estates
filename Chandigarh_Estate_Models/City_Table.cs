using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Chandigarh_Estates
{
    public class City_Table
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "The City Name field is required.")]
        [StringLength(20, ErrorMessage = "The City Name must be between 2 and 20 characters.", MinimumLength = 2)]
        public string CityName { get; set; }

        [Required(ErrorMessage = "The State Id field is required.")]
        public int StateId { get; set; }
    }
}
