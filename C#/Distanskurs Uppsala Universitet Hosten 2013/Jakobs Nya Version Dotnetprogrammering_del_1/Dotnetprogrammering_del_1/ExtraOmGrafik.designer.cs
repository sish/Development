namespace Dotnetprogrammering_del_1
{
    partial class ExtraOmGrafik
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
            this.paintBox = new System.Windows.Forms.PictureBox();
            this.btnRita1A = new System.Windows.Forms.Button();
            this.btnRita1B = new System.Windows.Forms.Button();
            this.btnSudda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.paintBox)).BeginInit();
            this.SuspendLayout();
            // 
            // paintBox
            // 
            this.paintBox.BackColor = System.Drawing.Color.White;
            this.paintBox.Location = new System.Drawing.Point(13, 13);
            this.paintBox.Name = "paintBox";
            this.paintBox.Size = new System.Drawing.Size(556, 343);
            this.paintBox.TabIndex = 0;
            this.paintBox.TabStop = false;
            // 
            // btnRita1A
            // 
            this.btnRita1A.Location = new System.Drawing.Point(44, 389);
            this.btnRita1A.Name = "btnRita1A";
            this.btnRita1A.Size = new System.Drawing.Size(152, 23);
            this.btnRita1A.TabIndex = 1;
            this.btnRita1A.Text = "1A - rita";
            this.btnRita1A.UseVisualStyleBackColor = true;
            this.btnRita1A.Click += new System.EventHandler(this.btnRita1A_Click);
            // 
            // btnRita1B
            // 
            this.btnRita1B.Location = new System.Drawing.Point(223, 389);
            this.btnRita1B.Name = "btnRita1B";
            this.btnRita1B.Size = new System.Drawing.Size(152, 23);
            this.btnRita1B.TabIndex = 2;
            this.btnRita1B.Text = "1B - rita";
            this.btnRita1B.UseVisualStyleBackColor = true;
            this.btnRita1B.Click += new System.EventHandler(this.btnRita1B_Click);
            // 
            // btnSudda
            // 
            this.btnSudda.Location = new System.Drawing.Point(446, 388);
            this.btnSudda.Name = "btnSudda";
            this.btnSudda.Size = new System.Drawing.Size(75, 23);
            this.btnSudda.TabIndex = 3;
            this.btnSudda.Text = "Sudda";
            this.btnSudda.UseVisualStyleBackColor = true;
            this.btnSudda.Click += new System.EventHandler(this.btnSudda_Click);
            // 
            // ExtraOmGrafik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 474);
            this.Controls.Add(this.btnSudda);
            this.Controls.Add(this.btnRita1B);
            this.Controls.Add(this.btnRita1A);
            this.Controls.Add(this.paintBox);
            this.Name = "ExtraOmGrafik";
            this.Text = "Grafik";
            ((System.ComponentModel.ISupportInitialize)(this.paintBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox paintBox;
        private System.Windows.Forms.Button btnRita1A;
        private System.Windows.Forms.Button btnRita1B;
        private System.Windows.Forms.Button btnSudda;
    }
}