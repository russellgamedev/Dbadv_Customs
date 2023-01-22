using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace dbadv_customs
{
    public partial class Customer_View_Form : Form
    {
        public Customer_View_Form()
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection(
                "Server=localhost;Port=5432;Database=Customs;User Id=postgres;Password=1234");
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "Select * from customer";
            NpgsqlDataReader dr = comm.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            comm.Dispose();
            conn.Close();
        }

        private void Customer_View_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
