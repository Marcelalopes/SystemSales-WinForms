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
        /// <summary>
        /// bank connection object
        /// </summary>
        SalesContext db = new SalesContext();

        /// <summary>
        /// cart list
        /// </summary>
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

        /// <summary>
        /// method to populate and update the data grid view
        /// </summary>
        /// <param name="db">bank connection object</param>
        private void UpdateDGV(SalesContext db)
        {
            dgvProducts.DataSource = db.Products.ToList();
            dgvSales.DataSource = db.Sales.ToList();

            cbIdClient.DataSource = db.Clients.ToList();
            cbIdClient.DisplayMember = "name";
            cbIdClient.ValueMember = "Id";
        }

        /// <summary>
        /// method to add products to cart
        /// </summary>
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

        /// <summary>
        /// checkout method
        /// </summary>
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

        /// <summary>
        /// method for popular list view
        /// </summary>
        /// <param name="list">products list</param>
        private void AddListView(List<Product> list)
        {
            listView1.Text = " ";
            foreach (Product i in list)
            {
                listView1.Items.Add(i.Id.ToString(), (int)i.Price);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
