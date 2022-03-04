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
    public partial class laporan : Form
    {
        public laporan()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=ALI\SQLEXPRESS; Initial Catalog=db19sa1145;Integrated Security=True");

        private void tampilData()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  * FROM tbtransaksi";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tbtransaksi");
            dglaporan.DataSource = ds;
            dglaporan.DataMember = "tbtransaksi";
            dglaporan.ReadOnly = true;
        }

        private void laporan_Load(object sender, EventArgs e)
        {
            tampilData();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {

            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand("select * from tbtransaksi where userid like '%" + txtcari.Text + "%'", connect);
            SqlDataReader RD = Cmd.ExecuteReader();
            RD.Read();
            if (RD.HasRows)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tbtransaksi where userid like '%" + txtcari.Text + "%'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "tbtransaksi");
                dglaporan.DataSource = ds;
                dglaporan.DataMember = "tbtransaksi";
                dglaporan.ReadOnly = true;
            }
        }
    }
}
