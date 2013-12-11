namespace CustomCollectionsTestApp
{
    partial class TestApp
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
            this.lbl_int = new System.Windows.Forms.Label();
            this.tbx_addint = new System.Windows.Forms.TextBox();
            this.btn_addint = new System.Windows.Forms.Button();
            this.lbx_intlist = new System.Windows.Forms.ListBox();
            this.btn_intremove = new System.Windows.Forms.Button();
            this.btn_containsint = new System.Windows.Forms.Button();
            this.tbx_containsint = new System.Windows.Forms.TextBox();
            this.lbl_containsint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_int
            // 
            this.lbl_int.AutoSize = true;
            this.lbl_int.Location = new System.Drawing.Point(12, 9);
            this.lbl_int.Name = "lbl_int";
            this.lbl_int.Size = new System.Drawing.Size(68, 13);
            this.lbl_int.TabIndex = 0;
            this.lbl_int.Text = "Test Add Int:";
            // 
            // tbx_addint
            // 
            this.tbx_addint.Location = new System.Drawing.Point(86, 6);
            this.tbx_addint.Name = "tbx_addint";
            this.tbx_addint.Size = new System.Drawing.Size(100, 20);
            this.tbx_addint.TabIndex = 1;
            // 
            // btn_addint
            // 
            this.btn_addint.Location = new System.Drawing.Point(192, 4);
            this.btn_addint.Name = "btn_addint";
            this.btn_addint.Size = new System.Drawing.Size(75, 23);
            this.btn_addint.TabIndex = 2;
            this.btn_addint.Text = "Add";
            this.btn_addint.UseVisualStyleBackColor = true;
            this.btn_addint.Click += new System.EventHandler(this.btn_addint_Click);
            // 
            // lbx_intlist
            // 
            this.lbx_intlist.FormattingEnabled = true;
            this.lbx_intlist.Location = new System.Drawing.Point(273, 4);
            this.lbx_intlist.Name = "lbx_intlist";
            this.lbx_intlist.Size = new System.Drawing.Size(114, 199);
            this.lbx_intlist.TabIndex = 3;
            // 
            // btn_intremove
            // 
            this.btn_intremove.Location = new System.Drawing.Point(192, 33);
            this.btn_intremove.Name = "btn_intremove";
            this.btn_intremove.Size = new System.Drawing.Size(75, 23);
            this.btn_intremove.TabIndex = 4;
            this.btn_intremove.Text = "Remove";
            this.btn_intremove.UseVisualStyleBackColor = true;
            this.btn_intremove.Click += new System.EventHandler(this.btn_intremove_Click);
            // 
            // btn_containsint
            // 
            this.btn_containsint.Location = new System.Drawing.Point(192, 62);
            this.btn_containsint.Name = "btn_containsint";
            this.btn_containsint.Size = new System.Drawing.Size(75, 23);
            this.btn_containsint.TabIndex = 5;
            this.btn_containsint.Text = "Contains";
            this.btn_containsint.UseVisualStyleBackColor = true;
            this.btn_containsint.Click += new System.EventHandler(this.btn_containsint_Click);
            // 
            // tbx_containsint
            // 
            this.tbx_containsint.Location = new System.Drawing.Point(86, 64);
            this.tbx_containsint.Name = "tbx_containsint";
            this.tbx_containsint.Size = new System.Drawing.Size(100, 20);
            this.tbx_containsint.TabIndex = 6;
            // 
            // lbl_containsint
            // 
            this.lbl_containsint.AutoSize = true;
            this.lbl_containsint.Location = new System.Drawing.Point(12, 67);
            this.lbl_containsint.Name = "lbl_containsint";
            this.lbl_containsint.Size = new System.Drawing.Size(59, 13);
            this.lbl_containsint.TabIndex = 7;
            this.lbl_containsint.Text = "Check that";
            // 
            // TestApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 300);
            this.Controls.Add(this.lbl_containsint);
            this.Controls.Add(this.tbx_containsint);
            this.Controls.Add(this.btn_containsint);
            this.Controls.Add(this.btn_intremove);
            this.Controls.Add(this.lbx_intlist);
            this.Controls.Add(this.btn_addint);
            this.Controls.Add(this.tbx_addint);
            this.Controls.Add(this.lbl_int);
            this.Name = "TestApp";
            this.Text = "Test ObservableList";
            this.Load += new System.EventHandler(this.TestApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_int;
        private System.Windows.Forms.TextBox tbx_addint;
        private System.Windows.Forms.Button btn_addint;
        private System.Windows.Forms.ListBox lbx_intlist;
        private System.Windows.Forms.Button btn_intremove;
        private System.Windows.Forms.Button btn_containsint;
        private System.Windows.Forms.TextBox tbx_containsint;
        private System.Windows.Forms.Label lbl_containsint;
    }
}

