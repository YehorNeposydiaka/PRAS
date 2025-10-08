using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pras.Models
{
    public class CheckProducts
    {
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double PriceAtSale { get; set; }

        public Check Check { get; set; }
        public Product Product { get; set; }
    }
}
