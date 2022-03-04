using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Prj19SA1145
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            
        }

        //koneksi data
        SqlConnection connect = new SqlConnection(@"Data Source=ALI\SQLEXPRESS; Initial Catalog=db19sa1145;Integrated Security=True");

        private void resetdata()
        {
            txtpass.Text = "";
            txtuser.Text = "";
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {          
        }
        public static string kasir;
        
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            //login
            try
            {
                if (txtuser.Text == "" || txtpass.Text == "" )
                {
                    MessageBox.Show("Semua data tidak boleh kosong");
                }
                else
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "SELECT * FROM tbadmin WHERE Userid='" + txtuser.Text +
                        "' And Password='" + txtpass.Text + "'";
                    SqlDataReader rd;
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        MessageBox.Show("Login Berhasil");
                        if (cbsuper.Checked==true){
                            kasir = txtuser.Text;
                            menuAdmin menuadm = new menuAdmin();
                            menuadm.Show();
                            //kirim nama user login ke nama user bagian transaksi
                            
                            
                        }else if (cbuser.Checked == true)
                        {
                            kasir = txtuser.Text;
                            menuUser user = new menuUser();
                            user.Show();
                            this.Close();
                        }
                        resetdata();
                        

                    }
                    else
                    {
                        MessageBox.Show("Password atau username salah");
                        txtpass.Focus();
                    }
                    connect.Close();
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
          
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin ingin keluar ?", "Keluar", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cbsuper_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsuper.Checked == true)
            {
                cbuser.Checked = false;
            }
            
            
        }

        private void cbuser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbuser.Checked == true)
            {
                cbsuper.Checked = false;
            }
          
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            txtuser.Focus();
        }
    }
}
