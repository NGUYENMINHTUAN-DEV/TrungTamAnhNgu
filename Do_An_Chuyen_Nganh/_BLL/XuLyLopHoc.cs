using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace _BLL
{
    public class XyLyLopHoc
    {
        private AnhNguDataContext LopHocContext = new AnhNguDataContext();
        public class LopHocViewModel
        {
            public string MaLopHoc { get; set; }
            public string TenLop { get; set; }
            public string TenKhoaHoc { get; set; }
        
            public DateTime NgayBatDau { get; set; }
            public DateTime NgayKetThuc { get; set; }
            public int SoLuongHocVienHienTai { get; set; }
            public int SoLuongHocVienToiDa { get; set; }
          
        }

        public List<LopHocViewModel> LayDanhSachLopHoc()
        {
            return LopHocContext.LopHocs
                .Join(LopHocContext.KhoaHocs, lh => lh.MaKhoaHoc, kh => kh.MaKhoaHoc, (lh, kh) => new LopHocViewModel
                {
                    MaLopHoc = lh.MaLopHoc,
                    TenLop = lh.TenLop,
                    TenKhoaHoc = kh.TenKhoaHoc,
                    NgayBatDau = (DateTime)lh.NgayBatDau,
                    NgayKetThuc = (DateTime)lh.NgayKetThuc,
                    SoLuongHocVienHienTai = (int)lh.SoLuongHocVienHienTai,
                    SoLuongHocVienToiDa = (int)lh.SoLuongHocVienToiDa,
                   
                })
                .ToList();
        }
      

        public void ThemLopHoc(LopHoc lopHoc)
        {
            LopHocContext.LopHocs.InsertOnSubmit(lopHoc);
            LopHocContext.SubmitChanges();
        }
        public List<string> GetMaKhoaHoc()
        {
            var khoahoc = LopHocContext.KhoaHocs.Select(kh => $"{kh.MaKhoaHoc} - {kh.TenKhoaHoc}").ToList();
            return khoahoc;
        }
        public void XoaLopHoc(string maLopHoc)
        {
            var lopHocToRemove = LopHocContext.LopHocs.FirstOrDefault(lh => lh.MaLopHoc == maLopHoc);

            if (lopHocToRemove != null)
            {
                LopHocContext.LopHocs.DeleteOnSubmit(lopHocToRemove);
                LopHocContext.SubmitChanges();
            }
        }

        public void SuaLopHoc(LopHoc lopHoc)
        {
            LopHoc lh = LopHocContext.LopHocs.SingleOrDefault(l => l.MaLopHoc == lopHoc.MaLopHoc);
            if (lh != null)
            {
                lh.TenLop = lopHoc.TenLop;
                lh.MaKhoaHoc = lopHoc.MaKhoaHoc;
                lh.NgayBatDau = lopHoc.NgayBatDau;
                lh.NgayKetThuc = lopHoc.NgayKetThuc;
                lh.SoLuongHocVienToiDa = lopHoc.SoLuongHocVienToiDa;
                lh.SoLuongHocVienHienTai = lopHoc.SoLuongHocVienHienTai;
                LopHocContext.SubmitChanges();
            }
        }

        public List<LopHoc> TimKiemLopHoc(string tuKhoa)
        {
            var query = LopHocContext.LopHocs.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(lh =>
                    lh.MaLopHoc.Contains(tuKhoa) ||
                    lh.TenLop.Contains(tuKhoa) ||
                    lh.MaKhoaHoc.Contains(tuKhoa) ||
                    lh.NgayBatDau.ToString().Contains(tuKhoa) ||
                    lh.NgayKetThuc.ToString().Contains(tuKhoa) ||
                    lh.SoLuongHocVienToiDa.ToString().Contains(tuKhoa)||
                       lh.SoLuongHocVienHienTai.ToString().Contains(tuKhoa) 
                );
            }

            return query.ToList();
        }
    }
}
