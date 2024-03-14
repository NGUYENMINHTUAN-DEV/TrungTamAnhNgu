using _BLL;
using _BLL._BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Chuyen_Nganh
{
    public partial class fPhanPhoiTaiLieu : Form
    {
        private XyLyTaiLieu taiLieuProcessor = new XyLyTaiLieu();
        private XuLyPhatTaiLieu phatTaiLieuProcessor = new XuLyPhatTaiLieu();
        public fPhanPhoiTaiLieu()
        {
            InitializeComponent();
        }

       
        private void fPhanPhoiTaiLieu_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataPTL();
            AutoSizeColumns();
            AutoSizeColumnsPTL();
            XulyCotTiengViet();
            XulyCotTiengVietPTL();

        }
      
        private void XulyCotTiengVietPTL()
        {
            dataPtl.Columns["IDPhatTaiLieu"].HeaderText = "ID Phát Tài Liệu";
            dataPtl.Columns["TenHocVien"].HeaderText = "Tên Học Viên";
            dataPtl.Columns["MaTaiLieu"].HeaderText = "Mã Tài Liệu";
            dataPtl.Columns["NgayPhatTaiLieu"].HeaderText = "Ngày Phát Tài Liệu";
            dataPtl.Columns["SoLuongPhat"].HeaderText = "Số Lượng Tài Liệu Phát";
        }
            private void XulyCotTiengViet()
        {
            dataTaiLieu.Columns["MaTaiLieu"].HeaderText = "Mã Tài Liệu";
            dataTaiLieu.Columns["TenTaiLieu"].HeaderText = "Tên Tài Liệu";
            dataTaiLieu.Columns["TenKhoaHoc"].HeaderText = "Tên Khóa Học";
            dataTaiLieu.Columns["Sl"].HeaderText = "Số Lượng Tài Liệu";
        }
        private void dataTaiLieu_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataTaiLieu.CurrentRow;
            if (selectedRow != null)
            {
                string maTaiLieu = selectedRow.Cells["MaTaiLieu"].Value.ToString();
                string tenTaiLieu = selectedRow.Cells["TenTaiLieu"].Value.ToString();
                string maKhoaHoc = selectedRow.Cells["TenKhoaHoc"].Value.ToString();
                string soLuongTaiLieu = selectedRow.Cells["Sl"].Value.ToString();
                txttl.Text = maTaiLieu;
                txttentl.Text = tenTaiLieu;
                combomakh.Text = maKhoaHoc;
                txtsl.Text = soLuongTaiLieu;
            }
        }
        private void LoadData()
        {
            dataTaiLieu.DataSource = taiLieuProcessor.GetTaiLieu();
            //dataTaiLieu.Columns["KhoaHoc"].Visible = false;
            combomakh.DataSource = taiLieuProcessor.GetMaKhoaHoc();
        }
        private void LoadDataPTL()
        {
            dataPtl.DataSource = phatTaiLieuProcessor.GetPhatTaiLieu();
       //     dataPtl.Columns["HocVien"].Visible = false;
       //     dataPtl.Columns["TaiLieu"].Visible = false;
        }
        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in dataTaiLieu.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void AutoSizeColumnsPTL()
        {
            foreach (DataGridViewColumn column in dataPtl.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private Random random = new Random();
        private string SinhMaTaiLieu()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "TL" + randomPart;
        }
        private void btnthemtl_Click(object sender, EventArgs e)
        {
            string[] makh = combomakh.Text.Split('-');
            string MaKH = makh[0].Trim();
            TaiLieu taiLieu = new TaiLieu
            {
                MaTaiLieu = SinhMaTaiLieu(),
                TenTaiLieu = txttentl.Text,
                MaKhoaHoc = MaKH,
                SoLuongTaiLieu = int.Parse(txtsl.Text)
            };

            taiLieuProcessor.ThemTaiLieu(taiLieu);
            LoadData();
            LoadDataPTL();
            ClearInputFields();
        }

        private void btnXoatl_Click(object sender, EventArgs e)
        {
            if (dataTaiLieu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataTaiLieu.SelectedRows[0];
                string maTaiLieu = selectedRow.Cells["MaTaiLieu"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài liệu có mã " + maTaiLieu + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    taiLieuProcessor.XoaTaiLieu(maTaiLieu);
                    LoadData();
                    LoadDataPTL();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài liệu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaTl_Click(object sender, EventArgs e)
        {
            if (dataTaiLieu.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataTaiLieu.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataTaiLieu.Rows[selectedRowIndex];
                string maTaiLieu = selectedRow.Cells["MaTaiLieu"].Value.ToString();

                string[] makh = combomakh.Text.Split('-');
                string MaKH = makh[0].Trim();
                TaiLieu existingTaiLieu = new TaiLieu
                {
                    MaTaiLieu = maTaiLieu,
                    TenTaiLieu = txttentl.Text,
                
                    MaKhoaHoc = MaKH,
                    SoLuongTaiLieu = int.Parse(txtsl.Text)
                };

                taiLieuProcessor.SuaTaiLieu(existingTaiLieu);
                LoadData();
                LoadDataPTL();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài liệu để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btntktl_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            List<TaiLieu> ketQuaTimKiem = taiLieuProcessor.TimKiemTaiLieu(tuKhoa);
            dataTaiLieu.DataSource = ketQuaTimKiem;
        }
        private void ClearInputFields()
        {
            txttl.Clear();
            txttentl.Clear();
            combomakh.SelectedIndex = -1;
            txtsl.Clear();
        }
        private void dataPtl_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataPtl.CurrentRow;
            if (selectedRow != null)
            {
                string idPhatTaiLieu = selectedRow.Cells["IDPhatTaiLieu"].Value.ToString();
                string maHocVien = selectedRow.Cells["TenHocVien"].Value.ToString();
                string maTaiLieu = selectedRow.Cells["MaTaiLieu"].Value.ToString();
                string ngayPhatTaiLieu = selectedRow.Cells["NgayPhatTaiLieu"].Value.ToString();
                string SlPhat = selectedRow.Cells["SoLuongPhat"].Value.ToString();
                txtidptl.Text = idPhatTaiLieu;
                txtTenHocVien.Text = maHocVien;
                txtTenTaiLieu.Text = maTaiLieu;
                date.Value = DateTime.Parse(ngayPhatTaiLieu);
                txtSlPhat.Text = SlPhat;
            }
        }

     
        private void ClearInputFieldsPTL()
        {
            txtidptl.Clear();
            date.Value = DateTime.Now;
        }

      

        private void btnthemPTL_Click(object sender, EventArgs e)
        {
            PhatTaiLieu phatTaiLieu = new PhatTaiLieu
            {
                IDPhatTaiLieu = txtidptl.Text,
                MaHocVien = txtTenHocVien.Text,
                MaTaiLieu = txtTenTaiLieu.Text,
                NgayPhatTaiLieu = date.Value
            };

            phatTaiLieuProcessor.PhatTaiLieu(phatTaiLieu);
            LoadDataPTL();
            ClearInputFieldsPTL();
        }

        private void btnXoaPTL_Click(object sender, EventArgs e)
        {
            if (dataPtl.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataPtl.SelectedRows[0];
                string idPhatTaiLieu = selectedRow.Cells["IDPhatTaiLieu"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phát tài liệu có ID " + idPhatTaiLieu + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    phatTaiLieuProcessor.XoaPhatTaiLieu(idPhatTaiLieu);
                    dataPtl.DataSource = phatTaiLieuProcessor.GetPhatTaiLieu();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phát tài liệu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaPTL_Click(object sender, EventArgs e)
        {
            if (dataPtl.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataPtl.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dataPtl.Rows[selectedRowIndex];
                string idPhatTaiLieu = selectedRow.Cells["IDPhatTaiLieu"].Value.ToString();

                PhatTaiLieu existingPhatTaiLieu = new PhatTaiLieu
                {
                    IDPhatTaiLieu = idPhatTaiLieu,
                    MaHocVien = txtTenHocVien.Text,
                    MaTaiLieu = txtTenTaiLieu.Text,
                    NgayPhatTaiLieu = date.Value
                };

                phatTaiLieuProcessor.SuaTaiLieu(existingPhatTaiLieu);
                dataPtl.DataSource = phatTaiLieuProcessor.GetPhatTaiLieu();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phát tài liệu để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTkPTL_Click(object sender, EventArgs e)
        {
            string tuKhoa = txttimkiemptl.Text.Trim();
            List<PhatTaiLieu> ketQuaTimKiem = phatTaiLieuProcessor.TimKiemPhatTaiLieu(tuKhoa);
            dataPtl.DataSource = ketQuaTimKiem;
        }

        private void txtsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
