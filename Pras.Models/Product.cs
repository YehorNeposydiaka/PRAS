using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pras.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public int Code {  get; set; }
        public string Name { get; set; }
        public double CostPrice {  get; set; }
        public double Price {  get; set; }
        public double Quantity {  get; set; }
        public int BaseId {  get; set; }
        public bool Status {  get; set; }

        public Base Base { get; set; }
    }
}
