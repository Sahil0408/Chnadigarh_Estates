using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chandigarh_Estates
{
    public class CompanyDetail
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set;}
        public string Address { get; set;}
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Pin { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
      
    }
}
