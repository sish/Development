namespace Dotnetprogrammering_del_1
{
    partial class Uppg2B
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
            this.txtNetto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrutto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBeräkna = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNetto
            // 
            this.txtNetto.Location = new System.Drawing.Point(112, 45);
            this.txtNetto.Name = "txtNetto";
            this.txtNetto.Size = new System.Drawing.Size(100, 20);
            this.txtNetto.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nettopris";
            // 
            // txtBrutto
            // 
            this.txtBrutto.Location = new System.Drawing.Point(112, 85);
            this.txtBrutto.Name = "txtBrutto";
            this.txtBrutto.ReadOnly = true;
            this.txtBrutto.Size = new System.Drawing.Size(100, 20);
            this.txtBrutto.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pris inkl. moms";
            // 
            // btnBeräkna
            // 
            this.btnBeräkna.Location = new System.Drawing.Point(74, 150);
            this.btnBeräkna.Name = "btnBeräkna";
            this.btnBeräkna.Size = new System.Drawing.Size(75, 23);
            this.btnBeräkna.TabIndex = 4;
            this.btnBeräkna.Text = "Beräkna";
            this.btnBeräkna.UseVisualStyleBackColor = true;
            this.btnBeräkna.Click += new System.EventHandler(this.btnBeräkna_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(155, 150);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Radera";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Uppg2B
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBeräkna);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBrutto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNetto);
            this.Name = "Uppg2B";
            this.Text = "Uppgift 2B";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNetto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrutto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBeräkna;
        private System.Windows.Forms.Button btnClear;
    }
}