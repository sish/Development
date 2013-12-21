namespace CreditCard
{
    partial class CreditCard
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
            this.tbx_firstname = new System.Windows.Forms.TextBox();
            this.tbx_lastname = new System.Windows.Forms.TextBox();
            this.rdb_bank = new System.Windows.Forms.RadioButton();
            this.rdb_creditcard = new System.Windows.Forms.RadioButton();
            this.lbl_firstname = new System.Windows.Forms.Label();
            this.lbl_lastname = new System.Windows.Forms.Label();
            this.lbl_paymenttype = new System.Windows.Forms.Label();
            this.btn_create = new System.Windows.Forms.Button();
            this.tbx_masswithdraw = new System.Windows.Forms.TextBox();
            this.btn_debitall = new System.Windows.Forms.Button();
            this.btn_clean = new System.Windows.Forms.Button();
            this.lbx_customers = new System.Windows.Forms.ListBox();
            this.btn_listcustomers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_firstname
            // 
            this.tbx_firstname.Location = new System.Drawing.Point(73, 12);
            this.tbx_firstname.Name = "tbx_firstname";
            this.tbx_firstname.Size = new System.Drawing.Size(131, 20);
            this.tbx_firstname.TabIndex = 0;
            this.tbx_firstname.TextChanged += new System.EventHandler(this.tbx_firstname_TextChanged);
            // 
            // tbx_lastname
            // 
            this.tbx_lastname.Location = new System.Drawing.Point(73, 38);
            this.tbx_lastname.Name = "tbx_lastname";
            this.tbx_lastname.Size = new System.Drawing.Size(131, 20);
            this.tbx_lastname.TabIndex = 1;
            this.tbx_lastname.TextChanged += new System.EventHandler(this.tbx_lastname_TextChanged);
            // 
            // rdb_bank
            // 
            this.rdb_bank.AutoSize = true;
            this.rdb_bank.Location = new System.Drawing.Point(78, 64);
            this.rdb_bank.Name = "rdb_bank";
            this.rdb_bank.Size = new System.Drawing.Size(50, 17);
            this.rdb_bank.TabIndex = 2;
            this.rdb_bank.TabStop = true;
            this.rdb_bank.Text = "Bank";
            this.rdb_bank.UseVisualStyleBackColor = true;
            // 
            // rdb_creditcard
            // 
            this.rdb_creditcard.AutoSize = true;
            this.rdb_creditcard.Location = new System.Drawing.Point(134, 64);
            this.rdb_creditcard.Name = "rdb_creditcard";
            this.rdb_creditcard.Size = new System.Drawing.Size(70, 17);
            this.rdb_creditcard.TabIndex = 3;
            this.rdb_creditcard.TabStop = true;
            this.rdb_creditcard.Text = "Kreditkort";
            this.rdb_creditcard.UseVisualStyleBackColor = true;
            // 
            // lbl_firstname
            // 
            this.lbl_firstname.AutoSize = true;
            this.lbl_firstname.Location = new System.Drawing.Point(12, 15);
            this.lbl_firstname.Name = "lbl_firstname";
            this.lbl_firstname.Size = new System.Drawing.Size(48, 13);
            this.lbl_firstname.TabIndex = 4;
            this.lbl_firstname.Text = "Förnamn";
            // 
            // lbl_lastname
            // 
            this.lbl_lastname.AutoSize = true;
            this.lbl_lastname.Location = new System.Drawing.Point(12, 41);
            this.lbl_lastname.Name = "lbl_lastname";
            this.lbl_lastname.Size = new System.Drawing.Size(55, 13);
            this.lbl_lastname.TabIndex = 5;
            this.lbl_lastname.Text = "Efternamn";
            // 
            // lbl_paymenttype
            // 
            this.lbl_paymenttype.AutoSize = true;
            this.lbl_paymenttype.Location = new System.Drawing.Point(12, 66);
            this.lbl_paymenttype.Name = "lbl_paymenttype";
            this.lbl_paymenttype.Size = new System.Drawing.Size(60, 13);
            this.lbl_paymenttype.TabIndex = 6;
            this.lbl_paymenttype.Text = "Betalmetod";
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(129, 87);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 7;
            this.btn_create.Text = "Skapa";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // tbx_masswithdraw
            // 
            this.tbx_masswithdraw.Location = new System.Drawing.Point(12, 167);
            this.tbx_masswithdraw.Name = "tbx_masswithdraw";
            this.tbx_masswithdraw.Size = new System.Drawing.Size(88, 20);
            this.tbx_masswithdraw.TabIndex = 8;
            // 
            // btn_debitall
            // 
            this.btn_debitall.Location = new System.Drawing.Point(106, 165);
            this.btn_debitall.Name = "btn_debitall";
            this.btn_debitall.Size = new System.Drawing.Size(98, 23);
            this.btn_debitall.TabIndex = 9;
            this.btn_debitall.Text = "Debitera Kunder";
            this.btn_debitall.UseVisualStyleBackColor = true;
            this.btn_debitall.Click += new System.EventHandler(this.btn_debitall_Click);
            // 
            // btn_clean
            // 
            this.btn_clean.Location = new System.Drawing.Point(12, 87);
            this.btn_clean.Name = "btn_clean";
            this.btn_clean.Size = new System.Drawing.Size(111, 23);
            this.btn_clean.TabIndex = 10;
            this.btn_clean.Text = "Rensa Formulär";
            this.btn_clean.UseVisualStyleBackColor = true;
            this.btn_clean.Click += new System.EventHandler(this.btn_clean_Click);
            // 
            // lbx_customers
            // 
            this.lbx_customers.FormattingEnabled = true;
            this.lbx_customers.Location = new System.Drawing.Point(210, 12);
            this.lbx_customers.Name = "lbx_customers";
            this.lbx_customers.Size = new System.Drawing.Size(195, 147);
            this.lbx_customers.TabIndex = 11;
            // 
            // btn_listcustomers
            // 
            this.btn_listcustomers.Location = new System.Drawing.Point(330, 164);
            this.btn_listcustomers.Name = "btn_listcustomers";
            this.btn_listcustomers.Size = new System.Drawing.Size(75, 23);
            this.btn_listcustomers.TabIndex = 12;
            this.btn_listcustomers.Text = "Lista Kunder";
            this.btn_listcustomers.UseVisualStyleBackColor = true;
            this.btn_listcustomers.Click += new System.EventHandler(this.btn_listcustomers_Click);
            // 
            // CreditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 199);
            this.Controls.Add(this.btn_listcustomers);
            this.Controls.Add(this.lbx_customers);
            this.Controls.Add(this.btn_clean);
            this.Controls.Add(this.btn_debitall);
            this.Controls.Add(this.tbx_masswithdraw);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.lbl_paymenttype);
            this.Controls.Add(this.lbl_lastname);
            this.Controls.Add(this.lbl_firstname);
            this.Controls.Add(this.rdb_creditcard);
            this.Controls.Add(this.rdb_bank);
            this.Controls.Add(this.tbx_lastname);
            this.Controls.Add(this.tbx_firstname);
            this.Name = "CreditCard";
            this.Text = "Uppgift Kreditkort - Andreas Joelsson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_firstname;
        private System.Windows.Forms.TextBox tbx_lastname;
        private System.Windows.Forms.RadioButton rdb_bank;
        private System.Windows.Forms.RadioButton rdb_creditcard;
        private System.Windows.Forms.Label lbl_firstname;
        private System.Windows.Forms.Label lbl_lastname;
        private System.Windows.Forms.Label lbl_paymenttype;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox tbx_masswithdraw;
        private System.Windows.Forms.Button btn_debitall;
        private System.Windows.Forms.Button btn_clean;
        private System.Windows.Forms.ListBox lbx_customers;
        private System.Windows.Forms.Button btn_listcustomers;
    }
}

