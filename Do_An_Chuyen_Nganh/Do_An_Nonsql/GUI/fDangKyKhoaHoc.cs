using _BLL;
using Do_An_Chuyen_Nganh.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Do_An_Chuyen_Nganh.fDangNhap;

namespace Do_An_Chuyen_Nganh
{
    public partial class fDangKyKhoaHoc : Form
    {
        private XyLyDangKyKhoaHoc dangKyProcessor = new XyLyDangKyKhoaHoc();
        private bool isLoadingData = false;
        private Random random = new Random();
        private XuLyXepLop xuLyXepLop = new XuLyXepLop();
        public fDangKyKhoaHoc()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            LoadGioiTinhComboBox();
            dataDangKy.DataSource = dangKyProcessor.GetDangKyKhoaHoc();
          //  dataDangKy.Columns["HocVien"].Visible = false;
          //  dataDangKy.Columns["KhoaHoc"].Visible = false;
            comboMaHocVien.DataSource = dangKyProcessor.GetMaHocVien();
        
        }
        private void LoadGioiTinhComboBox()
        {
            comboHT.Items.Add("Tiền mặt");
            comboHT.Items.Add("Chuyển khoản");
            comboHT.SelectedIndex = 0;
        }
        public class KhoaHocCheckItem
        {
            public string MaKhoaHoc { get; set; }
            public bool IsChecked { get; set; }
            public decimal DonGia { get; set; } 
        }
        private string NhapSoDienThoai()
        {
            string soDienThoai = "";

            using (fKtraDK formNhapSoDienThoai = new fKtraDK())
            {
                formNhapSoDienThoai.StartPosition = FormStartPosition.CenterScreen;

                if (formNhapSoDienThoai.ShowDialog() == DialogResult.OK)
                {
                    soDienThoai = formNhapSoDienThoai.SoDienThoaiNhap;
                }
            }

            return soDienThoai;
        }
        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in dataDangKy.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void ClearInputFields()
        {
            txtma.Clear();
            comboMaHocVien.SelectedIndex = -1;
         
            dateNgayDK.Value = DateTime.Now;
          
            check.Checked = false;
            comboHT.SelectedIndex = -1;
        }
        private void XulyCotTiengViet()
        {

            dataDangKy.Columns["MaDangKy"].HeaderText = "Mã Đăng Ký";
            dataDangKy.Columns["TenHocVien"].HeaderText = "Tên Học Viên";
            dataDangKy.Columns["TenKhoaHoc"].HeaderText = "Tên Khóa Học";
            dataDangKy.Columns["NgayDangKy"].HeaderText = "Ngày Đăng Ký";
            dataDangKy.Columns["Dathanhtoan"].HeaderText = "Đã Thanh Toán";
            dataDangKy.Columns["HinhThucThanhToan"].HeaderText = "Hình Thức Thanh Toán";
        }
        private void dataDKKH_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataDangKy.CurrentRow;
            if (selectedRow != null)
            {
                string maDangKy = selectedRow.Cells["MaDangKy"].Value.ToString();
                string maHocVien = selectedRow.Cells["TenHocVien"].Value.ToString();
             
                DateTime ngayDangKy = Convert.ToDateTime(selectedRow.Cells["NgayDangKy"].Value);
              
                bool daThanhToan = Convert.ToBoolean(selectedRow.Cells["Dathanhtoan"].Value);
                object hinhThucThanhToanObj = selectedRow.Cells["HinhThucThanhToan"].Value;

                string hinhThucThanhToan = hinhThucThanhToanObj != null ? hinhThucThanhToanObj.ToString() : null;

                txtma.Text = maDangKy;
                comboMaHocVien.Text = maHocVien;
                dateNgayDK.Value = ngayDangKy;
                check.Checked = daThanhToan;
                comboHT.Text = hinhThucThanhToan;
            }
        }

        private void fDangKy_Load(object sender, EventArgs e)
        {
            LoadData();
            AutoSizeColumns();
            XulyCotTiengViet();
        }
      
        private string SinhMaDangKy()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "DK" + randomPart;
        }
        private string SinhMaPhieuThu()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "PT" + randomPart;
        }
        private string SimhMaXL()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "XL" + randomPart;
        }
        public void XepLopHocVien(string maDangKy, List<string> maKhoaHocList)
        {
            foreach (string maKhoaHoc in maKhoaHocList)
            {
                KhoaHoc khoaHoc = dangKyProcessor.LayThongTinKhoaHocTheoMa(maKhoaHoc);
                if (khoaHoc != null)
                {
                    List<LopHoc> lopHocList = dangKyProcessor.LayDanhSachLopHocTheoKhoaHoc(maKhoaHoc);
                    foreach (LopHoc lopHoc in lopHocList)
                    {
                        if (lopHoc.SoLuongHocVienHienTai < lopHoc.SoLuongHocVienToiDa)
                        {
                            XepLopHocVien xepLopHocVien = new XepLopHocVien
                            {
                                IDXepLop = SimhMaXL(),
                                MaLopHoc = lopHoc.MaLopHoc,
                                MaHocVien = dangKyProcessor.LayMaHocVienTheoMaDangKy(maDangKy)
                            };
                            dangKyProcessor.ThemXepLopHocVien(xepLopHocVien);
                            lopHoc.SoLuongHocVienHienTai++;
                            dangKyProcessor.CapNhatThongTinLopHoc(lopHoc);
                            break;
                        }
                    }
                    khoaHoc.SoLuongHocVien--;
                    dangKyProcessor.CapNhatThongTinKhoaHoc(khoaHoc);
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string[] mahv = comboMaHocVien.Text.Split('-');
            string mahvpasrt = mahv[0].Trim();
            string maDangKy = SinhMaDangKy();
            List<string> maKhoaHocList = new List<string>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (checkedListBox1.Items[i] is KhoaHocCheckItem)
                    {
                        KhoaHocCheckItem khoaHocItem = (KhoaHocCheckItem)checkedListBox1.Items[i];
                        string[] makh = khoaHocItem.MaKhoaHoc.Split('-');
                        string Makh = makh[0].Trim();
                        maKhoaHocList.Add(Makh);                       
                    }
                }
            }
            DangKyKhoaHoc dangKy = new DangKyKhoaHoc
            {
                MaDangKy = maDangKy,
                MaHocVien = mahvpasrt,
                NgayDangKy = dateNgayDK.Value,
                DaThanhToan = check.Checked,
                HinhThucThanhToan = comboHT.Text
            };

            dangKyProcessor.ThemDangKyKhoaHoc(dangKy);   
            foreach (string maKhoaHoc in maKhoaHocList)
            {
                DangKyKhoaHoc_KhoaHoc dk_kh = new DangKyKhoaHoc_KhoaHoc
                {
                    MaDangKy = maDangKy,
                    MaKhoaHoc = maKhoaHoc
                };

                dangKyProcessor.ThemDangKyKhoaHoc_KhoaHoc(dk_kh);
                KhoaHoc khoaHoc = dangKyProcessor.LayThongTinKhoaHocTheoMa(maKhoaHoc);
                if (khoaHoc != null)
                {
                   
                    XepLopHocVien(maDangKy, new List<string> { maKhoaHoc });

                    // Hiển thị thông báo xếp lớp
                    MessageBox.Show($"Đã xếp lớp cho học viên {mahvpasrt} ở khóa học {maKhoaHoc}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    khoaHoc.SoLuongHocVien--; 
                    dangKyProcessor.CapNhatThongTinKhoaHoc(khoaHoc);
                }
            }
           
            string manv =UserInfo.MaNhanVien;
            decimal tongTien;
            string a = SinhMaPhieuThu();
            if (decimal.TryParse(label7.Text, out tongTien))
            {
                double? tongTienDouble = Convert.ToDouble(tongTien);

                PhieuThu phieuthu = new PhieuThu
                {
                    MaPhieuThu = a,
                    MaHocVien = mahvpasrt,
                    NgayLap = dateNgayDK.Value,
                    TongTien = tongTienDouble,
                    MaNhanVien = manv,
                    TrangThai = "Chưa thanh toán"
                };
                dangKyProcessor.ThemPhieuThu(phieuthu);
             
            }
            else
            {
               
                MessageBox.Show("Giá trị đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
            foreach (string maKhoaHoc in maKhoaHocList)
            {
                ChiTietPhieuThu CtPT = new ChiTietPhieuThu
                {
                    MaPhieuThu = a,
                    MaKhoaHoc = maKhoaHoc,
                };

                dangKyProcessor.ThemChiTietPhieuTHu(CtPT);
            }
            LoadData();
            ClearInputFields();
            DialogResult result = MessageBox.Show("Bạn muốn thanh toán cho các đăng ký đã thêm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                fThanhToan thanhToanForm = new fThanhToan(a);
                
                thanhToanForm.StartPosition = FormStartPosition.CenterScreen;
                thanhToanForm.ShowDialog();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataDangKy.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataDangKy.SelectedRows[0];
                string maDangKy = selectedRow.Cells["MaDangKy"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đăng ký có mã " + maDangKy + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dangKyProcessor.XoaDangKyKhoaHoc(maDangKy);
                    dangKyProcessor.XoaPhieuThuTheoMaDangKy(maDangKy);
                    dataDangKy.DataSource = dangKyProcessor.GetDangKyKhoaHoc();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đăng ký để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //if (dataDangKy.SelectedRows.Count > 0)
            //{
            //    int selectedRowIndex = dataDangKy.SelectedRows[0].Index;
            //    DataGridViewRow selectedRow = dataDangKy.Rows[selectedRowIndex];
            //    string maDangKy = selectedRow.Cells["MaDangKy"].Value.ToString();

            //    string[] mahv = comboMaHocVien.Text.Split('-');
            //    string mahvpasrt = mahv[0].Trim();
            //    string[] makh = comboMaKhoaHoc.Text.Split('-');
            //    string makhpasrt = makh[0].Trim();
            //    DangKyKhoaHoc dangKy = new DangKyKhoaHoc
            //    {
            //        MaDangKy = txtma.Text,
            //        MaHocVien = mahvpasrt,
            //        MaKhoaHoc = makhpasrt,
            //        NgayDangKy = dateNgayDK.Value,
            //        TrangThai = txtTrangThai.Text,
            //        DaThanhToan = check.Checked,
            //        HinhThucThanhToan = txtHinhthuc.Text
            //    };

            //    dangKyProcessor.SuaDangKyKhoaHoc(dangKy);
            //    dataDangKy.DataSource = dangKyProcessor.GetDangKyKhoaHoc();
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một đăng ký để sửa chữa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTk.Text.Trim();
            List<DangKyKhoaHoc> ketQuaTimKiem = dangKyProcessor.TimKiemDangKyKhoaHoc(tuKhoa);
            dataDangKy.DataSource = ketQuaTimKiem;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XuLyTimKiemHocVien();
        }
        public void XuLyTimKiemHocVien()
        {
            while (true)
            {
                string soDienThoai = NhapSoDienThoai();
                bool hocVienDaDangKy = dangKyProcessor.KiemTraHocVienDaDangKy(soDienThoai);

                if (hocVienDaDangKy)
                {
                    DialogResult dialogResult = MessageBox.Show($"Học viên có số điện thoại {soDienThoai} đã đăng ký khóa học. Bạn có muốn đăng ký khóa học không?", "Tiếp tục tìm kiếm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        string maHocVien = dangKyProcessor.LayMaHocVienTheoSoDienThoai(soDienThoai);

                        if (!string.IsNullOrEmpty(maHocVien))
                        {
                            dataDangKy.SelectionChanged -= dataDKKH_SelectionChanged;
                            comboMaHocVien.SelectedItem = maHocVien;
                            foreach (DataGridViewRow row in dataDangKy.Rows)
                            {
                                if (row.Cells["MaHocVien"].Value.ToString() == maHocVien)
                                {
                                    row.Selected = true;
                                    break;
                                }
                            }
                            dataDangKy.SelectionChanged += dataDKKH_SelectionChanged;
                            LoadData();
                            AutoSizeColumns();
                            XulyCotTiengViet();

                            break;
                        }
                    }
                    MessageBox.Show("Đã hủy tìm kiếm.");
                    break;
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show($"Học viên có số điện thoại {soDienThoai} chưa đăng ký khóa học. Bạn có muốn đăng ký mới không?", "Đăng ký mới", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        fDangKy_Load(this, EventArgs.Empty);
                        break;
                    }
                    else
                    {
                        DialogResult continueSearchResult = MessageBox.Show("Đã hủy đăng ký mới. Bạn có muốn tiếp tục tìm kiếm không?", "Tiếp tục tìm kiếm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (continueSearchResult == DialogResult.No)
                        {
                            fDangKy_Load(this, EventArgs.Empty);
                            break;
                        }

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fQuanLyHocVien a= new fQuanLyHocVien();
            a.StartPosition = FormStartPosition.CenterScreen;
            a.ShowDialog();
            fDangKy_Load(this, EventArgs.Empty);

        }

       
        private Form customForm; 
        private void btnchonKhoaHoc_Click(object sender, EventArgs e)
        {
            List<KhoaHocCheckItem> danhSachKhoaHoc = dangKyProcessor.GetMaKhoaHoc()
     .Select(maKhoaHoc => new KhoaHocCheckItem
     {
         MaKhoaHoc = maKhoaHoc,
         IsChecked = false,
         DonGia = 0 
     })
     .ToList();

            checkedListBox1.DataSource = danhSachKhoaHoc;
            checkedListBox1.DisplayMember = "MaKhoaHoc";
            checkedListBox1.ValueMember = "IsChecked";
            if (checkedListBox1.Items.Count > 0)
            {
              
                if (customForm == null || customForm.IsDisposed)
                {
                    customForm = new Form();
                    customForm.Text = "Chọn khóa học";
                    customForm.StartPosition = FormStartPosition.CenterScreen;

                    checkedListBox1.Dock = DockStyle.Fill;

                    var okButton = new Button();
                    okButton.Text = "OK";
                    okButton.DialogResult = DialogResult.OK;

                    customForm.Controls.Add(checkedListBox1);
                    customForm.Controls.Add(okButton);

                    okButton.Click += (s, args) => customForm.Close();
                }
                if (customForm.ShowDialog() == DialogResult.OK)
                {
                    
                    StringBuilder selectedKhoaHoc = new StringBuilder();
                    selectedKhoaHoc.AppendLine("Các khóa học đã chọn:");

                    foreach (var item in checkedListBox1.CheckedItems)
                    {
                        selectedKhoaHoc.AppendLine(item.ToString());
                    }

                    MessageBox.Show(selectedKhoaHoc.ToString(), "Thông tin khóa học đã chọn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bạn đã huỷ việc chọn khóa học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu khóa học để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private List<string> selectedCourses = new List<string>();

      
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<KhoaHocCheckItem> danhSachKhoaHoc = dangKyProcessor.GetMaKhoaHoc()
       .Select(maKhoaHoc => new KhoaHocCheckItem
       {
           MaKhoaHoc = maKhoaHoc,
           IsChecked = false
       })
       .ToList();

            checkedListBox1.DataSource = danhSachKhoaHoc;
            checkedListBox1.DisplayMember = "MaKhoaHoc";
            checkedListBox1.ValueMember = "IsChecked";
            decimal DonGia = 0m;
            if (e.Index >= 0 && e.Index < checkedListBox1.Items.Count)
            {
                KhoaHocCheckItem selectedItem = (KhoaHocCheckItem)checkedListBox1.Items[e.Index];
                string maKhoaHoc = string.IsNullOrEmpty(selectedItem.MaKhoaHoc) ? string.Empty : selectedItem.MaKhoaHoc.Split('-')[0].Trim();

                if (e.NewValue == CheckState.Checked)
                {
                    selectedCourses.Add(maKhoaHoc);
                }
                else
                {
                    selectedCourses.Remove(maKhoaHoc);
                }
                foreach (string selectedCourse in selectedCourses)
                {
                    DonGia += dangKyProcessor.LayDonGiaKhoaHoc(selectedCourse);
                }
                label7.Text = DonGia.ToString("N0");
            }


        }
        
    }
}
