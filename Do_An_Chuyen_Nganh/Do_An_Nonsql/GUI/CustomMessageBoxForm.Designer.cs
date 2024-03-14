namespace Do_An_Chuyen_Nganh.GUI
{
    partial class CustomMessageBoxForm
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
            this.btnTudong = new System.Windows.Forms.Button();
            this.btnBangtay = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTudong
            // 
            this.btnTudong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTudong.Location = new System.Drawing.Point(190, 65);
            this.btnTudong.Name = "btnTudong";
            this.btnTudong.Size = new System.Drawing.Size(82, 26);
            this.btnTudong.TabIndex = 0;
            this.btnTudong.Text = "Tự động";
            this.btnTudong.UseVisualStyleBackColor = true;
            this.btnTudong.Click += new System.EventHandler(this.btnTudong_Click);
            // 
            // btnBangtay
            // 
            this.btnBangtay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBangtay.Location = new System.Drawing.Point(287, 65);
            this.btnBangtay.Name = "btnBangtay";
            this.btnBangtay.Size = new System.Drawing.Size(86, 26);
            this.btnBangtay.TabIndex = 1;
            this.btnBangtay.Text = "Bằng tay";
            this.btnBangtay.UseVisualStyleBackColor = true;
            this.btnBangtay.Click += new System.EventHandler(this.btnBangtay_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(38, 23);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(45, 19);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "label1";
            // 
            // CustomMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 103);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.btnBangtay);
            this.Controls.Add(this.btnTudong);
            this.Name = "CustomMessageBoxForm";
            this.Text = "CustomMessageBoxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTudong;
        private System.Windows.Forms.Button btnBangtay;
        private System.Windows.Forms.Label labelMessage;
    }
}