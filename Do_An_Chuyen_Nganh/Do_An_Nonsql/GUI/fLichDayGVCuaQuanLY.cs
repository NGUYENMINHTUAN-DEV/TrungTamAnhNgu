using _BLL;
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
    public partial class fLichDayGVCuaQuanLY : Form
    {
        private XuLyXemThoiKhoaBieu quanLyLichHocBLL = new XuLyXemThoiKhoaBieu();
        public fLichDayGVCuaQuanLY()
        {
            InitializeComponent();
        }
        private void HienThiLichDay()
        {
            string[] magv = comboBox1.Text.Split('-');
            string Magv = magv[0].Trim();
            List<XuLyXemThoiKhoaBieu.ThongTinLopHoc> thongTinLopHocList = quanLyLichHocBLL.LayLichDayCuaGiangVien(Magv);

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

        private void fLichDayGVCuaQuanLY_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = quanLyLichHocBLL.GetMaGiangVien();
            dataTKB.Rows.Clear();
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

        private void btnInLich_Click(object sender, EventArgs e)
        {
            string selectGiagvien = comboBox1.Text.Trim();
            string[] giagnvien = selectGiagvien.Split('-');
            string tengiangvien = giagnvien.Length > 1 ? giagnvien[1].Trim() : selectGiagvien;
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
                                Paragraph title = new Paragraph("Thời khóa biểu của " + (tengiangvien) + "\n", font);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataTKB.Rows.Clear();
            HienThiLichDay();
        }
    }
}
