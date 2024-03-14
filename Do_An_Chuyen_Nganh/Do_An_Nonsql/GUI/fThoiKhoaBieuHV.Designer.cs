namespace Do_An_Chuyen_Nganh.GUI
{
    partial class fThoiKhoaBieuHV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataTKB = new System.Windows.Forms.DataGridView();
            this.btnInLich = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataTKB)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTKB
            // 
            this.dataTKB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataTKB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTKB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataTKB.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataTKB.Location = new System.Drawing.Point(13, 13);
            this.dataTKB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataTKB.Name = "dataTKB";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTKB.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataTKB.RowHeadersWidth = 51;
            this.dataTKB.Size = new System.Drawing.Size(1609, 762);
            this.dataTKB.TabIndex = 0;
            this.dataTKB.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataTKB_CellFormatting);
            // 
            // btnInLich
            // 
            this.btnInLich.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnInLich.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInLich.Location = new System.Drawing.Point(1487, 783);
            this.btnInLich.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInLich.Name = "btnInLich";
            this.btnInLich.Size = new System.Drawing.Size(135, 42);
            this.btnInLich.TabIndex = 3;
            this.btnInLich.Text = "In Lịch";
            this.btnInLich.UseVisualStyleBackColor = false;
            this.btnInLich.Click += new System.EventHandler(this.button1_Click);
            // 
            // fThoiKhoaBieuHV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 838);
            this.Controls.Add(this.btnInLich);
            this.Controls.Add(this.dataTKB);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fThoiKhoaBieuHV";
            this.Text = "fThoiKhoaBieu";
            this.Load += new System.EventHandler(this.fThoiKhoaBieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTKB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataTKB;
        private System.Windows.Forms.Button btnInLich;
    }
}