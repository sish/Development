namespace Library
{
    partial class UCAuthorLoan
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
            this.btn_addBook = new System.Windows.Forms.Button();
            this.tbx_noOfBooks = new System.Windows.Forms.TextBox();
            this.lbl_books = new System.Windows.Forms.Label();
            this.tbx_author = new System.Windows.Forms.TextBox();
            this.lbl_author = new System.Windows.Forms.Label();
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
            // btn_addBook
            // 
            this.btn_addBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addBook.Location = new System.Drawing.Point(157, 55);
            this.btn_addBook.Name = "btn_addBook";
            this.btn_addBook.Size = new System.Drawing.Size(75, 23);
            this.btn_addBook.TabIndex = 10;
            this.btn_addBook.Text = "Add Book";
            this.btn_addBook.UseVisualStyleBackColor = true;
            this.btn_addBook.Click += new System.EventHandler(this.btn_addBook_Click);
            // 
            // tbx_noOfBooks
            // 
            this.tbx_noOfBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_noOfBooks.Location = new System.Drawing.Point(105, 29);
            this.tbx_noOfBooks.Name = "tbx_noOfBooks";
            this.tbx_noOfBooks.Size = new System.Drawing.Size(127, 20);
            this.tbx_noOfBooks.TabIndex = 9;
            // 
            // lbl_books
            // 
            this.lbl_books.AutoSize = true;
            this.lbl_books.Location = new System.Drawing.Point(12, 32);
            this.lbl_books.Name = "lbl_books";
            this.lbl_books.Size = new System.Drawing.Size(87, 13);
            this.lbl_books.TabIndex = 8;
            this.lbl_books.Text = "Books by author:";
            // 
            // tbx_author
            // 
            this.tbx_author.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_author.Location = new System.Drawing.Point(59, 3);
            this.tbx_author.Name = "tbx_author";
            this.tbx_author.Size = new System.Drawing.Size(173, 20);
            this.tbx_author.TabIndex = 7;
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Location = new System.Drawing.Point(12, 6);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(41, 13);
            this.lbl_author.TabIndex = 6;
            this.lbl_author.Text = "Author:";
            // 
            // lbl_information
            // 
            this.lbl_information.AutoSize = true;
            this.lbl_information.Location = new System.Drawing.Point(8, 167);
            this.lbl_information.Name = "lbl_information";
            this.lbl_information.Size = new System.Drawing.Size(22, 13);
            this.lbl_information.TabIndex = 48;
            this.lbl_information.Text = "tbd";
            // 
            // btn_returnBook
            // 
            this.btn_returnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_returnBook.Location = new System.Drawing.Point(157, 162);
            this.btn_returnBook.Name = "btn_returnBook";
            this.btn_returnBook.Size = new System.Drawing.Size(75, 23);
            this.btn_returnBook.TabIndex = 47;
            this.btn_returnBook.Text = "Return";
            this.btn_returnBook.UseVisualStyleBackColor = true;
            this.btn_returnBook.Click += new System.EventHandler(this.btn_returnBook_Click);
            // 
            // lbl_duration
            // 
            this.lbl_duration.AutoSize = true;
            this.lbl_duration.Location = new System.Drawing.Point(8, 139);
            this.lbl_duration.Name = "lbl_duration";
            this.lbl_duration.Size = new System.Drawing.Size(50, 13);
            this.lbl_duration.TabIndex = 46;
            this.lbl_duration.Text = "Duration:";
            // 
            // tbx_duration
            // 
            this.tbx_duration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_duration.Location = new System.Drawing.Point(64, 136);
            this.tbx_duration.Name = "tbx_duration";
            this.tbx_duration.Size = new System.Drawing.Size(168, 20);
            this.tbx_duration.TabIndex = 45;
            // 
            // lbl_timeOfReturn
            // 
            this.lbl_timeOfReturn.AutoSize = true;
            this.lbl_timeOfReturn.Location = new System.Drawing.Point(8, 113);
            this.lbl_timeOfReturn.Name = "lbl_timeOfReturn";
            this.lbl_timeOfReturn.Size = new System.Drawing.Size(80, 13);
            this.lbl_timeOfReturn.TabIndex = 44;
            this.lbl_timeOfReturn.Text = "Time of Return:";
            // 
            // tbx_timeOfReturn
            // 
            this.tbx_timeOfReturn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_timeOfReturn.Location = new System.Drawing.Point(94, 110);
            this.tbx_timeOfReturn.Name = "tbx_timeOfReturn";
            this.tbx_timeOfReturn.Size = new System.Drawing.Size(138, 20);
            this.tbx_timeOfReturn.TabIndex = 43;
            // 
            // lbl_timeOfLoan
            // 
            this.lbl_timeOfLoan.AutoSize = true;
            this.lbl_timeOfLoan.Location = new System.Drawing.Point(8, 87);
            this.lbl_timeOfLoan.Name = "lbl_timeOfLoan";
            this.lbl_timeOfLoan.Size = new System.Drawing.Size(72, 13);
            this.lbl_timeOfLoan.TabIndex = 42;
            this.lbl_timeOfLoan.Text = "Time of Loan:";
            // 
            // tbx_timeOfLoan
            // 
            this.tbx_timeOfLoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_timeOfLoan.Location = new System.Drawing.Point(86, 84);
            this.tbx_timeOfLoan.Name = "tbx_timeOfLoan";
            this.tbx_timeOfLoan.Size = new System.Drawing.Size(146, 20);
            this.tbx_timeOfLoan.TabIndex = 41;
            // 
            // UCAuthorLoan
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
            this.Controls.Add(this.btn_addBook);
            this.Controls.Add(this.tbx_noOfBooks);
            this.Controls.Add(this.lbl_books);
            this.Controls.Add(this.tbx_author);
            this.Controls.Add(this.lbl_author);
            this.Name = "UCAuthorLoan";
            this.Size = new System.Drawing.Size(235, 420);
            this.Load += new System.EventHandler(this.UCAuthorLoan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addBook;
        private System.Windows.Forms.TextBox tbx_noOfBooks;
        private System.Windows.Forms.Label lbl_books;
        private System.Windows.Forms.TextBox tbx_author;
        private System.Windows.Forms.Label lbl_author;
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
