using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace _BLL
{
    public class XyLyThoiKhoaBieu
    {
        private AnhNguDataContext ThoiKhoaBieuContext = new AnhNguDataContext();
        public class ThoiKhoaBieuViewModel
        {
            public string MaThoiKhoaBieu { get; set; }
            public string TenGiangVien { get; set; }
            public string TenPhongHoc { get; set; }
            public string TenLop { get; set; }
            public int? Thu { get; set; }
            public int? TietBatDau { get; set; }
            public int? TietKetThuc { get; set; }
            public string DiaDiem { get; set; }
            public string CaHoc { get; set; }
            public DateTime? NgayHoc { get; set; }
            public string LoaiLich { get; set; }
            public DateTime? NgayThi { get; set; }
            public string MaToChucThi { get; set; }
        }
        public List<ThoiKhoaBieuViewModel> GetThoiKhoaBieu()
        {
            return ThoiKhoaBieuContext.ThoiKhoaBieus
                .Select(tkb => new ThoiKhoaBieuViewModel
                {
                    MaThoiKhoaBieu = tkb.IDThoiKhoaBieu,
                    TenGiangVien = tkb.GiangVien.HoTen,
                    TenPhongHoc = tkb.PhongHoc.TenPhongHoc,
                    TenLop = tkb.LopHoc.TenLop,
                    Thu = tkb.Thu,
                    TietBatDau = tkb.TietBatDau,
                    TietKetThuc = tkb.TietKetThuc,
                    DiaDiem = tkb.DiaDiem,
                    CaHoc = tkb.CaHoc,
                    NgayHoc = tkb.NgayHoc,
                    LoaiLich = tkb.LoaiLich,
                    NgayThi = tkb.NgayThi,
                    MaToChucThi = tkb.MaToChucThi,
                })
                .ToList();
        }
        public List<string> GetMaHocVien()
        {
            return ThoiKhoaBieuContext.HocViens.Select((HocVien hv) => $"{hv.MaHocVien} - {hv.HoTen}").ToList();
        }

        public List<string> GetMaGiangVien()
        {
            return ThoiKhoaBieuContext.GiangViens.Select((GiangVien gv) => $"{gv.MaGiangVien} - {gv.HoTen}").ToList();
        }

        public List<string> GetMaPhong()
        {
            return ThoiKhoaBieuContext.PhongHocs.Select((PhongHoc ph) => $"{ph.MaPhongHoc} - {ph.TenPhongHoc}").ToList();
        }

        public List<string> GetMaLop()
        {
            return ThoiKhoaBieuContext.LopHocs.Select((LopHoc l) => $"{l.MaLopHoc} - {l.TenLop}").ToList();
        }
        public List<string> GetMaToChucThi()
        {
            return ThoiKhoaBieuContext.ToChucThis.Select((ToChucThi tc) => $"{tc.MaToChucThi} - {tc.TenToChucThi}").ToList();
        }
        public string GenerateRandomID(string prefix)
        {
            string guid = Guid.NewGuid().ToString();
            string randomPart = guid.Substring(guid.Length - 4);
            string newID = $"{prefix}{randomPart}";
            return newID;
        }
        public void ThemThoiKhoaBieu(ThoiKhoaBieu thoiKhoaBieu)
        {
            ThoiKhoaBieuContext.ThoiKhoaBieus.InsertOnSubmit(thoiKhoaBieu);
            ThoiKhoaBieuContext.SubmitChanges();
        }
        public string GetLastInsertedID()
        {
            var lastRecord = ThoiKhoaBieuContext.ThoiKhoaBieus.OrderByDescending(tkb => tkb.IDThoiKhoaBieu).FirstOrDefault();
            return lastRecord?.IDThoiKhoaBieu;
        }
        public void XoaThoiKhoaBieu(string idThoiKhoaBieu)
        {
            ThoiKhoaBieu thoiKhoaBieu = ThoiKhoaBieuContext.ThoiKhoaBieus.FirstOrDefault((ThoiKhoaBieu tkb) => tkb.IDThoiKhoaBieu == idThoiKhoaBieu);
            if (thoiKhoaBieu != null)
            {
                ThoiKhoaBieuContext.ThoiKhoaBieus.DeleteOnSubmit(thoiKhoaBieu);
                ThoiKhoaBieuContext.SubmitChanges();
            }
        }
        public void SuaThoiKhoaBieu(string idThoiKhoaBieu, ThoiKhoaBieu thoiKhoaBieu)
        {
            ThoiKhoaBieu thoiKhoaBieu2 = ThoiKhoaBieuContext.ThoiKhoaBieus.SingleOrDefault(t => t.IDThoiKhoaBieu == idThoiKhoaBieu);
                thoiKhoaBieu2.MaGiangVien = thoiKhoaBieu.MaGiangVien;
                thoiKhoaBieu2.MaPhongHoc = thoiKhoaBieu.MaPhongHoc;
                thoiKhoaBieu2.MaLopHoc = thoiKhoaBieu.MaLopHoc;
                thoiKhoaBieu2.Thu = thoiKhoaBieu.Thu;
                thoiKhoaBieu2.TietBatDau = thoiKhoaBieu.TietBatDau;
                thoiKhoaBieu2.TietKetThuc = thoiKhoaBieu.TietKetThuc;
                thoiKhoaBieu2.DiaDiem = thoiKhoaBieu.DiaDiem;
                ThoiKhoaBieuContext.SubmitChanges();
            
        }
        public List<ThoiKhoaBieuViewModel> TimKiemThoiKhoaBieu(string tuKhoa)
        {
            IQueryable<ThoiKhoaBieuViewModel> source = GetThoiKhoaBieu().AsQueryable();
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                source = source.Where((ThoiKhoaBieuViewModel tkb) =>
                    tkb.MaThoiKhoaBieu.Contains(tuKhoa) ||
                    tkb.TenGiangVien.Contains(tuKhoa) ||
                    tkb.TenPhongHoc.Contains(tuKhoa) ||
                    tkb.TenLop.Contains(tuKhoa) ||
                    ((object)tkb.Thu).ToString().Contains(tuKhoa) ||
                    ((object)tkb.TietBatDau).ToString().Contains(tuKhoa) ||
                    ((object)tkb.TietKetThuc).ToString().Contains(tuKhoa) ||
                    tkb.DiaDiem.Contains(tuKhoa));
            }

            return source.ToList();
        }


        public List<LopHoc> LayDanhSachLopHocDaDangKy(string maHocVien)
        {
            var query = from dangKy in ThoiKhoaBieuContext.DangKyKhoaHocs
                        where dangKy.MaHocVien == maHocVien
                        join dk_kh in ThoiKhoaBieuContext.DangKyKhoaHoc_KhoaHocs on dangKy.MaDangKy equals dk_kh.MaDangKy
                        join khoaHoc in ThoiKhoaBieuContext.KhoaHocs on dk_kh.MaKhoaHoc equals khoaHoc.MaKhoaHoc
                        join lopHoc in ThoiKhoaBieuContext.LopHocs on khoaHoc.MaKhoaHoc equals lopHoc.MaKhoaHoc
                        select lopHoc;

            return query.Distinct().ToList();
        }


        public List<string> KiemTraTrungTruocKhiThem(int? thu, string maPhongHoc, int? tietBatDau, int? tietKetThuc, string diaDiem, string caHoc, DateTime? ngayHoc)
        {
            List<string> errorMessages = new List<string>();
            var existingSchedules = ThoiKhoaBieuContext.ThoiKhoaBieus
                .Where(tkb => tkb.Thu == thu && tkb.MaPhongHoc == maPhongHoc)
                .ToList();

            foreach (var schedule in existingSchedules)
            {
                if ((tietBatDau.HasValue && tietKetThuc.HasValue &&
                    (tietBatDau.Value >= schedule.TietBatDau && tietBatDau.Value <= schedule.TietKetThuc ||
                    tietKetThuc.Value >= schedule.TietBatDau && tietKetThuc.Value <= schedule.TietKetThuc)))
                {
                    errorMessages.Add($"Lịch học trùng với tiết học của lịch có ID {schedule.IDThoiKhoaBieu}.");
                }
                if (diaDiem == schedule.DiaDiem)
                {
                    errorMessages.Add($"Lịch học trùng với địa điểm của lịch có ID {schedule.IDThoiKhoaBieu}.");
                }
                if (caHoc == schedule.CaHoc)
                {
                    errorMessages.Add($"Lịch học trùng với ca học của lịch có ID {schedule.IDThoiKhoaBieu}.");
                }
                if (ngayHoc.HasValue && ngayHoc.Value.Date == schedule.NgayHoc)
                {
                    errorMessages.Add($"Lịch học trùng với ngày học của lịch có ID {schedule.IDThoiKhoaBieu}.");
                }
            }

            return errorMessages;
        }

        public void ThemDuLieuToChucThi(string maToChucThi, string maHocVien, string maLopHoc, string diemThi)
        {
            float? diemThiValue = null;

            if (!string.IsNullOrEmpty(diemThi) && float.TryParse(diemThi, out float result))
            {
                diemThiValue = result;
            }
            var existingToChucThiLop = ThoiKhoaBieuContext.ToChucThi_LOPs
                .FirstOrDefault(tctl => tctl.MaToChucThi == maToChucThi && tctl.MaLopHoc == maLopHoc);

            if (existingToChucThiLop == null)
            {
                ToChucThi_LOP tochucthilop = new ToChucThi_LOP
                {
                    MaLopHoc = maLopHoc,
                    MaToChucThi = maToChucThi 
                };
                ThoiKhoaBieuContext.ToChucThi_LOPs.InsertOnSubmit(tochucthilop);
                ThoiKhoaBieuContext.SubmitChanges();
            }
            DiemThi diemthihv = new DiemThi
            {
                MaHocVien = maHocVien,
                MaToChucThi = maToChucThi,
                Diem = diemThiValue
            };
            ThoiKhoaBieuContext.DiemThis.InsertOnSubmit(diemthihv);
            ThoiKhoaBieuContext.SubmitChanges();
        }
        public bool KiemTraTrungThoiGianHoc(ThoiKhoaBieu thoiKhoaBieu)
        {
            var trungThoiGian = ThoiKhoaBieuContext.ThoiKhoaBieus
                .Any(tk => tk.IDThoiKhoaBieu != thoiKhoaBieu.IDThoiKhoaBieu &&
                           tk.Thu == thoiKhoaBieu.Thu &&
                           ((tk.TietBatDau <= thoiKhoaBieu.TietBatDau && tk.TietKetThuc >= thoiKhoaBieu.TietBatDau) ||
                            (tk.TietBatDau <= thoiKhoaBieu.TietKetThuc && tk.TietKetThuc >= thoiKhoaBieu.TietKetThuc)));

            return trungThoiGian;
        }

        public bool KiemTraTrungCaHoc(ThoiKhoaBieu thoiKhoaBieu)
        {
            var trungCaHoc = ThoiKhoaBieuContext.ThoiKhoaBieus
                .Any(tk => tk.IDThoiKhoaBieu != thoiKhoaBieu.IDThoiKhoaBieu &&
                           tk.Thu == thoiKhoaBieu.Thu &&
                           tk.CaHoc == thoiKhoaBieu.CaHoc);

            return trungCaHoc;
        }
        public bool KiemTraTrungNgayHoc(ThoiKhoaBieu thoiKhoaBieu)
        {
            var trungNgayHoc = ThoiKhoaBieuContext.ThoiKhoaBieus
                .Any(tk => tk.IDThoiKhoaBieu != thoiKhoaBieu.IDThoiKhoaBieu &&
                           tk.NgayHoc == thoiKhoaBieu.NgayHoc &&
                           tk.CaHoc == thoiKhoaBieu.CaHoc);

            return trungNgayHoc;
        }
        public bool KiemTraTrungNgayThi(ThoiKhoaBieu thoiKhoaBieu)
        {
            var trungNgayThi = ThoiKhoaBieuContext.ThoiKhoaBieus
                .Any(tk => tk.IDThoiKhoaBieu != thoiKhoaBieu.IDThoiKhoaBieu &&
                            tk.NgayThi == thoiKhoaBieu.NgayThi &&
                            ((tk.TietBatDau <= thoiKhoaBieu.TietBatDau && tk.TietKetThuc >= thoiKhoaBieu.TietBatDau) ||
                            (tk.TietBatDau <= thoiKhoaBieu.TietKetThuc && tk.TietKetThuc >= thoiKhoaBieu.TietKetThuc)));

            return trungNgayThi;
        }
        public bool KiemTraTrungThuVaTietHoc(ThoiKhoaBieu thoiKhoaBieu)
        {
            var trungThuVaTietHoc = ThoiKhoaBieuContext.ThoiKhoaBieus
                .Any(tk => tk.IDThoiKhoaBieu != thoiKhoaBieu.IDThoiKhoaBieu &&
                           tk.Thu == thoiKhoaBieu.Thu &&
                           (tk.TietBatDau <= thoiKhoaBieu.TietBatDau && tk.TietKetThuc >= thoiKhoaBieu.TietBatDau));

            return trungThuVaTietHoc;
        }
       
    }
}
   