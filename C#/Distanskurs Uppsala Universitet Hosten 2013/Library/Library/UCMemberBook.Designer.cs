namespace Library
{
    partial class UCMemberBook
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.tbx_ssn = new System.Windows.Forms.TextBox();
            this.lbl_ssn = new System.Windows.Forms.Label();
            this.cbx_currentloans = new System.Windows.Forms.ComboBox();
            this.btn_return = new System.Windows.Forms.Button();
            this.lbl_loans = new System.Windows.Forms.Label();
            this.tbx_title = new System.Windows.Forms.TextBox();
            this.lbl_bookTitle = new System.Windows.Forms.Label();
            this.tbx_isbn = new System.Windows.Forms.TextBox();
            this.lbl_isbn = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.rtb_description = new System.Windows.Forms.RichTextBox();
            this.lbl_copies = new System.Windows.Forms.Label();
            this.btn_editBook = new System.Windows.Forms.Button();
            this.btn_addCopy = new System.Windows.Forms.Button();
            this.tbx_copies = new System.Windows.Forms.TextBox();
            this.lbl_availableCopies = new System.Windows.Forms.Label();
            this.tbx_availableCopies = new System.Windows.Forms.TextBox();
            this.btn_loan = new System.Windows.Forms.Button();
            this.btn_editMember = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(3, 6);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name:";
            // 
            // tbx_name
            // 
            this.tbx_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_name.Location = new System.Drawing.Point(47, 3);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(185, 20);
            this.tbx_name.TabIndex = 1;
            // 
            // tbx_ssn
            // 
            this.tbx_ssn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_ssn.Location = new System.Drawing.Point(41, 29);
            this.tbx_ssn.Name = "tbx_ssn";
            this.tbx_ssn.Size = new System.Drawing.Size(191, 20);
            this.tbx_ssn.TabIndex = 2;
            // 
            // lbl_ssn
            // 
            this.lbl_ssn.AutoSize = true;
            this.lbl_ssn.Location = new System.Drawing.Point(3, 32);
            this.lbl_ssn.Name = "lbl_ssn";
            this.lbl_ssn.Size = new System.Drawing.Size(32, 13);
            this.lbl_ssn.TabIndex = 3;
            this.lbl_ssn.Text = "SSN:";
            // 
            // cbx_currentloans
            // 
            this.cbx_currentloans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_currentloans.FormattingEnabled = true;
            this.cbx_currentloans.Location = new System.Drawing.Point(85, 55);
            this.cbx_currentloans.Name = "cbx_currentloans";
            this.cbx_currentloans.Size = new System.Drawing.Size(147, 21);
            this.cbx_currentloans.TabIndex = 4;
            // 
            // btn_return
            // 
            this.btn_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_return.Location = new System.Drawing.Point(182, 82);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(50, 23);
            this.btn_return.TabIndex = 5;
            this.btn_return.Text = "Return";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // lbl_loans
            // 
            this.lbl_loans.AutoSize = true;
            this.lbl_loans.Location = new System.Drawing.Point(3, 58);
            this.lbl_loans.Name = "lbl_loans";
            this.lbl_loans.Size = new System.Drawing.Size(76, 13);
            this.lbl_loans.TabIndex = 6;
            this.lbl_loans.Text = "Current Loans:";
            // 
            // tbx_title
            // 
            this.tbx_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_title.Location = new System.Drawing.Point(39, 111);
            this.tbx_title.Name = "tbx_title";
            this.tbx_title.Size = new System.Drawing.Size(193, 20);
            this.tbx_title.TabIndex = 8;
            // 
            // lbl_bookTitle
            // 
            this.lbl_bookTitle.AutoSize = true;
            this.lbl_bookTitle.Location = new System.Drawing.Point(3, 114);
            this.lbl_bookTitle.Name = "lbl_bookTitle";
            this.lbl_bookTitle.Size = new System.Drawing.Size(30, 13);
            this.lbl_bookTitle.TabIndex = 7;
            this.lbl_bookTitle.Text = "Title:";
            // 
            // tbx_isbn
            // 
            this.tbx_isbn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_isbn.Location = new System.Drawing.Point(41, 137);
            this.tbx_isbn.Name = "tbx_isbn";
            this.tbx_isbn.Size = new System.Drawing.Size(191, 20);
            this.tbx_isbn.TabIndex = 10;
            // 
            // lbl_isbn
            // 
            this.lbl_isbn.AutoSize = true;
            this.lbl_isbn.Location = new System.Drawing.Point(3, 140);
            this.lbl_isbn.Name = "lbl_isbn";
            this.lbl_isbn.Size = new System.Drawing.Size(35, 13);
            this.lbl_isbn.TabIndex = 9;
            this.lbl_isbn.Text = "ISBN:";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(3, 160);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(63, 13);
            this.lbl_description.TabIndex = 12;
            this.lbl_description.Text = "Description:";
            // 
            // rtb_description
            // 
            this.rtb_description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_description.Location = new System.Drawing.Point(3, 176);
            this.rtb_description.Name = "rtb_description";
            this.rtb_description.Size = new System.Drawing.Size(229, 153);
            this.rtb_description.TabIndex = 11;
            this.rtb_description.Text = "";
            // 
            // lbl_copies
            // 
            this.lbl_copies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_copies.AutoSize = true;
            this.lbl_copies.Location = new System.Drawing.Point(3, 338);
            this.lbl_copies.Name = "lbl_copies";
            this.lbl_copies.Size = new System.Drawing.Size(42, 13);
            this.lbl_copies.TabIndex = 18;
            this.lbl_copies.Text = "Copies:";
            // 
            // btn_editBook
            // 
            this.btn_editBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editBook.Location = new System.Drawing.Point(80, 387);
            this.btn_editBook.Name = "btn_editBook";
            this.btn_editBook.Size = new System.Drawing.Size(75, 23);
            this.btn_editBook.TabIndex = 17;
            this.btn_editBook.Text = "Edit Book";
            this.btn_editBook.UseVisualStyleBackColor = true;
            this.btn_editBook.Click += new System.EventHandler(this.btn_editBook_Click);
            // 
            // btn_addCopy
            // 
            this.btn_addCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addCopy.Location = new System.Drawing.Point(161, 387);
            this.btn_addCopy.Name = "btn_addCopy";
            this.btn_addCopy.Size = new System.Drawing.Size(66, 23);
            this.btn_addCopy.TabIndex = 16;
            this.btn_addCopy.Text = "Buy Book";
            this.btn_addCopy.UseVisualStyleBackColor = true;
            this.btn_addCopy.Click += new System.EventHandler(this.btn_addCopy_Click);
            // 
            // tbx_copies
            // 
            this.tbx_copies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_copies.Location = new System.Drawing.Point(51, 335);
            this.tbx_copies.Name = "tbx_copies";
            this.tbx_copies.Size = new System.Drawing.Size(181, 20);
            this.tbx_copies.TabIndex = 15;
            // 
            // lbl_availableCopies
            // 
            this.lbl_availableCopies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_availableCopies.AutoSize = true;
            this.lbl_availableCopies.Location = new System.Drawing.Point(3, 364);
            this.lbl_availableCopies.Name = "lbl_availableCopies";
            this.lbl_availableCopies.Size = new System.Drawing.Size(85, 13);
            this.lbl_availableCopies.TabIndex = 19;
            this.lbl_availableCopies.Text = "Available Copies";
            // 
            // tbx_availableCopies
            // 
            this.tbx_availableCopies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_availableCopies.Location = new System.Drawing.Point(94, 361);
            this.tbx_availableCopies.Name = "tbx_availableCopies";
            this.tbx_availableCopies.Size = new System.Drawing.Size(138, 20);
            this.tbx_availableCopies.TabIndex = 20;
            // 
            // btn_loan
            // 
            this.btn_loan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_loan.Location = new System.Drawing.Point(6, 386);
            this.btn_loan.Name = "btn_loan";
            this.btn_loan.Size = new System.Drawing.Size(68, 23);
            this.btn_loan.TabIndex = 21;
            this.btn_loan.Text = "Loan Book";
            this.btn_loan.UseVisualStyleBackColor = true;
            this.btn_loan.Click += new System.EventHandler(this.btn_loan_Click);
            // 
            // btn_editMember
            // 
            this.btn_editMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editMember.Location = new System.Drawing.Point(101, 82);
            this.btn_editMember.Name = "btn_editMember";
            this.btn_editMember.Size = new System.Drawing.Size(75, 23);
            this.btn_editMember.TabIndex = 22;
            this.btn_editMember.Text = "Edit Member";
            this.btn_editMember.UseVisualStyleBackColor = true;
            this.btn_editMember.Click += new System.EventHandler(this.btn_editMember_Click);
            // 
            // UCMemberBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_editMember);
            this.Controls.Add(this.btn_loan);
            this.Controls.Add(this.tbx_availableCopies);
            this.Controls.Add(this.lbl_availableCopies);
            this.Controls.Add(this.lbl_copies);
            this.Controls.Add(this.btn_editBook);
            this.Controls.Add(this.btn_addCopy);
            this.Controls.Add(this.tbx_copies);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.rtb_description);
            this.Controls.Add(this.tbx_isbn);
            this.Controls.Add(this.lbl_isbn);
            this.Controls.Add(this.tbx_title);
            this.Controls.Add(this.lbl_bookTitle);
            this.Controls.Add(this.lbl_loans);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.cbx_currentloans);
            this.Controls.Add(this.lbl_ssn);
            this.Controls.Add(this.tbx_ssn);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.lbl_name);
            this.Name = "UCMemberBook";
            this.Size = new System.Drawing.Size(235, 420);
            this.Load += new System.EventHandler(this.UCMemberBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.TextBox tbx_ssn;
        private System.Windows.Forms.Label lbl_ssn;
        private System.Windows.Forms.ComboBox cbx_currentloans;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Label lbl_loans;
        private System.Windows.Forms.TextBox tbx_title;
        private System.Windows.Forms.Label lbl_bookTitle;
        private System.Windows.Forms.TextBox tbx_isbn;
        private System.Windows.Forms.Label lbl_isbn;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.RichTextBox rtb_description;
        private System.Windows.Forms.Label lbl_copies;
        private System.Windows.Forms.Button btn_editBook;
        private System.Windows.Forms.Button btn_addCopy;
        private System.Windows.Forms.TextBox tbx_copies;
        private System.Windows.Forms.Label lbl_availableCopies;
        private System.Windows.Forms.TextBox tbx_availableCopies;
        private System.Windows.Forms.Button btn_loan;
        private System.Windows.Forms.Button btn_editMember;
    }
}
