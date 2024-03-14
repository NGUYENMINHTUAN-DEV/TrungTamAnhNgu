using _BLL;
using ClosedXML.Excel;
using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using static _BLL.XuLyDiemSo;
using System.IO;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Do_An_Chuyen_Nganh
{
    public partial class fDiemSo : Form
    {
        private XuLyDiemSo xylydiem = new XuLyDiemSo();
        public fDiemSo()
        {
            InitializeComponent();
        }

        private void fDiemSoVaDanhGia_Load(object sender, EventArgs e)
        {
            comboMaKh.DataSource = xylydiem.GetMaKhoa();
           combomalop.DataSource = xylydiem.GetMaLop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Export Excel";
            save.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(save.FileName);
                    MessageBox.Show("Thành Công !!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }

        private void comboMaKh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] makh = comboMaKh.Text.Split('-');
            string Makh = makh[0].Trim();
            List<LopHoc> danhSachLopHoc = xylydiem.GetDanhSachLopHoc(Makh);
            combomalop.DataSource = danhSachLopHoc;
            combomalop.DisplayMember = "MaLopHoc";
            combomalop.ValueMember = "MaLopHoc";
        }

        private void combomalop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maLopHoc = combomalop.SelectedValue.ToString();
            List<XuLyDiemSo.DiemThiInfo> diemThiList = xylydiem.GetDiemThiByMaLop(maLopHoc);
            dataGridView1.DataSource = diemThiList;
        }

        private void ExportToExcel(string filePath)
        {
            Excel.Application apiliecation = new Excel.Application();
            apiliecation.Application.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                apiliecation.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    apiliecation.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }

            apiliecation.Columns.AutoFit();
            apiliecation.ActiveWorkbook.SaveCopyAs(filePath);
            apiliecation.ActiveWorkbook.Saved = true;
        }


        private void ImportCSV(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                DataTable dataTable = new DataTable();

                for (int i = excelWorksheet.Dimension.Start.Column; i <= excelWorksheet.Dimension.End.Column; i++)
                {
                    dataTable.Columns.Add(excelWorksheet.Cells[1, i].Value.ToString());
                }

                for (int i = excelWorksheet.Dimension.Start.Row + 1; i <= excelWorksheet.Dimension.End.Row; i++)
                {
                    List<string> listrows = new List<string>();

                    for (int j = excelWorksheet.Dimension.Start.Column; j <= excelWorksheet.Dimension.End.Column; j++)
                    {
                        object cellValue = excelWorksheet.Cells[i, j].Value;

                        if (cellValue is double && DateTime.FromOADate((double)cellValue).Year > 1900) 
                        {
                            DateTime dateValue = DateTime.FromOADate((double)cellValue);
                            listrows.Add(dateValue.ToString("dd-MM-yyyy"));
                        }
                        else
                        {
                            string cellStringValue = cellValue != null ? cellValue.ToString() : string.Empty;
                            listrows.Add(cellStringValue);
                        }
                    }

                    dataTable.Rows.Add(listrows.ToArray());
                }

                dataGridView1.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            openFileDialog.Title = "Import Excel";
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImportCSV(openFileDialog.FileName);
                    MessageBox.Show("Thành công!!!!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }
        public class DiemThiInfo
        {
            public string MaHocVien { get; set; }
            public string HoTen { get; set; }
            public float? DiemThi { get; set; } 
            public DateTime? NgayThi { get; set; }
            public string TenToChucThi { get; set; }
        }

        private void LuuDuLieuVaoCSDL()
        {
            try
            {
                DataTable dataTable = (DataTable)dataGridView1.DataSource;

                var diemThiData = dataTable.AsEnumerable().Select(row =>
                {
                    try
                    {
                        double? diemThiValue = null;
                        object diemThiObj = row["DiemThi"];

                        if (diemThiObj != DBNull.Value)
                        {
                            if (double.TryParse(diemThiObj.ToString(), out double diemThi))
                            {
                                diemThiValue = diemThi;
                            }
                            else
                            {
                                Console.WriteLine("Invalid value in 'DiemThi' column: " + diemThiObj.ToString());
                            }
                        }

                        return new DiemThiInfoCSV
                        {
                            MaHocVien = row.Field<string>("MaHocVien"),
                            HoTen = row.Field<string>("HoTen"),
                            DiemThi = diemThiValue,
                            //  NgayThi = row.Field<DateTime?>("NgayThi"),
                        };
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine($"InvalidCastException: {ex.Message}");
                        return null;
                    }
                }).ToList();

               
                using (var context = new AnhNguDataContext())
                {
                    string maLopHoc = combomalop.SelectedValue.ToString();

                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    string tenToChucThi = selectedRow.Cells["TenToChucThi"].Value.ToString();
                    var existingToChucThi = context.ToChucThis.FirstOrDefault(tc => tc.TenToChucThi == tenToChucThi);

                    string maToChucThi;

                    if (existingToChucThi == null)
                    {
                        MessageBox.Show("Tên tổ chức thi không tồn tại trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                    }
                    else
                    {
                        maToChucThi = existingToChucThi.MaToChucThi;
                        var existingToChucThiLop = context.ToChucThi_LOPs.FirstOrDefault(tcl => tcl.MaLopHoc == maLopHoc && tcl.MaToChucThi == maToChucThi);

                        if (existingToChucThiLop == null)
                        {
                          
                            ToChucThi_LOP toChucThiLop = new ToChucThi_LOP
                            {
                                MaLopHoc = maLopHoc,
                                MaToChucThi = maToChucThi
                            };

                            context.ToChucThi_LOPs.InsertOnSubmit(toChucThiLop);
                            context.SubmitChanges();
                        }
                        foreach (var diemThi in diemThiData)
                        {
                            if (diemThi != null)
                            {
                                DiemThi diemThiEntity = new DiemThi
                                {
                                    MaHocVien = diemThi.MaHocVien,
                                    MaToChucThi = maToChucThi,
                                    Diem = (float?)diemThi.DiemThi
                                };

                                xylydiem.LuuDiemThi(diemThiEntity);

                                xylydiem.CapNhatDiemThiTrongBangDiem(maToChucThi, diemThi.MaHocVien, (float?)diemThi.DiemThi);
                            }
                        }
                    }
                }

                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LuuDuLieuVaoCSDL();
        }
    }
}
