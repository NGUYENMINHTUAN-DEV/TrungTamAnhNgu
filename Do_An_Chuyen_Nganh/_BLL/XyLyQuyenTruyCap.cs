using System;
using System.Collections.Generic;
using System.Linq;

namespace _BLL
{
    public class XuLyQuyenTruyCap
    {
        private AnhNguDataContext QuyenTruyCapContext = new AnhNguDataContext();

        public XuLyQuyenTruyCap()
        {
        }

        public List<QuyenTruyCap> GetQuyenTruyCap()
        {
            return QuyenTruyCapContext.QuyenTruyCaps.Select(qtc => qtc).ToList();
        }

        public void ThemQuyenTruyCap(QuyenTruyCap quyenTruyCap)
        {
            QuyenTruyCapContext.QuyenTruyCaps.InsertOnSubmit(quyenTruyCap);
            QuyenTruyCapContext.SubmitChanges();
        }

        public void SuaQuyenTruyCap(QuyenTruyCap quyenTruyCap)
        {
            QuyenTruyCap qtc = QuyenTruyCapContext.QuyenTruyCaps.SingleOrDefault(q => q.MaQuyenTruyCap == quyenTruyCap.MaQuyenTruyCap);
            if (qtc != null)
            {
                qtc.TenQuyenTruyCap = quyenTruyCap.TenQuyenTruyCap;
                QuyenTruyCapContext.SubmitChanges();
            }
        }

        public void XoaQuyenTruyCap(string maQuyenTruyCap)
        {
            var quyenTruyCapToRemove = QuyenTruyCapContext.QuyenTruyCaps.FirstOrDefault(qtc => qtc.MaQuyenTruyCap == maQuyenTruyCap);

            if (quyenTruyCapToRemove != null)
            {
                QuyenTruyCapContext.QuyenTruyCaps.DeleteOnSubmit(quyenTruyCapToRemove);
                QuyenTruyCapContext.SubmitChanges();
            }
        }

        public List<QuyenTruyCap> TimKiemQuyenTruyCap(string tuKhoa)
        {
            var query = QuyenTruyCapContext.QuyenTruyCaps.AsQueryable();

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                query = query.Where(qtc =>
                    qtc.MaQuyenTruyCap.Contains(tuKhoa) ||
                    qtc.TenQuyenTruyCap.Contains(tuKhoa)
                );
            }

            return query.ToList();
        }
    }
}
