using _BLL;
using DevExpress.XtraEditors.TextEditController.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Do_An_Chuyen_Nganh
{
    public partial class fThongKe : Form
    {
        private XuLyThongKe xuLyThongKe = new XuLyThongKe();
        
        public fThongKe()
        {
            InitializeComponent();
            label1.Text = "Tổng doanh thu: " + (xuLyThongKe.LayTongDoanhThu().ToString("N0") + " đồng");
            label2.Text = "Tổng số học viên đăng ký:  " + (xuLyThongKe.LayTongSoLuongHocVienDangKy());
            var thongKeData = xuLyThongKe.ThongKeKetQuaCuoiKy();
            ShowDataBieuDoTron(thongKeData);
            CustomBieuDoTron();
            var thongketron = xuLyThongKe.ThongKeHocVienTheoKhoaHoc();
            HienThiBieuDo(thongketron);
            CustomBieuDo();
            var thongkesoluongvang = xuLyThongKe.ThongKeSoBuoiVangTrongLop();
            ShowBieuDoVang(thongkesoluongvang);
            CustomBieuDoVang();
            var thongkesllopday = xuLyThongKe.ThongKeSoLuongLopDay();
            ShowBieuDoTronGiangVien(thongkesllopday);
            CustomGiangVien();
            var thongKeDoanhThuKhoaHoc = xuLyThongKe.ThongKeDoanhThuTheoKhoaHoc();
            var thongKeDoTuoiData = xuLyThongKe.ThongKeSoLuongHocVienTheoDoTuoi();
            ShowBieuDoDoTuoi(thongKeDoTuoiData);
            CustomBieuDoDoTuoi();
        }

        private void HienThiBieuDo(Dictionary<string, int> data)
        {
            charbieudocot.Series.Clear();
            charbieudocot.Series.Add("Số hv");
            charbieudocot.Series["Số hv"].ChartType = SeriesChartType.Column;
            foreach (var kvp in data)
            {
                charbieudocot.Series["Số hv"].Points.AddXY(kvp.Key, kvp.Value);
            }
        }
        private void CustomBieuDo()
        {
           
            charbieudocot.ChartAreas[0].AxisX.Title = "Tên Khóa Học";
            charbieudocot.ChartAreas[0].AxisY.Title = "Số Lượng Học Viên";
            charbieudocot.Titles.Add("Biểu Đồ Thống Kê Học Viên Theo Khoa Học");
        }

        private void ShowDataBieuDoTron(Dictionary<string, int> data)
        {
            if (charbieudotron.Series.IndexOf("KetQuaCuoiKy") == -1)
            {
                charbieudotron.Series.Add("KetQuaCuoiKy");
            }

            charbieudotron.Series["KetQuaCuoiKy"].ChartType = SeriesChartType.Pie;

            foreach (var kvp in data)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(kvp.Key, kvp.Value);
                point.Label = $"{kvp.Key}: {kvp.Value}"; 
                charbieudotron.Series["KetQuaCuoiKy"].Points.Add(point);
            }
        }
        private void CustomBieuDoTron()
        {
            charbieudotron.Titles.Add("Biểu Đồ Thống Kê Kết Quả Cuối Kỳ");
        }
        private void ShowBieuDoVang(Dictionary<string, int> data)
        {
            charvang.Series.Clear();
            charvang.Series.Add("Số buổi vắng");
            charvang.Series["Số buổi vắng"].ChartType = SeriesChartType.Column;
            foreach (var kvp in data)
            {
                charvang.Series["Số buổi vắng"].Points.AddXY(kvp.Key, kvp.Value);
            }
        }
        private void CustomBieuDoVang()
        {
            charvang.ChartAreas[0].AxisX.Title = "Tên học viên";
            charvang.ChartAreas[0].AxisY.Title = "Số buổi vắng";
            charvang.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            charvang.ChartAreas[0].AxisX.Interval = 1;
            charvang.Titles.Add("Biểu Đồ Thống Kê Số Buổi Vắng");
        }
        private void ShowBieuDoTronGiangVien(Dictionary<string, int> data)
        {
            chargiangvien.Series.Clear();
            chargiangvien.Series.Add("Số Lượng Lớp Dạy");
            chargiangvien.Series["Số Lượng Lớp Dạy"].ChartType = SeriesChartType.Pie;
            foreach (var kvp in data)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(kvp.Key, kvp.Value);
                point.Label = $"{kvp.Key}: {kvp.Value}";
                point.LabelForeColor = Color.Black;
                point.LabelBackColor = Color.Transparent;
                point.LabelToolTip = $"{kvp.Key}: {kvp.Value}";
                chargiangvien.Series["Số Lượng Lớp Dạy"].Points.Add(point);
            }
        }

        private void CustomGiangVien()
        {
            chargiangvien.Titles.Add("Biểu Đồ Thống Kê Số Lượng Lớp Dạy Của Giảng Viên");
        }
        private void ShowBieuDoDoTuoi(Dictionary<string, int> data)
        {
            charDoTuoi.Series.Clear();
            charDoTuoi.Series.Add("SL Học Viên");
            charDoTuoi.Series["SL Học Viên"].ChartType = SeriesChartType.Column;
            foreach (var kvp in data)
            {
                charDoTuoi.Series["SL Học Viên"].Points.AddXY(kvp.Key, kvp.Value);
            }
        }

        private void CustomBieuDoDoTuoi()
        {
            charDoTuoi.ChartAreas[0].AxisX.Title = "Độ Tuổi";
            charDoTuoi.ChartAreas[0].AxisY.Title = "Số Lượng Học Viên";
            charDoTuoi.Titles.Add("Biểu Đồ Thống Kê Số Lượng Học Viên Theo Độ Tuổi");
        }
    }
}
