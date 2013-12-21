namespace Dotnetprogrammering_del_1
{
    partial class Uppg3D
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
            this.grbChoose = new System.Windows.Forms.GroupBox();
            this.rdbPyramid = new System.Windows.Forms.RadioButton();
            this.rdbCylinder = new System.Windows.Forms.RadioButton();
            this.rdbPrism = new System.Windows.Forms.RadioButton();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grbChoose.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbChoose
            // 
            this.grbChoose.Controls.Add(this.rdbPyramid);
            this.grbChoose.Controls.Add(this.rdbCylinder);
            this.grbChoose.Controls.Add(this.rdbPrism);
            this.grbChoose.Location = new System.Drawing.Point(42, 51);
            this.grbChoose.Name = "grbChoose";
            this.grbChoose.Size = new System.Drawing.Size(147, 137);
            this.grbChoose.TabIndex = 0;
            this.grbChoose.TabStop = false;
            this.grbChoose.Text = "Välj kropp";
            // 
            // rdbPyramid
            // 
            this.rdbPyramid.AutoSize = true;
            this.rdbPyramid.Location = new System.Drawing.Point(28, 102);
            this.rdbPyramid.Name = "rdbPyramid";
            this.rdbPyramid.Size = new System.Drawing.Size(62, 17);
            this.rdbPyramid.TabIndex = 2;
            this.rdbPyramid.TabStop = true;
            this.rdbPyramid.Text = "Pyramid";
            this.rdbPyramid.UseVisualStyleBackColor = true;
            // 
            // rdbCylinder
            // 
            this.rdbCylinder.AutoSize = true;
            this.rdbCylinder.Location = new System.Drawing.Point(28, 67);
            this.rdbCylinder.Name = "rdbCylinder";
            this.rdbCylinder.Size = new System.Drawing.Size(84, 17);
            this.rdbCylinder.TabIndex = 1;
            this.rdbCylinder.TabStop = true;
            this.rdbCylinder.Text = "Rak cylinder";
            this.rdbCylinder.UseVisualStyleBackColor = true;
            this.rdbCylinder.CheckedChanged += new System.EventHandler(this.rdbCylinder_CheckedChanged);
            // 
            // rdbPrism
            // 
            this.rdbPrism.AutoSize = true;
            this.rdbPrism.Location = new System.Drawing.Point(28, 33);
            this.rdbPrism.Name = "rdbPrism";
            this.rdbPrism.Size = new System.Drawing.Size(56, 17);
            this.rdbPrism.TabIndex = 0;
            this.rdbPrism.TabStop = true;
            this.rdbPrism.Text = "Prisma";
            this.rdbPrism.UseVisualStyleBackColor = true;
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(157, 221);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(100, 20);
            this.txtBase.TabIndex = 1;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(48, 224);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(77, 13);
            this.lblBase.TabIndex = 2;
            this.lblBase.Text = "Basytans area:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(48, 261);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(44, 13);
            this.lblHeight.TabIndex = 3;
            this.lblHeight.Text = "Höjden:";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(157, 258);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 4;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(157, 352);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(100, 20);
            this.txtResult.TabIndex = 5;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(48, 355);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(62, 13);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Volymen är:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(157, 299);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Beräkna";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(35, 299);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Rensa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Uppg3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 389);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblBase);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.grbChoose);
            this.Name = "Uppg3D";
            this.Text = "Uppgift 3D";
            this.grbChoose.ResumeLayout(false);
            this.grbChoose.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbChoose;
        private System.Windows.Forms.RadioButton rdbPyramid;
        private System.Windows.Forms.RadioButton rdbCylinder;
        private System.Windows.Forms.RadioButton rdbPrism;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
    }
}