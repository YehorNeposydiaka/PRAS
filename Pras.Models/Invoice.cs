using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pras.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int BaseId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string DocumentNumber { get; set; }
        public double TotalAmount { get; set; }

        public Base Base { get; set; }
    }
}
