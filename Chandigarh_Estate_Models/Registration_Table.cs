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
        [Key]
        public int RegId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PhoneNo { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        

    }
}
