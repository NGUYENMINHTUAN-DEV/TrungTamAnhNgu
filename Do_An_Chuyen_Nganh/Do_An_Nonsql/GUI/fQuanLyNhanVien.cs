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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Do_An_Chuyen_Nganh
{
    public partial class fQuanLyNhanVien : Form
    {
        private XuLyNhanVien nhanvien = new XuLyNhanVien();
        private XuLyTaiKhoan xuLyTaiKhoan = new XuLyTaiKhoan();
        private Random random = new Random();
        public fQuanLyNhanVien()
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
            datanv.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            datanv.Columns["HoTen"].HeaderText = "Họ Tên";
            datanv.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            datanv.Columns["GioiTinh"].HeaderText = "Giới Tính";
            datanv.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            datanv.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            datanv.Columns["Email"].HeaderText = "Email";
            datanv.Columns["MaTaiKhoan"].HeaderText = "Mã Tài Khoản";
        }
        private void LoadData()
        {

            datanv.DataSource = nhanvien.GetNV();
            datanv.Columns["TaiKhoan"].Visible = false;
            comboMaTaiKhoan.DataSource = nhanvien.GetMaTK();
        }
        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in datanv.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadGioiTinhComboBox();
            LoadData();
            AutoSizeColumns();
            XulyCotTiengViet();
        }
        private string SinhMaNhanVien()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "NV" + randomPart;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string[] maTaiKhoanParts = comboMaTaiKhoan.Text.Split('-');
            string maTaiKhoan = maTaiKhoanParts[0].Trim();

            NhanVien newNhanVien = new NhanVien
            {
                MaNhanVien = SinhMaNhanVien(),
                HoTen = txtHT.Text,
                NgaySinh = DateTime.Parse(dateNS.Text),
                GioiTinh = comboGT.Text,
                DiaChi = txtdc.Text,
                SoDienThoai = txtsdt.Text,
                Email = txtemail.Text,
                MaTaiKhoan = maTaiKhoan
            };

            nhanvien.ThemNV(newNhanVien);
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

        private void datanv_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = datanv.CurrentRow;
            if (selectedRow != null)
            {
                string manv = selectedRow.Cells["MaNhanVien"].Value.ToString();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (datanv.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datanv.SelectedRows[0];
                string manv = selectedRow.Cells["MaNhanVien"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên có mã " + manv + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    XuLyNhanVien nhanvienProcessor = new XuLyNhanVien();
                    nhanvienProcessor.XoaNV(manv); 
                    datanv.DataSource = nhanvienProcessor.GetNV();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (datanv.SelectedRows.Count > 0)
            {
                int selectedRowIndex = datanv.SelectedRows[0].Index;
                DataGridViewRow selectedRow = datanv.Rows[selectedRowIndex];
                string manv = selectedRow.Cells["MaNhanVien"].Value.ToString();
                string[] maTaiKhoanParts = comboMaTaiKhoan.Text.Split('-');
                string maTaiKhoan = maTaiKhoanParts[0].Trim();

                NhanVien newNhanVien = new NhanVien
                {
                    MaNhanVien = txtMa.Text,
                    HoTen = txtHT.Text,
                    NgaySinh = DateTime.Parse(dateNS.Text),
                    GioiTinh = comboGT.Text,
                    DiaChi = txtdc.Text,
                    SoDienThoai = txtsdt.Text,
                    Email = txtemail.Text,
                    MaTaiKhoan = maTaiKhoan
                };
                XuLyNhanVien nhanvienProcessor = new XuLyNhanVien();
                nhanvienProcessor.SuaNV(newNhanVien);
                datanv.DataSource = nhanvienProcessor.GetNV();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên sửa chữa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTk.Text.Trim();
            List<NhanVien> ketQuaTimKiem = nhanvien.TimKiemNhanVien(tuKhoa);
            datanv.DataSource = ketQuaTimKiem;
        }
        private void TaoTaiKhoanTuDong()
        {
            var taiKhoan = xuLyTaiKhoan.TaoTaiKhoanNhanVienNgauNhien();

            if (taiKhoan != null)
            {
                string thongTinTaiKhoan = $"Tên đăng nhập:   {taiKhoan.TenDangNhap}   \nMật khẩu:   {taiKhoan.MatKhau}   \nQuyền truy cập:   {taiKhoan.MaQuyenTruyCap}";
                MessageBox.Show(thongTinTaiKhoan, "Thông tin tài khoản nhân viên");
                comboMaTaiKhoan.DataSource = nhanvien.GetMaTK();
            }
            else
            {
                MessageBox.Show("Không thể tạo tài khoản nhân viên tự động.", "Lỗi");
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

        private void btnHienThiTT_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = datanv.CurrentRow;

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
