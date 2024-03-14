using _BLL;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraRichEdit.Import.Html;
using Do_An_Chuyen_Nganh.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _BLL.XyLyThoiKhoaBieu;

namespace Do_An_Chuyen_Nganh
{
    public partial class fQuanLyLichHoc : Form
    {
        private XyLyThoiKhoaBieu thoiKhoaBieuProcessor = new XyLyThoiKhoaBieu();
        private Random random = new Random();
        public fQuanLyLichHoc()
        {
            InitializeComponent();
        }

     
        private void fQuanLyLichHoc_Load(object sender, EventArgs e)
        {
            LoadData();
            AutoSizeColumns();
            XulyCotTiengViet();

        }
        private void XulyCotTiengViet()
        {
            dataThoiKhoaBieu.Columns["MaThoiKhoaBieu"].HeaderText = "IDTKB";
            dataThoiKhoaBieu.Columns["TenGiangVien"].HeaderText = "Tên Giảng Viên";
            dataThoiKhoaBieu.Columns["TenPhongHoc"].HeaderText = "Tên Phòng Học";
            dataThoiKhoaBieu.Columns["TenLop"].HeaderText = "Tên Lớp Học";
            dataThoiKhoaBieu.Columns["Thu"].HeaderText = "Thứ";
            dataThoiKhoaBieu.Columns["TietBatDau"].HeaderText = "Tiết Bắt Đầu";
            dataThoiKhoaBieu.Columns["TietKetThuc"].HeaderText = "Tiết Kết Thúc";
            dataThoiKhoaBieu.Columns["DiaDiem"].HeaderText = "Địa Điểm";
            dataThoiKhoaBieu.Columns["CaHoc"].HeaderText = "Ca Học";
            dataThoiKhoaBieu.Columns["NgayHoc"].HeaderText = "Ngày Học";
            dataThoiKhoaBieu.Columns["LoaiLich"].HeaderText = "Loại Lịch";
            dataThoiKhoaBieu.Columns["NgayThi"].HeaderText = "Ngày Thi";
            dataThoiKhoaBieu.Columns["MaToChucThi"].HeaderText = "Mã Tổ Chức";
        }
        private void LoadData()
        {
            dataThoiKhoaBieu.DataSource = thoiKhoaBieuProcessor.GetThoiKhoaBieu();
            combogv.DataSource = thoiKhoaBieuProcessor.GetMaGiangVien();
            
            combolop.DataSource = thoiKhoaBieuProcessor.GetMaLop();
            comphong.DataSource = thoiKhoaBieuProcessor.GetMaPhong();
            comboTC.DataSource = thoiKhoaBieuProcessor.GetMaToChucThi();
        }

