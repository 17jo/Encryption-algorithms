
namespace _17969_Jovana_Stepanovic
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
            this.btnRC4 = new System.Windows.Forms.Button();
            this.btnEnigma = new System.Windows.Forms.Button();
            this.btnTEA = new System.Windows.Forms.Button();
            this.btnCBC = new System.Windows.Forms.Button();
            this.btnCRC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRC4
            // 
            this.btnRC4.Location = new System.Drawing.Point(64, 70);
            this.btnRC4.Name = "btnRC4";
            this.btnRC4.Size = new System.Drawing.Size(107, 50);
            this.btnRC4.TabIndex = 0;
            this.btnRC4.Text = "RC4";
            this.btnRC4.UseVisualStyleBackColor = true;
            this.btnRC4.Click += new System.EventHandler(this.btnRC4_Click);
            // 
            // btnEnigma
            // 
            this.btnEnigma.Location = new System.Drawing.Point(274, 182);
            this.btnEnigma.Name = "btnEnigma";
            this.btnEnigma.Size = new System.Drawing.Size(107, 50);
            this.btnEnigma.TabIndex = 1;
            this.btnEnigma.Text = "Enigma";
            this.btnEnigma.UseVisualStyleBackColor = true;
            this.btnEnigma.Click += new System.EventHandler(this.btnEnigma_Click);
            // 
            // btnTEA
            // 
            this.btnTEA.Location = new System.Drawing.Point(171, 126);
            this.btnTEA.Name = "btnTEA";
            this.btnTEA.Size = new System.Drawing.Size(107, 50);
            this.btnTEA.TabIndex = 2;
            this.btnTEA.Text = "TEA";
            this.btnTEA.UseVisualStyleBackColor = true;
            this.btnTEA.Click += new System.EventHandler(this.btnTEA_Click);
            // 
            // btnCBC
            // 
            this.btnCBC.Location = new System.Drawing.Point(64, 182);
            this.btnCBC.Name = "btnCBC";
            this.btnCBC.Size = new System.Drawing.Size(107, 50);
            this.btnCBC.TabIndex = 3;
            this.btnCBC.Text = "CBC";
            this.btnCBC.UseVisualStyleBackColor = true;
            this.btnCBC.Click += new System.EventHandler(this.btnCBC_Click);
            // 
            // btnCRC
            // 
            this.btnCRC.Location = new System.Drawing.Point(274, 70);
            this.btnCRC.Name = "btnCRC";
            this.btnCRC.Size = new System.Drawing.Size(107, 50);
            this.btnCRC.TabIndex = 4;
            this.btnCRC.Text = "CRC";
            this.btnCRC.UseVisualStyleBackColor = true;
            this.btnCRC.Click += new System.EventHandler(this.btnCRC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 320);
            this.Controls.Add(this.btnCRC);
            this.Controls.Add(this.btnCBC);
            this.Controls.Add(this.btnTEA);
            this.Controls.Add(this.btnEnigma);
            this.Controls.Add(this.btnRC4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRC4;
        private System.Windows.Forms.Button btnEnigma;
        private System.Windows.Forms.Button btnTEA;
        private System.Windows.Forms.Button btnCBC;
        private System.Windows.Forms.Button btnCRC;
    }
}

