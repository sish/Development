namespace Library
{
    partial class AuthorForm
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
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_SaveEdit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(56, 12);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(170, 20);
            this.tbx_name.TabIndex = 0;
            this.tbx_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_name_KeyPress);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 15);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "Name:";
            // 
            // btn_SaveEdit
            // 
            this.btn_SaveEdit.Location = new System.Drawing.Point(232, 10);
            this.btn_SaveEdit.Name = "btn_SaveEdit";
            this.btn_SaveEdit.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveEdit.TabIndex = 2;
            this.btn_SaveEdit.Text = "button1";
            this.btn_SaveEdit.UseVisualStyleBackColor = true;
            this.btn_SaveEdit.Click += new System.EventHandler(this.btn_SaveEdit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(313, 10);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // AuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 45);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_SaveEdit);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.tbx_name);
            this.MinimumSize = new System.Drawing.Size(413, 83);
            this.Name = "AuthorForm";
            this.Text = "Author";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_SaveEdit;
        private System.Windows.Forms.Button btn_cancel;
    }
}