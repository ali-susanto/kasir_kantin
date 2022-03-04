using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prj19SA1145
{
    public partial class menuAdmin : Form
    {
        public menuAdmin()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void menuAdmin_Load(object sender, EventArgs e)
        {
            user.Text = login.kasir;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {
            dataUser user = new dataUser();
            user.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();

        }

        private void guna2PictureBox9_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin ingin keluar ?", "Keluar", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            dataUser user = new dataUser();
            user.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            dataCustomer cs = new dataCustomer();
            cs.Show();
        }

        private void btncs_Click(object sender, EventArgs e)
        {
            dataCustomer cs = new dataCustomer();
            cs.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            dataMenu menu = new dataMenu();
            menu.Show();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            dataMenu menu = new dataMenu();
            menu.Show();
        }

        private void transaksi_Click(object sender, EventArgs e)
        {
            transaksi trx = new transaksi();
            trx.Show();

        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            transaksi trx = new transaksi();
            trx.Show();
        }

        private void btnlaporan_Click(object sender, EventArgs e)
        {
            laporan lp = new laporan();
            lp.Show();
        }

        private void laporan_Click(object sender, EventArgs e)
        {
            laporan lp = new laporan();
            lp.Show();
        }
    }
}
