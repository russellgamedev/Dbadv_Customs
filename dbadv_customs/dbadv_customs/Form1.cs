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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Add_Customer_button_Click(object sender, EventArgs e)
        {
            Add_Customer_Form customer_Form = new Add_Customer_Form();
            customer_Form.Show();
        }

        private void Customer_List_button_Click(object sender, EventArgs e)
        {
            Customer_View_Form customer_View = new Customer_View_Form();
            customer_View.Show();
        }

        private void Add_Cargo_button_Click(object sender, EventArgs e)
        {
            Add_Cargo add_Cargo = new Add_Cargo();
            add_Cargo.Show();
        }

        private void Store_List_button_Click(object sender, EventArgs e)
        {
            Store_View storeView = new Store_View();
            storeView.Show();
        }
    }

    

}
