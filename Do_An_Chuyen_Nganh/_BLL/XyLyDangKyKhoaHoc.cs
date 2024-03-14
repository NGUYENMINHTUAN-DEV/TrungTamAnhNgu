using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _BLL
{
    public class XyLyDangKyKhoaHoc
    {
        private AnhNguDataContext DangKyKhoaHocContext = new AnhNguDataContext();

        public XyLyDangKyKhoaHoc()
        {

        }

        public class DangKyKhoaHocViewModel
        {
            public string MaDangKy { get; set; }
            public string TenHocVien { get; set; }
            public string TenKhoaHoc { get; set; }
            public DateTime? NgayDangKy { get; set; }
           
            public bool Dathanhtoan { get; set; }
            public string HinhThucThanhToan { get; set; }
        }

        public List<DangKyKhoaHocViewModel> GetDangKyKhoaHoc()
        {
            return DangKyKhoaHocContext.DangKyKhoaHocs
                .Join(DangKyKhoaHocContext.HocViens, dk => dk.MaHocVien, hv => hv.MaHocVien, (dk, hv) => new { dk, hv })
                .Join(DangKyKhoaHocContext.DangKyKhoaHoc_KhoaHocs, j => j.dk.MaDangKy, kh => kh.MaDangKy, (j, kh) => new { j, kh })
                .Join(DangKyKhoaHocContext.KhoaHocs, jk => jk.kh.MaKhoaHoc, kh => kh.MaKhoaHoc, (jk, kh) => new DangKyKhoaHocViewModel
                {
                    MaDangKy = jk.j.dk.MaDangKy,
                    TenHocVien = jk.j.hv.HoTen,
                    TenKhoaHoc = kh.TenKhoaHoc,
                    NgayDangKy = jk.j.dk.NgayDangKy,
                    Dathanhtoan = (bool)jk.j.dk.DaThanhToan,
                    HinhThucThanhToan = jk.j.dk.HinhThucThanhToan
                })
                .ToList();
        }

        public List<string> GetMaHocVien()
        {
            var hocvien = DangKyKhoaHocContext.HocViens.Select(hv => $"{hv.MaHocVien} - {hv.HoTen}").ToList();
            return hocvien;
        }

        public List<string> GetMaKhoaHoc()
        {
            var khoahoc = DangKyKhoaHocContext.KhoaHocs
                .Select(kh => $"{kh.MaKhoaHoc.Trim()} - {kh.TenKhoaHoc}")
                .ToList();
            return khoahoc;
        }

        public void ThemDangKyKhoaHoc_KhoaHoc(DangKyKhoaHoc_KhoaHoc dangKyKhoaHoc_KhoaHoc)
        {
            DangKyKhoaHocContext.DangKyKhoaHoc_KhoaHocs.InsertOnSubmit(dangKyKhoaHoc_KhoaHoc);
            DangKyKhoaHocContext.SubmitChanges();
        }
        public void ThemDangKyKhoaHoc(DangKyKhoaHoc dangKyKhoaHoc)
        {
            DangKyKhoaHocContext.DangKyKhoaHocs.InsertOnSubmit(dangKyKhoaHoc);
            DangKyKhoaHocContext.SubmitChanges();
        }
        public KhoaHoc LayThongTinKhoaHocTheoMa(string maKhoaHoc)
        {
            return DangKyKhoaHocContext.KhoaHocs.SingleOrDefault(kh => kh.MaKhoaHoc == maKhoaHoc);
        }

        public void CapNhatThongTinKhoaHoc(KhoaHoc khoaHoc)
        {
            DangKyKhoaHocContext.SubmitChanges();
        }
        public void CapNhatThongTinLopHoc(LopHoc lophoc)
        {
            DangKyKhoaHocContext.SubmitChanges();
        }
        public void ThemPhieuThu(PhieuThu phieuthu)
        {
            DangKyKhoaHocContext.PhieuThus.InsertOnSubmit(phieuthu);
            DangKyKhoaHocContext.SubmitChanges();
        }
        public void ThemChiTietPhieuTHu(ChiTietPhieuThu chitietphieuthu)
        {
            DangKyKhoaHocContext.ChiTietPhieuThus.InsertOnSubmit(chitietphieuthu);
            DangKyKhoaHocContext.SubmitChanges();
        }
        public void XoaDangKyKhoaHoc(string maDangKy)
        {
            var dangKyToDelete = DangKyKhoaHocContext.DangKyKhoaHocs.SingleOrDefault(dk => dk.MaDangKy == maDangKy);

            if (dangKyToDelete != null)
            {
                var khoaHocList = DangKyKhoaHocContext.DangKyKhoaHoc_KhoaHocs
                    .Where(dk_kh => dk_kh.MaDangKy == maDangKy)
                    .Select(dk_kh => dk_kh.MaKhoaHoc)
                    .ToList();

                foreach (var maKhoaHoc in khoaHocList)
                {
                    var existingKhoaHoc = DangKyKhoaHocContext.KhoaHocs.SingleOrDefault(kh => kh.MaKhoaHoc == maKhoaHoc);
                    if (existingKhoaHoc != null && existingKhoaHoc.SoLuongHocVien > 0)
                    {
                        existingKhoaHoc.SoLuongHocVien--;
                    }
                }
                DangKyKhoaHocContext.DangKyKhoaHocs.DeleteOnSubmit(dangKyToDelete);
                DangKyKhoaHocContext.DangKyKhoaHoc_KhoaHocs.DeleteAllOnSubmit(
                    DangKyKhoaHocContext.DangKyKhoaHoc_KhoaHocs.Where(dk_kh => dk_kh.MaDangKy == maDangKy)
                );
                DangKyKhoaHocContext.SubmitChanges();
            }
            else
            {
                Console.WriteLine($"Không tìm thấy đăng ký với mã {maDangKy}");
            }
        }
        public void XoaPhieuThuTheoMaDangKy(string maDangKy)
        {
            var chiTietPhieuThuList = DangKyKhoaHocContext.ChiTietPhieuThus
                .Where(ct => ct.MaPhieuThu == maDangKy)
                .ToList();

            foreach (var chiTietPhieuThu in chiTietPhieuThuList)
            {
                DangKyKhoaHocContext.ChiTietPhieuThus.DeleteOnSubmit(chiTietPhieuThu);
            }

            var phieuThuList = DangKyKhoaHocContext.PhieuThus
                .Where(pt => pt.MaHocVien == maDangKy)
                .ToList();

            foreach (var phieuThu in phieuThuList)
            {
                DangKyKhoaHocContext.PhieuThus.DeleteOnSubmit(phieuThu);
            }

            DangKyKhoaHocContext.SubmitChanges();
        }
        public void SuaDangKyKhoaHoc(DangKyKhoaHoc dangKyKhoaHoc)
        {
            if (DangKyKhoaHocContext.HocViens.Any(hv => hv.MaHocVien == dangKyKhoaHoc.MaHocVien))
            {
                DangKyKhoaHoc dk = DangKyKhoaHocContext.DangKyKhoaHocs.SingleOrDefault(d => d.MaDangKy == dangKyKhoaHoc.MaDangKy);
                if (dk != null)
                {
                    dk.MaHocVien = dangKyKhoaHoc.MaHocVien;
                    dk.NgayDangKy = dangKyKhoaHoc.NgayDangKy;
                    dk.DaThanhToan = dangKyKhoaHoc.DaThanhToan;
                    dk.HinhThucThanhToan = dangKyKhoaHoc.HinhThucThanhToan;
                    DangKyKhoaHocContext.SubmitChanges();
                }
            }
        }


        public List<DangKyKhoaHoc> TimKiemDangKyKhoaHoc(string tuKhoa)
        {
            var query = DangKyKhoaHocContext.DangKyKhoaHocs.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(dk =>
                    dk.MaDangKy.Contains(tuKhoa) ||
                    dk.MaHocVien.Contains(tuKhoa) ||
                    dk.NgayDangKy.ToString().Contains(tuKhoa) ||
                    dk.DaThanhToan.ToString().Contains(tuKhoa) ||
                    dk.HinhThucThanhToan.Contains(tuKhoa)
                );
            }

            return query.ToList();
        }

        public bool KiemTraHocVienDaDangKy(string soDienThoai)
        {
            var trangThaiDangKy = from hocVien in DangKyKhoaHocContext.HocViens
                                  join taiKhoan in DangKyKhoaHocContext.TaiKhoans on hocVien.MaTaiKhoan equals taiKhoan.MaTaiKhoan
                                  join dangKy in DangKyKhoaHocContext.DangKyKhoaHocs on hocVien.MaHocVien equals dangKy.MaHocVien into gj
                                  from subDangKy in gj.DefaultIfEmpty()
                                  where hocVien.SoDienThoai == soDienThoai
                                  select subDangKy;
            bool hocVienDaDangKy = trangThaiDangKy.Any(subDangKy => subDangKy != null);
            return hocVienDaDangKy;
        }
        public string LayMaHocVienTheoSoDienThoai(string soDienThoai)
        {
            var hocVien = DangKyKhoaHocContext.HocViens.FirstOrDefault(hv => hv.SoDienThoai == soDienThoai);

            if (hocVien != null)
            {
                return hocVien.MaHocVien;
            }
            else
            {
                return null;
            }
        }
        public decimal LayTongTienKhoaHoc(string maKhoaHoc)
        {
            decimal? tongTien = (decimal?)DangKyKhoaHocContext.KhoaHocs
                .Where(kh => kh.MaKhoaHoc == maKhoaHoc)
                .Sum(kh => kh.HocPhi);
            return tongTien ?? 0m;
        }
        public decimal LayDonGiaKhoaHoc(string maKhoaHoc)
        {
            double? hocPhi = DangKyKhoaHocContext.KhoaHocs
                .Where(kh => kh.MaKhoaHoc == maKhoaHoc)
                .Sum(kh => kh.HocPhi);

            return (decimal?)hocPhi ?? 0m;
        }
        public List<LopHoc> LayDanhSachLopHocTheoKhoaHoc(string maKhoaHoc)
        {
            var danhSachLopHoc = DangKyKhoaHocContext.LopHocs
                .Where(lh => lh.MaKhoaHoc == maKhoaHoc)
                .ToList();

            return danhSachLopHoc;
        }

        public string LayMaHocVienTheoMaDangKy(string maDangKy)
        {
            var dangKy = DangKyKhoaHocContext.DangKyKhoaHocs.FirstOrDefault(dk => dk.MaDangKy == maDangKy);

            if (dangKy != null)
            {
                return dangKy.MaHocVien;
            }
            else
            {
                return null;
            }
        }
        public void ThemXepLopHocVien(XepLopHocVien xeplop)
        {
            DangKyKhoaHocContext.XepLopHocViens.InsertOnSubmit(xeplop);
            DangKyKhoaHocContext.SubmitChanges();
        }
        public string LayMaPhieuThuTheoMaDangKy(string maDangKy)
        {
            var maPhieuThu = DangKyKhoaHocContext.PhieuThus
                .Join(DangKyKhoaHocContext.ChiTietPhieuThus,
                      pt => pt.MaPhieuThu,
                      cpt => cpt.MaPhieuThu,
                      (pt, cpt) => new { PhieuThu = pt, ChiTietPhieuThu = cpt })
                .Join(DangKyKhoaHocContext.DangKyKhoaHoc_KhoaHocs,
                      joined => joined.ChiTietPhieuThu.MaKhoaHoc,
                      dkkh => dkkh.MaKhoaHoc,
                      (joined, dkkh) => new { joined.PhieuThu, joined.ChiTietPhieuThu, DangKyKhoaHoc_KhoaHoc = dkkh })
                .Where(joined => joined.DangKyKhoaHoc_KhoaHoc.MaDangKy == maDangKy || joined.PhieuThu.MaHocVien == maDangKy)
                .Select(joined => joined.PhieuThu.MaPhieuThu)
                .FirstOrDefault();

            return maPhieuThu;
        }

        public void SuaPhieuThu(PhieuThu phieuThuMoi)
        {
            if (DangKyKhoaHocContext.HocViens.Any(hv => hv.MaHocVien == phieuThuMoi.MaHocVien))
            {
                PhieuThu phieuThu = DangKyKhoaHocContext.PhieuThus.SingleOrDefault(pt => pt.MaPhieuThu == phieuThuMoi.MaPhieuThu);

                if (phieuThu != null)
                {
                    phieuThu.MaHocVien = phieuThuMoi.MaHocVien;
                    phieuThu.NgayLap = phieuThuMoi.NgayLap;
                    phieuThu.TongTien = phieuThuMoi.TongTien;
                    phieuThu.MaNhanVien = phieuThuMoi.MaNhanVien;
                    phieuThu.TrangThai = phieuThuMoi.TrangThai;
                    DangKyKhoaHocContext.SubmitChanges();
                }
            }
        }
        public string LayMaHocVienTuMaDangKy(string maDangKy)
        {
            var maHocVien = DangKyKhoaHocContext.DangKyKhoaHocs
                .Where(dk => dk.MaDangKy == maDangKy)
                .Select(dk => dk.MaHocVien)
                .FirstOrDefault();

            return maHocVien;
        }

        public XepLopHocVien LayThongTinXepLopTuMaHocVien(string maHocVien)
        {
            var thongTinXepLop = DangKyKhoaHocContext.XepLopHocViens
                .Where(xl => xl.MaHocVien == maHocVien)
                .FirstOrDefault();

            return thongTinXepLop;
        }
        public void XoaXepLopHocVienTheoMaXepLop(string maXepLop)
        {
            var xepLopToDelete = DangKyKhoaHocContext.XepLopHocViens
                .SingleOrDefault(xl => xl.IDXepLop == maXepLop);

            if (xepLopToDelete != null)
            {
                DangKyKhoaHocContext.XepLopHocViens.DeleteOnSubmit(xepLopToDelete);
                DangKyKhoaHocContext.SubmitChanges();
            }
            else
            {
                Console.WriteLine($"Không tìm thấy xếp lớp với mã {maXepLop}");
            }
        }





    }
}
