namespace DEC_HEX_BIN
{
    partial class Form1
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
            this.tbDec = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHex = new System.Windows.Forms.MaskedTextBox();
            this.tbBin = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // tbDec
            // 
            this.tbDec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDec.BackColor = System.Drawing.SystemColors.Window;
            this.tbDec.Location = new System.Drawing.Point(36, 12);
            this.tbDec.Name = "tbDec";
            this.tbDec.Size = new System.Drawing.Size(236, 20);
            this.tbDec.TabIndex = 3;
            this.tbDec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            this.tbDec.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            this.tbDec.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbDec_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "DEC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "BIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "HEX";
            // 
            // tbHex
            // 
            this.tbHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHex.Location = new System.Drawing.Point(36, 66);
            this.tbHex.Name = "tbHex";
            this.tbHex.Size = new System.Drawing.Size(236, 20);
            this.tbHex.TabIndex = 7;
            this.tbHex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            this.tbHex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            this.tbHex.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbHex_PreviewKeyDown);
            // 
            // tbBin
            // 
            this.tbBin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBin.Location = new System.Drawing.Point(36, 39);
            this.tbBin.Name = "tbBin";
            this.tbBin.Size = new System.Drawing.Size(236, 20);
            this.tbBin.TabIndex = 8;
            this.tbBin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_KeyPress);
            this.tbBin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_KeyUp);
            this.tbBin.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbBin_PreviewKeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 91);
            this.Controls.Add(this.tbBin);
            this.Controls.Add(this.tbHex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDec);
            this.Name = "Form1";
            this.Text = "DEC-HEX-BIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox tbDec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbHex;
        private System.Windows.Forms.MaskedTextBox tbBin;
    }
}

