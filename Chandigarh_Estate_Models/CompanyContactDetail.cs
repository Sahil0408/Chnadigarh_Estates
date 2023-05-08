using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chandigarh_Estates
{
    public class CompanyContactDetail
    {
        public int Id {  get; set; }
        public int CompanyId { get; set; }
        public string ContactPersonName { get; set;}
        public string ContactPersonDesignation { get; set;}
        public  string ContactPersonEmail { get; set;}
        public string ContactPersonPhoneNo { get; set;}
        public bool Status { get; set;}
    }
}
