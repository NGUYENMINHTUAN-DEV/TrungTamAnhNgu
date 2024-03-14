using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace _BLL
    {
        public class XuLyPhatTaiLieu
        {
            AnhNguDataContext PhatTaiLieuContext = new AnhNguDataContext();

            public XuLyPhatTaiLieu()
            {
            }
            public class PhatTaiLieuA
            {
                public string IDPhatTaiLieu { get; set; }
                public string TenHocVien { get; set; }
                public string MaTaiLieu { get; set; }
                public DateTime NgayPhatTaiLieu { get; set; }
                public int SoLuongPhat { get; set; }
            }
            public List<PhatTaiLieuA> GetPhatTaiLieu()
            {
                return PhatTaiLieuContext.PhatTaiLieus
                    .Select(ptl => new PhatTaiLieuA
                    {
                        IDPhatTaiLieu = ptl.IDPhatTaiLieu,
                        TenHocVien = ptl.HocVien.HoTen, // Sửa thành tên của học viên thay vì mã học viên
                        MaTaiLieu = ptl.MaTaiLieu,
                        NgayPhatTaiLieu = (DateTime)ptl.NgayPhatTaiLieu,
                        SoLuongPhat = (int)ptl.SoLuongPhat
                    })
                    .ToList();
            }

            public List<string> GetMaTaiLieu()
            {
                var tailieu = PhatTaiLieuContext.TaiLieus.Select(tl => $"{tl.MaTaiLieu} - {tl.TenTaiLieu}").ToList();
                return tailieu;
            }
            public List<string> GetMaHocVien()
            {
                var hocvien = PhatTaiLieuContext.HocViens.Select(hv => $"{hv.MaHocVien} - {hv.HoTen}").ToList();
                return hocvien;
            }
            public void PhatTaiLieu(PhatTaiLieu phatTaiLieu)
            {
                PhatTaiLieuContext.PhatTaiLieus.InsertOnSubmit(phatTaiLieu);
                PhatTaiLieuContext.SubmitChanges();
            }
            public void SuaTaiLieu(PhatTaiLieu phatTaiLieu)
            {
                PhatTaiLieu ptl = PhatTaiLieuContext.PhatTaiLieus.SingleOrDefault(t => t.IDPhatTaiLieu == phatTaiLieu.IDPhatTaiLieu);
                if (ptl != null)
                {
                    ptl.MaHocVien = phatTaiLieu.MaHocVien;
                    ptl.MaTaiLieu = phatTaiLieu.MaTaiLieu;
                    ptl.NgayPhatTaiLieu = phatTaiLieu.NgayPhatTaiLieu;
                    PhatTaiLieuContext.SubmitChanges();
                }
            }
            public void XoaPhatTaiLieu(string idPhatTaiLieu)
            {
                var phatTaiLieuToRemove = PhatTaiLieuContext.PhatTaiLieus.FirstOrDefault(ptl => ptl.IDPhatTaiLieu == idPhatTaiLieu);

                if (phatTaiLieuToRemove != null)
                {
                    PhatTaiLieuContext.PhatTaiLieus.DeleteOnSubmit(phatTaiLieuToRemove);
                    PhatTaiLieuContext.SubmitChanges();
                }
            }

            public List<PhatTaiLieu> TimKiemPhatTaiLieu(string tuKhoa)
            {
                var query = PhatTaiLieuContext.PhatTaiLieus.AsQueryable();

                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    query = query.Where(ptl =>
                        ptl.IDPhatTaiLieu.Contains(tuKhoa) ||
                        ptl.MaHocVien.Contains(tuKhoa) ||
                        ptl.MaTaiLieu.Contains(tuKhoa) ||
                        ptl.NgayPhatTaiLieu.ToString().Contains(tuKhoa)
                    );
                }

                return query.ToList();
            }
        }
    }

}
