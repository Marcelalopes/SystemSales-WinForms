using WinFormsSales.Context;
using WinFormsSales.Models;

namespace WinFormsSales.Forms
{
    public partial class FormClient : Form
    {
        /// <summary>
        /// bank connection object
        /// </summary>
        SalesContext db = new SalesContext();
        public FormClient()
        {
            InitializeComponent();
            UpdateDGV(db);
            
        }

        /// <summary>
        /// method to populate and update the data grid view
        /// </summary>
        private void UpdateDGV(SalesContext db)
        {
            dgvClient.DataSource = db.Clients.ToList();
        }

        /// <summary>
        /// method to register client
        /// </summary>
        private void btnAddC_Click(object sender, EventArgs e)
        {
            Client c = new Client(tbName.Text, tbCpf.Text, tbPhone.Text, tbEmail.Text);
            db.Clients.Add(c);
            db.SaveChanges();

            UpdateDGV(db);
        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// method to allow only letters name text box
        /// </summary>
        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("This field doesn't accept numbers");
                e.Handled = true;
            }

        }
    }
}
