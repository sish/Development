namespace Library
{
    partial class UCAuthorBook
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
            this.lbl_author = new System.Windows.Forms.Label();
            this.tbx_author = new System.Windows.Forms.TextBox();
            this.lbl_books = new System.Windows.Forms.Label();
            this.tbx_noOfBooks = new System.Windows.Forms.TextBox();
            this.lbl_bookTitle = new System.Windows.Forms.Label();
            this.btn_addBook = new System.Windows.Forms.Button();
            this.tbx_title = new System.Windows.Forms.TextBox();
            this.lbl_isbn = new System.Windows.Forms.Label();
            this.tbx_isbn = new System.Windows.Forms.TextBox();
            this.rtb_description = new System.Windows.Forms.RichTextBox();
            this.lbl_description = new System.Windows.Forms.Label();
            this.tbx_copies = new System.Windows.Forms.TextBox();
            this.btn_addCopy = new System.Windows.Forms.Button();
            this.btn_editBook = new System.Windows.Forms.Button();
            this.lbl_copies = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Location = new System.Drawing.Point(3, 9);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(41, 13);
            this.lbl_author.TabIndex = 0;
            this.lbl_author.Text = "Author:";
            // 
            // tbx_author
            // 
            this.tbx_author.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_author.Location = new System.Drawing.Point(50, 6);
            this.tbx_author.Name = "tbx_author";
            this.tbx_author.Size = new System.Drawing.Size(173, 20);
            this.tbx_author.TabIndex = 1;
            // 
            // lbl_books
            // 
            this.lbl_books.AutoSize = true;
            this.lbl_books.Location = new System.Drawing.Point(3, 35);
            this.lbl_books.Name = "lbl_books";
            this.lbl_books.Size = new System.Drawing.Size(87, 13);
            this.lbl_books.TabIndex = 2;
            this.lbl_books.Text = "Books by author:";
            // 
            // tbx_noOfBooks
            // 
            this.tbx_noOfBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_noOfBooks.Location = new System.Drawing.Point(96, 32);
            this.tbx_noOfBooks.Name = "tbx_noOfBooks";
            this.tbx_noOfBooks.Size = new System.Drawing.Size(127, 20);
            this.tbx_noOfBooks.TabIndex = 3;
            // 
            // lbl_bookTitle
            // 
            this.lbl_bookTitle.AutoSize = true;
            this.lbl_bookTitle.Location = new System.Drawing.Point(3, 90);
            this.lbl_bookTitle.Name = "lbl_bookTitle";
            this.lbl_bookTitle.Size = new System.Drawing.Size(30, 13);
            this.lbl_bookTitle.TabIndex = 4;
            this.lbl_bookTitle.Text = "Title:";
            // 
            // btn_addBook
            // 
            this.btn_addBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addBook.Location = new System.Drawing.Point(148, 58);
            this.btn_addBook.Name = "btn_addBook";
            this.btn_addBook.Size = new System.Drawing.Size(75, 23);
            this.btn_addBook.TabIndex = 5;
            this.btn_addBook.Text = "Add Book";
            this.btn_addBook.UseVisualStyleBackColor = true;
            this.btn_addBook.Click += new System.EventHandler(this.btn_addBook_Click);
            // 
            // tbx_title
            // 
            this.tbx_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_title.Location = new System.Drawing.Point(39, 87);
            this.tbx_title.Name = "tbx_title";
            this.tbx_title.Size = new System.Drawing.Size(184, 20);
            this.tbx_title.TabIndex = 6;
            // 
            // lbl_isbn
            // 
            this.lbl_isbn.AutoSize = true;
            this.lbl_isbn.Location = new System.Drawing.Point(3, 116);
            this.lbl_isbn.Name = "lbl_isbn";
            this.lbl_isbn.Size = new System.Drawing.Size(35, 13);
            this.lbl_isbn.TabIndex = 7;
            this.lbl_isbn.Text = "ISBN:";
            // 
            // tbx_isbn
            // 
            this.tbx_isbn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_isbn.Location = new System.Drawing.Point(44, 113);
            this.tbx_isbn.Name = "tbx_isbn";
            this.tbx_isbn.Size = new System.Drawing.Size(179, 20);
            this.tbx_isbn.TabIndex = 8;
            // 
            // rtb_description
            // 
            this.rtb_description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_description.Location = new System.Drawing.Point(3, 156);
            this.rtb_description.Name = "rtb_description";
            this.rtb_description.Size = new System.Drawing.Size(220, 206);
            this.rtb_description.TabIndex = 9;
            this.rtb_description.Text = "";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(3, 140);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(63, 13);
            this.lbl_description.TabIndex = 10;
            this.lbl_description.Text = "Description:";
            // 
            // tbx_copies
            // 
            this.tbx_copies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_copies.Location = new System.Drawing.Point(44, 368);
            this.tbx_copies.Name = "tbx_copies";
            this.tbx_copies.Size = new System.Drawing.Size(179, 20);
            this.tbx_copies.TabIndex = 11;
            // 
            // btn_addCopy
            // 
            this.btn_addCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addCopy.Location = new System.Drawing.Point(148, 394);
            this.btn_addCopy.Name = "btn_addCopy";
            this.btn_addCopy.Size = new System.Drawing.Size(75, 23);
            this.btn_addCopy.TabIndex = 12;
            this.btn_addCopy.Text = "Buy Book";
            this.btn_addCopy.UseVisualStyleBackColor = true;
            this.btn_addCopy.Click += new System.EventHandler(this.btn_addCopy_Click);
            // 
            // btn_editBook
            // 
            this.btn_editBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editBook.Location = new System.Drawing.Point(67, 394);
            this.btn_editBook.Name = "btn_editBook";
            this.btn_editBook.Size = new System.Drawing.Size(75, 23);
            this.btn_editBook.TabIndex = 13;
            this.btn_editBook.Text = "Edit Book";
            this.btn_editBook.UseVisualStyleBackColor = true;
            this.btn_editBook.Click += new System.EventHandler(this.btn_editBook_Click);
            // 
            // lbl_copies
            // 
            this.lbl_copies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_copies.AutoSize = true;
            this.lbl_copies.Location = new System.Drawing.Point(3, 371);
            this.lbl_copies.Name = "lbl_copies";
            this.lbl_copies.Size = new System.Drawing.Size(42, 13);
            this.lbl_copies.TabIndex = 14;
            this.lbl_copies.Text = "Copies:";
            // 
            // UCAuthorBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_copies);
            this.Controls.Add(this.btn_editBook);
            this.Controls.Add(this.btn_addCopy);
            this.Controls.Add(this.tbx_copies);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.rtb_description);
            this.Controls.Add(this.tbx_isbn);
            this.Controls.Add(this.lbl_isbn);
            this.Controls.Add(this.tbx_title);
            this.Controls.Add(this.btn_addBook);
            this.Controls.Add(this.lbl_bookTitle);
            this.Controls.Add(this.tbx_noOfBooks);
            this.Controls.Add(this.lbl_books);
            this.Controls.Add(this.tbx_author);
            this.Controls.Add(this.lbl_author);
            this.Name = "UCAuthorBook";
            this.Size = new System.Drawing.Size(235, 420);
            this.Load += new System.EventHandler(this.UCAuthorBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.TextBox tbx_author;
        private System.Windows.Forms.Label lbl_books;
        private System.Windows.Forms.TextBox tbx_noOfBooks;
        private System.Windows.Forms.Label lbl_bookTitle;
        private System.Windows.Forms.Button btn_addBook;
        private System.Windows.Forms.TextBox tbx_title;
        private System.Windows.Forms.Label lbl_isbn;
        private System.Windows.Forms.TextBox tbx_isbn;
        private System.Windows.Forms.RichTextBox rtb_description;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.TextBox tbx_copies;
        private System.Windows.Forms.Button btn_addCopy;
        private System.Windows.Forms.Button btn_editBook;
        private System.Windows.Forms.Label lbl_copies;
    }
}
