using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public  class XuLyThongKe
    {
        private AnhNguDataContext thongke = new AnhNguDataContext();

        public Dictionary<string, int> ThongKeHocVienTheoKhoaHoc()
        {
            var query = from dangKy in thongke.DangKyKhoaHoc_KhoaHocs
                        join khoaHoc in thongke.KhoaHocs on dangKy.MaKhoaHoc equals khoaHoc.MaKhoaHoc
                        group dangKy by khoaHoc.TenKhoaHoc into g
                        select new { KhoaHoc = g.Key, SoLuong = g.Count() };

            return query.ToDictionary(item => item.KhoaHoc, item => item.SoLuong);
        }

        public double LayTongDoanhThu()
        {
            double? tongDoanhThu = thongke.PhieuThus.Sum(pt => pt.TongTien);
            return tongDoanhThu ?? 0;

        }
        public Dictionary<string, int> ThongKeKetQuaCuoiKy()
        {
                var query = from diemCuoiKy in thongke.DiemThis
                            group diemCuoiKy by
                                diemCuoiKy.Diem >= 5.0 ? "Đậu" : "Rớt" into g
                            select new { KetQua = g.Key, SoLuong = g.Count() };

                return query.ToDictionary(item => item.KetQua, item => item.SoLuong);
        }
        public int LayTongSoLuongHocVienDangKy()
        {
            int tongSoLuongHocVienDangKy = thongke.DangKyKhoaHocs.Count();
            return tongSoLuongHocVienDangKy;
        }
        public Dictionary<string, int> ThongKeSoBuoiVangTrongLop()
        {
            var query = from xepLop in thongke.XepLopHocViens
                        join hocVien in thongke.HocViens on xepLop.MaHocVien equals hocVien.MaHocVien
                        join thoiKhoaBieu in thongke.ThoiKhoaBieus on xepLop.MaLopHoc equals thoiKhoaBieu.MaLopHoc
                        let diemDanhGroup = from dd in thongke.DiemDanhs
                                            where dd.MaHocVien == hocVien.MaHocVien && dd.MaLopHoc == thoiKhoaBieu.MaLopHoc && dd.NgayDiemDanh == thoiKhoaBieu.NgayHoc
                                            select dd
                        where diemDanhGroup.FirstOrDefault() == null || diemDanhGroup.First().TrangThaiDiemDanh == "Vắng"
                        group hocVien by new { hocVien.MaHocVien, hocVien.HoTen } into g
                        select new { HoTen = g.Key.HoTen, SoBuoiVang = g.Count() };

            return query.ToDictionary(item => $"{item.HoTen}", item => item.SoBuoiVang);
        }

        public Dictionary<string, int> ThongKeSoLuongLopDay()
        {
            var query = from giangVien in thongke.GiangViens
                        join thoiKhoaBieu in thongke.ThoiKhoaBieus on giangVien.MaGiangVien equals thoiKhoaBieu.MaGiangVien
                        group giangVien by giangVien.HoTen into g
                        select new { HoTen = g.Key, SoLuongLopDay = g.Count() };

            return query.ToDictionary(item => item.HoTen, item => item.SoLuongLopDay);
        }
        public Dictionary<string, double> ThongKeDoanhThuTheoKhoaHoc()
        {
            var query = from khoaHoc in thongke.KhoaHocs
                        join chiTietPhieuThu in thongke.ChiTietPhieuThus on khoaHoc.MaKhoaHoc equals chiTietPhieuThu.MaKhoaHoc
                        join phieuThu in thongke.PhieuThus on chiTietPhieuThu.MaPhieuThu equals phieuThu.MaPhieuThu
                        group new { khoaHoc, phieuThu } by khoaHoc.TenKhoaHoc into g
                        select new { KhoaHoc = g.Key, DoanhThu = g.Sum(x => x.phieuThu.TongTien) };

            return query.ToDictionary(item => item.KhoaHoc, item => item.DoanhThu ?? 0);
        }
        public Dictionary<string, int> ThongKeSoLuongHocVienTheoDoTuoi()
        {
            var query = from hocVien in thongke.HocViens
                        let tuoi = hocVien.NgaySinh.HasValue ? (DateTime.Now.Year - hocVien.NgaySinh.Value.Year) : (int?)null
                        where tuoi.HasValue
                        group hocVien by (tuoi.Value / 10) * 10 into g
                        select new { DoTuoi = $"{g.Key}-{g.Key + 9}", SoLuongHocVien = g.Count() };

            return query.ToDictionary(item => item.DoTuoi, item => item.SoLuongHocVien);
        }

    }
}
