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
    public partial class fQuanLyLop : Form
    {
        private XyLyLopHoc xyLyLopHoc = new XyLyLopHoc();
        private XyLyKhoaHoc xyLyKhoaHoc = new XyLyKhoaHoc();
        private XyLyQuanLyLopHocVien xyLyQuanLyLopHocVien = new XyLyQuanLyLopHocVien();
        private Random random = new Random();
        public fQuanLyLop()
        {
            InitializeComponent();
        }

       
        private void fQuanLyLop_Load(object sender, EventArgs e)
        {
            LoadData();
            AutoSizeColumns();
            XulyCotTiengViet();
        }
        private void XulyCotTiengViet()
        {
            dataLopHoc.Columns["MaLopHoc"].HeaderText = "Mã Lớp Học";
            dataLopHoc.Columns["TenLop"].HeaderText = "Tên Lớp";
            dataLopHoc.Columns["TenKhoaHoc"].HeaderText = "Tên Khóa Học";
            dataLopHoc.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            dataLopHoc.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
            dataLopHoc.Columns["SoLuongHocVienHienTai"].HeaderText = "Số Lượng Học Viên Hiện Tại";
            dataLopHoc.Columns["SoLuongHocVienToiDa"].HeaderText = "Số Lượng Học Viên Tối Đa";
        }

        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in dataLopHoc.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void LoadData()
        {
            dataLopHoc.DataSource = xyLyLopHoc.LayDanhSachLopHoc();
          //  dataLopHoc.Columns["KhoaHoc"].Visible = false;
            comboMaKhoaHoc.DataSource = xyLyLopHoc.GetMaKhoaHoc();
        }
        private string SinhMaLop()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "LH" + randomPart;
        }
        private void btnThemL_Click(object sender, EventArgs e)
        {
            string[] MaKhoaHoc = comboMaKhoaHoc.Text.Split('-');
            string maKhoaHoc = MaKhoaHoc[0].Trim();
            LopHoc lopHoc = new LopHoc
            {
                MaLopHoc = SinhMaLop(),
                TenLop = txtTenLop.Text,
                MaKhoaHoc = maKhoaHoc,
                NgayBatDau = dateBD.Value,
                NgayKetThuc = dateKT.Value,
                SoLuongHocVienHienTai = int.Parse(txtSl.Text),
                SoLuongHocVienToiDa = int.Parse(txtSlToiDa.Text)
            };

            xyLyLopHoc.ThemLopHoc(lopHoc);
            LoadData();
            ClearInputFields();
        }

        private void dataLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataLopHoc.CurrentRow;
            if (selectedRow != null)
            {
                string maLopHoc = selectedRow.Cells["MaLopHoc"].Value.ToString();
                string tenLop = selectedRow.Cells["TenLop"].Value.ToString();
                string maKhoaHoc = selectedRow.Cells["TenKhoaHoc"].Value.ToString();
                string ngayBatDau = selectedRow.Cells["NgayBatDau"].Value.ToString();
                string ngayKetThuc = selectedRow.Cells["NgayKetThuc"].Value.ToString();
                string soLuongHocVien = selectedRow.Cells["SoLuongHocVienHienTai"].Value.ToString();
                string soluonghvtoida = selectedRow.Cells["SoLuongHocVienToiDa"].Value.ToString();
               
                txtMaLop.Text = maLopHoc;
                txtTenLop.Text = tenLop;
                comboMaKhoaHoc.Text = maKhoaHoc;
                dateBD.Value = DateTime.Parse(ngayBatDau);
                dateKT.Value = DateTime.Parse(ngayKetThuc);
                txtSl.Text = soLuongHocVien;
                txtSlToiDa.Text = soluonghvtoida;
            }
        }

        private void btnXoaL_Click(object sender, EventArgs e)
        {
            if (dataLopHoc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataLopHoc.SelectedRows[0];
                string maLopHoc = selectedRow.Cells["MaLopHoc"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa lớp học có mã " + maLopHoc + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    xyLyLopHoc.XoaLopHoc(maLopHoc);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lớp học để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaL_Click(object sender, EventArgs e)
        {
            if (dataLopHoc.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataLopHoc.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataLopHoc.Rows[selectedRowIndex];
                string maLopHoc = selectedRow.Cells["MaLopHoc"].Value.ToString();
                string[] MaKhoaHoc = comboMaKhoaHoc.Text.Split('-');
                string maKhoaHoc = MaKhoaHoc[0].Trim();
                LopHoc lopHoc = new LopHoc
                {
                    MaLopHoc = txtMaLop.Text,
                    TenLop = txtTenLop.Text,
                    MaKhoaHoc = maKhoaHoc,
                    NgayBatDau = dateBD.Value,
                    NgayKetThuc = dateKT.Value,
                    SoLuongHocVienHienTai = int.Parse(txtSl.Text),
                    SoLuongHocVienToiDa = int.Parse(txtSlToiDa.Text)
                };

                xyLyLopHoc.SuaLopHoc(lopHoc);
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lớp học để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTKL_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTKLOP.Text.Trim();
            List<LopHoc> ketQuaTimKiem = xyLyLopHoc.TimKiemLopHoc(tuKhoa);
            dataLopHoc.DataSource = ketQuaTimKiem;
        }
        private void ClearInputFields()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            comboMaKhoaHoc.SelectedIndex = -1;
            dateBD.Value = DateTime.Now;
            dateKT.Value = DateTime.Now;
            txtSl.Clear();
            txtSlToiDa.Clear();
        }
        private void comboMaKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMaKhoaHoc.SelectedValue != null)
            {
                string selectedText = comboMaKhoaHoc.SelectedValue.ToString();
                string maKhoaHoc = string.IsNullOrEmpty(selectedText) ? string.Empty : selectedText.Split('-')[0].Trim();
                var thoiGianKhoaHoc = xyLyKhoaHoc.LayThoiGianKhoaHoc(maKhoaHoc);

                if (thoiGianKhoaHoc != null)
                {
                    DateTime? thoiGianBatDau = thoiGianKhoaHoc.Item1;
                    DateTime? thoiGianKetThuc = thoiGianKhoaHoc.Item2;
                    dateBD.Value = thoiGianBatDau ?? DateTime.Now; 
                    dateKT.Value = thoiGianKetThuc ?? DateTime.Now; 
                }
                else
                {
                    dateBD.Value = DateTime.Now; 
                    dateKT.Value = DateTime.Now;
                }
            }
        }
     

       

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void txtSl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSlToiDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
