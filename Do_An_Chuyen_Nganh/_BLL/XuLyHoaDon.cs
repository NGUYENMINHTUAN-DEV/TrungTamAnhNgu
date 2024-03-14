using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public class XuLyHoaDon
    {
        AnhNguDataContext ctx = new AnhNguDataContext();
        public string MaHocVien { get; set; }
        public string HoTenHV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string MaNhanVien { get; set; }
        public string HoTenNhanVien { get; set; }
        public string MaDangKy { get; set; }
        public string MaKhoaHoc { get; set; }
        public string TenKhoaHoc { get; set; }
        public double HocPhi { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string DiaDiemHoc { get; set; }
        public string MaPhieuThu { get; set; }
        public DateTime NgayLap { get; set; }
        public double TongTien { get; set; }
        public string HinhThucThanhToan { get; set; }
        public DateTime NgayDangKy { get; set; }

        


    }
}
