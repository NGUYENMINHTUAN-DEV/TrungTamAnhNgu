using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public class XuLyDiemSo
    {
        AnhNguDataContext DiemSocontext = new AnhNguDataContext();
        public XuLyDiemSo()
        {

        }
        public List<LopHoc> GetDanhSachLopHoc(string maKhoaHoc)
        {
            using (var context = new AnhNguDataContext())
            {
                var danhSachLopHoc = from lop in context.LopHocs
                                     where lop.MaKhoaHoc == maKhoaHoc
                                     select lop;

                return danhSachLopHoc.ToList();
            }
        }
        public List<DiemThiInfo> GetDiemThiByMaLop(string maLopHoc)
        {
            using (var context = new AnhNguDataContext())
            {
                var result = from hocVien in context.HocViens
                             join xepLop in context.XepLopHocViens on hocVien.MaHocVien equals xepLop.MaHocVien
                             join lopHoc in context.LopHocs on xepLop.MaLopHoc equals lopHoc.MaLopHoc
                             join thoiKhoaBieu in context.ThoiKhoaBieus on lopHoc.MaLopHoc equals thoiKhoaBieu.MaLopHoc into tkb
                             from thoiKhoaBieu in tkb.DefaultIfEmpty()
                             join diemThi in context.DiemThis on new { MaHocVien = hocVien.MaHocVien, MaToChucThi = thoiKhoaBieu.MaToChucThi } equals new { MaHocVien = diemThi.MaHocVien, MaToChucThi = diemThi.MaToChucThi } into dt
                             from diemThi in dt.DefaultIfEmpty()
                             join toChucThi in context.ToChucThis on thoiKhoaBieu.MaToChucThi equals toChucThi.MaToChucThi into tct
                             from toChucThi in tct.DefaultIfEmpty()
                             where lopHoc.MaLopHoc == maLopHoc && (thoiKhoaBieu == null || thoiKhoaBieu.LoaiLich == "Thi")
                             select new DiemThiInfo
                             {
                                 MaHocVien = hocVien.MaHocVien,
                                 HoTen = hocVien.HoTen,
                                 DiemThi = diemThi != null ? diemThi.Diem : null,
                                 NgayThi = thoiKhoaBieu != null ? thoiKhoaBieu.NgayThi : null,
                                 TenToChucThi = toChucThi != null ? toChucThi.TenToChucThi : null
                             };

                return result.ToList();
            }
        }
        public class DiemThiInfoCSV
        {
            public string MaHocVien { get; set; }
            public string HoTen { get; set; }
            public double? DiemThi { get; set; }
            public DateTime? NgayThi { get; set; }
            public string MaLopHoc { get; set; }
        }
        public class DiemThiInfo
        {
            public string MaHocVien { get; set; }
            public string HoTen { get; set; }
            public double? DiemThi { get; set; }
            public DateTime? NgayThi { get; set; }
            public string TenToChucThi { get; set; } 
        }

        public List<string> GetMaLop()
        {
            return DiemSocontext.LopHocs.Select((LopHoc l) => $"{l.MaLopHoc} - {l.TenLop}").ToList();
        }
        public List<string> GetMaKhoa()
        {
            return DiemSocontext.KhoaHocs.Select((KhoaHoc k) => $"{k.MaKhoaHoc} - {k.TenKhoaHoc}").ToList();
        }


        public void LuuDiemThi(DiemThi diemThiEntity)
        {
            using (var context = new AnhNguDataContext())
            {
                var existingDiemThi = context.DiemThis.SingleOrDefault(dt => dt.MaHocVien == diemThiEntity.MaHocVien && dt.MaToChucThi == diemThiEntity.MaToChucThi);

                if (existingDiemThi != null)
                {
                    existingDiemThi.Diem = diemThiEntity.Diem;
                }
                else
                {
                    context.DiemThis.InsertOnSubmit(diemThiEntity);
                }
                context.SubmitChanges();
            }
        }


        public void CapNhatDiemThiTrongBangDiem(string maToChuc, string maHocVien, float? diem)
        {
            using (var context = new AnhNguDataContext())
            {
                var diemThi = context.DiemThis
                    .Where(dt => dt.MaHocVien == maHocVien)
                    .FirstOrDefault();

                if (diemThi != null)
                {
                    diemThi.Diem = diem;
                    diemThi.MaToChucThi = maToChuc;
                    context.SubmitChanges();
                }
            }
        }
    }
}
