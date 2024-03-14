using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public  class XuLyDiemDanhHocVien
    {  private AnhNguDataContext DiemDanhContext = new AnhNguDataContext();
        public class ThongTinHocVienDiemDanh
        {
            public string MaHocVien { get; set; }
            public string TenHocVien { get; set; }
            public DateTime? NgayDiemDanh { get; set; }
            public string CoDiHoc { get; set; }
            public string maphong { get; set; }
            public int? Thu { get; set; }
            public int? TietBatDau { get; set; }
            public int? TietKetThuc { get; set; }
            public string CaHoc { get; set; }
            public string LoaiLich { get; set; }
            public DateTime? Ngaythi { get; set; }
            public string MaToChuc { get; set; }

        }
        public List<ThongTinHocVienDiemDanh> LayDanhSachHocVienTheoThoiKhoaBieu(string maLopHoc, string maPhong, int thu, int tietBatDau, int tietKetThuc, string caHoc, DateTime ngayHoc, string loaiLich, DateTime ngayThi, string maToChuc)
        {
            List<ThongTinHocVienDiemDanh> danhSachHocVien = new List<ThongTinHocVienDiemDanh>();

            IQueryable<ThoiKhoaBieu> thoiKhoaBieuQuery;

            if (loaiLich == "Học")
            {
                thoiKhoaBieuQuery = DiemDanhContext.ThoiKhoaBieus
                    .Where(tkb => tkb.MaLopHoc == maLopHoc && tkb.MaPhongHoc == maPhong && tkb.Thu == thu && tkb.CaHoc == caHoc && tkb.TietBatDau >= tietBatDau && tkb.TietKetThuc <= tietKetThuc && tkb.NgayHoc.HasValue && tkb.NgayHoc.Value.Date == ngayHoc.Date && tkb.LoaiLich == "Học");
            }
            else
            {
                thoiKhoaBieuQuery = DiemDanhContext.ThoiKhoaBieus
                    .Where(tkb => tkb.MaLopHoc == maLopHoc && tkb.MaPhongHoc == maPhong && tkb.Thu == thu && tkb.CaHoc == caHoc && tkb.TietBatDau >= tietBatDau && tkb.TietKetThuc <= tietKetThuc && tkb.NgayThi.HasValue && tkb.NgayThi.Value.Date == ngayThi.Date && tkb.LoaiLich == "Thi" && tkb.MaToChucThi== maToChuc);
            }

            var thoiKhoaBieuList = thoiKhoaBieuQuery.ToList();

            foreach (var thoiKhoaBieu in thoiKhoaBieuList)
            {
                var hocVienList = DiemDanhContext.XepLopHocViens
                    .Where(qlhv => qlhv.MaLopHoc == maLopHoc)
                    .Select(qlhv => qlhv.HocVien)
                    .ToList();

                if (thoiKhoaBieu.PhongHoc == null)
                    continue;

                foreach (var hocVien in hocVienList)
                {
                    var existingStudent = danhSachHocVien.FirstOrDefault(s => s.MaHocVien == hocVien.MaHocVien);

                    if (existingStudent != null)
                    {
                        existingStudent.NgayDiemDanh = (loaiLich == "Học") ? (thoiKhoaBieu.NgayHoc?.Date ?? DateTime.MinValue) : (thoiKhoaBieu.NgayThi?.Date ?? DateTime.MinValue);
                        existingStudent.maphong = thoiKhoaBieu.PhongHoc.TenPhongHoc;
                        existingStudent.Thu = thoiKhoaBieu.Thu;
                        existingStudent.TietBatDau = thoiKhoaBieu.TietBatDau;
                        existingStudent.TietKetThuc = thoiKhoaBieu.TietKetThuc;
                        existingStudent.CaHoc = thoiKhoaBieu.CaHoc;
                        existingStudent.LoaiLich = loaiLich ?? "Học";

                        if (loaiLich == "Thi")
                        {
                            existingStudent.Ngaythi = thoiKhoaBieu.NgayThi?.Date ?? DateTime.MinValue;
                            existingStudent.MaToChuc = maToChuc;
                            existingStudent.CoDiHoc = LayTrangThaiDiemDanh(hocVien.MaHocVien, maLopHoc, ngayHoc, ngayThi);
                        }
                        else
                        {
                            existingStudent.CoDiHoc = LayTrangThaiDiemDanh(hocVien.MaHocVien, maLopHoc, ngayHoc, ngayThi);
                        }
                    }
                    else
                    {
                        var thongTinHocVien = new ThongTinHocVienDiemDanh
                        {
                            MaHocVien = hocVien.MaHocVien,
                            TenHocVien = hocVien.HoTen,
                            NgayDiemDanh = (loaiLich == "Học") ? thoiKhoaBieu.NgayHoc?.Date ?? DateTime.MinValue : DateTime.MinValue,
                            maphong = thoiKhoaBieu.PhongHoc.TenPhongHoc,
                            Thu = thoiKhoaBieu.Thu,
                            TietBatDau = thoiKhoaBieu.TietBatDau,
                            TietKetThuc = thoiKhoaBieu.TietKetThuc,
                            CaHoc = thoiKhoaBieu.CaHoc,
                            LoaiLich = loaiLich ?? "Học",
                            Ngaythi = (loaiLich == "Thi") ? thoiKhoaBieu.NgayThi?.Date ?? DateTime.MinValue : DateTime.MinValue,
                            MaToChuc = (loaiLich == "Thi") ? maToChuc : null,
                            CoDiHoc = LayTrangThaiDiemDanh(hocVien.MaHocVien, maLopHoc, ngayHoc, ngayThi)
                        };

                        danhSachHocVien.Add(thongTinHocVien);
                    }
                }
            }
            danhSachHocVien = danhSachHocVien.OrderBy(hv => hv.MaHocVien).ToList();

            return danhSachHocVien;
        }

        public string LayTrangThaiDiemDanh(string maHocVien, string maLopHoc, DateTime? ngayHoc, DateTime? ngayThi)
        {
            var ngayDanhGia = (ngayThi == null) ? ngayHoc : ngayThi;

            var diemDanhHocVien = DiemDanhContext.DiemDanhs
                .FirstOrDefault(dd => (dd.MaHocVien == maHocVien && dd.MaLopHoc == maLopHoc && ngayDanhGia != null && dd.NgayDiemDanh == ngayDanhGia));

            if (diemDanhHocVien != null)
            {
                return diemDanhHocVien.TrangThaiDiemDanh;
            }

            return "Đã điểm danh";
        }
        public string GenerateIDDiemDanh()
        {
            string prefix = "IDDN";
            string randomSuffix = Guid.NewGuid().ToString("N").Substring(0, 4);
            string generatedID = $"{prefix}_{randomSuffix}";

            return generatedID;
        }
        public void CapNhatTrangThaiDiemDanh(string maHocVien, string maLopHoc, DateTime ngayHoc, string coDiHoc)
        {
           
            var thoiKhoaBieu = DiemDanhContext.ThoiKhoaBieus
                .FirstOrDefault(tkb => tkb.MaLopHoc == maLopHoc
                                        && ((tkb.NgayHoc == ngayHoc && tkb.LoaiLich == "Học")
                                            || (tkb.NgayThi == ngayHoc && tkb.LoaiLich == "Thi")));
            if (thoiKhoaBieu != null)
            {
                var diemDanh = DiemDanhContext.DiemDanhs
                    .FirstOrDefault(dd => dd.MaHocVien == maHocVien
                                            && dd.MaLopHoc == maLopHoc
                                            && dd.NgayDiemDanh == ngayHoc);

                if (diemDanh != null)
                {
                    diemDanh.TrangThaiDiemDanh = coDiHoc;
                }
                else
                {
                    diemDanh = new DiemDanh
                    {
                        IDDiemDanh = GenerateIDDiemDanh(),
                        MaHocVien = maHocVien,
                        MaLopHoc = maLopHoc,
                        NgayDiemDanh = (thoiKhoaBieu.LoaiLich == "Học") ? thoiKhoaBieu.NgayHoc : thoiKhoaBieu.NgayThi,
                        TrangThaiDiemDanh = coDiHoc
                    };

                    DiemDanhContext.DiemDanhs.InsertOnSubmit(diemDanh);
                }

                DiemDanhContext.SubmitChanges();
            }
        }







    }

}

