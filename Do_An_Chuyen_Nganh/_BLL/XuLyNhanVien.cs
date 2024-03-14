using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public class XuLyNhanVien
    {
        AnhNguDataContext NhanVien = new AnhNguDataContext();
       
        public XuLyNhanVien()
        {

        }
        public List<NhanVien> GetNV()
        {
            return NhanVien.NhanViens.Select(NV => NV).ToList<NhanVien>();
        }
        public List<string> GetMaTK()
        {
            var taikhoan = NhanVien.TaiKhoans.Select(tk => $"{tk.MaTaiKhoan} - {tk.TenDangNhap}").ToList();
            return taikhoan;
        }
        public void ThemNV(NhanVien nhanvien)
        {
            NhanVien.NhanViens.InsertOnSubmit(nhanvien);
            NhanVien.SubmitChanges();
        }
        public void XoaNV(string maNhanVien)
        {
            var nhanvienToRemove = NhanVien.NhanViens.FirstOrDefault(kh => kh.MaNhanVien == maNhanVien);

            if (nhanvienToRemove != null)
            {
                NhanVien.NhanViens.DeleteOnSubmit(nhanvienToRemove);
                NhanVien.SubmitChanges();
            }
        }
        public void SuaNV(NhanVien nhanvien)
        {
            NhanVien nv = NhanVien.NhanViens.SingleOrDefault(k => k.MaNhanVien == nhanvien.MaNhanVien);
            if (nv != null)
            {
                nv.HoTen= nhanvien.HoTen;
                nv.NgaySinh = nhanvien.NgaySinh;
                nv.GioiTinh = nhanvien.GioiTinh;
                nv.DiaChi = nhanvien.DiaChi;
                nv.SoDienThoai = nhanvien.SoDienThoai;
                nv.Email= nhanvien.Email;
                nv.MaTaiKhoan = nhanvien.MaTaiKhoan;
                NhanVien.SubmitChanges();
            }
        }
        public List<NhanVien> TimKiemNhanVien(string tuKhoa)
        {
            var query = NhanVien.NhanViens.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(nv =>
                    nv.MaNhanVien.Contains(tuKhoa) ||
                    nv.HoTen.Contains(tuKhoa) ||
                    nv.GioiTinh.Contains(tuKhoa) ||
                    nv.DiaChi.Contains(tuKhoa) ||
                    nv.SoDienThoai.Contains(tuKhoa) ||
                    nv.Email.Contains(tuKhoa) ||
                    nv.MaTaiKhoan.Contains(tuKhoa)
                );
            }

            return query.ToList();
        }


    }
}