        private string SinhMaTKB()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "TKB" + randomPart;
        }
        private void btnThemTKB_Click(object sender, EventArgs e)
        {
            string[] magv = combogv.Text.Split('-');
            string Magv = magv[0].Trim();
            string[] maph = comphong.Text.Split('-');
            string Maph = maph[0].Trim();
            string[] malop = combolop.Text.Split('-');
            string Malop = malop[0].Trim();
            string[] maTc = comboTC.Text.Split('-');
            string Matc = maTc[0].Trim();

            ThoiKhoaBieu thoiKhoaBieu = new ThoiKhoaBieu
            {
                IDThoiKhoaBieu = SinhMaTKB(),
                MaGiangVien = Magv,
                MaPhongHoc = Maph,
                MaLopHoc = Malop,
                Thu = Convert.ToInt32(txtThu.Text),
                TietBatDau = Convert.ToInt32(txtTietBD.Text),
                TietKetThuc = Convert.ToInt32(txtTietKT.Text),
                DiaDiem = txtDiaDiem.Text,
                CaHoc = txtcahoc.Text,
                MaToChucThi = string.IsNullOrEmpty(Matc) ? null : Matc,
            };
            if (thoiKhoaBieuProcessor.KiemTraTrungThoiGianHoc(thoiKhoaBieu))
            {
                MessageBox.Show("Thời khoá biểu trùng thời gian học với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (thoiKhoaBieuProcessor.KiemTraTrungCaHoc(thoiKhoaBieu))
            {
                MessageBox.Show("Thời khoá biểu trùng ca học với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (thoiKhoaBieuProcessor.KiemTraTrungNgayHoc(thoiKhoaBieu))
            {
                MessageBox.Show("Thời khoá biểu trùng ngày học với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (thoiKhoaBieuProcessor.KiemTraTrungNgayThi(thoiKhoaBieu))
            {
                MessageBox.Show("Thời khoá biểu trùng ngày thi với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (thoiKhoaBieuProcessor.KiemTraTrungThuVaTietHoc(thoiKhoaBieu))
            {
                MessageBox.Show("Thời khoá biểu trùng thứ và tiết học với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioLichThi.Checked)
            {
                thoiKhoaBieu.NgayThi = dateNgayThi.Value;
                dateTimePicker1.Enabled = false;
                dateNgayThi.Enabled = true;
                MessageBox.Show("Bạn đã chọn xếp lịch thi");
                thoiKhoaBieu.LoaiLich = "Thi";
                if (!string.IsNullOrEmpty(Malop))
                {
     
                }
            }
            else if (radioLichHoc.Checked)
            {
                thoiKhoaBieu.NgayHoc = dateTimePicker1.Value;
                dateTimePicker1.Enabled = true;
                dateNgayThi.Enabled = false;
                MessageBox.Show("Bạn đã chọn xếp lịch học");
                thoiKhoaBieu.LoaiLich = "Học";
            }

            thoiKhoaBieuProcessor.ThemThoiKhoaBieu(thoiKhoaBieu);

            LoadData();
            ClearInputFieldsThoiKhoaBieu();
            MessageBox.Show("Thêm Thời khóa biểu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    
        private void ClearInputFieldsThoiKhoaBieu()
        {
            txtIDTKB.Clear();
            combogv.SelectedIndex = -1;
            comphong.SelectedIndex = -1;
            combolop.SelectedIndex = -1;
            txtThu.Clear();
            txtTietBD.Clear();
            txtTietKT.Clear();
            txtDiaDiem.Clear();
            txtcahoc.Clear();
        }
        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in dataThoiKhoaBieu.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnXoaTKB_Click(object sender, EventArgs e)
        {
            if (dataThoiKhoaBieu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataThoiKhoaBieu.SelectedRows[0];
                string idThoiKhoaBieu = selectedRow.Cells["MaThoiKhoaBieu"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thời khóa biểu có ID " + idThoiKhoaBieu + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        thoiKhoaBieuProcessor.XoaThoiKhoaBieu(idThoiKhoaBieu);
                        dataThoiKhoaBieu.DataSource = thoiKhoaBieuProcessor.GetThoiKhoaBieu();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("Vui lòng chọn combobox với giá trị đúng"))
                        {
                            MessageBox.Show("Không thể xóa vì giá trị trong một trong những cột vượt quá độ dài cho phép.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thời khóa biểu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaTKB_Click(object sender, EventArgs e)
        {
            if (dataThoiKhoaBieu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataThoiKhoaBieu.SelectedRows[0];
                string idThoiKhoaBieu = selectedRow.Cells["MaThoiKhoaBieu"].Value.ToString();
                string[] magv = combogv.Text.Split('-');
                string Magv = magv[0].Trim();
                string[] maph = comphong.Text.Split('-');
                string Maph = maph[0].Trim();
                string[] malop = combolop.Text.Split('-');
                string Malop = malop[0].Trim();
                ThoiKhoaBieu thoiKhoaBieu = new ThoiKhoaBieu
                {
                    IDThoiKhoaBieu = idThoiKhoaBieu,
                    MaGiangVien = Magv,
                    MaPhongHoc = Maph,
                    MaLopHoc = Malop,
                    Thu = Convert.ToInt32(txtThu.Text),
                    TietBatDau = Convert.ToInt32(txtTietBD.Text),
                    TietKetThuc = Convert.ToInt32(txtTietKT.Text),
                    DiaDiem = txtDiaDiem.Text,
                    CaHoc = txtcahoc.Text,
                    NgayHoc = dateTimePicker1.Value,
                };
                if (thoiKhoaBieuProcessor.KiemTraTrungThoiGianHoc(thoiKhoaBieu))
                {
                    MessageBox.Show("Thời khoá biểu trùng thời gian học với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (thoiKhoaBieuProcessor.KiemTraTrungCaHoc(thoiKhoaBieu))
                {
                    MessageBox.Show("Thời khoá biểu trùng ca học với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (thoiKhoaBieuProcessor.KiemTraTrungNgayHoc(thoiKhoaBieu))
                {
                    MessageBox.Show("Thời khoá biểu trùng ngày học với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (thoiKhoaBieuProcessor.KiemTraTrungThuVaTietHoc(thoiKhoaBieu))
                {
                    MessageBox.Show("Thời khoá biểu trùng thứ và tiết học với một lịch khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thoiKhoaBieuProcessor.SuaThoiKhoaBieu(idThoiKhoaBieu, thoiKhoaBieu);
                LoadData();
                ClearInputFieldsThoiKhoaBieu();
                MessageBox.Show("Sửa Thời khóa biểu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thời khóa biểu để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnTimTKB_Click(object sender, EventArgs e)
        {
            string keyword = txtTk.Text.Trim();
            List<ThoiKhoaBieuViewModel> ketQuaTimKiem = thoiKhoaBieuProcessor.TimKiemThoiKhoaBieu(keyword);
            dataThoiKhoaBieu.DataSource = ketQuaTimKiem;
        }
        private void dataThoiKhoaBieu_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataThoiKhoaBieu.CurrentRow;
            if (selectedRow != null)
            {
                string idThoiKhoaBieu = selectedRow.Cells["MaThoiKhoaBieu"].Value?.ToString();
                string maGiangVien = selectedRow.Cells["TenGiangVien"].Value?.ToString();
                string maPhongHoc = selectedRow.Cells["TenPhongHoc"].Value?.ToString();
                string maLopHoc = selectedRow.Cells["TenLop"].Value?.ToString();
                string thu = selectedRow.Cells["Thu"].Value?.ToString();
                string tietBatDau = selectedRow.Cells["TietBatDau"].Value?.ToString();
                string tietKetThuc = selectedRow.Cells["TietKetThuc"].Value?.ToString();
                string diaDiem = selectedRow.Cells["DiaDiem"].Value?.ToString();
                string ca = selectedRow.Cells["CaHoc"].Value?.ToString();
                string ngayhoc = selectedRow.Cells["NgayHoc"].Value?.ToString();
                string loaiLich = selectedRow.Cells["LoaiLich"].Value?.ToString();
                string ngaythi = selectedRow.Cells["NgayThi"].Value?.ToString();
                string matc = selectedRow.Cells["MaToChucThi"].Value?.ToString();

                txtIDTKB.Text = idThoiKhoaBieu;
                combogv.Text = maGiangVien;
                comphong.Text = maPhongHoc;
                combolop.Text = maLopHoc;
                txtThu.Text = thu;
                txtTietBD.Text = tietBatDau;
                txtTietKT.Text = tietKetThuc;
                txtDiaDiem.Text = diaDiem;
                txtcahoc.Text = ca;
                DateTime parsedDate;

                if (!string.IsNullOrEmpty(ngayhoc) && DateTime.TryParse(ngayhoc, out parsedDate))
                {
                    dateTimePicker1.Value = parsedDate;
                }
              

                if (!string.IsNullOrEmpty(ngaythi) && DateTime.TryParse(ngaythi, out parsedDate))
                {
                    dateNgayThi.Value = parsedDate;
                }



                comboTC.Text = matc;
                if (loaiLich == "Học")
                {
                   
                    radioLichHoc.Checked = true;
                    dateTimePicker1.Enabled = true;
                    dateNgayThi.Enabled = false;
                }
                else if (loaiLich == "Thi")
                {
                    radioLichThi.Checked = true;
                    dateTimePicker1.Enabled = false;
                    dateNgayThi.Enabled = true;
                }

            }
        }
        private void radioLichHoc_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLichHoc.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateNgayThi.Enabled = false; 
            }
            else
            {
                dateTimePicker1.Enabled = false;
                dateNgayThi.Enabled = true; 
            }
        }

        private void radioLichThi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLichThi.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateNgayThi.Enabled = true;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateNgayThi.Enabled = false; 
            }
        }

        private void btnTaoToChuc_Click(object sender, EventArgs e)
        {
            fToChucThi a = new fToChucThi();
            a.StartPosition = FormStartPosition.CenterScreen;
            a.ShowDialog();
            LoadData();
        }

        private void txtThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
