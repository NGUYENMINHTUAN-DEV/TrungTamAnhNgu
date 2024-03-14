using _BLL;
using DevExpress.ClipboardSource.SpreadsheetML;
using Do_An_Chuyen_Nganh.GUI;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VietQRPaymentAPI;
using static Do_An_Chuyen_Nganh.fDangNhap;


namespace Do_An_Chuyen_Nganh
{
    public partial class fThanhToan : Form
    {
        private string mapt;
        private AnhNguDataContext PhieuThuContext = new AnhNguDataContext();
        private XyLyPhieuThu xuLyPhieuThu = new XyLyPhieuThu();
        private Random random = new Random();
        public fThanhToan(string maPT)
        {
            InitializeComponent();
            this.mapt = maPT;
            txtMaPhieuThu.Text = maPT;
        }
        public string HocVien
        {
            get { return txtMaHocVien.Text; }
            set { txtMaHocVien.Text = value; }
        }


        public string TrangThai
        {
            get { return txtTrangThai.Text; }
            set { txtTrangThai.Text = value; }
        }

        public string TongTien
        {
            get { return txtTongTien.Text; }
            set { txtTongTien.Text = value; }
        }
        private void fThanhToan_Load(object sender, EventArgs e)
        {
            LoadDataThanhToan();
        }
    
       

    private void XulyCotTiengViet()
        {
            dataThanhToan.Columns["mapheiu"].HeaderText = "Mã Phiếu Thu";
            dataThanhToan.Columns["tenhocvine"].HeaderText = "Tên Học Viên";
            dataThanhToan.Columns["ngaylap"].HeaderText = "Ngày Lập";
            dataThanhToan.Columns["tongtien"].HeaderText = "Tổng Tiền";
            dataThanhToan.Columns["tennv"].HeaderText = "Tên Nhân Viên";
            dataThanhToan.Columns["trangthai"].HeaderText = "Trạng Thái";
        }

        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in dataThanhToan.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void LoadDataThanhToan()
        {
            dataThanhToan.DataSource = xuLyPhieuThu.Getphieuthu();
          //  dataThanhToan.Columns["HocVien"].Visible = false;
          //  dataThanhToan.Columns["NhanVien"].Visible = false;
            AutoSizeColumns();
            XulyCotTiengViet();
        }

        private void btnThanhToanQR_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataThanhToan.CurrentRow;
            if (selectedRow != null)
            {
                string tongTien = selectedRow.Cells["tongtien"].Value?.ToString();
                fThanhToanQR a = new fThanhToanQR(tongTien);
                a.StartPosition = FormStartPosition.CenterScreen;
                a.ShowDialog();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text.Trim();
            List<PhieuThu> ketQuaTimKiem = xuLyPhieuThu.TimKiemPhieuThu(tuKhoa);
            dataThanhToan.DataSource = ketQuaTimKiem;
        }


        private void dataThanhToan_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataThanhToan.CurrentRow; 
            {
                if (selectedRow != null)
                {
                  
                    string maPhieuThu = selectedRow.Cells["mapheiu"].Value?.ToString();
                    string maHocVien = selectedRow.Cells["tenhocvine"].Value?.ToString();
                    string ngayLapStr = selectedRow.Cells["ngaylap"].Value?.ToString();
                    string tongTien = selectedRow.Cells["tongtien"].Value?.ToString();
                    string maNhanVien = selectedRow.Cells["tennv"].Value?.ToString();
                    string trangThai = selectedRow.Cells["trangthai"].Value?.ToString();
                    try
                    {
                        dateNgayLap.Value = DateTime.Parse(ngayLapStr);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Ngày lập không hợp lệ.");
                    }
                    txtMaPhieuThu.Text = maPhieuThu;
                    txtMaHocVien.Text = maHocVien;
                    txtTongTien.Text = tongTien;
                    txtMaNhanVien.Text = maNhanVien;
                    txtTrangThai.Text = trangThai;
                }
            }
        }

