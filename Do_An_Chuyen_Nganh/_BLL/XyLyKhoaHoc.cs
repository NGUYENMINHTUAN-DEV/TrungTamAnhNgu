using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public class XyLyKhoaHoc
    {
        AnhNguDataContext KhoaHocContext = new AnhNguDataContext();

        public XyLyKhoaHoc()
        {

        }

        public List<KhoaHoc> GetKhoaHoc()
        {
            return KhoaHocContext.KhoaHocs.Select(kh => kh).ToList<KhoaHoc>();
        }

        public void ThemKhoaHoc(KhoaHoc khoaHoc)
        {
            KhoaHocContext.KhoaHocs.InsertOnSubmit(khoaHoc);
            KhoaHocContext.SubmitChanges();
        }
        public void ThemLopHoc(LopHoc lopHoc)
        {
            KhoaHoc khoaHoc = KhoaHocContext.KhoaHocs.FirstOrDefault(kh => kh.MaKhoaHoc == lopHoc.MaKhoaHoc);

            if (khoaHoc != null)
            {
                if (( lopHoc.SoLuongHocVienToiDa) > khoaHoc.SoLuongHocVien)
                {

                    return;
                }
                KhoaHocContext.LopHocs.InsertOnSubmit(lopHoc);
                KhoaHocContext.SubmitChanges();
            }
        }
        public void XoaKhoaHoc(string maKhoaHoc)
        {
            var khoaHocToRemove = KhoaHocContext.KhoaHocs.FirstOrDefault(kh => kh.MaKhoaHoc == maKhoaHoc);

            if (khoaHocToRemove != null)
            {
                KhoaHocContext.KhoaHocs.DeleteOnSubmit(khoaHocToRemove);
                KhoaHocContext.SubmitChanges();
            }
        }

        public void SuaKhoaHoc(KhoaHoc khoaHoc)
        {
            KhoaHoc kh = KhoaHocContext.KhoaHocs.SingleOrDefault(k => k.MaKhoaHoc == khoaHoc.MaKhoaHoc);
            if (kh != null)
            {
                kh.TenKhoaHoc = khoaHoc.TenKhoaHoc;
                kh.MoTa = khoaHoc.MoTa;
                kh.HocPhi = khoaHoc.HocPhi;
                kh.ThoiGianBatDau = khoaHoc.ThoiGianBatDau;
                kh.ThoiGianKetThuc = khoaHoc.ThoiGianKetThuc;
                kh.SoLuongHocVien = khoaHoc.SoLuongHocVien;
                kh.DiaDiemHoc = khoaHoc.DiaDiemHoc;
                KhoaHocContext.SubmitChanges();
            }
        }

        public List<KhoaHoc> TimKiemKhoaHoc(string tuKhoa)
        {
            var query = KhoaHocContext.KhoaHocs.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(kh =>
                    kh.MaKhoaHoc.Contains(tuKhoa) ||
                    kh.TenKhoaHoc.Contains(tuKhoa) ||
                    kh.MoTa.Contains(tuKhoa) ||
                    kh.HocPhi.ToString().Contains(tuKhoa) ||
                    kh.ThoiGianBatDau.ToString().Contains(tuKhoa) ||
                    kh.ThoiGianKetThuc.ToString().Contains(tuKhoa) ||
                    kh.SoLuongHocVien.ToString().Contains(tuKhoa) ||
                    kh.DiaDiemHoc.Contains(tuKhoa) 
                   
                );
            }

            return query.ToList();
        }
        public Tuple<DateTime?, DateTime?> LayThoiGianKhoaHoc(string maKhoaHoc)
        {
            var khoaHoc = KhoaHocContext.KhoaHocs
                .FirstOrDefault(kh => kh.MaKhoaHoc == maKhoaHoc);

            if (khoaHoc != null)
            {
                return new Tuple<DateTime?, DateTime?>(khoaHoc.ThoiGianBatDau, khoaHoc.ThoiGianKetThuc);
            }

            return null;
        }
    }
}
