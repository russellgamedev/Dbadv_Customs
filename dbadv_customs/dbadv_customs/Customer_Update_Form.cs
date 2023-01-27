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
    public partial class Customer_Update_Form : Form
    {
        List<Customer> customerList = new List<Customer>();

        public Customer_Update_Form()
        {
            InitializeComponent();
            InitCustomerComboBox();

        }

        private void Customer_Update_Form_Load(object sender, EventArgs e)
        {

        }

        void InitCustomerComboBox()
        {

            //customerComboBox.SelectedIndex = -1;
            customerComboBox.Items.Clear();
            SetCustomerList();
            for (int i = 0; i < customerList.Count; i++)
            {
                string item = customerList[i].cstmFname + " " +
                            customerList[i].cstmLname + " : " +
                            customerList[i].cstmSsn;

                customerComboBox.Items.Add(item);
            }

            customerComboBox.SelectedIndex = GetCustomerIndex();

        }

        int GetCustomerIndex()
        {
            string[] ssnItems = new string[customerComboBox.Items.Count];
            string[] ssnSplited = null;
            for (int i = 0; i < customerComboBox.Items.Count; i++)
            {
                ssnItems[i] = customerComboBox.Items[i] as string;
                ssnSplited = ssnItems[i].Split(' ', ':');
                ssnItems[i] = ssnSplited[ssnSplited.Length - 1];
            }

            for (int i = 0; i < ssnItems.Length; i++)            
            {
                if (ssnItems[i] == ssnTxtbox.Text)
                {                    
                    return i;
                }
            }

            return -1;
        }


        void SetCustomerList()
        {
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
                        drow[2].ToString(),
                        drow[3].ToString(),
                        drow[4].ToString(),
                        drow[5].ToString(),
                        drow[6].ToString(), 
                        drow[7].ToString(),
                        drow[8].ToString(),
                        drow[9].ToString());
                    customerList.Add(cstm);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer customer = FindCustomer(GetCustomerSsnFromCombobox());
            if (customer == null) return;

            fnameTxtBox.Text = customer.cstmFname;
            lnameTxtBox.Text = customer.cstmLname;
            ssnTxtbox.Text = customer.cstmSsn;
            phNumberTxtbox.Text = customer.cstmNumber;
            emailTxtbox.Text = customer.cstmEmail;
            cityTxtBox.Text = customer.cstmCity;
            countryTxtBox.Text = customer.cstmCountry;
            streetTxtBox.Text = customer.cstmStreet;
            plaqueTxtBox.Text = customer.cstmPlaque;
            postNumberTxtBox.Text = customer.cstmPostNumber;
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

        Customer FindCustomer(string ssn)
        {
            Customer customer = null;
            foreach (Customer c in customerList)
            {
                if (c.cstmSsn.Equals(ssn))
                {
                    customer = c;
                    break;
                }
            }
            return customer;
        }
        private void Update_button_Click(object sender, EventArgs e)
        {
            if (!SsnLenghtIs10()) return;
            if (!PhoneNumberLenghtIs11()) return;
            if (!PostNumberLenghtIs10()) return;
            if (TextBoxIsNull())
            {
                MessageBox.Show("Please Complete form!");
                return;
            }

            try
            {
                string myCustomerSsn = GetCustomerSsnFromCombobox();
                string query = "UPDATE Customer Set " +
                    "customer_fname = @customer_fname, " +
                    "customer_lname = @customer_lname, " +
                    "customer_ssn = @customer_ssn, " +
                    "customer_number = @customer_number, " +
                    "customer_email = @customer_email, " +
                    "customer_country = @customer_country, " +
                    "customer_city = @customer_city, " +
                    "customer_postal_code = @customer_postal_code, " +
                    "customer_street = @customer_street, " +
                    "customer_plaque = @customer_plaque " +
                    "where customer_ssn = @myCustomerSsn";

                
                NpgsqlConnection conn = new NpgsqlConnection
                    (DatabaseManager.connection_String);
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = query;
                comm.Parameters.AddWithValue("@customer_fname", fnameTxtBox.Text);
                comm.Parameters.AddWithValue("@customer_lname", lnameTxtBox.Text);
                comm.Parameters.AddWithValue("@customer_ssn", ssnTxtbox.Text);
                comm.Parameters.AddWithValue("@customer_number", phNumberTxtbox.Text);
                comm.Parameters.AddWithValue("@customer_email", emailTxtbox.Text);
                comm.Parameters.AddWithValue("@customer_country", countryTxtBox.Text);
                comm.Parameters.AddWithValue("@customer_city", cityTxtBox.Text);
                comm.Parameters.AddWithValue("@customer_postal_code", postNumberTxtBox.Text);
                comm.Parameters.AddWithValue("@customer_street", streetTxtBox.Text);
                comm.Parameters.AddWithValue("@customer_plaque", int.Parse(plaqueTxtBox.Text));
                comm.Parameters.AddWithValue("@myCustomerSsn", myCustomerSsn);
                comm.ExecuteNonQuery();

                InitCustomerDataGridView();
                InitCustomerComboBox();
                MessageBox.Show("Customer Updated!", "Update!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            
            Customer_View_Form customer_view =
                   GetWinWithName("Customer_View_Form");
            customer_view.InitDataGridView();
        }

        Customer_View_Form GetWinWithName(string winName)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form form in fc)
            {
                if (form.Name == winName)
                {
                    return form as Customer_View_Form;                    
                }
            }

            return null;
        }

        class Customer
        {
            public string cstmFname;
            public string cstmLname;
            public string cstmSsn;
            public string cstmNumber;
            public string cstmEmail;
            public string cstmCountry;
            public string cstmCity;
            public string cstmPostNumber;
            public string cstmStreet;
            public string cstmPlaque;
            public Customer(string cstmFname, string cstmLname, string cstmSsn, 
                string cstmNumber, string cstmEmail, string cstmCountry, 
                string cstmCity, string cstmPostalCode, string cstmStreet, 
                string cstmPlaque)
            {
                this.cstmFname = cstmFname;
                this.cstmLname = cstmLname;
                this.cstmSsn = cstmSsn;
                this.cstmNumber = cstmNumber;
                this.cstmEmail = cstmEmail;
                this.cstmCountry = cstmCountry;
                this.cstmCity = cstmCity;
                this.cstmPostNumber = cstmPostalCode;
                this.cstmStreet = cstmStreet;
                this.cstmPlaque = cstmPlaque;
            }
        }

    }
}
