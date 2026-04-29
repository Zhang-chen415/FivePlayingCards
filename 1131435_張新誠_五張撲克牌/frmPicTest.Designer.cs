namespace _1131435_張新誠_五張撲克牌
{
    partial class frmPicTest
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
            this.btnTest = new System.Windows.Forms.Button();
            this.lblNum = new System.Windows.Forms.Label();
            this.picTest = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Lavender;
            this.btnTest.Location = new System.Drawing.Point(270, 54);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 64);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "換牌";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click_1);
            // 
            // lblNum
            // 
            this.lblNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNum.Location = new System.Drawing.Point(257, 136);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(100, 33);
            this.lblNum.TabIndex = 2;
            // 
            // picTest
            // 
            this.picTest.Image = global::_1131435_張新誠_五張撲克牌.Properties.Resources.back;
            this.picTest.Location = new System.Drawing.Point(86, 54);
            this.picTest.Name = "picTest";
            this.picTest.Size = new System.Drawing.Size(85, 115);
            this.picTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTest.TabIndex = 0;
            this.picTest.TabStop = false;
            // 
            // frmPicTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 229);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.picTest);
            this.Name = "frmPicTest";
            this.Text = "frmPicTest";
            this.Load += new System.EventHandler(this.frmPicTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTest;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblNum;
    }
}