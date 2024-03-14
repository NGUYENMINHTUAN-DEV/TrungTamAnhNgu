using _BLL;
using DevExpress.XtraEditors.Design;
using iTextSharp.text.pdf;
using iTextSharp.text;
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

namespace Do_An_Chuyen_Nganh.GUI
{
    public partial class fLichDayGV : Form
    {
    
        private XuLyXemThoiKhoaBieu quanLyLichHocBLL = new XuLyXemThoiKhoaBieu();
        private XuLyDiemDanhHocVien xuLyDiemDanhHocVien = new XuLyDiemDanhHocVien();
 
        private string maGiangVien;
        private string hoTen;
        public fLichDayGV(string hoTen, string maGiangVien)
        {
            this.hoTen = hoTen;
            this.maGiangVien = maGiangVien;
            InitializeComponent();
            dataTKB.Columns.Add("TenLop", "Tên Lớp");
            dataTKB.Columns.Add("TenPhongHoc", "Tên Phòng Học");
            dataTKB.Columns.Add("Thu", "Thứ");
            dataTKB.Columns.Add("TietBatDau", "Tiết Bắt Đầu");
            dataTKB.Columns.Add("TietKetThuc", "Tiết Kết Thúc");
            dataTKB.Columns.Add("CaHoc", "Ca Học");
            dataTKB.Columns.Add("NgayHoc", "Ngày Học");
            dataTKB.Columns.Add("LoaiLich", "Loại Lịch");
            dataTKB.Columns.Add("NgayThi", "Ngày Thi");
            dataTKB.Columns.Add("MaToChucThi", "Mã Tổ chức");
        }
        private void HienThiLichDay()
        {
            List<XuLyXemThoiKhoaBieu.ThongTinLopHoc> thongTinLopHocList = quanLyLichHocBLL.LayLichDayCuaGiangVien(maGiangVien);

            foreach (var thongTinLopHoc in thongTinLopHocList)
            {
                if (thongTinLopHoc != null)
                {
                    int rowIndex = dataTKB.Rows.Add();

                    dataTKB.Rows[rowIndex].Cells["TenLop"].Value = thongTinLopHoc.TenLop;
                    dataTKB.Rows[rowIndex].Cells["TenPhongHoc"].Value = thongTinLopHoc.TenPhongHoc;
                    dataTKB.Rows[rowIndex].Cells["Thu"].Value = thongTinLopHoc.Thu;
                    dataTKB.Rows[rowIndex].Cells["TietBatDau"].Value = thongTinLopHoc.TietBatDau;
                    dataTKB.Rows[rowIndex].Cells["TietKetThuc"].Value = thongTinLopHoc.TietKetThuc;
                    dataTKB.Rows[rowIndex].Cells["CaHoc"].Value = thongTinLopHoc.Cahoc;
                    if (thongTinLopHoc.NgayHoc.HasValue)
                    {
                        dataTKB.Rows[rowIndex].Cells["NgayHoc"].Value = thongTinLopHoc.NgayHoc.Value.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dataTKB.Rows[rowIndex].Cells["NgayHoc"].Value = DBNull.Value;
                    }
                    dataTKB.Rows[rowIndex].Cells["LoaiLich"].Value = thongTinLopHoc.LoaiLich;
                    dataTKB.Rows[rowIndex].Cells["NgayThi"].Value = thongTinLopHoc.NgayThi;
                    dataTKB.Rows[rowIndex].Cells["MaToChucThi"].Value = thongTinLopHoc.MaToChucThi;
                }
            }
        }

        

        private void dataTKB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenLopHoc = dataTKB.Rows[e.RowIndex].Cells["TenLop"].Value?.ToString();

