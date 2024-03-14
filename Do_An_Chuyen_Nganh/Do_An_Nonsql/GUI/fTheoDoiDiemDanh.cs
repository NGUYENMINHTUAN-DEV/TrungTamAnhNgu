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
    public partial class fTheoDoiDiemDanh : Form
    {
        private XyLyDiemDanh diemDanhProcessor = new XyLyDiemDanh();
       
      
        public fTheoDoiDiemDanh()
        {
            InitializeComponent();
          
        }

       
        private void LoadComBoDiemDanh()
        {
            combodd.Items.Add("Đã điểm danh");
            combodd.Items.Add("Vắng");
            combodd.SelectedIndex = 0;
        }
        private void LoadData()
        {
            dataDiemDanh.DataSource = diemDanhProcessor.GetDiemDanh();
            comboLop.DataSource= diemDanhProcessor.GetMaLop();
           // dataDiemDanh.Columns["HocVien"].Visible = false;
           // dataDiemDanh.Columns["LopHoc"].Visible = false;
            // dataDiemDanh.Columns["KhoaHoc"].Visible = false;
            LoadComBoDiemDanh();
            comMaHV.DataSource = diemDanhProcessor.GetMaHocVien();
        }
       
        private void XulyCotTiengViet()
        {
            dataDiemDanh.Columns["IDDiemDanh"].HeaderText = "ID Điểm Danh";
            dataDiemDanh.Columns["TenHocVien"].HeaderText = "Tên Học Viên";
            dataDiemDanh.Columns["TenLopHoc"].HeaderText = "Tên Lớp Học";
            dataDiemDanh.Columns["NgayDiemDanh"].HeaderText = "Ngày Điểm Danh";
            dataDiemDanh.Columns["TrangThaiDiemDanh"].HeaderText = "Trạng Thái Điểm Danh";
        }

        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in dataDiemDanh.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private Random random = new Random();
        private string SinhMaIDDiemDanh()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "DD" + randomPart;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] mahv = comMaHV.Text.Split('-');
                string Mahv = mahv[0].Trim();
                string[] malop = comboLop.Text.Split('-');
                string Malop = malop[0].Trim();
                DiemDanh diemDanh = new DiemDanh
                {
                    IDDiemDanh = SinhMaIDDiemDanh(),
                    MaHocVien = Mahv,
                    MaLopHoc = Malop,
                    NgayDiemDanh = datengay.Value,
                    TrangThaiDiemDanh = combodd.Text
                };

                diemDanhProcessor.ThemDiemDanh(diemDanh);
                MessageBox.Show("Thêm Điểm Danh Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm Điểm Danh Thất Bại. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fTheoDoiDiemDanh_Load(object sender, EventArgs e)
        {
            LoadData();
            AutoSizeColumns();
            XulyCotTiengViet();
        }
   
        private void dataDiemDanh_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataDiemDanh.CurrentRow;
            if (selectedRow != null)
            {
                string idDiemDanh = selectedRow.Cells["IDDiemDanh"].Value.ToString();
                string maHocVien = selectedRow.Cells["TenHocVien"].Value.ToString();
                string maLopHoc = selectedRow.Cells["TenLopHoc"].Value.ToString();
                DateTime ngayDiemDanh = Convert.ToDateTime(selectedRow.Cells["NgayDiemDanh"].Value);
                string trangThaiDiemDanh = selectedRow.Cells["TrangThaiDiemDanh"].Value.ToString();

                txtID.Text = idDiemDanh;
                comMaHV.Text = maHocVien;
                comboLop.Text = maLopHoc;
                datengay.Value = ngayDiemDanh;
                combodd.Text = trangThaiDiemDanh;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataDiemDanh.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataDiemDanh.SelectedRows[0];
                string idDiemDanh = selectedRow.Cells["IDDiemDanh"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm danh có ID {idDiemDanh} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        diemDanhProcessor.XoaDiemDanh(idDiemDanh);
                        MessageBox.Show("Xóa Điểm Danh Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Xóa Điểm Danh Thất Bại. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một điểm danh để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataDiemDanh.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataDiemDanh.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataDiemDanh.Rows[selectedRowIndex];
                string idDiemDanh = selectedRow.Cells["IDDiemDanh"].Value.ToString();
                string[] mahv = comMaHV.Text.Split('-');
                string Mahv = mahv[0].Trim();
                string[] malop = comboLop.Text.Split('-');
                string Malop = malop[0].Trim();
                DiemDanh diemDanh = new DiemDanh
                {
                    IDDiemDanh = idDiemDanh,
                    MaHocVien = Mahv,
                    MaLopHoc = Malop,
                    NgayDiemDanh = datengay.Value,
                    TrangThaiDiemDanh = combodd.Text
                };

                try
                {
                    diemDanhProcessor.SuaDiemDanh(diemDanh);
                    MessageBox.Show("Sửa Điểm Danh Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sửa Điểm Danh Thất Bại. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một điểm danh để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            List<DiemDanh> ketQuaTimKiem = diemDanhProcessor.TimKiemDiemDanh(tuKhoa);
            dataDiemDanh.DataSource = ketQuaTimKiem;
        }
        private void ClearInputFields()
        {
            txtID.Clear();
            comMaHV.SelectedIndex = -1;
            comboLop.SelectedIndex = -1;
            datengay.Value = DateTime.Now;
            combodd.SelectedIndex = -1;
        }
        private void LoadCoMboHV(string magv)
        {
            comMaHV.DataSource = null;
            comMaHV.Items.Clear();

            XyLyQuanLyLopHocVien quanLyLopHocVienBLL = new XyLyQuanLyLopHocVien();

            List<HocVien> dshv = quanLyLopHocVienBLL.LayDanhSachHocVienTrongLop(magv);

            // Thêm items mới
            foreach (HocVien hv in dshv)
            {
                comMaHV.Items.Add($"{hv.MaHocVien} - {hv.HoTen}");
            }
        }
        private void comboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLop.SelectedItem != null)
            {
                string maHocVien = comboLop.SelectedItem.ToString().Split('-')[0].Trim();
                LoadCoMboHV(maHocVien);
            }
            else
            {
                // Xử lý khi comHocvien.SelectedItem là null.
            }
        }
    }
}
