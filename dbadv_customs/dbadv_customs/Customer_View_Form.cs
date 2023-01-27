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
            InitDataGridView();           
        }


        public void InitDataGridView()
        {
            DataTable dataTable = new DataTable();
            dataTable.Clear();
            dataGridView1.DataSource = dataTable;

            try
            {
                dataTable = DatabaseManager
                    .GetDataTableFromQuery("Select * from customer");
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Customer_View_Form_Load(object sender, EventArgs e)
        {

        }

        private void Same_City_button_Click(object sender, EventArgs e)
        {
            CloseOpenedWin();

            DatabaseManager.subCustomerViewQuery =
                "SELECT customer_fname, customer_lname, customer_city " +
                "FROM customer " +
                "JOIN(SELECT customer_city " +
                "FROM customer GROUP BY customer_city " +
                "HAVING count(*) > 1) AS cities " +
                "USING(customer_city)";

            OpenSubWinForm();
        }

        private void Cargo_Counter_button_Click(object sender, EventArgs e)
        {
            CloseOpenedWin();

            DatabaseManager.subCustomerViewQuery = "Select customer_fname, customer_lname, " +
                        "count(customer_ssn) as cargo_count " +
                        "from customer " +
                        "join cargo on cargo.customer_has = customer_ssn " +
                        "group by customer_ssn";

            OpenSubWinForm();
        }


        private void City_Counter_button_Click(object sender, EventArgs e)
        {
            CloseOpenedWin();
            DatabaseManager.subCustomerViewQuery = 
                "select customer_city, count(*) from " +
                "customer group by customer_city";
            OpenSubWinForm();
        }

        void CloseOpenedWin()
        {
            CloseWinWithName("Sub_Customer_View_Form");
            CloseWinWithName("Customer_Update_Form");
            CloseWinWithName("Add_Customer_Form");
            CloseWinWithName("Delete_Customer_Form");
        }

        void OpenSubWinForm()
        {
            Sub_Customer_View_Form subWin = new Sub_Customer_View_Form();
            subWin.Show();
        }

        void CloseWinWithName(string winName)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form form in fc)
            {
                if (form.Name == winName)
                {
                    form.Close();
                    break;
                }
            }
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            CloseOpenedWin();

            Customer_Update_Form updateWin = new Customer_Update_Form();
            updateWin.Show();
        }

        private void Add_Customer_button_Click(object sender, EventArgs e)
        {
            CloseOpenedWin();
            Add_Customer_Form customer_form = new Add_Customer_Form();
            customer_form.Show();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            CloseOpenedWin();
            Delete_Customer_Form delete_form = new Delete_Customer_Form();
            delete_form.Show();
        }
    }
}
