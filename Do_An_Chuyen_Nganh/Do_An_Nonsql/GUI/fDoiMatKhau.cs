using _BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Chuyen_Nganh
{
    public partial class fDoiMatKhau : Form
    {
        public fDoiMatKhau()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';
            txtMKMoi.PasswordChar = '*';
            txtXacNhanMK.PasswordChar = '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap f = new fDangNhap();
            f.ShowDialog();
            this.Close();
        }

        private void cboHTMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienThiMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = '\0'; // Hiển thị mật khẩu
                txtMKMoi.PasswordChar = '\0';
                txtXacNhanMK.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*'; // Ẩn mật khẩu bằng ký tự '*'
                txtMKMoi.PasswordChar = '*';
                txtXacNhanMK.PasswordChar = '*';
            }
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDN.Text;
            string matKhauHienTai = txtMatKhau.Text;
            string matKhauMoi = txtMKMoi.Text;
            string xacNhanMatKhau = txtXacNhanMK.Text;

            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp với mật khẩu mới. Vui lòng nhập lại.");
                return;
            }

            XuLyTaiKhoan taiKhoanContext = new XuLyTaiKhoan();
            bool doiMatKhauThanhCong = taiKhoanContext.DoiMatKhau(tenDangNhap, matKhauHienTai, matKhauMoi);

            if (doiMatKhauThanhCong)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.");
            }
        }
    }
}
