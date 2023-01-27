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
    public partial class Sub_Customer_View_Form : Form
    {
        public Sub_Customer_View_Form()
        {
            InitializeComponent();                    

            dataGridView1.DataSource = DatabaseManager
                .GetDataTableFromQuery(DatabaseManager.subCustomerViewQuery);
        }



        private void Sub_Customer_View_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
