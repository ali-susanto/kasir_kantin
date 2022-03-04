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
    public partial class dataUser : Form
    {
        public dataUser()
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
            cmd.CommandText = "SELECT * FROM tbadmin ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbadmin");
            //isi dari perintah sql ditampung ke dataset
            datausr.DataSource = ds;
            //set datsource untuk menampilkan data dari dataset
            datausr.DataMember = "tbadmin";
            datausr.ReadOnly = true;
        }

        private void resetData()
        {
            txtid.Text = "";
            txtpass.Text = "";
            cbSuper.Checked = false;
            cbUser.Checked = false;
            txtnama.Text = "";
        }

        private void dataUser_Load(object sender, EventArgs e)
        {
            tampilData();
            resetData();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "ADDUSER";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Userid = new SqlParameter("@id", SqlDbType.VarChar);
            SqlParameter Password = new SqlParameter("@pass", SqlDbType.VarChar);
            SqlParameter username = new SqlParameter("@nama", SqlDbType.VarChar);
            SqlParameter Otoritas = new SqlParameter("@otoritas", SqlDbType.VarChar);

            Userid.Value = txtid.Text;
            Password.Value = txtpass.Text;
            username.Value = txtnama.Text;
            if (cbSuper.Checked == true)
            {
                
                Otoritas.Value = cbSuper.Text;
            }else if (cbUser.Checked == true)
            {
                
                Otoritas.Value = cbUser.Text;
            }
            
            cmd.Parameters.Add(Userid);
            cmd.Parameters.Add(Password);
            cmd.Parameters.Add(username);
            cmd.Parameters.Add(Otoritas);

            cmd.ExecuteNonQuery();

            connect.Close();
            MessageBox.Show("Data berhasil di tambahkan");
            tampilData();
            resetData();
            
        }

        private void cbSuper_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSuper.Checked == true)
            {
                cbSuper.Text = "Supervisor";
                cbUser.Checked = false;
            }
        }

        private void cbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUser.Checked == true)
            {
                cbUser.Text = "User";
                cbSuper.Checked = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //txtUser.Enabled = true;
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "UPDATEUSER";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Userid = new SqlParameter("@id", SqlDbType.VarChar);
            SqlParameter Password = new SqlParameter("@pass", SqlDbType.VarChar);
            SqlParameter username = new SqlParameter("@nama", SqlDbType.VarChar);
            SqlParameter Otoritas = new SqlParameter("@otoritas", SqlDbType.VarChar);

            Userid.Value = txtid.Text;
            Password.Value = txtpass.Text;
            username.Value = txtnama.Text;
            if (cbSuper.Checked == true)
            {

                Otoritas.Value = cbSuper.Text;
            }
            else if (cbUser.Checked == true)
            {

                Otoritas.Value = cbUser.Text;
            }

            cmd.Parameters.Add(Userid);
            cmd.Parameters.Add(Password);
            cmd.Parameters.Add(username);
            cmd.Parameters.Add(Otoritas);

            cmd.ExecuteNonQuery();

            connect.Close();
            MessageBox.Show("Data berhasil di ubah");
            tampilData();
            resetData();

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            //txtUser.Enabled = true;
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DELUSER";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Userid = new SqlParameter("@id", SqlDbType.VarChar);

            Userid.Value = txtid.Text;

            cmd.Parameters.Add(Userid);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Data berhasil di hapus");
            tampilData();
            resetData();
        }

        private void datausr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //databinding
            txtid.Text = datausr.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtid.ReadOnly = true;
            txtpass.Text = datausr.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtnama.Text = datausr.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }
    }
}
