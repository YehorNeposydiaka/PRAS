using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pras.Models
{
    public class Base
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Status { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
