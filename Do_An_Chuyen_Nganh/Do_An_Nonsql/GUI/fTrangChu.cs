using _BLL;
using Do_An_Chuyen_Nganh.GUI;
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
    public partial class fTrangChu : Form
    {
        private string hoTen;
        private string maGiangVien;
        private string maHocVien;

        public fTrangChu(string hoTen, string maGiangVien,string maHocVien)
        {
            InitializeComponent();
            this.hoTen = hoTen;
            this.maGiangVien = maGiangVien;
            this.maHocVien = maHocVien;
            AnDanhMuc();
            HienThiHienTen();
        }
   
        private Form ALLForm;

        private void OpenALL(Form ALL)
        {
            if (ALLForm != null)
            {
                ALLForm.Close();
            }
            ALLForm = ALL;
            ALL.TopLevel = false;
            ALL.FormBorderStyle = FormBorderStyle.None;
            ALL.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(ALL);
            panel_Body.Tag = ALL;
            ALL.BringToFront();
            ALL.Show();
        }



        private void ptrHome_Click(object sender, EventArgs e)
        {
            if (ALLForm != null)
            {
                ALLForm.Close();
            }
            lblHienThi.Text = "Trang Chủ";
        }

        private void AnDanhMuc()
        {
            panelQLDanhMuc.Visible = false;
        }

        private void HienThiDanhMuc()
        {
            if (panelQLDanhMuc.Visible == true)
                panelQLDanhMuc.Visible = false;
        }

        private void HienThiMenu(Panel Menu)
        {
            if (Menu.Visible == false)
            {
                HienThiDanhMuc();
                Menu.Visible = true;
            }
            else
                Menu.Visible = false;
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            HienThiDanhMuc();
            OpenALL(new fQuanLyNhanVien());
            lblHienThi.Text = btnQLNV.Text;
        }

        private void btnQLHV_Click(object sender, EventArgs e)
        {
            HienThiDanhMuc();
            OpenALL(new fQuanLyHocVien());
            lblHienThi.Text = btnQLHV.Text;
        }

        private void btnQLGV_Click(object sender, EventArgs e)
        {
            HienThiDanhMuc();
            OpenALL(new fQuanLyGiangVien());
            lblHienThi.Text = btnQLGV.Text;
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            HienThiDanhMuc();
            OpenALL(new fQuanLyKhoaHoc());
            lblHienThi.Text = btnQLKH.Text;
        }

        private void btnQLLH_Click(object sender, EventArgs e)
        {
            HienThiDanhMuc();
            OpenALL(new fQuanLyLichHoc());
            lblHienThi.Text = btnQLLH.Text;
        }

        private void btnQLPQ_Click(object sender, EventArgs e)
        {
            HienThiDanhMuc();
            OpenALL(new fQuanLyPhanQuyen());
            lblHienThi.Text = btnQLPQ.Text;
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            HienThiDanhMuc();
            OpenALL(new fQuanLyPhongHoc());
            lblHienThi.Text = btnP.Text;
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            HienThiDanhMuc();
            OpenALL(new fQuanLyLop());
            lblHienThi.Text = btnL.Text;
        }

        private void btnQLDM_Click(object sender, EventArgs e)
        {
            HienThiMenu(panelQLDanhMuc);
        }


        private void fTrangChu_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        public void HienThiQuanLy()
        {
            btnLichHocCuaHocVien.Visible = false;
            btnLichDayGiangVien.Visible = false;
        }
        public void HienThiGiangVien()
        {
            btnTraCuuLichHocCuaHocVien.Visible = false;
            btnTraCuuGiangVien.Visible = false;
            btnLichHocCuaHocVien.Visible = false;
            btnQLDM.Visible = false;
            btnDangKy.Visible = false;
            btnThongKe.Visible = false;
            btnTT.Visible = false;
        }
        public void HienThiHocVien()
        {
            btnDanhSachHocVienTheoLop.Visible = false;
            btnTraCuuLichHocCuaHocVien.Visible = false;
            btnTraCuuGiangVien.Visible = false;
            btnLichDayGiangVien.Visible = false;
            btnQLDM.Visible = false;
            btnTDDD.Visible = false;
            btnDSVDG.Visible = false;
            btnThongKe.Visible = false;
            btnPPTL.Visible = false;
            btnTT.Visible = false;
            btnDangKy.Visible = false;

        }

        public void HienThiNhanVien()
        {
            btnLichHocCuaHocVien.Visible = false;
            btnLichDayGiangVien.Visible = false;
        }

        private void HienThiHienTen()
        {
            lbTenTaiKhoan.Text = $"Xin chào: {hoTen}!";
        }

        private void btnTraCuuGiangVien_Click(object sender, EventArgs e)
        { 
            OpenALL(new fLichDayGVCuaQuanLY());
            lblHienThi.Text = btnTraCuuGiangVien.Text;
        }

        private void btnLichDayGiangVien_Click(object sender, EventArgs e)
        {
            fLichDayGV fLichDayGV = new fLichDayGV(hoTen, maGiangVien); // Truyền mã giảng viên vào FLichDayGV
            OpenALL(fLichDayGV);
            lblHienThi.Text = btnLichDayGiangVien.Text;
        }

        private void btnLichHocCuaHocVien_Click(object sender, EventArgs e)
        {
            fThoiKhoaBieuHV fThoiKhoaBieuHV = new fThoiKhoaBieuHV(hoTen, maHocVien);
            OpenALL(fThoiKhoaBieuHV);
            lblHienThi.Text = btnLichHocCuaHocVien.Text;
        }

        private void btnTraCuuLichHocCuaHocVien_Click(object sender, EventArgs e)
        {
            OpenALL(new fLichHocVienQuanLy());
            lblHienThi.Text = btnTraCuuLichHocCuaHocVien.Text;
        }

        private void btnTDDD_Click(object sender, EventArgs e)
        {
            OpenALL(new fTheoDoiDiemDanh());
            lblHienThi.Text = btnTDDD.Text;
        }

        private void btnDSVDG_Click(object sender, EventArgs e)
        {
            OpenALL(new fDiemSo());
            lblHienThi.Text = btnDSVDG.Text;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            OpenALL(new fDangKyKhoaHoc());
            lblHienThi.Text = btnDangKy.Text;
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            OpenALL(new fThanhToan(""));
            lblHienThi.Text = btnTT.Text;
        }

        private void btnPPTL_Click(object sender, EventArgs e)
        {
            OpenALL(new fPhanPhoiTaiLieu());
            lblHienThi.Text = btnPPTL.Text;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenALL(new fThongKe());
            lblHienThi.Text = btnThongKe.Text;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            fDangNhap loginForm = new fDangNhap();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnDanhSachHocVienTheoLop_Click(object sender, EventArgs e)
        {
            OpenALL(new fSapXepLopHoc());
            lblHienThi.Text = btnDanhSachHocVienTheoLop.Text;
        }
    }
}
