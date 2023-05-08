using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chandigarh_Estates
{
    public class Country_Table
    {
        [Key]
        public int? CountryId { get; set; }
        public string CountryName { get; set; }

    }
}
