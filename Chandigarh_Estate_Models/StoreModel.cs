using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chandigarh_Estates
{
    public class StoreModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PhoneNo { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public int RegId { get; set; }
    }
}
