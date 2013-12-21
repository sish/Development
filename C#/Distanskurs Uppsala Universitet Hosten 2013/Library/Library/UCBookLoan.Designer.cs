namespace Library
{
    partial class UCBookLoan
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
            this.lbl_copies = new System.Windows.Forms.Label();
            this.btn_editBook = new System.Windows.Forms.Button();
            this.btn_addCopy = new System.Windows.Forms.Button();
            this.tbx_copies = new System.Windows.Forms.TextBox();
            this.lbl_description = new System.Windows.Forms.Label();
            this.rtb_description = new System.Windows.Forms.RichTextBox();
            this.tbx_isbn = new System.Windows.Forms.TextBox();
            this.lbl_isbn = new System.Windows.Forms.Label();
            this.tbx_title = new System.Windows.Forms.TextBox();
            this.lbl_bookTitle = new System.Windows.Forms.Label();
            this.tbx_timeOfLoan = new System.Windows.Forms.TextBox();
            this.lbl_timeOfLoan = new System.Windows.Forms.Label();
            this.tbx_timeOfReturn = new System.Windows.Forms.TextBox();
            this.lbl_timeOfReturn = new System.Windows.Forms.Label();
            this.tbx_duration = new System.Windows.Forms.TextBox();
            this.lbl_duration = new System.Windows.Forms.Label();
            this.btn_return = new System.Windows.Forms.Button();
            this.lbl_information = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_copies
            // 
            this.lbl_copies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_copies.AutoSize = true;
            this.lbl_copies.Location = new System.Drawing.Point(8, 253);
            this.lbl_copies.Name = "lbl_copies";
            this.lbl_copies.Size = new System.Drawing.Size(42, 13);
            this.lbl_copies.TabIndex = 24;
            this.lbl_copies.Text = "Copies:";
            // 
            // btn_editBook
            // 
            this.btn_editBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editBook.Location = new System.Drawing.Point(76, 276);
            this.btn_editBook.Name = "btn_editBook";
            this.btn_editBook.Size = new System.Drawing.Size(75, 23);
            this.btn_editBook.TabIndex = 23;
            this.btn_editBook.Text = "Edit Book";
            this.btn_editBook.UseVisualStyleBackColor = true;
            this.btn_editBook.Click += new System.EventHandler(this.btn_editBook_Click);
            // 
            // btn_addCopy
            // 
            this.btn_addCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addCopy.Location = new System.Drawing.Point(157, 276);
            this.btn_addCopy.Name = "btn_addCopy";
            this.btn_addCopy.Size = new System.Drawing.Size(75, 23);
            this.btn_addCopy.TabIndex = 22;
            this.btn_addCopy.Text = "Buy Book";
            this.btn_addCopy.UseVisualStyleBackColor = true;
            this.btn_addCopy.Click += new System.EventHandler(this.btn_addCopy_Click);
            // 
            // tbx_copies
            // 
            this.tbx_copies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_copies.Location = new System.Drawing.Point(52, 250);
            this.tbx_copies.Name = "tbx_copies";
            this.tbx_copies.Size = new System.Drawing.Size(180, 20);
            this.tbx_copies.TabIndex = 21;
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(11, 56);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(63, 13);
            this.lbl_description.TabIndex = 20;
            this.lbl_description.Text = "Description:";
            // 
            // rtb_description
            // 
            this.rtb_description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_description.Location = new System.Drawing.Point(11, 72);
            this.rtb_description.Name = "rtb_description";
            this.rtb_description.Size = new System.Drawing.Size(221, 172);
            this.rtb_description.TabIndex = 19;
            this.rtb_description.Text = "";
            // 
            // tbx_isbn
            // 
            this.tbx_isbn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_isbn.Location = new System.Drawing.Point(52, 29);
            this.tbx_isbn.Name = "tbx_isbn";
            this.tbx_isbn.Size = new System.Drawing.Size(180, 20);
            this.tbx_isbn.TabIndex = 18;
            // 
            // lbl_isbn
            // 
            this.lbl_isbn.AutoSize = true;
            this.lbl_isbn.Location = new System.Drawing.Point(11, 32);
            this.lbl_isbn.Name = "lbl_isbn";
            this.lbl_isbn.Size = new System.Drawing.Size(35, 13);
            this.lbl_isbn.TabIndex = 17;
            this.lbl_isbn.Text = "ISBN:";
            // 
            // tbx_title
            // 
            this.tbx_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_title.Location = new System.Drawing.Point(47, 3);
            this.tbx_title.Name = "tbx_title";
            this.tbx_title.Size = new System.Drawing.Size(185, 20);
            this.tbx_title.TabIndex = 16;
            // 
            // lbl_bookTitle
            // 
            this.lbl_bookTitle.AutoSize = true;
            this.lbl_bookTitle.Location = new System.Drawing.Point(11, 6);
            this.lbl_bookTitle.Name = "lbl_bookTitle";
            this.lbl_bookTitle.Size = new System.Drawing.Size(30, 13);
            this.lbl_bookTitle.TabIndex = 15;
            this.lbl_bookTitle.Text = "Title:";
            // 
            // tbx_timeOfLoan
            // 
            this.tbx_timeOfLoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_timeOfLoan.Location = new System.Drawing.Point(86, 305);
            this.tbx_timeOfLoan.Name = "tbx_timeOfLoan";
            this.tbx_timeOfLoan.Size = new System.Drawing.Size(146, 20);
            this.tbx_timeOfLoan.TabIndex = 25;
            // 
            // lbl_timeOfLoan
            // 
            this.lbl_timeOfLoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_timeOfLoan.AutoSize = true;
            this.lbl_timeOfLoan.Location = new System.Drawing.Point(8, 308);
            this.lbl_timeOfLoan.Name = "lbl_timeOfLoan";
            this.lbl_timeOfLoan.Size = new System.Drawing.Size(72, 13);
            this.lbl_timeOfLoan.TabIndex = 26;
            this.lbl_timeOfLoan.Text = "Time of Loan:";
            // 
            // tbx_timeOfReturn
            // 
            this.tbx_timeOfReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_timeOfReturn.Location = new System.Drawing.Point(94, 331);
            this.tbx_timeOfReturn.Name = "tbx_timeOfReturn";
            this.tbx_timeOfReturn.Size = new System.Drawing.Size(138, 20);
            this.tbx_timeOfReturn.TabIndex = 27;
            // 
            // lbl_timeOfReturn
            // 
            this.lbl_timeOfReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_timeOfReturn.AutoSize = true;
            this.lbl_timeOfReturn.Location = new System.Drawing.Point(8, 334);
            this.lbl_timeOfReturn.Name = "lbl_timeOfReturn";
            this.lbl_timeOfReturn.Size = new System.Drawing.Size(80, 13);
            this.lbl_timeOfReturn.TabIndex = 28;
            this.lbl_timeOfReturn.Text = "Time of Return:";
            // 
            // tbx_duration
            // 
            this.tbx_duration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_duration.Location = new System.Drawing.Point(64, 357);
            this.tbx_duration.Name = "tbx_duration";
            this.tbx_duration.Size = new System.Drawing.Size(168, 20);
            this.tbx_duration.TabIndex = 29;
            // 
            // lbl_duration
            // 
            this.lbl_duration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_duration.AutoSize = true;
            this.lbl_duration.Location = new System.Drawing.Point(8, 360);
            this.lbl_duration.Name = "lbl_duration";
            this.lbl_duration.Size = new System.Drawing.Size(50, 13);
            this.lbl_duration.TabIndex = 30;
            this.lbl_duration.Text = "Duration:";
            // 
            // btn_return
            // 
            this.btn_return.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_return.Location = new System.Drawing.Point(157, 383);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(75, 23);
            this.btn_return.TabIndex = 31;
            this.btn_return.Text = "Return";
            this.btn_return.UseVisualStyleBackColor = true;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // lbl_information
            // 
            this.lbl_information.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_information.AutoSize = true;
            this.lbl_information.Location = new System.Drawing.Point(8, 388);
            this.lbl_information.Name = "lbl_information";
            this.lbl_information.Size = new System.Drawing.Size(22, 13);
            this.lbl_information.TabIndex = 32;
            this.lbl_information.Text = "tbd";
            // 
            // UCBookLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_information);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.lbl_duration);
            this.Controls.Add(this.tbx_duration);
            this.Controls.Add(this.lbl_timeOfReturn);
            this.Controls.Add(this.tbx_timeOfReturn);
            this.Controls.Add(this.lbl_timeOfLoan);
            this.Controls.Add(this.tbx_timeOfLoan);
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
            this.Name = "UCBookLoan";
            this.Size = new System.Drawing.Size(235, 420);
            this.Load += new System.EventHandler(this.UCBookLoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_copies;
        private System.Windows.Forms.Button btn_editBook;
        private System.Windows.Forms.Button btn_addCopy;
        private System.Windows.Forms.TextBox tbx_copies;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.RichTextBox rtb_description;
        private System.Windows.Forms.TextBox tbx_isbn;
        private System.Windows.Forms.Label lbl_isbn;
        private System.Windows.Forms.TextBox tbx_title;
        private System.Windows.Forms.Label lbl_bookTitle;
        private System.Windows.Forms.TextBox tbx_timeOfLoan;
        private System.Windows.Forms.Label lbl_timeOfLoan;
        private System.Windows.Forms.TextBox tbx_timeOfReturn;
        private System.Windows.Forms.Label lbl_timeOfReturn;
        private System.Windows.Forms.TextBox tbx_duration;
        private System.Windows.Forms.Label lbl_duration;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Label lbl_information;
    }
}
