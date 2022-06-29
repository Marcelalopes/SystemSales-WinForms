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
        SalesContext db = new SalesContext();
        public FormProduct()
        {
            InitializeComponent();
            UpdateDGV(db);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product p = new Product(tbCodeEAN.Text,tbName.Text, double.Parse(tbPrice.Text), Convert.ToInt32(nudInventory.Value));
            db.Products.Add(p);
            db.SaveChanges();

            UpdateDGV(db);
        }
        private void UpdateDGV(SalesContext db)
        {
            dgvProduct.DataSource = db.Products.ToList();
        }

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
    }
}
