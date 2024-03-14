using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public  class XyLyPhieuThu
    {
        private AnhNguDataContext PhieuThuContext = new AnhNguDataContext();

        public XyLyPhieuThu()
        {
        }
        public class PhieuTHuModel
        {
            public string mapheiu { get; set; }
            public string tenhocvine { get; set; }
            public string trangthai { get; set; }
            public string tennv { get; set; }
            public DateTime ngaylap { get; set; }
            public double tongtien { get; set; }
        }

        public List<PhieuTHuModel> Getphieuthu()
        {
            return PhieuThuContext.PhieuThus
                .Select(pt => new PhieuTHuModel
                {
                    mapheiu = pt.MaPhieuThu,
                    tenhocvine = pt.HocVien.HoTen,
                    trangthai = pt.TrangThai,
                    tennv = pt.NhanVien.HoTen,
                    ngaylap = (DateTime)pt.NgayLap,
                    tongtien = (double)pt.TongTien,
                })
                .ToList();
        }
        public List<string> GetMaNhanVien()
        {
            var nhanvien = PhieuThuContext.NhanViens.Select(nv => $"{nv.MaNhanVien} - {nv.HoTen}").ToList();
            return nhanvien;
        }

        public void ThemPhieuThu(PhieuThu phieuThu)
        {
            PhieuThuContext.PhieuThus.InsertOnSubmit(phieuThu);
            PhieuThuContext.SubmitChanges();
        }

        public void SuaPhieuThu(PhieuThu phieuThu)
        {
            PhieuThu existingPhieuThu = PhieuThuContext.PhieuThus.SingleOrDefault(pt => pt.MaPhieuThu == phieuThu.MaPhieuThu);
            if (existingPhieuThu != null)
            {
                existingPhieuThu.MaHocVien = phieuThu.MaHocVien;
                existingPhieuThu.NgayLap = phieuThu.NgayLap;
                existingPhieuThu.TongTien = phieuThu.TongTien;
                existingPhieuThu.MaNhanVien = phieuThu.MaNhanVien;
                existingPhieuThu.TrangThai = phieuThu.TrangThai;
                PhieuThuContext.SubmitChanges();
            }
        }

        public void XoaPhieuThu(string maPhieuThu)
        {
            var phieuThuToRemove = PhieuThuContext.PhieuThus.SingleOrDefault(pt => pt.MaPhieuThu == maPhieuThu);
            if (phieuThuToRemove != null)
            {
                PhieuThuContext.PhieuThus.DeleteOnSubmit(phieuThuToRemove);
                PhieuThuContext.SubmitChanges();
            }
        }

        public List<PhieuThu> TimKiemPhieuThu(string tuKhoa)
        {
            var query = PhieuThuContext.PhieuThus.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(pt =>
                    pt.MaPhieuThu.Contains(tuKhoa) ||
                    pt.MaHocVien.Contains(tuKhoa) ||
                    pt.NgayLap.ToString().Contains(tuKhoa) ||
                    pt.TongTien.ToString().Contains(tuKhoa) ||
                    pt.MaNhanVien.Contains(tuKhoa) ||
                    pt.TrangThai.Contains(tuKhoa)
                );
            }

            return query.ToList();
        }
        public void CapNhatTrangThaiDaThanhToan(string maPhieuThu)
        {
            PhieuThu phieuThuCanCapNhat = PhieuThuContext.PhieuThus.FirstOrDefault(pt => pt.MaPhieuThu == maPhieuThu);
            if (phieuThuCanCapNhat != null)
            {
                phieuThuCanCapNhat.TrangThai = "Đã thanh toán";
                PhieuThuContext.SubmitChanges();
            }
        }
        public string TenKhoaHocDaDangKy(string maPhieuThu)
        {
            var query = from kh in PhieuThuContext.KhoaHocs
                        join dkkh in PhieuThuContext.DangKyKhoaHoc_KhoaHocs on kh.MaKhoaHoc equals dkkh.MaKhoaHoc
                        join dk in PhieuThuContext.DangKyKhoaHocs on dkkh.MaDangKy equals dk.MaDangKy
                        join pt in PhieuThuContext.PhieuThus on dk.MaHocVien equals pt.MaHocVien
                        where pt.MaPhieuThu == maPhieuThu
                        select kh.TenKhoaHoc;
            List<string> tenKhoaHocList = query.ToList();
            string tenKhoaHoc = string.Join(Environment.NewLine, tenKhoaHocList);
            return tenKhoaHoc;
        }
    }
}

