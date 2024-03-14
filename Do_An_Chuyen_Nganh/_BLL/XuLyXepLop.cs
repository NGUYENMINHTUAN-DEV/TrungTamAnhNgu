using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public class XuLyXepLop
    {
        AnhNguDataContext Xeplop = new AnhNguDataContext();
        public void ThemQuanLyLopHocVien(XepLopHocVien XepLopHocVien)
        {
            var lopHoc = Xeplop.LopHocs.SingleOrDefault(lop => lop.MaLopHoc == XepLopHocVien.MaLopHoc);

            if (lopHoc != null)
            {
                if (lopHoc.SoLuongHocVienHienTai < lopHoc.SoLuongHocVienToiDa)
                {
                    Xeplop.XepLopHocViens.InsertOnSubmit(XepLopHocVien);
                    Xeplop.SubmitChanges();
                    lopHoc.SoLuongHocVienHienTai++;
                    Xeplop.SubmitChanges();
                }
                else
                {
                    Console.WriteLine("Lớp đã đầy, không thể thêm học viên.");
                }
            }
        }
        public void SuaQuanLyLopHocVien(XepLopHocVien XepLopHocVien)
        {
            XepLopHocVien ql = Xeplop.XepLopHocViens.SingleOrDefault(q => q.IDXepLop == XepLopHocVien.IDXepLop);
            if (ql != null)
            {
                var lopHocCu = Xeplop.LopHocs.SingleOrDefault(lop => lop.MaLopHoc == ql.MaLopHoc);
                var lopHocMoi = Xeplop.LopHocs.SingleOrDefault(lop => lop.MaLopHoc == XepLopHocVien.MaLopHoc);

                if (lopHocCu != null)
                {
                    lopHocCu.SoLuongHocVienHienTai--;
                    Xeplop.SubmitChanges();
                }

                ql.MaLopHoc = XepLopHocVien.MaLopHoc;
                ql.MaHocVien = XepLopHocVien.MaHocVien;
                Xeplop.SubmitChanges();

                if (lopHocMoi != null)
                {
                    lopHocMoi.SoLuongHocVienHienTai++; 
                    Xeplop.SubmitChanges();
                }
            }
        }
        public void XoaQuanLyLopHocVien(string IDXepLop)
        {
            var quanLyToRemove = Xeplop.XepLopHocViens.FirstOrDefault(ql => ql.IDXepLop == IDXepLop);

            if (quanLyToRemove != null)
            {
                var lopHoc = Xeplop.LopHocs.SingleOrDefault(lop => lop.MaLopHoc == quanLyToRemove.MaLopHoc);

                if (lopHoc != null)
                {
                    lopHoc.SoLuongHocVienHienTai--;
                    Xeplop.XepLopHocViens.DeleteOnSubmit(quanLyToRemove);
                    Xeplop.SubmitChanges();
                    Xeplop.SubmitChanges();
                }
            }
        }

    }
}
