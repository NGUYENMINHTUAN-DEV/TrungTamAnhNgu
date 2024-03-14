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

namespace Do_An_Chuyen_Nganh.GUI
{
    public partial class fDiemDanhHocVien : Form
    {
        private XuLyDiemDanhHocVien xuLyDiemDanhHocVien = new XuLyDiemDanhHocVien();
        private AnhNguDataContext DiemDanhContext = new AnhNguDataContext();
        private string maLopHoc;
        private DateTime ngayHoc;
        private string MaPhong;
        private int thu;
        private int tietBatDau;
        private int tietKetThuc;
        private string caHoc;
        private string loailich;
        private DateTime ngaythi;
        private string matochuc;
        private List<XuLyDiemDanhHocVien.ThongTinHocVienDiemDanh> danhSachHocVien;

        public DateTime? NgayHoc { get; }
        public DateTime? NgayThi { get; }

        public fDiemDanhHocVien(string maLopHoc, DateTime ngayHoc, string maPhong, int thu, int tietBatDau, int tietKetThuc, string cahoc,string loailich,DateTime ngaythi, string matochuc, List<XuLyDiemDanhHocVien.ThongTinHocVienDiemDanh> danhSachHocVien)
        {
            InitializeComponent();
            this.maLopHoc = maLopHoc;
            this.ngayHoc = ngayHoc;
            this.MaPhong = maPhong;
            this.thu = thu;
            this.tietBatDau = tietBatDau;
            this.tietKetThuc = tietKetThuc;
            this.caHoc = cahoc;
            this.loailich = loailich;
            this.ngaythi= ngaythi;
            this.matochuc = matochuc;
            this.danhSachHocVien = danhSachHocVien;
            LoadDanhSachHocVien();
        }

        public fDiemDanhHocVien(string maLopHoc, DateTime? ngayHoc1, string maPhong, int thu, int tietBatDau, int tietKetThuc, string caHoc, string loaiLich, DateTime? ngayThi, string maToChuc, List<XuLyDiemDanhHocVien.ThongTinHocVienDiemDanh> danhSachHocVien)
        {
            this.maLopHoc = maLopHoc;
            NgayHoc = ngayHoc1;
            MaPhong = maPhong;
            this.thu = thu;
            this.tietBatDau = tietBatDau;
            this.tietKetThuc = tietKetThuc;
            this.caHoc = caHoc;
            loailich = loaiLich;
            NgayThi = ngayThi;
            matochuc = maToChuc;
            this.danhSachHocVien = danhSachHocVien;
        }
     

        private void LoadDanhSachHocVien()
        {
            var danhSachHocVienLocal = xuLyDiemDanhHocVien.LayDanhSachHocVienTheoThoiKhoaBieu(maLopHoc, MaPhong, thu, tietBatDau, tietKetThuc, caHoc, ngayHoc, loailich, ngaythi, matochuc);
            dataDiemDanh.DataSource = danhSachHocVienLocal;
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Đi học";
            checkBoxColumn.Name = "colDiHoc";
            dataDiemDanh.Columns.Add(checkBoxColumn);
            dataDiemDanh.CellFormatting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dataDiemDanh.Columns["colDiHoc"].Index)
                {
                    var trangThaiDiemDanh = dataDiemDanh.Rows[e.RowIndex].Cells["CoDiHoc"].Value.ToString();
                    e.Value = trangThaiDiemDanh == "Vắng";
                    if (trangThaiDiemDanh == "Đã điểm danh")
                    {
                        dataDiemDanh.Rows[e.RowIndex].Cells["colDiHoc"].ReadOnly = true;
                        dataDiemDanh.Rows[e.RowIndex].Cells["colDiHoc"].ToolTipText = "Học viên vắng";
                    }
                }
            };

            dataDiemDanh.CellContentClick += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dataDiemDanh.Columns["colDiHoc"].Index)
                {
                    if (dataDiemDanh.Rows[e.RowIndex].Cells["colDiHoc"] is DataGridViewCheckBoxCell cell)
                    {
                        if (cell.Value == null || !(bool)cell.Value)
                        {
                            dataDiemDanh.Rows[e.RowIndex].Cells["CoDiHoc"].Value = "Đã điểm danh";
                            cell.Value = true; 
                        }
                        else
                        {
                            dataDiemDanh.Rows[e.RowIndex].Cells["CoDiHoc"].Value = "Vắng";
                            cell.Value = false; 
                        }
                    }
                }
            };

        }



        private void btnLuudiemdanh_Click(object sender, EventArgs e)
        {
            try
            {
                string trangThaiDiemDanh;
                string maHocVien;
                List<string> maHocViens = new List<string>();
                foreach (DataGridViewRow row in dataDiemDanh.Rows)
                {
                    if (row.Cells["colDiHoc"] is DataGridViewCheckBoxCell cell && cell.Value != null)
                    {
                        if (row.Cells["MaHocVien"].Value != null)
                        {
                            maHocVien = row.Cells["MaHocVien"].Value.ToString();
                            maHocViens.Add(maHocVien);
                        }
                    }
                }
                foreach (DataGridViewRow row in dataDiemDanh.Rows)
                {
                    if (row.Cells["colDiHoc"] is DataGridViewCheckBoxCell cell && cell.Value != null)
                    {
                        maHocVien = row.Cells["MaHocVien"].Value.ToString();
                        bool isChecked = (bool)cell.Value;
                        DateTime ngayDiemDanh;
                        string loaiLich = row.Cells["LoaiLich"].Value.ToString();

                        if (loaiLich == "Học")
                        {
                            ngayDiemDanh = ngayHoc;
                        }
                        else
                        {
                            ngayDiemDanh = ngaythi;
                        }
                        trangThaiDiemDanh = isChecked ? "Đã điểm danh" : "Vắng";
                        xuLyDiemDanhHocVien.CapNhatTrangThaiDiemDanh(maHocVien, maLopHoc, ngayDiemDanh, trangThaiDiemDanh);
                        row.Cells["CoDiHoc"].Value = trangThaiDiemDanh;
                    }
                }
                MessageBox.Show("Đã điểm danh thành công!");
                dataDiemDanh.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

