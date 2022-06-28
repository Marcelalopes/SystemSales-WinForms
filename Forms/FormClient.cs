using WinFormsSales.Context;
using WinFormsSales.Models;

namespace WinFormsSales.Forms
{
    public partial class FormClient : Form
    {
        SalesContext context = new SalesContext();
        public FormClient()
        {
            InitializeComponent();
            UpdateDGV(context);
            
        }
        private void UpdateDGV(SalesContext db)
        {
            dgvClient.DataSource = db.Clients.ToList();
        }
        
        private void btnAddC_Click(object sender, EventArgs e)
        {
            Client c = new Client(tbName.Text, tbCpf.Text, tbPhone.Text, tbEmail.Text);
            context.Clients.Add(c);
            context.SaveChanges();

            UpdateDGV(context);
        }
    }
}
