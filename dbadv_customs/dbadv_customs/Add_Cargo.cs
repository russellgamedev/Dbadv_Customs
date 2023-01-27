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
    public partial class Add_Cargo : Form
    {
        List<Customer> customerList = new List<Customer>();
        List<Store> storeList = new List<Store>();
        public Add_Cargo()
        {
            InitializeComponent();
            InitCustomerComboBox();
            InitStoreComboBox();
        }

        private void Add_Cargo_Load(object sender, EventArgs e)
        {

        }


        private void CargoConfirmBtn_Click_1(object sender, EventArgs e)
        {
            if (TxtBoxIsNull())
            {
                MessageBox.Show("Please Complete form!");
                return;
            }

            if (!ComboBoxIsSelected(customerComboBox))
            {
                MessageBox.Show("Please Select Customer");
                return;
            }

            if (!ComboBoxIsSelected(storeComboBox))
            {
                MessageBox.Show("Please Select Store");
            }

            InsertToCargoTable();

        }

        void InsertToCargoTable()
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(DatabaseManager.connection_String);
                conn.Open();

                string query = "Insert into Cargo " +
                    "(cargo_status, cargo_name, cargo_origin, cargo_volume, cargo_weight," +
                    "cargo_city, cargo_country, cargo_has_fac, customer_has, empl_confirm," +
                    "enter_date, exit_date, enter_cargo, exit_cargo)" +
                    "values (@cargo_status, @cargo_name, @cargo_origin, @cargo_volume, @cargo_weight," +
                    "@cargo_city, @cargo_country, @cargo_has_fac, @customer_has, @empl_confirm," +
                    "@enter_date, @exit_date, @enter_cargo, @exit_cargo)";

                NpgsqlCommand comm = new NpgsqlCommand(query, conn);
                //comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@cargo_status", "in store");
                comm.Parameters.AddWithValue("@cargo_name", cargoNameTxtBox.Text);
                comm.Parameters.AddWithValue("@cargo_origin", originTxtBox.Text);
                comm.Parameters.AddWithValue("@cargo_volume", float.Parse(volumeTxtBox.Text));
                comm.Parameters.AddWithValue("@cargo_weight", float.Parse(weightTxtBox.Text));
                comm.Parameters.AddWithValue("@cargo_city", cityTxtBox.Text);
                comm.Parameters.AddWithValue("@cargo_country", countryTxtBox.Text);
                comm.Parameters.AddWithValue("@cargo_has_fac", DBNull.Value);
                comm.Parameters.AddWithValue("@customer_has", GetComboBoxItem(customerComboBox));
                // default empl
                comm.Parameters.AddWithValue("@empl_confirm", 1);
                comm.Parameters.AddWithValue("@enter_date", DateTime.Now);
                comm.Parameters.AddWithValue("@exit_date", DBNull.Value);
                comm.Parameters.AddWithValue("@enter_cargo", int.Parse(GetComboBoxItem(storeComboBox)));
                comm.Parameters.AddWithValue("@exit_cargo", DBNull.Value);

                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();

                MessageBox.Show("Cargo Added", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        bool ComboBoxIsSelected(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == -1) return false;
            return true;
        }

        string GetComboBoxItem(ComboBox comboBox)
        {
            string item = "";

            item = comboBox.SelectedItem.ToString();

            string[] itemSplited = item.Split(':', ' ');

            return itemSplited[itemSplited.Length - 1];
        }

        bool TxtBoxIsNull()
        {
            if (cargoNameTxtBox.Text == "") return true;
            if (originTxtBox.Text == "") return true;
            if (volumeTxtBox.Text == "") return true;
            if (weightTxtBox.Text == "") return true;
            if (countryTxtBox.Text == "") return true;
            if (cityTxtBox.Text == "") return true;
            return false;
        }

        void InitCustomerComboBox()
        {
            SetCustomerList();

            for (int i = 0; i < customerList.Count; i++)
            {
                string item = customerList[i].cstmFname + " " +
                            customerList[i].cstmLname + " : " +
                            customerList[i].cstmSsn;

                customerComboBox.Items.Add(item);
            }
        }

        void InitStoreComboBox()
        {
            SetStoreList();
            for (int i = 0; i < storeList.Count; i++)
            {
                storeComboBox.Items.Add(storeList[i].storeName + " : " +
                    storeList[i].storeId);
            }
        }


        void SetCustomerList()
        {
            //List<Customer> customerList = new List<Customer>();

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

        void SetStoreList()
        {
            string query = "Select * from store";
            DataTable dt = new DataTable();
            dt = DatabaseManager.GetDataTableFromQuery(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drow = dt.Rows[i];
                Store store = new Store(int.Parse(drow[0].ToString()),
                    drow[1].ToString());
                storeList.Add(store);
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

        class Store
        {
            public string storeName;
            public int storeId;
            public Store(int storeId, string storeName)
            {
                this.storeId = storeId;
                this.storeName = storeName;
            }
        }
    }
}
