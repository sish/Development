namespace Library
{
    partial class UCMemberLoan
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
            DisposeEvents();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_editMember = new System.Windows.Forms.Button();
            this.lbl_loans = new System.Windows.Forms.Label();
            this.btn_return = new System.Windows.Forms.Button();
            this.cbx_currentloans = new System.Windows.Forms.ComboBox();
            this.lbl_ssn = new System.Windows.Forms.Label();
            this.tbx_ssn = new System.Windows.Forms.TextBox();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_information = new System.Windows.Forms.Label();
            this.btn_returnBook = new System.Windows.Forms.Button();
            this.lbl_duration = new System.Windows.Forms.Label();
            this.tbx_duration = new System.Windows.Forms.TextBox();
            this.lbl_timeOfReturn = new System.Windows.Forms.Label();
            this.tbx_timeOfReturn = new System.Windows.Forms.TextBox();
            this.lbl_timeOfLoan = new System.Windows.Forms.Label();
            this.tbx_timeOfLoan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_editMember
            // 
            this.btn_editMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editMember.Location = new System.Drawing.Point(101, 82);
            this.btn_editMember.Name = "btn_editMember";
            this.btn_editMember.Size = new System.Drawing.Size(75, 23);
            this.btn_editMember.TabIndex = 30;
            this.btn_editMember.Text = "Edit Member";
            this.btn_editMember.UseVisualStyleBackColor = true;
            this.btn_editMember.Click += new System.EventHandler(this.btn_editMember_Click);
            // 
            // lbl_loans
            // 
            this.lbl_loans.AutoSize = true;
            this.lbl_loans.Location = new System.Drawing.Point(3, 58);
            this.lbl_loans.Name = "lbl_loans";
            this.lbl_loans.Size = new System.Drawing.Size(76, 13);
            this.lbl_loans.TabIndex = 29;
            this.lbl_loans.Text = "Current Loans:";
            // 
            // btn_return
            // 
            this.btn_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_return.Location = new System.Drawing.Point(182, 82);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(50, 23);
            this.btn_return.TabIndex = 28;
            this.btn_return.Text = "Return";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // cbx_currentloans
            // 
            this.cbx_currentloans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_currentloans.FormattingEnabled = true;
            this.cbx_currentloans.Location = new System.Drawing.Point(85, 55);
            this.cbx_currentloans.Name = "cbx_currentloans";
            this.cbx_currentloans.Size = new System.Drawing.Size(147, 21);
            this.cbx_currentloans.TabIndex = 27;
            // 
            // lbl_ssn
            // 
            this.lbl_ssn.AutoSize = true;
            this.lbl_ssn.Location = new System.Drawing.Point(3, 32);
            this.lbl_ssn.Name = "lbl_ssn";
            this.lbl_ssn.Size = new System.Drawing.Size(32, 13);
            this.lbl_ssn.TabIndex = 26;
            this.lbl_ssn.Text = "SSN:";
            // 
            // tbx_ssn
            // 
            this.tbx_ssn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_ssn.Location = new System.Drawing.Point(41, 29);
            this.tbx_ssn.Name = "tbx_ssn";
            this.tbx_ssn.Size = new System.Drawing.Size(191, 20);
            this.tbx_ssn.TabIndex = 25;
            // 
            // tbx_name
            // 
            this.tbx_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_name.Location = new System.Drawing.Point(47, 3);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(185, 20);
            this.tbx_name.TabIndex = 24;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(3, 6);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 23;
            this.lbl_name.Text = "Name:";
            // 
            // lbl_information
            // 
            this.lbl_information.AutoSize = true;
            this.lbl_information.Location = new System.Drawing.Point(7, 194);
            this.lbl_information.Name = "lbl_information";
            this.lbl_information.Size = new System.Drawing.Size(22, 13);
            this.lbl_information.TabIndex = 40;
            this.lbl_information.Text = "tbd";
            // 
            // btn_returnBook
            // 
            this.btn_returnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_returnBook.Location = new System.Drawing.Point(156, 189);
            this.btn_returnBook.Name = "btn_returnBook";
            this.btn_returnBook.Size = new System.Drawing.Size(75, 23);
            this.btn_returnBook.TabIndex = 39;
            this.btn_returnBook.Text = "Return";
            this.btn_returnBook.UseVisualStyleBackColor = true;
            this.btn_returnBook.Click += new System.EventHandler(this.btn_returnBook_Click);
            // 
            // lbl_duration
            // 
            this.lbl_duration.AutoSize = true;
            this.lbl_duration.Location = new System.Drawing.Point(7, 166);
            this.lbl_duration.Name = "lbl_duration";
            this.lbl_duration.Size = new System.Drawing.Size(50, 13);
            this.lbl_duration.TabIndex = 38;
            this.lbl_duration.Text = "Duration:";
            // 
            // tbx_duration
            // 
            this.tbx_duration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_duration.Location = new System.Drawing.Point(63, 163);
            this.tbx_duration.Name = "tbx_duration";
            this.tbx_duration.Size = new System.Drawing.Size(168, 20);
            this.tbx_duration.TabIndex = 37;
            // 
            // lbl_timeOfReturn
            // 
            this.lbl_timeOfReturn.AutoSize = true;
            this.lbl_timeOfReturn.Location = new System.Drawing.Point(7, 140);
            this.lbl_timeOfReturn.Name = "lbl_timeOfReturn";
            this.lbl_timeOfReturn.Size = new System.Drawing.Size(80, 13);
            this.lbl_timeOfReturn.TabIndex = 36;
            this.lbl_timeOfReturn.Text = "Time of Return:";
            // 
            // tbx_timeOfReturn
            // 
            this.tbx_timeOfReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_timeOfReturn.Location = new System.Drawing.Point(93, 137);
            this.tbx_timeOfReturn.Name = "tbx_timeOfReturn";
            this.tbx_timeOfReturn.Size = new System.Drawing.Size(138, 20);
            this.tbx_timeOfReturn.TabIndex = 35;
            // 
            // lbl_timeOfLoan
            // 
            this.lbl_timeOfLoan.AutoSize = true;
            this.lbl_timeOfLoan.Location = new System.Drawing.Point(7, 114);
            this.lbl_timeOfLoan.Name = "lbl_timeOfLoan";
            this.lbl_timeOfLoan.Size = new System.Drawing.Size(72, 13);
            this.lbl_timeOfLoan.TabIndex = 34;
            this.lbl_timeOfLoan.Text = "Time of Loan:";
            // 
            // tbx_timeOfLoan
            // 
            this.tbx_timeOfLoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_timeOfLoan.Location = new System.Drawing.Point(85, 111);
            this.tbx_timeOfLoan.Name = "tbx_timeOfLoan";
            this.tbx_timeOfLoan.Size = new System.Drawing.Size(146, 20);
            this.tbx_timeOfLoan.TabIndex = 33;
            // 
            // UCMemberLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_information);
            this.Controls.Add(this.btn_returnBook);
            this.Controls.Add(this.lbl_duration);
            this.Controls.Add(this.tbx_duration);
            this.Controls.Add(this.lbl_timeOfReturn);
            this.Controls.Add(this.tbx_timeOfReturn);
            this.Controls.Add(this.lbl_timeOfLoan);
            this.Controls.Add(this.tbx_timeOfLoan);
            this.Controls.Add(this.btn_editMember);
            this.Controls.Add(this.lbl_loans);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.cbx_currentloans);
            this.Controls.Add(this.lbl_ssn);
            this.Controls.Add(this.tbx_ssn);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.lbl_name);
            this.Name = "UCMemberLoan";
            this.Size = new System.Drawing.Size(235, 420);
            this.Load += new System.EventHandler(this.UCMemberLoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_editMember;
        private System.Windows.Forms.Label lbl_loans;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.ComboBox cbx_currentloans;
        private System.Windows.Forms.Label lbl_ssn;
        private System.Windows.Forms.TextBox tbx_ssn;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_information;
        private System.Windows.Forms.Button btn_returnBook;
        private System.Windows.Forms.Label lbl_duration;
        private System.Windows.Forms.TextBox tbx_duration;
        private System.Windows.Forms.Label lbl_timeOfReturn;
        private System.Windows.Forms.TextBox tbx_timeOfReturn;
        private System.Windows.Forms.Label lbl_timeOfLoan;
        private System.Windows.Forms.TextBox tbx_timeOfLoan;
    }
}
