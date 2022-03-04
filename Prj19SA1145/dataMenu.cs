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
    public partial class dataMenu : Form
    {
        public dataMenu()
        {
            InitializeComponent();
        }
        //koneksi data
        SqlConnection connect = new SqlConnection(@"Data Source=ALI\SQLEXPRESS; Initial Catalog=db19sa1145;Integrated Security=True");

        private void tampilData()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbmenu ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbmenu");
            //isi dari perintah sql ditampung ke dataset
            dgvmenu.DataSource = ds;
            //set datsource untuk menampilkan data dari dataset
            dgvmenu.DataMember = "tbmenu";
            dgvmenu.ReadOnly = true;
        }
        private void resetData()
        {
            txtId.Text = "";
            txtbeli.Text = "";
            txtjual.Text = "";
            txtnama.Text = "";
            txtsatuan.Text = "";
            txtstock.Text = "";
        }

        private void dataMenu_Load(object sender, EventArgs e)
        {
            tampilData();
            resetData();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "ADDMENU";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idMenu = new SqlParameter("@id", SqlDbType.VarChar);
                SqlParameter nama = new SqlParameter("@nama", SqlDbType.VarChar);
                SqlParameter hargabeli = new SqlParameter("@hargabeli", SqlDbType.Int);
                SqlParameter hargajual = new SqlParameter("@hargajual", SqlDbType.Int);
                SqlParameter satuan = new SqlParameter("@satuan", SqlDbType.VarChar);
                SqlParameter stok = new SqlParameter("@stok", SqlDbType.Int);

                idMenu.Value = txtId.Text;
                nama.Value = txtnama.Text;
                hargabeli.Value = txtbeli.Text;
                hargajual.Value = txtjual.Text;
                satuan.Value = txtsatuan.Text;
                stok.Value = txtstock.Text;

                cmd.Parameters.Add(idMenu);
                cmd.Parameters.Add(nama);
                cmd.Parameters.Add(hargabeli);
                cmd.Parameters.Add(hargajual);
                cmd.Parameters.Add(satuan);
                cmd.Parameters.Add(stok);

                cmd.ExecuteNonQuery();

                connect.Close();
                MessageBox.Show("Data berhasil di tambahkan");
                tampilData();
                resetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "UPDATEMENU";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idMenu = new SqlParameter("@id", SqlDbType.VarChar);
                SqlParameter nama = new SqlParameter("@nama", SqlDbType.VarChar);
                SqlParameter hargabeli = new SqlParameter("@hargabeli", SqlDbType.Int);
                SqlParameter hargajual = new SqlParameter("@hargajual", SqlDbType.Int);
                SqlParameter satuan = new SqlParameter("@satuan", SqlDbType.VarChar);
                SqlParameter stok = new SqlParameter("@stok", SqlDbType.Int);

                idMenu.Value = txtId.Text;
                nama.Value = txtnama.Text;
                hargabeli.Value = txtbeli.Text;
                hargajual.Value = txtjual.Text;
                satuan.Value = txtsatuan.Text;
                stok.Value = txtstock.Text;

                cmd.Parameters.Add(idMenu);
                cmd.Parameters.Add(nama);
                cmd.Parameters.Add(hargabeli);
                cmd.Parameters.Add(hargajual);
                cmd.Parameters.Add(satuan);
                cmd.Parameters.Add(stok);

                cmd.ExecuteNonQuery();

                connect.Close();
                MessageBox.Show("Data berhasil di ubah");
                tampilData();
                resetData();
                txtId.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "DELMENU";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idMenu = new SqlParameter("@id", SqlDbType.VarChar);
                idMenu.Value = txtId.Text;
                cmd.Parameters.Add(idMenu);
                cmd.ExecuteNonQuery();

                connect.Close();
                MessageBox.Show("Data berhasil di hapus");
                tampilData();
                resetData();
                txtId.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
    
        }

        private void dgvmenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //databinding
            txtId.Text = dgvmenu.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtId.ReadOnly = true;
            txtnama.Text = dgvmenu.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbeli.Text = dgvmenu.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtjual.Text = dgvmenu.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsatuan.Text = dgvmenu.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtstock.Text = dgvmenu.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
