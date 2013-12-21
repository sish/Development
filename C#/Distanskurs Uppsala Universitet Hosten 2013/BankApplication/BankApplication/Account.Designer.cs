namespace BankApplication
{
    partial class Account
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
            this.lbx_accounts = new System.Windows.Forms.ListBox();
            this.tbx_create = new System.Windows.Forms.TextBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.tbx_modify = new System.Windows.Forms.TextBox();
            this.btn_deposit = new System.Windows.Forms.Button();
            this.btn_withdraw = new System.Windows.Forms.Button();
            this.lbl_saldo = new System.Windows.Forms.Label();
            this.lbl_interest = new System.Windows.Forms.Label();
            this.tbx_interest = new System.Windows.Forms.TextBox();
            this.lbl_depwith = new System.Windows.Forms.Label();
            this.lbl_firstname = new System.Windows.Forms.Label();
            this.tbx_firstname = new System.Windows.Forms.TextBox();
            this.lbl_lastname = new System.Windows.Forms.Label();
            this.tbx_lastname = new System.Windows.Forms.TextBox();
            this.btn_changeIntrest = new System.Windows.Forms.Button();
            this.btn_addIntrest = new System.Windows.Forms.Button();
            this.lbl_percentage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbx_accounts
            // 
            this.lbx_accounts.FormattingEnabled = true;
            this.lbx_accounts.Location = new System.Drawing.Point(12, 12);
            this.lbx_accounts.Name = "lbx_accounts";
            this.lbx_accounts.Size = new System.Drawing.Size(222, 303);
            this.lbx_accounts.TabIndex = 11;
            this.lbx_accounts.SelectedIndexChanged += new System.EventHandler(this.lbx_accounts_SelectedIndexChanged);
            // 
            // tbx_create
            // 
            this.tbx_create.Location = new System.Drawing.Point(280, 66);
            this.tbx_create.Name = "tbx_create";
            this.tbx_create.Size = new System.Drawing.Size(60, 20);
            this.tbx_create.TabIndex = 3;
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(447, 63);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 5;
            this.btn_create.Text = "Skapa";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // tbx_modify
            // 
            this.tbx_modify.Location = new System.Drawing.Point(280, 95);
            this.tbx_modify.Name = "tbx_modify";
            this.tbx_modify.Size = new System.Drawing.Size(99, 20);
            this.tbx_modify.TabIndex = 7;
            this.tbx_modify.TextChanged += new System.EventHandler(this.tbx_modify_TextChanged);
            // 
            // btn_deposit
            // 
            this.btn_deposit.Location = new System.Drawing.Point(385, 92);
            this.btn_deposit.Name = "btn_deposit";
            this.btn_deposit.Size = new System.Drawing.Size(60, 23);
            this.btn_deposit.TabIndex = 8;
            this.btn_deposit.Text = "Sätt In";
            this.btn_deposit.UseVisualStyleBackColor = true;
            this.btn_deposit.Click += new System.EventHandler(this.btn_deposit_Click);
            // 
            // btn_withdraw
            // 
            this.btn_withdraw.Location = new System.Drawing.Point(451, 92);
            this.btn_withdraw.Name = "btn_withdraw";
            this.btn_withdraw.Size = new System.Drawing.Size(56, 23);
            this.btn_withdraw.TabIndex = 9;
            this.btn_withdraw.Text = "Ta Ut";
            this.btn_withdraw.UseVisualStyleBackColor = true;
            this.btn_withdraw.Click += new System.EventHandler(this.btn_withdraw_Click);
            // 
            // lbl_saldo
            // 
            this.lbl_saldo.AutoSize = true;
            this.lbl_saldo.Location = new System.Drawing.Point(240, 68);
            this.lbl_saldo.Name = "lbl_saldo";
            this.lbl_saldo.Size = new System.Drawing.Size(34, 13);
            this.lbl_saldo.TabIndex = 6;
            this.lbl_saldo.Text = "Saldo";
            // 
            // lbl_interest
            // 
            this.lbl_interest.AutoSize = true;
            this.lbl_interest.Location = new System.Drawing.Point(343, 69);
            this.lbl_interest.Name = "lbl_interest";
            this.lbl_interest.Size = new System.Drawing.Size(36, 13);
            this.lbl_interest.TabIndex = 7;
            this.lbl_interest.Text = "Ränta";
            // 
            // tbx_interest
            // 
            this.tbx_interest.Location = new System.Drawing.Point(385, 65);
            this.tbx_interest.Name = "tbx_interest";
            this.tbx_interest.Size = new System.Drawing.Size(41, 20);
            this.tbx_interest.TabIndex = 4;
            this.tbx_interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbx_interest.TextChanged += new System.EventHandler(this.tbx_interest_TextChanged);
            // 
            // lbl_depwith
            // 
            this.lbl_depwith.AutoSize = true;
            this.lbl_depwith.Location = new System.Drawing.Point(239, 98);
            this.lbl_depwith.Name = "lbl_depwith";
            this.lbl_depwith.Size = new System.Drawing.Size(40, 13);
            this.lbl_depwith.TabIndex = 9;
            this.lbl_depwith.Text = "Belopp";
            // 
            // lbl_firstname
            // 
            this.lbl_firstname.AutoSize = true;
            this.lbl_firstname.Location = new System.Drawing.Point(240, 12);
            this.lbl_firstname.Name = "lbl_firstname";
            this.lbl_firstname.Size = new System.Drawing.Size(48, 13);
            this.lbl_firstname.TabIndex = 10;
            this.lbl_firstname.Text = "Förnamn";
            // 
            // tbx_firstname
            // 
            this.tbx_firstname.Location = new System.Drawing.Point(294, 9);
            this.tbx_firstname.Name = "tbx_firstname";
            this.tbx_firstname.Size = new System.Drawing.Size(311, 20);
            this.tbx_firstname.TabIndex = 1;
            // 
            // lbl_lastname
            // 
            this.lbl_lastname.AutoSize = true;
            this.lbl_lastname.Location = new System.Drawing.Point(239, 38);
            this.lbl_lastname.Name = "lbl_lastname";
            this.lbl_lastname.Size = new System.Drawing.Size(55, 13);
            this.lbl_lastname.TabIndex = 12;
            this.lbl_lastname.Text = "Efternamn";
            // 
            // tbx_lastname
            // 
            this.tbx_lastname.Location = new System.Drawing.Point(294, 35);
            this.tbx_lastname.Name = "tbx_lastname";
            this.tbx_lastname.Size = new System.Drawing.Size(311, 20);
            this.tbx_lastname.TabIndex = 2;
            // 
            // btn_changeIntrest
            // 
            this.btn_changeIntrest.Location = new System.Drawing.Point(528, 64);
            this.btn_changeIntrest.Name = "btn_changeIntrest";
            this.btn_changeIntrest.Size = new System.Drawing.Size(79, 23);
            this.btn_changeIntrest.TabIndex = 6;
            this.btn_changeIntrest.Text = "Ändra Ränta";
            this.btn_changeIntrest.UseVisualStyleBackColor = true;
            this.btn_changeIntrest.Click += new System.EventHandler(this.btn_changeIntrest_Click);
            // 
            // btn_addIntrest
            // 
            this.btn_addIntrest.Location = new System.Drawing.Point(513, 92);
            this.btn_addIntrest.Name = "btn_addIntrest";
            this.btn_addIntrest.Size = new System.Drawing.Size(92, 23);
            this.btn_addIntrest.TabIndex = 10;
            this.btn_addIntrest.Text = "Addera Ränta";
            this.btn_addIntrest.UseVisualStyleBackColor = true;
            this.btn_addIntrest.Click += new System.EventHandler(this.btn_addIntrest_Click);
            // 
            // lbl_percentage
            // 
            this.lbl_percentage.AutoSize = true;
            this.lbl_percentage.Location = new System.Drawing.Point(430, 69);
            this.lbl_percentage.Name = "lbl_percentage";
            this.lbl_percentage.Size = new System.Drawing.Size(15, 13);
            this.lbl_percentage.TabIndex = 16;
            this.lbl_percentage.Text = "%";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 333);
            this.Controls.Add(this.lbl_percentage);
            this.Controls.Add(this.btn_addIntrest);
            this.Controls.Add(this.btn_changeIntrest);
            this.Controls.Add(this.tbx_lastname);
            this.Controls.Add(this.lbl_lastname);
            this.Controls.Add(this.tbx_firstname);
            this.Controls.Add(this.lbl_firstname);
            this.Controls.Add(this.lbl_depwith);
            this.Controls.Add(this.tbx_interest);
            this.Controls.Add(this.lbl_interest);
            this.Controls.Add(this.lbl_saldo);
            this.Controls.Add(this.btn_withdraw);
            this.Controls.Add(this.btn_deposit);
            this.Controls.Add(this.tbx_modify);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.tbx_create);
            this.Controls.Add(this.lbx_accounts);
            this.Name = "Account";
            this.Text = "Inlämningsuppgift 1 Bankkonto av Andreas Joelsson 2013-09";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_accounts;
        private System.Windows.Forms.TextBox tbx_create;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox tbx_modify;
        private System.Windows.Forms.Button btn_deposit;
        private System.Windows.Forms.Button btn_withdraw;
        private System.Windows.Forms.Label lbl_saldo;
        private System.Windows.Forms.Label lbl_interest;
        private System.Windows.Forms.TextBox tbx_interest;
        private System.Windows.Forms.Label lbl_depwith;
        private System.Windows.Forms.Label lbl_firstname;
        private System.Windows.Forms.TextBox tbx_firstname;
        private System.Windows.Forms.Label lbl_lastname;
        private System.Windows.Forms.TextBox tbx_lastname;
        private System.Windows.Forms.Button btn_changeIntrest;
        private System.Windows.Forms.Button btn_addIntrest;
        private System.Windows.Forms.Label lbl_percentage;
    }
}

