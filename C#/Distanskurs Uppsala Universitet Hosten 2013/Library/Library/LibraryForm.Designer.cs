namespace Library
{
    partial class LibraryForm
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
            this.msp_main = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_file_add_author = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_file_add_member = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_file_add_book = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.msp_file_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_edit_author = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_edit_member = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_edit_book = new System.Windows.Forms.ToolStripMenuItem();
            this.vIEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_view_authors = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_view_members = new System.Windows.Forms.ToolStripMenuItem();
            this.msp_view_books = new System.Windows.Forms.ToolStripMenuItem();
            this.lbx_firstbox = new System.Windows.Forms.ListBox();
            this.lbl_firstbox = new System.Windows.Forms.Label();
            this.scr_first = new System.Windows.Forms.SplitContainer();
            this.lbl_firstbox_search = new System.Windows.Forms.Label();
            this.tbx_firsbox = new System.Windows.Forms.TextBox();
            this.scr_second = new System.Windows.Forms.SplitContainer();
            this.cbx_second_select = new System.Windows.Forms.ComboBox();
            this.lbx_secondbox = new System.Windows.Forms.ListBox();
            this.msp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scr_first)).BeginInit();
            this.scr_first.Panel1.SuspendLayout();
            this.scr_first.Panel2.SuspendLayout();
            this.scr_first.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scr_second)).BeginInit();
            this.scr_second.Panel1.SuspendLayout();
            this.scr_second.SuspendLayout();
            this.SuspendLayout();
            // 
            // msp_main
            // 
            this.msp_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.eDITToolStripMenuItem,
            this.vIEWToolStripMenuItem});
            this.msp_main.Location = new System.Drawing.Point(0, 0);
            this.msp_main.Name = "msp_main";
            this.msp_main.Size = new System.Drawing.Size(784, 24);
            this.msp_main.TabIndex = 0;
            this.msp_main.Text = "msp_main";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem2,
            this.msp_file_exit});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msp_file_add_author,
            this.msp_file_add_member,
            this.msp_file_add_book});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.newToolStripMenuItem.Text = "Add";
            // 
            // msp_file_add_author
            // 
            this.msp_file_add_author.Name = "msp_file_add_author";
            this.msp_file_add_author.Size = new System.Drawing.Size(119, 22);
            this.msp_file_add_author.Text = "Author";
            this.msp_file_add_author.Click += new System.EventHandler(this.msp_file_add_author_Click);
            // 
            // msp_file_add_member
            // 
            this.msp_file_add_member.Name = "msp_file_add_member";
            this.msp_file_add_member.Size = new System.Drawing.Size(119, 22);
            this.msp_file_add_member.Text = "Member";
            this.msp_file_add_member.Click += new System.EventHandler(this.msp_file_add_member_Click);
            // 
            // msp_file_add_book
            // 
            this.msp_file_add_book.Name = "msp_file_add_book";
            this.msp_file_add_book.Size = new System.Drawing.Size(119, 22);
            this.msp_file_add_book.Text = "Book";
            this.msp_file_add_book.Click += new System.EventHandler(this.msp_file_add_book_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(93, 6);
            // 
            // msp_file_exit
            // 
            this.msp_file_exit.Name = "msp_file_exit";
            this.msp_file_exit.Size = new System.Drawing.Size(96, 22);
            this.msp_file_exit.Text = "Exit";
            this.msp_file_exit.Click += new System.EventHandler(this.msp_file_exit_Click);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msp_edit_author,
            this.msp_edit_member,
            this.msp_edit_book});
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.eDITToolStripMenuItem.Text = "EDIT";
            this.eDITToolStripMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.eDITToolStripMenuItem_MouseDown);
            // 
            // msp_edit_author
            // 
            this.msp_edit_author.Name = "msp_edit_author";
            this.msp_edit_author.Size = new System.Drawing.Size(152, 22);
            this.msp_edit_author.Text = "Author";
            this.msp_edit_author.Click += new System.EventHandler(this.msp_edit_author_Click);
            // 
            // msp_edit_member
            // 
            this.msp_edit_member.Name = "msp_edit_member";
            this.msp_edit_member.Size = new System.Drawing.Size(152, 22);
            this.msp_edit_member.Text = "Member";
            this.msp_edit_member.Click += new System.EventHandler(this.msp_edit_member_Click);
            // 
            // msp_edit_book
            // 
            this.msp_edit_book.Name = "msp_edit_book";
            this.msp_edit_book.Size = new System.Drawing.Size(152, 22);
            this.msp_edit_book.Text = "Book";
            this.msp_edit_book.Click += new System.EventHandler(this.msp_edit_book_Click);
            // 
            // vIEWToolStripMenuItem
            // 
            this.vIEWToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msp_view_authors,
            this.msp_view_members,
            this.msp_view_books});
            this.vIEWToolStripMenuItem.Name = "vIEWToolStripMenuItem";
            this.vIEWToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.vIEWToolStripMenuItem.Text = "VIEW";
            // 
            // msp_view_authors
            // 
            this.msp_view_authors.Name = "msp_view_authors";
            this.msp_view_authors.Size = new System.Drawing.Size(124, 22);
            this.msp_view_authors.Text = "Authors";
            this.msp_view_authors.Click += new System.EventHandler(this.msp_view_authors_Click);
            // 
            // msp_view_members
            // 
            this.msp_view_members.Name = "msp_view_members";
            this.msp_view_members.Size = new System.Drawing.Size(124, 22);
            this.msp_view_members.Text = "Members";
            this.msp_view_members.Click += new System.EventHandler(this.msp_view_members_Click);
            // 
            // msp_view_books
            // 
            this.msp_view_books.Name = "msp_view_books";
            this.msp_view_books.Size = new System.Drawing.Size(124, 22);
            this.msp_view_books.Text = "Books";
            this.msp_view_books.Click += new System.EventHandler(this.msp_view_books_Click);
            // 
            // lbx_firstbox
            // 
            this.lbx_firstbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbx_firstbox.FormattingEnabled = true;
            this.lbx_firstbox.Location = new System.Drawing.Point(3, 25);
            this.lbx_firstbox.Name = "lbx_firstbox";
            this.lbx_firstbox.Size = new System.Drawing.Size(247, 459);
            this.lbx_firstbox.TabIndex = 1;
            this.lbx_firstbox.SelectedIndexChanged += new System.EventHandler(this.lbx_firstbox_SelectedIndexChanged);
            // 
            // lbl_firstbox
            // 
            this.lbl_firstbox.AutoSize = true;
            this.lbl_firstbox.Location = new System.Drawing.Point(3, 9);
            this.lbl_firstbox.Name = "lbl_firstbox";
            this.lbl_firstbox.Size = new System.Drawing.Size(41, 13);
            this.lbl_firstbox.TabIndex = 2;
            this.lbl_firstbox.Text = "firstBox";
            // 
            // scr_first
            // 
            this.scr_first.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scr_first.Location = new System.Drawing.Point(0, 27);
            this.scr_first.Name = "scr_first";
            // 
            // scr_first.Panel1
            // 
            this.scr_first.Panel1.Controls.Add(this.lbl_firstbox_search);
            this.scr_first.Panel1.Controls.Add(this.tbx_firsbox);
            this.scr_first.Panel1.Controls.Add(this.lbx_firstbox);
            this.scr_first.Panel1.Controls.Add(this.lbl_firstbox);
            // 
            // scr_first.Panel2
            // 
            this.scr_first.Panel2.Controls.Add(this.scr_second);
            this.scr_first.Size = new System.Drawing.Size(784, 536);
            this.scr_first.SplitterDistance = 254;
            this.scr_first.TabIndex = 3;
            // 
            // lbl_firstbox_search
            // 
            this.lbl_firstbox_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_firstbox_search.AutoSize = true;
            this.lbl_firstbox_search.Location = new System.Drawing.Point(3, 510);
            this.lbl_firstbox_search.Name = "lbl_firstbox_search";
            this.lbl_firstbox_search.Size = new System.Drawing.Size(32, 13);
            this.lbl_firstbox_search.TabIndex = 4;
            this.lbl_firstbox_search.Text = "Filter:";
            // 
            // tbx_firsbox
            // 
            this.tbx_firsbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_firsbox.Location = new System.Drawing.Point(41, 507);
            this.tbx_firsbox.Name = "tbx_firsbox";
            this.tbx_firsbox.Size = new System.Drawing.Size(209, 20);
            this.tbx_firsbox.TabIndex = 3;
            this.tbx_firsbox.TextChanged += new System.EventHandler(this.tbx_firsbox_TextChanged);
            // 
            // scr_second
            // 
            this.scr_second.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scr_second.Location = new System.Drawing.Point(0, 0);
            this.scr_second.Name = "scr_second";
            // 
            // scr_second.Panel1
            // 
            this.scr_second.Panel1.Controls.Add(this.cbx_second_select);
            this.scr_second.Panel1.Controls.Add(this.lbx_secondbox);
            this.scr_second.Size = new System.Drawing.Size(526, 536);
            this.scr_second.SplitterDistance = 259;
            this.scr_second.TabIndex = 0;
            // 
            // cbx_second_select
            // 
            this.cbx_second_select.FormattingEnabled = true;
            this.cbx_second_select.Location = new System.Drawing.Point(3, 3);
            this.cbx_second_select.Name = "cbx_second_select";
            this.cbx_second_select.Size = new System.Drawing.Size(180, 21);
            this.cbx_second_select.TabIndex = 2;
            this.cbx_second_select.SelectedIndexChanged += new System.EventHandler(this.cbx_second_select_SelectedIndexChanged);
            // 
            // lbx_secondbox
            // 
            this.lbx_secondbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbx_secondbox.FormattingEnabled = true;
            this.lbx_secondbox.Location = new System.Drawing.Point(3, 25);
            this.lbx_secondbox.Name = "lbx_secondbox";
            this.lbx_secondbox.Size = new System.Drawing.Size(1097, 459);
            this.lbx_secondbox.TabIndex = 1;
            this.lbx_secondbox.SelectedIndexChanged += new System.EventHandler(this.lbx_secondbox_SelectedIndexChanged);
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.scr_first);
            this.Controls.Add(this.msp_main);
            this.MainMenuStrip = this.msp_main;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "LibraryForm";
            this.Text = "My Library App";
            this.msp_main.ResumeLayout(false);
            this.msp_main.PerformLayout();
            this.scr_first.Panel1.ResumeLayout(false);
            this.scr_first.Panel1.PerformLayout();
            this.scr_first.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scr_first)).EndInit();
            this.scr_first.ResumeLayout(false);
            this.scr_second.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scr_second)).EndInit();
            this.scr_second.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msp_main;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msp_file_add_author;
        private System.Windows.Forms.ToolStripMenuItem msp_file_add_member;
        private System.Windows.Forms.ToolStripMenuItem msp_file_add_book;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem msp_file_exit;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vIEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msp_view_authors;
        private System.Windows.Forms.ToolStripMenuItem msp_view_members;
        private System.Windows.Forms.ToolStripMenuItem msp_view_books;
        private System.Windows.Forms.ListBox lbx_firstbox;
        private System.Windows.Forms.Label lbl_firstbox;
        private System.Windows.Forms.SplitContainer scr_first;
        private System.Windows.Forms.TextBox tbx_firsbox;
        private System.Windows.Forms.Label lbl_firstbox_search;
        private System.Windows.Forms.SplitContainer scr_second;
        private System.Windows.Forms.ListBox lbx_secondbox;
        private System.Windows.Forms.ComboBox cbx_second_select;
        private System.Windows.Forms.ToolStripMenuItem msp_edit_author;
        private System.Windows.Forms.ToolStripMenuItem msp_edit_member;
        private System.Windows.Forms.ToolStripMenuItem msp_edit_book;

    }
}

