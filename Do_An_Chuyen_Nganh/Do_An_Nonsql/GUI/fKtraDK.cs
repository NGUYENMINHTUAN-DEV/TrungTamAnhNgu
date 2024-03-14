using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Chuyen_Nganh.GUI
{
    public partial class fKtraDK : Form
    {
        private bool isOKButtonClicked;
        public fKtraDK()
        {
            InitializeComponent();
            isOKButtonClicked = false;
        }
        public bool IsOKButtonClicked
        {
            get { return isOKButtonClicked; }
        }
        public string SoDienThoaiNhap
        {
            get { return this.txtsdt.Text; }
        }
        
        public bool IsValidPhoneNumber()
        {
            string phoneNumber = txtsdt.Text.Trim();
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Số điện thoại không được bỏ trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!phoneNumber.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa các ký tự số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidPhoneNumber())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
