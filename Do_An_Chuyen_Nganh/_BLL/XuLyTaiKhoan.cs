using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace _BLL
{
    public class XuLyTaiKhoan
    {
        private AnhNguDataContext TaiKhoanContext = new AnhNguDataContext();
        private readonly Random random = new Random();
        public XuLyTaiKhoan()
        {
        }

        public string CheckLogin(string username, string password)
        {
            string role = string.Empty;

            try
            {
                var query = from tk in TaiKhoanContext.TaiKhoans
                            join qt in TaiKhoanContext.QuyenTruyCaps on tk.MaQuyenTruyCap equals qt.MaQuyenTruyCap
                            where tk.TenDangNhap == username && tk.MatKhau == password
                            select qt.TenQuyenTruyCap;
                role = query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra thông tin đăng nhập: " + ex.Message);
            }

            return role;
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauHienTai, string matKhauMoi)
        {
            try
            {
                var query = from tk in TaiKhoanContext.TaiKhoans
                            where tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhauHienTai
                            select tk;

                var taiKhoan = query.FirstOrDefault();

                if (taiKhoan != null)
                {
                    taiKhoan.MatKhau = matKhauMoi;
                    TaiKhoanContext.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đổi mật khẩu: " + ex.Message);
            }

            return false;
        }
        public List<TaiKhoan> GetTaiKhoan()
        {
            return TaiKhoanContext.TaiKhoans.Select(tk => tk).ToList();
        }
        public List<string> GetMaQuyenTruyCap()
        {
            var quyen = TaiKhoanContext.QuyenTruyCaps.Select(qtc => $"{qtc.MaQuyenTruyCap} - {qtc.TenQuyenTruyCap}").ToList();
            return quyen;
        }

        public void ThemTaiKhoan(TaiKhoan taiKhoan)
        {
            TaiKhoanContext.TaiKhoans.InsertOnSubmit(taiKhoan);
            TaiKhoanContext.SubmitChanges();
        }

        public void XoaTaiKhoan(string maTaiKhoan)
        {
            var taiKhoanToRemove = TaiKhoanContext.TaiKhoans.FirstOrDefault(tk => tk.MaTaiKhoan == maTaiKhoan);

            if (taiKhoanToRemove != null)
            {
                TaiKhoanContext.TaiKhoans.DeleteOnSubmit(taiKhoanToRemove);
                TaiKhoanContext.SubmitChanges();
            }
        }

        public void SuaTaiKhoan(TaiKhoan taiKhoan)
        {
            TaiKhoan tk = TaiKhoanContext.TaiKhoans.SingleOrDefault(t => t.MaTaiKhoan == taiKhoan.MaTaiKhoan);
            if (tk != null)
            {
                tk.TenDangNhap = taiKhoan.TenDangNhap;
                tk.MatKhau = taiKhoan.MatKhau;
                tk.MaQuyenTruyCap = taiKhoan.MaQuyenTruyCap;
                TaiKhoanContext.SubmitChanges();
            }
        }

        public List<TaiKhoan> TimKiemTaiKhoan(string tuKhoa)
        {
            var query = TaiKhoanContext.TaiKhoans.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(tk =>
                    tk.MaTaiKhoan.Contains(tuKhoa) ||
                    tk.TenDangNhap.Contains(tuKhoa) ||
                    tk.MaQuyenTruyCap.Contains(tuKhoa)
                );
            }

            return query.ToList();
        }
        public TaiKhoan TaoTaiKhoanHocVienNgauNhien()
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    MaTaiKhoan = "TKHV" + TaoChuoiNgauNhien(),
                    TenDangNhap = TaoTenDangNhapNgauNhien(),
                    MatKhau = TaoMatKhauNgauNhien(),
                    MaQuyenTruyCap = "QT003"
                };

                TaiKhoanContext.TaiKhoans.InsertOnSubmit(taiKhoan);
                TaiKhoanContext.SubmitChanges();
                return taiKhoan;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tạo tài khoản và gán quyền học viên: " + ex.Message);
                return null;
            }
        }
        private string TaoChuoiNgauNhien()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            List<string> danhSachChuoi = new List<string>();

            while (true)
            {
                string chuoiNgauNhien = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());

                if (!danhSachChuoi.Contains(chuoiNgauNhien))
                {
                    danhSachChuoi.Add(chuoiNgauNhien);
                    return chuoiNgauNhien;
                }
            }
        }
        private string TaoTenDangNhapNgauNhien()
        {
            return "HocVien" + random.Next(1000, 9999).ToString();
        }
        private string TaoMatKhauNgauNhien()
        {
            return "Pass" + random.Next(10000, 99999).ToString();
        }
        //Nhan viên
        public TaiKhoan TaoTaiKhoanNhanVienNgauNhien()
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    MaTaiKhoan = "TKNV" + TaoChuoiNgauNhienNhanVien(),
                    TenDangNhap = TaoTenDangNhapNgauNhienNhanVien(),
                    MatKhau = TaoMatKhauNgauNhienNhanVien(),
                    MaQuyenTruyCap = "QT004"
                };

                TaiKhoanContext.TaiKhoans.InsertOnSubmit(taiKhoan);
                TaiKhoanContext.SubmitChanges();
                return taiKhoan;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tạo tài khoản và gán quyền nhân viên: " + ex.Message);
                return null;
            }

        }
        private string TaoChuoiNgauNhienNhanVien()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            List<string> danhSachChuoi = new List<string>();

            while (true)
            {
                string chuoiNgauNhien = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());

                if (!danhSachChuoi.Contains(chuoiNgauNhien))
                {
                    danhSachChuoi.Add(chuoiNgauNhien);
                    return chuoiNgauNhien;
                }
            }
        }
        private string TaoTenDangNhapNgauNhienNhanVien()
        {
            return "NhanVien" + random.Next(1000, 9999).ToString();
        }
        private string TaoMatKhauNgauNhienNhanVien()
        {
            return "Pass" + random.Next(10000, 99999).ToString();
        }
        //GiangVien
        public TaiKhoan TaoTaiKhoanGiangVienNgauNhien()
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    MaTaiKhoan = "TKGV" + TaoChuoiNgauNhienGiangVien(),
                    TenDangNhap = TaoTenDangNhapNgauNhienGiangVien(),
                    MatKhau = TaoMatKhauNgauNhienGiangVien(),
                    MaQuyenTruyCap = "QT002"
                };

                TaiKhoanContext.TaiKhoans.InsertOnSubmit(taiKhoan);
                TaiKhoanContext.SubmitChanges();
                return taiKhoan;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tạo tài khoản và gán quyền giảng viên: " + ex.Message);
                return null;
            }

        }
        private string TaoChuoiNgauNhienGiangVien()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            List<string> danhSachChuoi = new List<string>();

            while (true)
            {
                string chuoiNgauNhien = new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());

                if (!danhSachChuoi.Contains(chuoiNgauNhien))
                {
                    danhSachChuoi.Add(chuoiNgauNhien);
                    return chuoiNgauNhien;
                }
            }
        }
        private string TaoTenDangNhapNgauNhienGiangVien()
        {
            return "GiangVien" + random.Next(1000, 9999).ToString();
        }
        private string TaoMatKhauNgauNhienGiangVien()
        {
            return "Pass" + random.Next(10000, 99999).ToString();
        }
        public string LayMaGiangVien(string tenDangNhap)
        {
            var query = from taiKhoan in TaiKhoanContext.TaiKhoans
                        join giangvien in TaiKhoanContext.GiangViens on taiKhoan.MaTaiKhoan equals giangvien.MaTaiKhoan
                        where taiKhoan.TenDangNhap == tenDangNhap
                        select giangvien.MaGiangVien;

            return query.SingleOrDefault();
        }
        public string LayMaHocVien(string tenDangNhap)
        {
            var query = from taiKhoan in TaiKhoanContext.TaiKhoans
                        join hocvien in TaiKhoanContext.HocViens on taiKhoan.MaTaiKhoan equals hocvien.MaTaiKhoan
                        where taiKhoan.TenDangNhap == tenDangNhap
                        select hocvien.MaHocVien;

            return query.SingleOrDefault();
        }
        public string LayHoTen(string tenDangNhap, string matKhau)
        {
            string hoTen = string.Empty;

            try
            {
                var query = from tk in TaiKhoanContext.TaiKhoans
                            where tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau
                            join nv in TaiKhoanContext.NhanViens on tk.MaTaiKhoan equals nv.MaTaiKhoan into nvGroup
                            from nhanVien in nvGroup.DefaultIfEmpty()
                            join hv in TaiKhoanContext.HocViens on tk.MaTaiKhoan equals hv.MaTaiKhoan into hvGroup
                            from hocVien in hvGroup.DefaultIfEmpty()
                            join gv in TaiKhoanContext.GiangViens on tk.MaTaiKhoan equals gv.MaTaiKhoan into gvGroup
                            from giangVien in gvGroup.DefaultIfEmpty()
                            select nhanVien.HoTen ?? hocVien.HoTen ?? giangVien.HoTen;

                hoTen = query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin họ tên: " + ex.Message);
            }

            return hoTen;
        }
        public string LayMaNhanVien(string tenDangNhap, string matKhau)
        {
            string maNhanVien = string.Empty;

            try
            {
                var query = from tk in TaiKhoanContext.TaiKhoans
                            join nv in TaiKhoanContext.NhanViens on tk.MaTaiKhoan equals nv.MaTaiKhoan
                            where tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau
                            select nv.MaNhanVien;

                maNhanVien = query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin mã nhân viên: " + ex.Message);
            }

            return maNhanVien;
        }
        public TaiKhoan LayThongTinTaiKhoan(string maTaiKhoan)
        {
            TaiKhoan taiKhoan = null;

            try
            {
                var query = from tk in TaiKhoanContext.TaiKhoans
                            where tk.MaTaiKhoan == maTaiKhoan
                            select tk;

                taiKhoan = query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin tài khoản: " + ex.Message);
            }

            return taiKhoan;
        }
    }
}
