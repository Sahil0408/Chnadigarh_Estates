using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandigarhEstates.Model
{
    public class manageCustomer
    {
        [Key]
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public string CustomerName { get; set; }
        public string ParentName { get; set; }
        public string CustomerEmail { get; set; }
        public string Contact { get; set; }
        public int Amount { get; set; }
        public int TransactionId { get; set; }
        public int PlotSize { get; set; }
    }
}
