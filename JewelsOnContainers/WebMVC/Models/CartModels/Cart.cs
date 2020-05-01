using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Cart
    {
        public string BuyerId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }
     
    }
}
