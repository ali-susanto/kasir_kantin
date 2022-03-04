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
    public partial class dataCustomer : Form
    {
        public dataCustomer()
        {
            InitializeComponent();
        }
        //koneksi database
        SqlConnection connect = new SqlConnection(@"Data Source=ALI\SQLEXPRESS; Initial Catalog=db19sa1145;Integrated Security=True");

        private void tampilData()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM tbcustomer ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbcustomer");
            //isi dari perintah sql ditampung ke dataset
            datacs.DataSource = ds;
            //set datsource untuk menampilkan data dari dataset
            datacs.DataMember = "tbcustomer";
            datacs.ReadOnly = true;
        }

        private void resetData()
        {
            txtAlamat.Text="";
            txthp.Text = "";
            txtid.Text = "";
            txtkota.Text = "";
            txtnama.Text = "";
        }

        private void dataCustomer_Load(object sender, EventArgs e)
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
                cmd.CommandText = "ADDCUSTOMER";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idCustomer = new SqlParameter("@id", SqlDbType.VarChar);
                SqlParameter nama = new SqlParameter("@nama", SqlDbType.VarChar);
                SqlParameter alamat = new SqlParameter("@alamat", SqlDbType.VarChar);
                SqlParameter kota = new SqlParameter("@kota", SqlDbType.VarChar);
                SqlParameter hp = new SqlParameter("@hp", SqlDbType.VarChar);


                idCustomer.Value = txtid.Text;
                nama.Value = txtnama.Text;
                alamat.Value = txtAlamat.Text;
                kota.Value = txtkota.Text;
                hp.Value = txthp.Text;

                cmd.Parameters.Add(idCustomer);
                cmd.Parameters.Add(nama);
                cmd.Parameters.Add(alamat);
                cmd.Parameters.Add(kota);
                cmd.Parameters.Add(hp);

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
                //txtid.Enabled = true;
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "UPDATECUSTOMER";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idCustomer = new SqlParameter("@id", SqlDbType.VarChar);
                SqlParameter nama = new SqlParameter("@nama", SqlDbType.VarChar);
                SqlParameter alamat = new SqlParameter("@alamat", SqlDbType.VarChar);
                SqlParameter kota = new SqlParameter("@kota", SqlDbType.VarChar);
                SqlParameter hp = new SqlParameter("@hp", SqlDbType.VarChar);


                idCustomer.Value = txtid.Text;
                nama.Value = txtnama.Text;
                alamat.Value = txtAlamat.Text;
                kota.Value = txtkota.Text;
                hp.Value = txthp.Text;

                cmd.Parameters.Add(idCustomer);
                cmd.Parameters.Add(nama);
                cmd.Parameters.Add(alamat);
                cmd.Parameters.Add(kota);
                cmd.Parameters.Add(hp);

                cmd.ExecuteNonQuery();

                connect.Close();
                MessageBox.Show("Data berhasil di Ubah");
                tampilData();
                resetData();
                txtid.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                //txtid.Enabled = true;
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "DELCUSTOMER";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idCustomer = new SqlParameter("@id", SqlDbType.VarChar);
                idCustomer.Value = txtid.Text;
                cmd.Parameters.Add(idCustomer);
                cmd.ExecuteNonQuery();

                connect.Close();
                MessageBox.Show("Data berhasil di hapus");
                tampilData();
                resetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void datacs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //data binding
            txtid.Text = datacs.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtid.ReadOnly = true;
            txtnama.Text = datacs.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAlamat.Text = datacs.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtkota.Text = datacs.Rows[e.RowIndex].Cells[3].Value.ToString();
            txthp.Text = datacs.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
