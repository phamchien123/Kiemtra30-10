using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBanHang
{
    public partial class Form1 : Form
    {
        private ShoppingCart shoppingCart = new ShoppingCart();
        public Form1()
        {
            InitializeComponent();
            LoadProducts();
        }
        private void LoadProducts()
        {
            // Ví dụ: Tạo một số sản phẩm mẫu
            var products = new List<Product>
    {
        new Product("Sản phẩm 1", 10000, 1),
        new Product("Sản phẩm 2", 20000, 1),
        new Product("Sản phẩm 3", 30000, 1)
    };

            foreach (var product in products)
            {
                dataGridViewProducts.Rows.Add(product.Name, product.Price, product.Quantity);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProducts.SelectedRows[0];
                var product = new Product(
                    selectedRow.Cells["Name"].Value.ToString(),
                    Convert.ToDecimal(selectedRow.Cells["Price"].Value),
                    1
                );
                shoppingCart.AddProduct(product);
                UpdateCart();
            }
        }
        private void UpdateCart()
        {
            dataGridViewCart.Rows.Clear();
            foreach (var product in shoppingCart.Products)
            {
                dataGridViewCart.Rows.Add(product.Name, product.Price, product.Quantity, product.Price * product.Quantity);
            }

            txttongtien.Text = $"Tổng giá trị: {shoppingCart.GetTotalPrice():C}";
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewCart.SelectedRows[0];
                var productName = selectedRow.Cells["Name"].Value.ToString();
                var productToRemove = shoppingCart.Products.FirstOrDefault(p => p.Name == productName);
                if (productToRemove != null)
                {
                    shoppingCart.RemoveProduct(productToRemove);
                    UpdateCart();
                }
            }
        }
        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            if (shoppingCart.Products.Count > 0)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo");
                shoppingCart.Clear();
                UpdateCart();
            }
        }
    }
}