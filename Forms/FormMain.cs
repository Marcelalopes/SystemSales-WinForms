using WinFormsSales.Forms;

namespace WinFormsSales
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// variable to store form to be called
        /// </summary>
        private Form frmAtivo;
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// method to call the form to be opened
        /// </summary>
        /// <param name="frm">form variable</param>
        private void FormShow(Form frm)
        {
            ActiveFormClose();
            frmAtivo = frm;
            frm.TopLevel = false;
            panelContent.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        /// <summary>
        /// method to close active form
        /// </summary>
        private void ActiveFormClose()
        {
            if (frmAtivo != null)
                frmAtivo.Close();
        }

        /// <summary>
        /// method to active button
        /// </summary>
        /// <param name="frmAtivo"></param>
        private void ActiveButton(Button frmAtivo)
        {
            foreach (Control c in panelMenu.Controls)
                c.ForeColor = Color.FromArgb(1, 64, 64, 64);

            frmAtivo.ForeColor = Color.Black;
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActiveButton(btnHome);
            ActiveFormClose();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            ActiveButton(btnClient);
            FormShow(new FormClient());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActiveButton(btnProduct);
            FormShow(new FormProduct());
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            ActiveButton(btnSale);
            FormShow( new FormSale());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}