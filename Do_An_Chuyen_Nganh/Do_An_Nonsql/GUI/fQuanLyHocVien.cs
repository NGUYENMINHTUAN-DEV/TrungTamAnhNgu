using _BLL;
using Do_An_Chuyen_Nganh.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Chuyen_Nganh
{
    public partial class fQuanLyHocVien : Form
    {
        private XuLyHocVien hocvien = new XuLyHocVien();
        private XuLyTaiKhoan xuLyTaiKhoan = new XuLyTaiKhoan();
        private Random random = new Random();
        public fQuanLyHocVien()
        {
            InitializeComponent();
        }

        private void LoadGioiTinhComboBox()
        {
            comboGT.Items.Add("Nam");
            comboGT.Items.Add("Nữ");
            comboGT.SelectedIndex = 0;
        }

        private void XulyCotTiengViet()
        {
            dataHV.Columns["MaHocVien"].HeaderText = "Mã Học Viên";
            dataHV.Columns["HoTen"].HeaderText = "Họ Tên";
            dataHV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dataHV.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dataHV.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dataHV.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dataHV.Columns["Email"].HeaderText = "Email";
            dataHV.Columns["MaTaiKhoan"].HeaderText = "Mã Tài Khoản";
        }

        private void LoadData()
        {
            dataHV.DataSource = hocvien.GetHocVien();
            dataHV.Columns["TaiKhoan"].Visible = false;
            comboMaTaiKhoan.DataSource = hocvien.GetMaTaiKhoan();
        }

        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in dataHV.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void fQuanLyHocVien_Load(object sender, EventArgs e)
        {
            LoadGioiTinhComboBox();
            LoadData();
            AutoSizeColumns();
            XulyCotTiengViet();
        }

        private void dataHV_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataHV.CurrentRow;
            if (selectedRow != null)
            {
                string manv = selectedRow.Cells["MaHocVien"].Value.ToString();
                string hoTen = selectedRow.Cells["HoTen"].Value.ToString();
                DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                string diaChi = selectedRow.Cells["DiaChi"].Value.ToString();
                string soDienThoai = selectedRow.Cells["SoDienThoai"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();
                string maTaiKhoan = selectedRow.Cells["MaTaiKhoan"].Value.ToString();
                txtMa.Text = manv;
                txtHT.Text = hoTen;
                dateNS.Value = ngaySinh;
                comboGT.Text = gioiTinh;
                txtdc.Text = diaChi;
                txtsdt.Text = soDienThoai;
                txtemail.Text = email;
                comboMaTaiKhoan.Text = maTaiKhoan;
            }
        }
        private string SinhMaHocVien()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "HV" + randomPart;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string[] maTaiKhoanParts = comboMaTaiKhoan.Text.Split('-');
            string maTaiKhoan = maTaiKhoanParts[0].Trim();
            HocVien Hocvien = new HocVien
            {
                MaHocVien = SinhMaHocVien(),
                HoTen = txtHT.Text,
                NgaySinh = DateTime.Parse(dateNS.Text),
                GioiTinh = comboGT.Text,
                DiaChi = txtdc.Text,
                SoDienThoai = txtsdt.Text,
                Email = txtemail.Text,
                MaTaiKhoan = maTaiKhoan
            };

            hocvien.ThemHocVien(Hocvien);
            LoadData();
            ClearInputFields();
        }
        private void ClearInputFields()
        {
            txtMa.Clear();
            txtHT.Clear();
            dateNS.Value = DateTime.Now;
            comboGT.SelectedIndex = -1;
            txtdc.Clear();
            txtsdt.Clear();
            txtemail.Clear();
            comboMaTaiKhoan.SelectedIndex = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataHV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataHV.SelectedRows[0];
                string mahv = selectedRow.Cells["MaHocVien"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa học viên có mã " + mahv + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    XuLyHocVien hocvienProcessor = new XuLyHocVien();
                    hocvienProcessor.XoaHocVien(mahv);
                    dataHV.DataSource = hocvienProcessor.GetHocVien();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataHV.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataHV.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataHV.Rows[selectedRowIndex];
                string mahv = selectedRow.Cells["MaHocVien"].Value.ToString();
                string[] maTaiKhoanParts = comboMaTaiKhoan.Text.Split('-');
                string maTaiKhoan = maTaiKhoanParts[0].Trim();
                HocVien Hocvien = new HocVien
                {
                    MaHocVien = txtMa.Text,
                    HoTen = txtHT.Text,
                    NgaySinh = DateTime.Parse(dateNS.Text),
                    GioiTinh = comboGT.Text,
                    DiaChi = txtdc.Text,
                    SoDienThoai = txtsdt.Text,
                    Email = txtemail.Text,
                    MaTaiKhoan = maTaiKhoan
                };
                XuLyHocVien hocvienProcessor = new XuLyHocVien();
                hocvienProcessor.SuaHocVien(Hocvien);
                dataHV.DataSource = hocvienProcessor.GetHocVien();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học viên sửa chữa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTk.Text.Trim();
            List<HocVien> ketQuaTimKiem = hocvien.TimKiemHocVien(tuKhoa);
            dataHV.DataSource = ketQuaTimKiem;
        }
        private void TaoTaiKhoanTuDong()
        {
            var taiKhoan = xuLyTaiKhoan.TaoTaiKhoanHocVienNgauNhien();

            if (taiKhoan != null)
            {
                string thongTinTaiKhoan = $"Tên đăng nhập:   {taiKhoan.TenDangNhap}   \nMật khẩu:   {taiKhoan.MatKhau}   \nQuyền truy cập:   {taiKhoan.MaQuyenTruyCap}";
                MessageBox.Show(thongTinTaiKhoan, "Thông tin tài khoản học viên");
                comboMaTaiKhoan.DataSource = hocvien.GetMaTaiKhoan();
            }
            else
            {
                MessageBox.Show("Không thể tạo tài khoản học viên tự động.", "Lỗi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomMessageBoxForm customMessageBox = new CustomMessageBoxForm();
            customMessageBox.StartPosition = FormStartPosition.CenterScreen;
            string buttonTextYes = "Tự động";
            string buttonTextNo = "Bằng tay";
            DialogResult dialogResult = customMessageBox.ShowDialog(buttonTextYes, buttonTextNo, "Chọn cách tạo tài khoản: ", "Lựa chọn tạo tài khoản ");
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    TaoTaiKhoanTuDong();
                    break;
                case DialogResult.No:
                    fQuanLyPhanQuyen a = new fQuanLyPhanQuyen();
                    a.StartPosition = FormStartPosition.CenterScreen;
                    a.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Đã hủy tạo tài khoản.", "Thông báo");
                    break;
            }

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            if (!(new Regex(@"^[\w\.]+@([\w]+\.)+[\w]{2,4}$").IsMatch(txtemail.Text)))
            {
                errorProvider1.SetError(txtemail, "Định dạng email sai!");
                return;
            }
            this.errorProvider1.Clear();
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnHienThiTT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataHV.CurrentRow;

            if (selectedRow != null)
            {
                string maTaiKhoan = selectedRow.Cells["MaTaiKhoan"].Value.ToString();
                TaiKhoan taiKhoan = xuLyTaiKhoan.LayThongTinTaiKhoan(maTaiKhoan);

                if (taiKhoan != null)
                {
                    string thongTinTaiKhoan = $"Tên đăng nhập: {taiKhoan.TenDangNhap}\nMật khẩu: {taiKhoan.MatKhau}";
                    MessageBox.Show(thongTinTaiKhoan, "Thông tin tài khoản");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin tài khoản.", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một giảng viên để hiển thị thông tin tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
