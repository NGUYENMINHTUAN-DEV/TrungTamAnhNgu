using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _BLL
{
    public class XyLyPhongHoc
    {
        private AnhNguDataContext PhongHocContext = new AnhNguDataContext();

        public XyLyPhongHoc()
        {
        }

        public List<PhongHoc> LayDanhSachPhongHoc()
        {
            return PhongHocContext.PhongHocs.Select(ph => ph).ToList();
        }

        public void ThemPhongHoc(PhongHoc phongHoc)
        {
            PhongHocContext.PhongHocs.InsertOnSubmit(phongHoc);
            PhongHocContext.SubmitChanges();
        }

        public void SuaPhongHoc(PhongHoc phongHoc)
        {
            PhongHoc existingPhongHoc = PhongHocContext.PhongHocs.SingleOrDefault(ph => ph.MaPhongHoc == phongHoc.MaPhongHoc);
            if (existingPhongHoc != null)
            {
                existingPhongHoc.TenPhongHoc = phongHoc.TenPhongHoc;
                existingPhongHoc.SoLuongToiDa = phongHoc.SoLuongToiDa;
                existingPhongHoc.SoLuongDaDangKy = phongHoc.SoLuongDaDangKy;
                PhongHocContext.SubmitChanges();
            }
        }

        public void XoaPhongHoc(string maPhongHoc)
        {
            var phongHocToRemove = PhongHocContext.PhongHocs.SingleOrDefault(ph => ph.MaPhongHoc == maPhongHoc);
            if (phongHocToRemove != null)
            {
                PhongHocContext.PhongHocs.DeleteOnSubmit(phongHocToRemove);
                PhongHocContext.SubmitChanges();
            }
        }

        public List<PhongHoc> TimKiemPhongHoc(string tuKhoa)
        {
            var query = PhongHocContext.PhongHocs.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(ph =>
                    ph.MaPhongHoc.Contains(tuKhoa) ||
                    ph.TenPhongHoc.Contains(tuKhoa) ||
                    ph.SoLuongToiDa.ToString().Contains(tuKhoa) ||
                    ph.SoLuongDaDangKy.ToString().Contains(tuKhoa) 
                );
            }

            return query.ToList();
        }
    }
}