                if (!string.IsNullOrEmpty(tenLopHoc))
                {
                    string maLopHoc = quanLyLichHocBLL.LayMaLopHocTheoTenLop(tenLopHoc);

                    if (!string.IsNullOrEmpty(maLopHoc))
                    {
                        DateTime ngayHoc = DateTime.MinValue;
                        object ngayHocCellValue = dataTKB.Rows[e.RowIndex].Cells["NgayHoc"].Value;

                        if (ngayHocCellValue != null && ngayHocCellValue != DBNull.Value)
                        {
                            ngayHoc = Convert.ToDateTime(ngayHocCellValue);
                        }

                        string tenphong = dataTKB.Rows[e.RowIndex].Cells["TenPhongHoc"].Value?.ToString();
                        string maPhong = quanLyLichHocBLL.LayMaPhongHocTheoTenPhong(tenphong);
                        int thu = Convert.ToInt32(dataTKB.Rows[e.RowIndex].Cells["Thu"].Value);
                        int tietBatDau = Convert.ToInt32(dataTKB.Rows[e.RowIndex].Cells["TietBatDau"].Value);
                        int tietKetThuc = Convert.ToInt32(dataTKB.Rows[e.RowIndex].Cells["TietKetThuc"].Value);
                        string caHoc = dataTKB.Rows[e.RowIndex].Cells["CaHoc"].Value?.ToString();
                        string loaiLich = dataTKB.Rows[e.RowIndex].Cells["LoaiLich"].Value?.ToString();

                        DateTime ngayThi = DateTime.MinValue;
                        string maToChuc = null;

                        if (loaiLich == "Thi")
                        {
                            object ngayThiCellValue = dataTKB.Rows[e.RowIndex].Cells["NgayThi"].Value;
                            if (ngayThiCellValue != null && ngayThiCellValue != DBNull.Value)
                            {
                                ngayThi = Convert.ToDateTime(ngayThiCellValue);
                            }

                            maToChuc = dataTKB.Rows[e.RowIndex].Cells["MaToChucThi"].Value?.ToString();
                        }

                        var danhSachHocVien = xuLyDiemDanhHocVien.LayDanhSachHocVienTheoThoiKhoaBieu(maLopHoc, maPhong, thu, tietBatDau, tietKetThuc, caHoc, ngayHoc, loaiLich, ngayThi, maToChuc);

                        fDiemDanhHocVien f = new fDiemDanhHocVien(maLopHoc, ngayHoc, maPhong, thu, tietBatDau, tietKetThuc, caHoc, loaiLich, ngayThi, maToChuc, danhSachHocVien);
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.Show();
                    }
                }
            }
        }


        private void fThoiKhoaBieuGV_Load(object sender, EventArgs e)
        {
            dataTKB.Rows.Clear();
            HienThiLichDay();
        }

        private void dataTKB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataTKB.Columns[e.ColumnIndex].Name;

                if (columnName == "LoaiLich")
                {
                    string loaiLich = dataTKB.Rows[e.RowIndex].Cells[columnName].Value?.ToString();

                    if (loaiLich == "Thi")
                    {
                        e.CellStyle.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void btnInLich_Click(object sender, EventArgs e)
        {
            if (dataTKB.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "ThoiKhoaBieu.pdf";
                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Không thể ghi dữ liệu vào đĩa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (!ErrorMessage)
                    {
                        try
                        {
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12);

                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                Paragraph title = new Paragraph("Lịch Dạy của " + hoTen + "\n", font);
                                title.Alignment = Element.ALIGN_CENTER;
                                document.Add(title);
                                document.Add(new Paragraph(" "));

                                PdfPTable pTable = new PdfPTable(dataTKB.Columns.Count);
                                pTable.DefaultCell.Padding = 2;
                                pTable.WidthPercentage = 100;
                                pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                foreach (DataGridViewColumn col in dataTKB.Columns)
                                {
                                    PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, font));
                                    pTable.AddCell(pCell);
                                }
                                foreach (DataGridViewRow viewRow in dataTKB.Rows)
                                {
                                    foreach (DataGridViewCell dcell in viewRow.Cells)
                                    {
                                        string cellValue = dcell.Value?.ToString() ?? "";
                                        PdfPCell cell = new PdfPCell(new Phrase(cellValue, font));
                                        pTable.AddCell(cell);
                                    }
                                }
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }

                            MessageBox.Show("Dữ liệu xuất thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
