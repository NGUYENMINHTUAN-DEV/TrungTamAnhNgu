using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public  class XuLyXemThoiKhoaBieu
    {
        private AnhNguDataContext XulyTKB = new AnhNguDataContext();

        public List<ThongTinLopHoc> LayThongTinLopHoc(string maHocVien)
        {
            var thongTinLopHocList = new List<ThongTinLopHoc>();

            var query = from xepLop in XulyTKB.XepLopHocViens
                        join tkb in XulyTKB.ThoiKhoaBieus on xepLop.MaLopHoc equals tkb.MaLopHoc
                        where xepLop.MaHocVien == maHocVien
                        select new ThongTinLopHoc
                        {
                            TenLop = GetTenLop(xepLop.MaLopHoc),
                            TenPhongHoc = GetTenPhongHoc(tkb.MaPhongHoc),
                            Thu = tkb.Thu.ToString(),
                            TietBatDau = tkb.TietBatDau ?? 0,
                            TietKetThuc = tkb.TietKetThuc ?? 0,
                            TenGiangVien = GetTenGiangVien(tkb.MaGiangVien),
                            Cahoc = tkb.CaHoc,
                            NgayHoc = tkb.NgayHoc,
                            LoaiLich = tkb.LoaiLich,
                            NgayThi = tkb.NgayThi,
                            MaToChucThi = tkb.MaToChucThi
                        };

            thongTinLopHocList = query.ToList();

            return thongTinLopHocList;
        }

        private string GetTenLop(string Malop)
        {
            var lophoc = XulyTKB.LopHocs
                .FirstOrDefault(l => l.MaLopHoc == Malop);
            return lophoc?.TenLop ?? "N/A";
        }
        private string GetTenPhongHoc(string maPhongHoc)
        {
            var phongHoc = XulyTKB.PhongHocs
                .FirstOrDefault(ph => ph.MaPhongHoc == maPhongHoc);
            return phongHoc?.TenPhongHoc ?? "N/A";
        }

        private string GetTenGiangVien(string maGiangVien)
        {
            var giangVien = XulyTKB.GiangViens
                .FirstOrDefault(gv => gv.MaGiangVien == maGiangVien);

            return giangVien?.HoTen ?? "N/A";
        }
        public List<string> GetMaGiangVien()
        {
            var taikhoan = XulyTKB.GiangViens.Select(gv => $"{gv.MaGiangVien} - {gv.HoTen}").ToList();
            return taikhoan;
        }
        public List<string> GetMaHocVien()
        {
            var taikhoan = XulyTKB.HocViens.Select(hv => $"{hv.MaHocVien} - {hv.HoTen}").ToList();
            return taikhoan;
        }
        public class ThongTinLopHoc
        {
            public string TenLop { get; set; }
            public string TenPhongHoc { get; set; }
            public string Thu { get; set; }
            public int TietBatDau { get; set; }
            public int TietKetThuc { get; set; }
            public string TenGiangVien { get; set; }
            public string Cahoc { get; set; }
            public DateTime? NgayHoc { get; set; }
            public string LoaiLich { get; set; }
            public DateTime? NgayThi { get; set; }
            public string MaToChucThi { get; set; }
        }
        public List<ThongTinLopHoc> LayLichDayCuaGiangVien(string maGiangVien)
        {
            var thongTinLopHocList = new List<ThongTinLopHoc>();

            var lopHocList = XulyTKB.ThoiKhoaBieus
                .Where(tkb => tkb.MaGiangVien == maGiangVien)
                .ToList();

            foreach (var lopHoc in lopHocList)
            {
                var thongTinLopHoc = new ThongTinLopHoc
                {
                    TenLop = GetTenLop(lopHoc.MaLopHoc),
                    TenPhongHoc = GetTenPhongHoc(lopHoc.MaPhongHoc),
                    Thu = lopHoc.Thu.ToString(),
                    TietBatDau = lopHoc.TietBatDau ?? 0,
                    TietKetThuc = lopHoc.TietKetThuc ?? 0,
                    Cahoc = lopHoc.CaHoc,
                    NgayHoc = lopHoc.NgayThi.HasValue ? (DateTime?)null : lopHoc.NgayHoc, 
                    LoaiLich = lopHoc.LoaiLich,
                    NgayThi = lopHoc.NgayHoc.HasValue ? (DateTime?)null : lopHoc.NgayThi, 
                    MaToChucThi = lopHoc.MaToChucThi
                };

                thongTinLopHocList.Add(thongTinLopHoc);
            }

            return thongTinLopHocList;
        }



        public string LayMaLopHocTheoTenLop(string tenLopHoc)
        {
            var lopHoc = XulyTKB.LopHocs.FirstOrDefault(lop => lop.TenLop == tenLopHoc);

            if (lopHoc != null)
            {
                return lopHoc.MaLopHoc;
            }
            return string.Empty;
        }
        public string LayMaPhongHocTheoTenPhong(string tenphonghoc)
        {
            
            var phonghoc = XulyTKB.PhongHocs.FirstOrDefault(lop => lop.TenPhongHoc == tenphonghoc);

            if (phonghoc != null)
            {
                return phonghoc.MaPhongHoc;
            }
            return string.Empty;
        }

    }
}

