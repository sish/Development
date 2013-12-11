namespace Library
{
    partial class MemberForm
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_personal_number = new System.Windows.Forms.Label();
            this.tbx_personal_id = new System.Windows.Forms.TextBox();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.btn_save_edit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(39, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Name:";
            // 
            // lbl_personal_number
            // 
            this.lbl_personal_number.AutoSize = true;
            this.lbl_personal_number.Location = new System.Drawing.Point(12, 35);
            this.lbl_personal_number.Name = "lbl_personal_number";
            this.lbl_personal_number.Size = new System.Drawing.Size(65, 13);
            this.lbl_personal_number.TabIndex = 1;
            this.lbl_personal_number.Text = "Personal ID:";
            // 
            // tbx_personal_id
            // 
            this.tbx_personal_id.Location = new System.Drawing.Point(83, 32);
            this.tbx_personal_id.Name = "tbx_personal_id";
            this.tbx_personal_id.Size = new System.Drawing.Size(155, 20);
            this.tbx_personal_id.TabIndex = 2;
            this.tbx_personal_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_personal_id_KeyPress);
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(83, 6);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(155, 20);
            this.tbx_name.TabIndex = 1;
            // 
            // btn_save_edit
            // 
            this.btn_save_edit.Location = new System.Drawing.Point(244, 4);
            this.btn_save_edit.Name = "btn_save_edit";
            this.btn_save_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_save_edit.TabIndex = 3;
            this.btn_save_edit.Text = "button1";
            this.btn_save_edit.UseVisualStyleBackColor = true;
            this.btn_save_edit.Click += new System.EventHandler(this.btn_save_edit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(244, 30);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // MemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 63);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save_edit);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.tbx_personal_id);
            this.Controls.Add(this.lbl_personal_number);
            this.Controls.Add(this.lbl_name);
            this.MinimumSize = new System.Drawing.Size(346, 101);
            this.Name = "MemberForm";
            this.Text = "Member";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_personal_number;
        private System.Windows.Forms.TextBox tbx_personal_id;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Button btn_save_edit;
        private System.Windows.Forms.Button btn_cancel;
    }
}