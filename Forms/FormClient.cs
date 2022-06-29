using WinFormsSales.Context;
using WinFormsSales.Models;

namespace WinFormsSales.Forms
{
    public partial class FormClient : Form
    {
        SalesContext db = new SalesContext();
        public FormClient()
        {
            InitializeComponent();
            UpdateDGV(db);
            
        }
        private void UpdateDGV(SalesContext db)
        {
            dgvClient.DataSource = db.Clients.ToList();
        }
        
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
    }
}
