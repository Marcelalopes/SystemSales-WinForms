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
        private List<ItemSale> cart = new List<ItemSale>();
        public FormSale()
        {
            InitializeComponent();
            UpdateDGV(db);
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
            try
            {
                var line = dgvProducts.CurrentCell.OwningRow;
                var price = line.Cells[3].Value.ToString();
                var idproduct = line.Cells[0].Value.ToString();
                var inventory = line.Cells[4].Value.ToString();

                if (Convert.ToInt32(inventory) < (int)nudQuantity.Value)
                    MessageBox.Show("Out of stock!", "Alert");
                else if (nudQuantity.Value == 0)
                    MessageBox.Show("Invalid quantity!", "Alert");
                else
                    cart.Add(new ItemSale(int.Parse(idproduct), double.Parse(price)));

                listView1.Items.Add(idproduct, price);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Alert");
            }
            
        }

        /// <summary>
        /// checkout method
        /// </summary>
        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                double total = 0;
                int idClient = int.Parse(cbIdClient.SelectedValue.ToString());

                List<ItemSale> itens = new List<ItemSale>();

                foreach (ItemSale i in cart)
                {
                    total += i.Price;
                    itens.Add(new ItemSale(i.SaleId, i.ProductId, i.Price, Convert.ToInt32(nudQuantity.Value), total));
                }

                Sale s = new Sale(idClient, total);
                db.Sales.Add(s);

                db.SaveChanges();
                cart.Clear();
                UpdateDGV(db);
                MessageBox.Show("Registred sale!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"Alert");
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
