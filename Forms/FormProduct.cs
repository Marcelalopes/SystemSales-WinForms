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
    public partial class FormProduct : Form
    {
        /// <summary>
        /// bank connection object
        /// </summary>
        SalesContext db = new SalesContext();
        public FormProduct()
        {
            InitializeComponent();
            UpdateDGV(db);
        }

        /// <summary>
        /// method to register product
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbCodeEAN.Text == null || tbName.Text == null || tbPrice.Text == null)
                    MessageBox.Show("All fields must be filled!", "Alert");
                else if (nudInventory.Value == 0)
                    MessageBox.Show("Inventory Invalid!", "Alert");
                else
                {
                    Product p = new Product(tbCodeEAN.Text, tbName.Text, double.Parse(tbPrice.Text), Convert.ToInt32(nudInventory.Value));
                    db.Products.Add(p);
                    db.SaveChanges();
                }

                UpdateDGV(db);
                MessageBox.Show("registred product!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Alert");
            }

        }

        /// <summary>
        /// method to populate and update the data grid view
        /// </summary>
        private void UpdateDGV(SalesContext db)
        {
            dgvProduct.DataSource = db.Products.ToList();
        }

        /// <summary>
        /// method to allow only comma and number in price text box
        /// </summary>
        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (tbPrice.Text.Contains(","));
                }
                else
                {
                    MessageBox.Show("This field accepts only number and comma", "Alert");
                    e.Handled = true;
                }
            }
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
