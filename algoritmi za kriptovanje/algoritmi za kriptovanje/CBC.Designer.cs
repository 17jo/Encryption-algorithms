
namespace _17969_Jovana_Stepanovic
{
    partial class CBC
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDecrypt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEncrypt = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.btnDecryptFile = new System.Windows.Forms.Button();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.btnEncryptBitmap = new System.Windows.Forms.Button();
            this.btnDecryptBitmap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "Decrypt message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Encrypt message";
            // 
            // tbDecrypt
            // 
            this.tbDecrypt.Location = new System.Drawing.Point(157, 340);
            this.tbDecrypt.Multiline = true;
            this.tbDecrypt.Name = "tbDecrypt";
            this.tbDecrypt.Size = new System.Drawing.Size(618, 87);
            this.tbDecrypt.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Message";
            // 
            // tbEncrypt
            // 
            this.tbEncrypt.Location = new System.Drawing.Point(157, 240);
            this.tbEncrypt.Multiline = true;
            this.tbEncrypt.Name = "tbEncrypt";
            this.tbEncrypt.Size = new System.Drawing.Size(618, 86);
            this.tbEncrypt.TabIndex = 32;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(261, 175);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 31;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(157, 176);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 30;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(157, 102);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(100, 22);
            this.tbKey.TabIndex = 29;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(157, 23);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(100, 22);
            this.tbMessage.TabIndex = 28;
            // 
            // btnDecryptFile
            // 
            this.btnDecryptFile.Location = new System.Drawing.Point(653, 23);
            this.btnDecryptFile.Name = "btnDecryptFile";
            this.btnDecryptFile.Size = new System.Drawing.Size(122, 50);
            this.btnDecryptFile.TabIndex = 39;
            this.btnDecryptFile.Text = "DecryptFile";
            this.btnDecryptFile.UseVisualStyleBackColor = true;
            this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // btnEncryptFile
            // 
            this.btnEncryptFile.Location = new System.Drawing.Point(472, 23);
            this.btnEncryptFile.Name = "btnEncryptFile";
            this.btnEncryptFile.Size = new System.Drawing.Size(122, 50);
            this.btnEncryptFile.TabIndex = 38;
            this.btnEncryptFile.Text = "EncryptFile";
            this.btnEncryptFile.UseVisualStyleBackColor = true;
            this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);
            // 
            // btnEncryptBitmap
            // 
            this.btnEncryptBitmap.Location = new System.Drawing.Point(472, 127);
            this.btnEncryptBitmap.Name = "btnEncryptBitmap";
            this.btnEncryptBitmap.Size = new System.Drawing.Size(133, 49);
            this.btnEncryptBitmap.TabIndex = 40;
            this.btnEncryptBitmap.Text = "EncryptBitmap";
            this.btnEncryptBitmap.UseVisualStyleBackColor = true;
            this.btnEncryptBitmap.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDecryptBitmap
            // 
            this.btnDecryptBitmap.Location = new System.Drawing.Point(653, 127);
            this.btnDecryptBitmap.Name = "btnDecryptBitmap";
            this.btnDecryptBitmap.Size = new System.Drawing.Size(122, 49);
            this.btnDecryptBitmap.TabIndex = 41;
            this.btnDecryptBitmap.Text = "DecryptBitmap";
            this.btnDecryptBitmap.UseVisualStyleBackColor = true;
            this.btnDecryptBitmap.Click += new System.EventHandler(this.btnDecryptBitmap_Click);
            // 
            // CBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDecryptBitmap);
            this.Controls.Add(this.btnEncryptBitmap);
            this.Controls.Add(this.btnDecryptFile);
            this.Controls.Add(this.btnEncryptFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDecrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.tbMessage);
            this.Name = "CBC";
            this.Text = "CBC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDecrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.Button btnEncryptBitmap;
        private System.Windows.Forms.Button btnDecryptBitmap;
    }
}