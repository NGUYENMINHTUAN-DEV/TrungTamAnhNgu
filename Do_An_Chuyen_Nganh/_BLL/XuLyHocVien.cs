using System;
using System.Collections.Generic;
using System.Linq;

namespace _BLL
{
    public class XuLyHocVien
    {
        private AnhNguDataContext context = new AnhNguDataContext();

        public XuLyHocVien()
        {
        }

        public List<HocVien> GetHocVien()
        {
            return context.HocViens.ToList();
        }

        public List<string> GetMaTaiKhoan()
        {
            var taikhoan = context.TaiKhoans.Select(tk => $"{tk.MaTaiKhoan} - {tk.TenDangNhap}").ToList();
            return taikhoan;
        }

        public void ThemHocVien(HocVien hocVien)
        {
            context.HocViens.InsertOnSubmit(hocVien);
            context.SubmitChanges();
        }

        public void XoaHocVien(string maHocVien)
        {
            var hocVienToRemove = context.HocViens.FirstOrDefault(hv => hv.MaHocVien == maHocVien);

            if (hocVienToRemove != null)
            {
                context.HocViens.DeleteOnSubmit(hocVienToRemove);
                context.SubmitChanges();
            }
        }

        public void SuaHocVien(HocVien hocVien)
        {
            var hv = context.HocViens.SingleOrDefault(h => h.MaHocVien == hocVien.MaHocVien);

            if (hv != null)
            {
                hv.HoTen = hocVien.HoTen;
                hv.NgaySinh = hocVien.NgaySinh;
                hv.GioiTinh = hocVien.GioiTinh;
                hv.DiaChi = hocVien.DiaChi;
                hv.SoDienThoai = hocVien.SoDienThoai;
                hv.Email = hocVien.Email;
                hv.MaTaiKhoan = hocVien.MaTaiKhoan;

                context.SubmitChanges();
            }
        }

        public List<HocVien> TimKiemHocVien(string tuKhoa)
        {
            var query = context.HocViens.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(hv =>
                    hv.MaHocVien.Contains(tuKhoa) ||
                    hv.HoTen.Contains(tuKhoa) ||
                    hv.GioiTinh.Contains(tuKhoa) ||
                    hv.DiaChi.Contains(tuKhoa) ||
                    hv.SoDienThoai.Contains(tuKhoa) ||
                    hv.Email.Contains(tuKhoa) ||
                    hv.MaTaiKhoan.Contains(tuKhoa)
                );
            }

            return query.ToList();
        }
        public string LayMaHocVienTheoTen(string hoTen)
        {
            var hocVien = context.HocViens.FirstOrDefault(hv => hv.HoTen == hoTen);
            return hocVien?.MaHocVien;
        }
    }
}
