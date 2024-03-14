using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _BLL
{
    public class XuLyGiangVien
    {
        private AnhNguDataContext context = new AnhNguDataContext();

        public XuLyGiangVien()
        {
        }

        public List<GiangVien> GetGiangVien()
        {
            return context.GiangViens.ToList();
        }

        public List<string> GetMaTaiKhoan()
        {
            var taikhoan = context.TaiKhoans.Select(tk => $"{tk.MaTaiKhoan} - {tk.TenDangNhap}").ToList();
            return taikhoan;
        }

        public void ThemGiangVien(GiangVien giangVien)
        {
            context.GiangViens.InsertOnSubmit(giangVien);
            context.SubmitChanges();
        }

        public void XoaGiangVien(string maGiangVien)
        {
            var giangVienToRemove = context.GiangViens.FirstOrDefault(gv => gv.MaGiangVien == maGiangVien);

            if (giangVienToRemove != null)
            {
                context.GiangViens.DeleteOnSubmit(giangVienToRemove);
                context.SubmitChanges();
            }
        }

        public void SuaGiangVien(GiangVien giangVien)
        {
            var gv = context.GiangViens.SingleOrDefault(g => g.MaGiangVien == giangVien.MaGiangVien);

            if (gv != null)
            {
                gv.HoTen = giangVien.HoTen;
                gv.NgaySinh = giangVien.NgaySinh;
                gv.GioiTinh = giangVien.GioiTinh;
                gv.DiaChi = giangVien.DiaChi;
                gv.SoDienThoai = giangVien.SoDienThoai;
                gv.Email = giangVien.Email;
                gv.MaTaiKhoan = giangVien.MaTaiKhoan;

                context.SubmitChanges();
            }
        }

        public List<GiangVien> TimKiemGiangVien(string tuKhoa)
        {
            var query = context.GiangViens.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(gv =>
                    gv.MaGiangVien.Contains(tuKhoa) ||
                    gv.HoTen.Contains(tuKhoa) ||
                    gv.GioiTinh.Contains(tuKhoa) ||
                    gv.DiaChi.Contains(tuKhoa) ||
                    gv.SoDienThoai.Contains(tuKhoa) ||
                    gv.Email.Contains(tuKhoa) ||
                    gv.MaTaiKhoan.Contains(tuKhoa)
                );
            }

            return query.ToList();
        }
    }
}
