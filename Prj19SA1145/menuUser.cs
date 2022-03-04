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
    public partial class menuUser : Form
    {
        public menuUser()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin ingin keluar ?", "Pesan", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void menuUser_Load(object sender, EventArgs e)
        {

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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
            this.Close();
        }

        private void transaksi_Click(object sender, EventArgs e)
        {
            transaksi tr = new transaksi();
            tr.Show();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            transaksi tr = new transaksi();
            tr.Show();
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
    }
}
