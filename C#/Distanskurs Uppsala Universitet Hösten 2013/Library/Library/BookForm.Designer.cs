namespace Library
{
    partial class BookForm
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
            this.cbx_author = new System.Windows.Forms.ComboBox();
            this.tbx_title = new System.Windows.Forms.TextBox();
            this.tbx_isbn = new System.Windows.Forms.TextBox();
            this.lbl_author = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_isbn = new System.Windows.Forms.Label();
            this.btn_save_edit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_description = new System.Windows.Forms.Label();
            this.rtb_description = new System.Windows.Forms.RichTextBox();
            this.tbx_copies = new System.Windows.Forms.TextBox();
            this.lbl_copies = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbx_author
            // 
            this.cbx_author.FormattingEnabled = true;
            this.cbx_author.Location = new System.Drawing.Point(79, 12);
            this.cbx_author.Name = "cbx_author";
            this.cbx_author.Size = new System.Drawing.Size(227, 21);
            this.cbx_author.TabIndex = 0;
            // 
            // tbx_title
            // 
            this.tbx_title.Location = new System.Drawing.Point(79, 39);
            this.tbx_title.Name = "tbx_title";
            this.tbx_title.Size = new System.Drawing.Size(227, 20);
            this.tbx_title.TabIndex = 1;
            // 
            // tbx_isbn
            // 
            this.tbx_isbn.Location = new System.Drawing.Point(79, 65);
            this.tbx_isbn.Name = "tbx_isbn";
            this.tbx_isbn.Size = new System.Drawing.Size(227, 20);
            this.tbx_isbn.TabIndex = 2;
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Location = new System.Drawing.Point(32, 15);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(41, 13);
            this.lbl_author.TabIndex = 3;
            this.lbl_author.Text = "Author:";
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Location = new System.Drawing.Point(43, 42);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(30, 13);
            this.lbl_title.TabIndex = 4;
            this.lbl_title.Text = "Title:";
            // 
            // lbl_isbn
            // 
            this.lbl_isbn.AutoSize = true;
            this.lbl_isbn.Location = new System.Drawing.Point(38, 68);
            this.lbl_isbn.Name = "lbl_isbn";
            this.lbl_isbn.Size = new System.Drawing.Size(35, 13);
            this.lbl_isbn.TabIndex = 5;
            this.lbl_isbn.Text = "ISBN:";
            // 
            // btn_save_edit
            // 
            this.btn_save_edit.Location = new System.Drawing.Point(150, 249);
            this.btn_save_edit.Name = "btn_save_edit";
            this.btn_save_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_save_edit.TabIndex = 5;
            this.btn_save_edit.Text = "button1";
            this.btn_save_edit.UseVisualStyleBackColor = true;
            this.btn_save_edit.Click += new System.EventHandler(this.btn_save_edit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(231, 249);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(10, 94);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(63, 13);
            this.lbl_description.TabIndex = 8;
            this.lbl_description.Text = "Description:";
            // 
            // rtb_description
            // 
            this.rtb_description.Location = new System.Drawing.Point(79, 91);
            this.rtb_description.Name = "rtb_description";
            this.rtb_description.Size = new System.Drawing.Size(227, 152);
            this.rtb_description.TabIndex = 3;
            this.rtb_description.Text = "";
            // 
            // tbx_copies
            // 
            this.tbx_copies.Location = new System.Drawing.Point(79, 251);
            this.tbx_copies.Name = "tbx_copies";
            this.tbx_copies.Size = new System.Drawing.Size(65, 20);
            this.tbx_copies.TabIndex = 4;
            // 
            // lbl_copies
            // 
            this.lbl_copies.AutoSize = true;
            this.lbl_copies.Location = new System.Drawing.Point(31, 254);
            this.lbl_copies.Name = "lbl_copies";
            this.lbl_copies.Size = new System.Drawing.Size(42, 13);
            this.lbl_copies.TabIndex = 11;
            this.lbl_copies.Text = "Copies:";
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 284);
            this.Controls.Add(this.lbl_copies);
            this.Controls.Add(this.tbx_copies);
            this.Controls.Add(this.rtb_description);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save_edit);
            this.Controls.Add(this.lbl_isbn);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_author);
            this.Controls.Add(this.tbx_isbn);
            this.Controls.Add(this.tbx_title);
            this.Controls.Add(this.cbx_author);
            this.MinimumSize = new System.Drawing.Size(334, 322);
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_author;
        private System.Windows.Forms.TextBox tbx_title;
        private System.Windows.Forms.TextBox tbx_isbn;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_isbn;
        private System.Windows.Forms.Button btn_save_edit;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.RichTextBox rtb_description;
        private System.Windows.Forms.TextBox tbx_copies;
        private System.Windows.Forms.Label lbl_copies;
    }
}