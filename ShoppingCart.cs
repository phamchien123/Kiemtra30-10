using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang
{
    public class ShoppingCart
    {
        public List<Product> Products { get; private set; }

        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var product in Products)
            {
                total += product.Price * product.Quantity;
            }
            return total;
        }

        public void Clear()
        {
            Products.Clear();
        }
    }
}
