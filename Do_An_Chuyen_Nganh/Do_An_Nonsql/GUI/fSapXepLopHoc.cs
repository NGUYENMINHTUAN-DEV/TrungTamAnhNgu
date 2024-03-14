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
using static _BLL.XyLyQuanLyLopHocVien;

namespace Do_An_Chuyen_Nganh.GUI
{
    public partial class fSapXepLopHoc : Form
    {
        private XyLyQuanLyLopHocVien xyLyQuanLyLopHocVien = new XyLyQuanLyLopHocVien();
        private XuLyXepLop xuLyXepLop = new XuLyXepLop();
        private Random random = new Random();
        public fSapXepLopHoc()
        {
            InitializeComponent();
        }
        private void LoadDataQL()
        {
            dataQuanLyLopHocVien.DataSource = xyLyQuanLyLopHocVien.GetDanhSachQuanLyLopHocVien();
            dataQuanLyLopHocVien.Columns["HocVien"].Visible = false;
            dataQuanLyLopHocVien.Columns["LopHoc"].Visible = false;
            comboMaLop.DataSource = xyLyQuanLyLopHocVien.GetMaLop();
            comHocvien.DataSource = xyLyQuanLyLopHocVien.GetMaHocVien();
        }
        private string SinhMaQL()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 2)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            return "QLLH" + randomPart;
        }
        private void AutoSizeColumnsQL()
        {
            foreach (DataGridViewColumn column in dataQuanLyLopHocVien.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void fSapXepLopHoc_Load(object sender, EventArgs e)
        {
            LoadDataQL();
            AutoSizeColumnsQL();
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            fQuanLyLop QlLop = new fQuanLyLop();
            QlLop.StartPosition = FormStartPosition.CenterScreen;
            QlLop.ShowDialog();
        }

        private void comboMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMaLop.SelectedItem != null)
            {
                string malop = comboMaLop.SelectedItem.ToString().Split('-')[0].Trim();
                LoadCombohv(malop);
            }
            else
            {
               
            }
        }
        private void LoadCombohv(string maLop)
        {
            XyLyQuanLyLopHocVien quanLyLopHocVienBLL = new XyLyQuanLyLopHocVien();
            List<HocVienInfo> danhSachHocVien = quanLyLopHocVienBLL.LayDanhSachHocVienTrongLop(maLop)
                .Select(hv => new HocVienInfo { HoTen = hv.HoTen, NgaySinh = hv.NgaySinh })
                .ToList();
            dataQuanLyLopHocVien.DataSource = danhSachHocVien;
            dataQuanLyLopHocVien.Refresh();
        }

    }
}
