namespace Do_An_Chuyen_Nganh.GUI
{
    partial class fSapXepLopHoc
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboMaLop = new System.Windows.Forms.ComboBox();
            this.dataQuanLyLopHocVien = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.btnThemLop = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comHocvien = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuanLyLopHocVien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboMaLop);
            this.groupBox2.Controls.Add(this.dataQuanLyLopHocVien);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnThemLop);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.comHocvien);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(5, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1737, 836);
            this.groupBox2.TabIndex = 86;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Học Viên Theo Lớp";
            // 
            // comboMaLop
            // 
            this.comboMaLop.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMaLop.FormattingEnabled = true;
            this.comboMaLop.Location = new System.Drawing.Point(413, 44);
            this.comboMaLop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboMaLop.Name = "comboMaLop";
            this.comboMaLop.Size = new System.Drawing.Size(316, 34);
            this.comboMaLop.TabIndex = 105;
            this.comboMaLop.SelectedIndexChanged += new System.EventHandler(this.comboMaLop_SelectedIndexChanged);
            // 
            // dataQuanLyLopHocVien
            // 
            this.dataQuanLyLopHocVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataQuanLyLopHocVien.Location = new System.Drawing.Point(8, 167);
            this.dataQuanLyLopHocVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataQuanLyLopHocVien.Name = "dataQuanLyLopHocVien";
            this.dataQuanLyLopHocVien.RowHeadersWidth = 51;
            this.dataQuanLyLopHocVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataQuanLyLopHocVien.Size = new System.Drawing.Size(1621, 661);
            this.dataQuanLyLopHocVien.TabIndex = 89;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(901, 44);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 26);
            this.label12.TabIndex = 92;
            this.label12.Text = "Tên Học Viên";
            // 
            // btnThemLop
            // 
            this.btnThemLop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThemLop.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLop.Image = global::Do_An_Chuyen_Nganh.Properties.Resources.icons8_save_50;
            this.btnThemLop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemLop.Location = new System.Drawing.Point(728, 101);
            this.btnThemLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemLop.Name = "btnThemLop";
            this.btnThemLop.Size = new System.Drawing.Size(196, 49);
            this.btnThemLop.TabIndex = 86;
            this.btnThemLop.Text = "Thêm Lớp học";
            this.btnThemLop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemLop.UseVisualStyleBackColor = false;
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(193, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 26);
            this.label11.TabIndex = 91;
            this.label11.Text = "Tên Lớp";
            // 
            // comHocvien
            // 
            this.comHocvien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comHocvien.FormattingEnabled = true;
            this.comHocvien.Location = new System.Drawing.Point(1121, 44);
            this.comHocvien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comHocvien.Name = "comHocvien";
            this.comHocvien.Size = new System.Drawing.Size(316, 34);
            this.comHocvien.TabIndex = 97;
            // 
            // fSapXepLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 838);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fSapXepLopHoc";
            this.Text = "fSapXepLopHoc";
            this.Load += new System.EventHandler(this.fSapXepLopHoc_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataQuanLyLopHocVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboMaLop;
        private System.Windows.Forms.DataGridView dataQuanLyLopHocVien;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnThemLop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comHocvien;
    }
}