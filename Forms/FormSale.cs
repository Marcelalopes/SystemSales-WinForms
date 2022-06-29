using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSales.Context;
using WinFormsSales.Models;

namespace WinFormsSales.Forms
{
    public partial class FormSale : Form
    {
        SalesContext db = new SalesContext();
        private List<Product> cart = new List<Product>();
        public FormSale()
        {
            InitializeComponent();
            UpdateDGV(db);
            AddListView(cart);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void UpdateDGV(SalesContext db)
        {
            dgvProducts.DataSource = db.Products.ToList();
            dgvSales.DataSource = db.Sales.ToList();
            cbIdClient.DataSource = db.Clients.ToList();
            cbIdClient.DisplayMember = "name";
            cbIdClient.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var line = dgvProducts.CurrentCell.OwningRow;
            var idproduct = line.Cells[0].Value.ToString();
            var price = line.Cells[3].Value.ToString();
            var estoque = line.Cells[4].Value.ToString();

            if (Convert.ToInt32(estoque) < (int)nudQuantity.Value)
                MessageBox.Show("Out of stock!", "Alert");
            else if (nudQuantity.Value == 0)
                MessageBox.Show("Invalid quantity!", "Alert");
            else
                cart.Add(new Product(int.Parse(idproduct), double.Parse(price)));

            AddListView(cart);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            double total = 0;
            int idClient = int.Parse(cbIdClient.SelectedValue.ToString());

            foreach (Product i in cart)
            {
                total += i.Price * Convert.ToInt32(nudQuantity.Value);                
            }

            foreach (Product i in cart)
            {
                Sale s = new Sale(idClient, i.Id, i.Price, Convert.ToInt32(nudQuantity.Value), total);
                i.Inventory -= (int)nudQuantity.Value;
                db.Sales.Add(s);
            }

            db.SaveChanges();
            cart.Clear();
            UpdateDGV(db);
        }
        private void AddListView(List<Product> list)
        {
            listView1.Text = " ";
            foreach (Product i in list)
            {
                listView1.Items.Add(i.Id.ToString(), (int)i.Price);
            }
        }
    }
}
