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
        public string CityName { get; set; }
       public int StateId { get; set; }
    }
}
