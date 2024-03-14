using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{ 
    public  class XuLyToChucThi
    {
        AnhNguDataContext XulyToChucThi = new AnhNguDataContext();
        public void ThemToChucThi(ToChucThi tochucthi)
        {
            XulyToChucThi.ToChucThis.InsertOnSubmit(tochucthi);
            XulyToChucThi.SubmitChanges();
        }
        public List<ToChucThi> GetToChucThi()
        {
            return XulyToChucThi.ToChucThis.Select(tc => tc).ToList<ToChucThi>();
        }
        public void XoaToChucThi(string matc)
        {
            var Tochucremove = XulyToChucThi.ToChucThis.FirstOrDefault(tc => tc.MaToChucThi == matc);

            if (Tochucremove != null)
            {
                XulyToChucThi.ToChucThis.DeleteOnSubmit(Tochucremove);
                XulyToChucThi.SubmitChanges();
            }
        }
        public void SuaToChucThi(ToChucThi tc)
        {
            ToChucThi tochuc = XulyToChucThi.ToChucThis.SingleOrDefault(l => l.MaToChucThi == tc.MaToChucThi);
            if (tochuc != null)
            {
                tochuc.MaToChucThi = tc.MaToChucThi;
                tochuc.TenToChucThi = tc.TenToChucThi;
                XulyToChucThi.SubmitChanges();
            }
        }


    }
}