        private void btnInPhieuThu_Click(object sender, EventArgs e)
        {
            string maPhieuThu = txtMaPhieuThu.Text;

            if (!string.IsNullOrEmpty(maPhieuThu))
            {
                try
                {
                    xuLyPhieuThu.CapNhatTrangThaiDaThanhToan(maPhieuThu);
                    MessageBox.Show("Thanh toán thành công!");
                    LoadDataThanhToan();
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = "HoaDonHocPhi.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = saveFileDialog.FileName;
                            bool overwrite = true;

                            if (ExportPhieuThu(ref fileName, overwrite, maPhieuThu))
                            {
                                MessageBox.Show("Xuất Excel thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Xuất Excel thất bại!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã phiếu thu để cập nhật trạng thái.");
            }
        }
        public class PhieuThuModel
        {
            public string mapheiu { get; set; }
            public string tenhocvine { get; set; }
            public string trangthai { get; set; }
            public string tennv { get; set; }
            public DateTime ngaylap { get; set; }
            public double tongtien { get; set; }
            public string MaHocVien { get; set; }
            public string SoDienThoaiHocVien { get; set; }
            public string DiaChiHocVien { get; set; }
            public string MaKhoaHoc { get; set; }
            public string TenKhoaHoc { get; set; }
            public DateTime NgayBatDau { get; set; }
            public DateTime NgayKetThuc { get; set; }
            public double DonGia { get; set; }
            public List<KhoaHocModel> DanhSachKhoaHoc { get; set; }
        }
        public class KhoaHocModel
        {
            public string MaKhoaHoc { get; set; }
            public string TenKhoaHoc { get; set; }
            public DateTime NgayBatDau { get; set; }
            public DateTime NgayKetThuc { get; set; }
            public double DonGia { get; set; }
        }

        public PhieuThuModel LayThongTinPhieuThu(string maPhieuThu)
        {
            var phieuThuInfo = (from pt in PhieuThuContext.PhieuThus
                                join nv in PhieuThuContext.NhanViens on pt.MaNhanVien equals nv.MaNhanVien
                                join hv in PhieuThuContext.HocViens on pt.MaHocVien equals hv.MaHocVien
                                join ctp in PhieuThuContext.ChiTietPhieuThus on pt.MaPhieuThu equals ctp.MaPhieuThu
                                join kh in PhieuThuContext.KhoaHocs on ctp.MaKhoaHoc equals kh.MaKhoaHoc
                                where pt.MaPhieuThu == maPhieuThu
                                select new PhieuThuModel
                                {
                                    mapheiu = pt.MaPhieuThu,
                                    tenhocvine = hv.HoTen,
                                    trangthai = pt.TrangThai,
                                    tennv = nv.HoTen,
                                    ngaylap = (DateTime)pt.NgayLap,
                                    tongtien = (double)pt.TongTien,
                                    MaHocVien = pt.MaHocVien,
                                    SoDienThoaiHocVien = hv.SoDienThoai,
                                    DiaChiHocVien = hv.DiaChi,
                                    MaKhoaHoc = kh.MaKhoaHoc,
                                    TenKhoaHoc = kh.TenKhoaHoc,
                                    NgayBatDau = (DateTime)kh.ThoiGianBatDau,
                                    NgayKetThuc = (DateTime)kh.ThoiGianKetThuc,
                                    DonGia = (double)kh.HocPhi,
                                    DanhSachKhoaHoc = new List<KhoaHocModel>()
                                })
                                .FirstOrDefault();

            if (phieuThuInfo != null)
            {
                phieuThuInfo.tongtien = phieuThuInfo.DonGia;
                var khoaHocInfo = (from ctp in PhieuThuContext.ChiTietPhieuThus
                                   join kh in PhieuThuContext.KhoaHocs on ctp.MaKhoaHoc equals kh.MaKhoaHoc
                                   where ctp.MaPhieuThu == maPhieuThu
                                   select new KhoaHocModel
                                   {
                                       MaKhoaHoc = kh.MaKhoaHoc,
                                       TenKhoaHoc = kh.TenKhoaHoc,
                                       NgayBatDau = (DateTime)kh.ThoiGianBatDau,
                                       NgayKetThuc = (DateTime)kh.ThoiGianKetThuc,
                                       DonGia = (double)kh.HocPhi
                                   }).ToList();

                phieuThuInfo.DanhSachKhoaHoc.AddRange(khoaHocInfo);
            }

            return phieuThuInfo;
        }

        public bool ExportPhieuThu(ref string fileName, bool overwrite, string maPhieuThu)
        {
            if (!string.IsNullOrEmpty(maPhieuThu))
            {
                var phieuThuInfo = LayThongTinPhieuThu(maPhieuThu);

                if (phieuThuInfo != null)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("PhieuThu");
                            worksheet.Cells["A1:L1"].Merge = true;
                            worksheet.Cells["A1:L1"].Value = "Hóa Đơn Học Phí";
                            worksheet.Cells["A1:L1"].Style.Font.Bold = true;
                            worksheet.Cells["A1:L1"].Style.Font.Size = 16;
                            worksheet.Cells["A1:L1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            string[] headers = { "Tên Nhân Viên", "Tên Học Viên", "Mã Học Viên",
"Số Điện Thoại Học Viên", "Địa Chỉ Học Viên", "Mã Khóa Học",
"Tên Khóa Học", "Ngày Bắt Đầu", "Ngày Kết Thúc", "Đơn Giá", "Tổng Tiền" };

                            for (int i = 0; i < headers.Length; i++)
                            {
                                worksheet.Cells[3, i + 1].Value = headers[i];
                                worksheet.Cells[3, i + 1].Style.Font.Bold = true;
                                worksheet.Cells[3, i + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                if (i < 11)
                                {
                                    worksheet.Column(i + 1).Width = 15;
                                }
                                else
                                {
                                    worksheet.Column(i + 1).Width = 20;
                                }
                            }
                            worksheet.Cells[4, 1].Value = phieuThuInfo.tennv;
                            worksheet.Cells[4, 2].Value = phieuThuInfo.tenhocvine;
                            worksheet.Cells[4, 3].Value = phieuThuInfo.MaHocVien;
                            worksheet.Cells[4, 4].Value = phieuThuInfo.SoDienThoaiHocVien;
                            worksheet.Cells[4, 5].Value = phieuThuInfo.DiaChiHocVien;
                            worksheet.Cells[7, 11].Formula = $"SUM(K5:K{phieuThuInfo.DanhSachKhoaHoc.Count + 4})";
                            int currentRow = 5;
                            foreach (var khoaHoc in phieuThuInfo.DanhSachKhoaHoc)
                            {
                                worksheet.Cells[currentRow, 6].Value = khoaHoc.MaKhoaHoc;
                                worksheet.Cells[currentRow, 7].Value = khoaHoc.TenKhoaHoc;
                                worksheet.Cells[currentRow, 8].Style.Numberformat.Format = "dd/MM/yyyy";
                                worksheet.Cells[currentRow, 8].Value = khoaHoc.NgayBatDau.ToOADate();
                                worksheet.Cells[currentRow, 9].Style.Numberformat.Format = "dd/MM/yyyy";
                                worksheet.Cells[currentRow, 9].Value = khoaHoc.NgayKetThuc.ToOADate();
                                worksheet.Cells[currentRow, 10].Value = khoaHoc.DonGia;
                                worksheet.Cells[currentRow, 11].Value = khoaHoc.DonGia;

                                currentRow++;
                            }
                            worksheet.Cells[2, 1, currentRow, 12].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            worksheet.Cells[currentRow + 2, 7].Value = $"Học Viên Ký Tên:{phieuThuInfo.tenhocvine}";
                            worksheet.Cells[currentRow + 2, 7, currentRow + 2, 9].Merge = true;
                            worksheet.Cells[currentRow + 2, 10].Value = $"Nhân Viên Ký Tên: {phieuThuInfo.tennv}";
                            worksheet.Cells[currentRow + 2, 10, currentRow + 2, 12].Merge = true;

                            worksheet.Cells[1, 13].Value = $"Ngày In Hóa Đơn: {DateTime.Now.ToString("dd/MM/yyyy")}";
                            worksheet.Cells[1, 13, 1, 18].Merge = true;
                            worksheet.Row(3).Height = 25;

                            var fileInfo = new FileInfo(fileName);
                            if (overwrite && fileInfo.Exists)
                            {
                                fileInfo.Delete();
                            }

                            package.SaveAs(fileInfo);
                            return true;
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void txtMaPhieuThu_TextChanged(object sender, EventArgs e)
        {
            string maPhieuThu = txtMaPhieuThu.Text;
            string tenKhoaHoc = xuLyPhieuThu.TenKhoaHocDaDangKy(maPhieuThu);
            txtTenKhoaHocDaDangKy.Multiline = true;
            txtTenKhoaHocDaDangKy.ScrollBars = ScrollBars.Vertical; // Hoặc ScrollBars.Both
            txtTenKhoaHocDaDangKy.Text = tenKhoaHoc;
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenKhoaHocDaDangKy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
