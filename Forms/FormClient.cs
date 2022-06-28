using WinFormsSales.Context;
using WinFormsSales.Forms.FormsAdd;
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

        private void btnAddClient_Click(object sender, EventArgs e)
        {
           
        }
        private void UpdateDGV(SalesContext db)
        {
            dgvClient.DataSource = db.Clients.ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client c = new Client(tbName.Text, tbCpf.Text, tbPhone.Text, tbEmail.Text);
            context.Clients.Add(c);
            context.SaveChanges();

            UpdateDGV(context);
        }
    }
}
