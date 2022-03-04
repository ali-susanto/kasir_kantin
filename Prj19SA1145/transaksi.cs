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
    public partial class transaksi : Form
    {
        public transaksi()
        {
            InitializeComponent();
        }
        //koneksi data
        SqlConnection connect = new SqlConnection(@"Data Source=ALI\SQLEXPRESS; Initial Catalog=db19sa1145;Integrated Security=True");

        private string noTrx
        {
            get
            {
                connect.Open();
                string nomor = "TR-001";
                SqlCommand cmd = new SqlCommand("SELECT max(right(idTransaksi,4)) from tbtransaksi", connect);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                if (rd[0].ToString() != "")
                    nomor = "TR-" + (int.Parse(rd[0].ToString()) + 1).ToString();
                rd.Close();
                return nomor;
            }
        }

        private void isiMenu()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT nmMenu FROM tbmenu";
            DataSet ds1 = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds1, "tbmenu");
            cmbMenu.DataSource = ds1.Tables["tbmenu"];
            cmbMenu.DisplayMember = "nmMenu";
        }

        private void resetData()
        {
            connect.Close();
            txtid.Text = noTrx;
            txtid.Text = "";
            txtidcs.Text = "";
            txtidmenu.Text = "";
            txtjumlah.Text = "";
            //txttotal.Text = "";
            txtuser.Text = "";
        }
        private void transaksi_Load(object sender, EventArgs e)
        {
            txtid.ReadOnly = true;
            txtid.Text = noTrx;
            isiMenu();
            txtuser.Text = login.kasir;
            txtTgl.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        string hargaBeli;
        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect.Close();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbmenu WHERE nmMenu='" + cmbMenu.Text + "'", connect);
            connect.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();
                txtidmenu.Text = rd[0].ToString();
                hargaBeli = rd[2].ToString();
                txtharga.Text = rd[3].ToString();
                rd.Close();
            }

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //bayar
                if (txtharga.Text == "")
                {
                    MessageBox.Show("Harga harus diisi");
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "INSERT INTO tbtransaksi VALUES('" + txtid.Text + "','" +
                    txtTgl.Text + "','" + txtidcs.Text + "','" + txtuser.Text + "')";
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                //input ke tabel detail transaksi
                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = connect;
                cmd2.CommandText = "INSERT INTO tbdetailtransaksi VALUES('" + txtid.Text + "','" +
                    txtidmenu.Text + "','" + hargaBeli + "','" + txtharga.Text + "','" + txtjumlah.Text + "')";
                cmd2.CommandType = CommandType.Text;
                int harga = int.Parse(txtharga.Text.ToString());
                int jumlah = int.Parse(txtjumlah.Text.ToString());
                int total = harga * jumlah;
                txttotal.Text = total.ToString();
                cmd2.ExecuteNonQuery();

                resetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
