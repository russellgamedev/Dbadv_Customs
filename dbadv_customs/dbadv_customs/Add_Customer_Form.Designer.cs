﻿namespace dbadv_customs
{
    partial class Add_Customer_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.postNumberError = new System.Windows.Forms.Label();
            this.phoneNumberError = new System.Windows.Forms.Label();
            this.ssnError = new System.Windows.Forms.Label();
            this.ConfirmCustomerBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.postNumberTxtBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.plaqueTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.streetTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.countryTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cityTxtBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.emailTxtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phNumberTxtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ssnTxtbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lnameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fnameTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // postNumberError
            // 
            this.postNumberError.AutoSize = true;
            this.postNumberError.ForeColor = System.Drawing.Color.Red;
            this.postNumberError.Location = new System.Drawing.Point(544, 336);
            this.postNumberError.Name = "postNumberError";
            this.postNumberError.Size = new System.Drawing.Size(87, 16);
            this.postNumberError.TabIndex = 49;
            this.postNumberError.Text = "10 characters";
            this.postNumberError.Visible = false;
            // 
            // phoneNumberError
            // 
            this.phoneNumberError.AutoSize = true;
            this.phoneNumberError.ForeColor = System.Drawing.Color.Red;
            this.phoneNumberError.Location = new System.Drawing.Point(556, 134);
            this.phoneNumberError.Name = "phoneNumberError";
            this.phoneNumberError.Size = new System.Drawing.Size(87, 16);
            this.phoneNumberError.TabIndex = 48;
            this.phoneNumberError.Text = "11 characters";
            this.phoneNumberError.Visible = false;
            // 
            // ssnError
            // 
            this.ssnError.AutoSize = true;
            this.ssnError.ForeColor = System.Drawing.Color.Red;
            this.ssnError.Location = new System.Drawing.Point(191, 134);
            this.ssnError.Name = "ssnError";
            this.ssnError.Size = new System.Drawing.Size(87, 16);
            this.ssnError.TabIndex = 47;
            this.ssnError.Text = "10 characters";
            this.ssnError.Visible = false;
            // 
            // ConfirmCustomerBtn
            // 
            this.ConfirmCustomerBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.ConfirmCustomerBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ConfirmCustomerBtn.Location = new System.Drawing.Point(332, 400);
            this.ConfirmCustomerBtn.Name = "ConfirmCustomerBtn";
            this.ConfirmCustomerBtn.Size = new System.Drawing.Size(142, 38);
            this.ConfirmCustomerBtn.TabIndex = 46;
            this.ConfirmCustomerBtn.Text = "Confirm";
            this.ConfirmCustomerBtn.UseVisualStyleBackColor = false;
            this.ConfirmCustomerBtn.Click += new System.EventHandler(this.ConfirmCustomerBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(292, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 32);
            this.label11.TabIndex = 45;
            this.label11.Text = "Create Customer";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label11.UseCompatibleTextRendering = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(453, 336);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 44;
            this.label9.Text = "Post Number*";
            // 
            // postNumberTxtBox
            // 
            this.postNumberTxtBox.Location = new System.Drawing.Point(456, 355);
            this.postNumberTxtBox.Name = "postNumberTxtBox";
            this.postNumberTxtBox.Size = new System.Drawing.Size(197, 22);
            this.postNumberTxtBox.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 16);
            this.label10.TabIndex = 42;
            this.label10.Text = "Plaque*";
            // 
            // plaqueTxtBox
            // 
            this.plaqueTxtBox.Location = new System.Drawing.Point(158, 355);
            this.plaqueTxtBox.Name = "plaqueTxtBox";
            this.plaqueTxtBox.Size = new System.Drawing.Size(197, 22);
            this.plaqueTxtBox.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(453, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "Street*";
            // 
            // streetTxtBox
            // 
            this.streetTxtBox.Location = new System.Drawing.Point(456, 288);
            this.streetTxtBox.Name = "streetTxtBox";
            this.streetTxtBox.Size = new System.Drawing.Size(197, 22);
            this.streetTxtBox.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Country*";
            // 
            // countryTxtBox
            // 
            this.countryTxtBox.Location = new System.Drawing.Point(158, 288);
            this.countryTxtBox.Name = "countryTxtBox";
            this.countryTxtBox.Size = new System.Drawing.Size(197, 22);
            this.countryTxtBox.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(453, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "City*";
            // 
            // cityTxtBox
            // 
            this.cityTxtBox.Location = new System.Drawing.Point(456, 217);
            this.cityTxtBox.Name = "cityTxtBox";
            this.cityTxtBox.Size = new System.Drawing.Size(197, 22);
            this.cityTxtBox.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Email*";
            // 
            // emailTxtbox
            // 
            this.emailTxtbox.Location = new System.Drawing.Point(158, 217);
            this.emailTxtbox.Name = "emailTxtbox";
            this.emailTxtbox.Size = new System.Drawing.Size(197, 22);
            this.emailTxtbox.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Phone Number*";
            // 
            // phNumberTxtbox
            // 
            this.phNumberTxtbox.Location = new System.Drawing.Point(456, 153);
            this.phNumberTxtbox.Name = "phNumberTxtbox";
            this.phNumberTxtbox.Size = new System.Drawing.Size(197, 22);
            this.phNumberTxtbox.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Ssn*";
            // 
            // ssnTxtbox
            // 
            this.ssnTxtbox.Location = new System.Drawing.Point(158, 153);
            this.ssnTxtbox.Name = "ssnTxtbox";
            this.ssnTxtbox.Size = new System.Drawing.Size(197, 22);
            this.ssnTxtbox.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Last Name*";
            // 
            // lnameTxtBox
            // 
            this.lnameTxtBox.Location = new System.Drawing.Point(456, 82);
            this.lnameTxtBox.Name = "lnameTxtBox";
            this.lnameTxtBox.Size = new System.Drawing.Size(197, 22);
            this.lnameTxtBox.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "First Name*";
            // 
            // fnameTxtBox
            // 
            this.fnameTxtBox.Location = new System.Drawing.Point(158, 82);
            this.fnameTxtBox.Name = "fnameTxtBox";
            this.fnameTxtBox.Size = new System.Drawing.Size(197, 22);
            this.fnameTxtBox.TabIndex = 25;
            // 
            // Add_Customer_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.postNumberError);
            this.Controls.Add(this.phoneNumberError);
            this.Controls.Add(this.ssnError);
            this.Controls.Add(this.ConfirmCustomerBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.postNumberTxtBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.plaqueTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.streetTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.countryTxtBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cityTxtBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.emailTxtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.phNumberTxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ssnTxtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnameTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fnameTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Add_Customer_Form";
            this.Text = "Add_Customer_Form";
            this.Load += new System.EventHandler(this.Add_Customer_FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label postNumberError;
        private System.Windows.Forms.Label phoneNumberError;
        private System.Windows.Forms.Label ssnError;
        private System.Windows.Forms.Button ConfirmCustomerBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox postNumberTxtBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox plaqueTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox streetTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox countryTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cityTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox emailTxtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox phNumberTxtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ssnTxtbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lnameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fnameTxtBox;
    }
}