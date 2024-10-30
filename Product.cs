using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public Image Image { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            //Image = image;
            Quantity = quantity;
        }
    }
}
