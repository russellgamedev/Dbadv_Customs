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
    public partial class Delete_Customer_Form : Form
    {
        List<Customer> customerList = new List<Customer>();

        public Delete_Customer_Form()
        {
            InitializeComponent();
            InitCustomerComboBox();
        }

        private void Delete_Customer_Form_Load(object sender, EventArgs e)
        {

        }

        void InitCustomerComboBox()
        {
            customerComboBox.SelectedIndex = -1;
            customerComboBox.Items.Clear();
            SetCustomerList();

            for (int i = 0; i < customerList.Count; i++)
            {
                string item = customerList[i].cstmFname + " " +
                            customerList[i].cstmLname + " : " +
                            customerList[i].cstmSsn;

                customerComboBox.Items.Add(item);
            }
        }

        void SetCustomerList()
        {
            //List<Customer> customerList = new List<Customer>();
            customerList.Clear();
            try
            {
                DataTable dt = new DataTable();
                dt = DatabaseManager.GetDataTableFromQuery
                ("Select * from customer");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow drow = dt.Rows[i];
                    Customer cstm = new Customer(drow[0].ToString(),
                        drow[1].ToString(),
                        drow[2].ToString());
                    customerList.Add(cstm);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        class Customer
        {
            public string cstmFname;
            public string cstmLname;
            public string cstmSsn;
            public Customer(string cstmFname, string cstmLname, string cstmSsn)
            {
                this.cstmFname = cstmFname;
                this.cstmLname = cstmLname;
                this.cstmSsn = cstmSsn;
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {

            if (GetCustomerSsnFromCombobox() == null)
            {
                MessageBox.Show("Please Select Customer");
                return;
            }
            string myCustomerSsn = GetCustomerSsnFromCombobox();

            try
            {

                string query = "Delete from customer " +
                                "where customer_ssn = @customer_ssn";


                NpgsqlConnection conn = new NpgsqlConnection
                    (DatabaseManager.connection_String);
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@customer_ssn", myCustomerSsn);
                comm.ExecuteNonQuery();              

                InitCustomerComboBox();

                MessageBox.Show("Customer Deleted!", "Delete!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string GetCustomerSsnFromCombobox()
        {
            if (customerComboBox.SelectedIndex == -1)
            {
                return null;
            }

            string selected = customerComboBox.SelectedItem.ToString();
            string[] splited = selected.Split(' ', ':');
            return splited[splited.Length - 1];
        }

    }
}
