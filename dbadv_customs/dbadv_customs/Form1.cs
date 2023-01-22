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

        private void ConfirmCustomerBtn_Click(object sender, EventArgs e)
        {
            if (!SsnLenghtIs10()) return;
            if (!PhoneNumberLenghtIs11()) return;
            if (!PostNumberLenghtIs10()) return;
            if (!TextBoxIsNull()) return;

            Console.WriteLine("Customer Added To db");
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
            if (TextLengthIsMax(phoneNumberError.Text, 11))
            {
                phoneNumberError.Visible = false;
                return true;
            }
        
            phoneNumberError.Visible = true;
            return false;

        }

        bool PostNumberLenghtIs10()
        {
            if (TextLengthIsMax(ssnTxtbox.Text, 10))
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

    }
}
