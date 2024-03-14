using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public class XyLyDiemDanh
    {
        private AnhNguDataContext DiemDanhContext = new AnhNguDataContext();
        public class DiemDanhViewModel
        {
            public string IDDiemDanh { get; set; }
            public string TenHocVien { get; set; }
            public string TenLopHoc { get; set; }
            public DateTime NgayDiemDanh { get; set; }
            public string TrangThaiDiemDanh { get; set; }
           
        }

        public List<DiemDanhViewModel> GetDiemDanh()
        {
            return DiemDanhContext.DiemDanhs
                .Join(DiemDanhContext.HocViens, dd => dd.MaHocVien, hv => hv.MaHocVien, (dd, hv) => new { dd, hv })
                .Join(DiemDanhContext.LopHocs, j => j.dd.MaLopHoc, lh => lh.MaLopHoc, (j, lh) => new DiemDanhViewModel
                {
                    IDDiemDanh = j.dd.IDDiemDanh,
                    TenHocVien = j.hv.HoTen,
                    TenLopHoc = lh.TenLop,
                    NgayDiemDanh = (DateTime)j.dd.NgayDiemDanh,
                    TrangThaiDiemDanh = j.dd.TrangThaiDiemDanh,
                })
                .ToList();
        }

        public List<string> GetMaHocVien()
        {
            var hocvien = DiemDanhContext.HocViens.Select(hv => $"{hv.MaHocVien} - {hv.HoTen}").ToList();
            return hocvien;
        }
        public List<string> GetMaLop()
        {
            var lophoc = DiemDanhContext.LopHocs.Select(lop => $"{lop.MaLopHoc} - {lop.TenLop}").ToList();
            return lophoc;
        }
        public List<string> GetMaKhoaHoc()
        {
            var khoahoc = DiemDanhContext.KhoaHocs.Select(kh => $"{kh.MaKhoaHoc} - {kh.TenKhoaHoc}").ToList();
            return khoahoc;
        }
        public void ThemDiemDanh(DiemDanh diemDanh)
        {
            DiemDanhContext.DiemDanhs.InsertOnSubmit(diemDanh);
            DiemDanhContext.SubmitChanges();
        }

        public void XoaDiemDanh(string idDiemDanh)
        {
            var diemDanhToRemove = DiemDanhContext.DiemDanhs.FirstOrDefault(dd => dd.IDDiemDanh == idDiemDanh);

            if (diemDanhToRemove != null)
            {
                DiemDanhContext.DiemDanhs.DeleteOnSubmit(diemDanhToRemove);
                DiemDanhContext.SubmitChanges();
            }
        }

        public void SuaDiemDanh(DiemDanh diemDanh)
        {
            DiemDanh dd = DiemDanhContext.DiemDanhs.SingleOrDefault(d => d.IDDiemDanh == diemDanh.IDDiemDanh);
            if (dd != null)
            {
                dd.MaHocVien = diemDanh.MaHocVien;
                dd.MaLopHoc = diemDanh.MaLopHoc;
                dd.NgayDiemDanh = diemDanh.NgayDiemDanh;
                dd.TrangThaiDiemDanh = diemDanh.TrangThaiDiemDanh;
                DiemDanhContext.SubmitChanges();
            }
        }

        public List<DiemDanh> TimKiemDiemDanh(string tuKhoa)
        {
            var query = DiemDanhContext.DiemDanhs.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(dd =>
                    dd.IDDiemDanh.Contains(tuKhoa) ||
                    dd.MaHocVien.Contains(tuKhoa) ||
                    dd.MaLopHoc.Contains(tuKhoa) ||
                    dd.NgayDiemDanh.ToString().Contains(tuKhoa) ||
                    dd.TrangThaiDiemDanh.Contains(tuKhoa)
                );
            }

            return query.ToList();
        }

        public void DiemDanhNhieuHocVien(string maLopHoc, string maKhoaHoc, DateTime ngayDiemDanh, List<string> maHocViens)
        {
            foreach (var maHocVien in maHocViens)
            {
                DiemDanh diemDanh = new DiemDanh
                {
                    MaHocVien = maHocVien,
                    MaLopHoc = maLopHoc,
                    NgayDiemDanh = ngayDiemDanh,
                    TrangThaiDiemDanh = "Đã điểm danh"
                };

                ThemDiemDanh(diemDanh);
            }
        }

        public void LuuTrangThaiDiemDanh(string maHocVien, string maLopHoc, DateTime ngayDiemDanh, string coDiHoc)
        {
            var diemDanh = DiemDanhContext.DiemDanhs
                .FirstOrDefault(dd => dd.MaHocVien == maHocVien && dd.MaLopHoc == maLopHoc && dd.NgayDiemDanh == ngayDiemDanh);

            if (diemDanh != null)
            {
                diemDanh.TrangThaiDiemDanh = coDiHoc;
            }
            else
            {
                diemDanh = new DiemDanh
                {
                    MaHocVien = maHocVien,
                    MaLopHoc = maLopHoc,
                    NgayDiemDanh = ngayDiemDanh,
                    TrangThaiDiemDanh = coDiHoc
                };

                DiemDanhContext.DiemDanhs.InsertOnSubmit(diemDanh);
            }

            DiemDanhContext.SubmitChanges();
        }
    }
}
