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
    public partial class Add_Customer_Form : Form
    {
        public Add_Customer_Form()
        {
            InitializeComponent();
        }

        private void Add_Customer_FormLoad(object sender, EventArgs e)
        {

        }

        private void ConfirmCustomerBtn_Click(object sender, EventArgs e)
        {
            if (!SsnLenghtIs10()) return;
            if (!PhoneNumberLenghtIs11()) return;
            if (!PostNumberLenghtIs10()) return;
            if (TextBoxIsNull())
            {
                MessageBox.Show("Please Complete form!");
                return;
            }

            InsertToCustomerTable();
        }

        void InsertToCustomerTable()
        {            
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(DatabaseManager.connection_String);
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand("add_new_customer", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@fname", SqlDbType.NVarChar).Value = fnameTxtBox.Text;
                comm.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = lnameTxtBox.Text;
                comm.Parameters.AddWithValue("@ssn", SqlDbType.NVarChar).Value = ssnTxtbox.Text;
                comm.Parameters.AddWithValue("@c_number", SqlDbType.NVarChar).Value = phNumberTxtbox.Text;
                comm.Parameters.AddWithValue("@email", SqlDbType.Text).Value = emailTxtbox.Text;
                comm.Parameters.AddWithValue("@country", SqlDbType.NVarChar).Value = countryTxtBox.Text;
                comm.Parameters.AddWithValue("@city", SqlDbType.NVarChar).Value = cityTxtBox.Text;
                comm.Parameters.AddWithValue("@postal_code", SqlDbType.Int).Value = int.Parse(postNumberTxtBox.Text);
                comm.Parameters.AddWithValue("@street", SqlDbType.NVarChar).Value = streetTxtBox.Text;
                comm.Parameters.AddWithValue("@plaque", SqlDbType.Int).Value = int.Parse(plaqueTxtBox.Text);
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();

                InitCustomerDataGridView();
                MessageBox.Show("Customer Added", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool TextBoxIsNull()
        {
            if (fnameTxtBox.Text == "") return true;
            if (fnameTxtBox.Text == "") return true;
            if (ssnTxtbox.Text == "") return true;
            if (phoneNumberError.Text == "") return true;
            if (emailTxtbox.Text == "") return true;
            if (cityTxtBox.Text == "") return true;
            if (countryTxtBox.Text == "") return true;
            if (streetTxtBox.Text == "") return true;
            if (plaqueTxtBox.Text == "") return true;
            if (postNumberTxtBox.Text == "") return true;

            return false;

        }

        bool SsnLenghtIs10()
        {
            if (TextLengthIsMax(ssnTxtbox.Text, 10))
            {
                ssnError.Visible = false;
                return true;
            }

            ssnError.Visible = true;
            return false;

        }
        bool PhoneNumberLenghtIs11()
        {
            Console.WriteLine(phNumberTxtbox.Text.Length);
            if (TextLengthIsMax(phNumberTxtbox.Text, 11))
            {
                phoneNumberError.Visible = false;
                return true;
            }

            phoneNumberError.Visible = true;
            return false;

        }

        bool PostNumberLenghtIs10()
        {
            if (TextLengthIsMax(postNumberTxtBox.Text, 10))
            {
                postNumberError.Visible = false;
                return true;
            }
            postNumberError.Visible = true;
            return false;

        }
        bool TextLengthIsMax(string text, int maxLength)
        {
            return text.Length == maxLength;
        }

        void InitCustomerDataGridView()
        {
            Customer_View_Form customer_view = new Customer_View_Form();
            customer_view.InitDataGridView();
        }

    }
}
