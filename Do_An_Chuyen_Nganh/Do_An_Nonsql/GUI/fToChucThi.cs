using _BLL;
using DocumentFormat.OpenXml.Office2010.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_Chuyen_Nganh.GUI
{
    public partial class fToChucThi : Form
    {
       
        XuLyToChucThi xulytochucthi = new XuLyToChucThi();
        private Random random = new Random();
        public fToChucThi()
        {
          
            InitializeComponent();
        }
        private string SinhMaKyThi()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string randomPart = new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return "TC" + randomPart;
        }
        private void XulyCotTiengViet()
        {
            dateKyThi.Columns["MaToChucThi"].HeaderText = "Mã Kỳ Thi";
            dateKyThi.Columns["TenToChucThi"].HeaderText = "Tên Kỳ Thi";
        }
        private void LoadData()
        {
            dateKyThi.DataSource = xulytochucthi.GetToChucThi();
          
        }
        private void AutoSizeColumns()
        {
            foreach (DataGridViewColumn column in dateKyThi.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                ToChucThi tochucthi = new ToChucThi
                {
                    MaToChucThi = SinhMaKyThi(),
                    TenToChucThi = txtTenTc.Text,
                };

                xulytochucthi.ThemToChucThi(tochucthi);
                MessageBox.Show("Thêm Tổ Chức Thi Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thêm Tổ Chức Thi Thất Bại. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fToChucThi_Load(object sender, EventArgs e)
        {
            LoadData();
            XulyCotTiengViet();
            AutoSizeColumns();
        }

        private void dateKyThi_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dateKyThi.CurrentRow;
            if (selectedRow != null)
            {
                string makythi = selectedRow.Cells["MaToChucThi"].Value.ToString();
                string tenkythi = selectedRow.Cells["TenToChucThi"].Value.ToString();

                txtMaTc.Text = makythi;
                txtTenTc.Text = tenkythi;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dateKyThi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dateKyThi.SelectedRows[0];
                string matochuc = selectedRow.Cells["MaToChucThi"].Value.ToString();
                string tenkythi = selectedRow.Cells["TenToChucThi"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa kỳ thi có tên {tenkythi} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xulytochucthi.XoaToChucThi(matochuc);
                        MessageBox.Show("Xóa Tổ Chức Thi Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Xóa Tổ Chức Thi Thất Bại. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một kỳ thi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dateKyThi.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dateKyThi.SelectedRows[0].Index;
                DataGridViewRow selectedRow = dateKyThi.Rows[selectedRowIndex];
                ToChucThi tc = new ToChucThi
                {
                    MaToChucThi = txtMaTc.Text,
                    TenToChucThi = txtTenTc.Text,
                };
                try
                {
                    xulytochucthi.SuaToChucThi(tc);
                    MessageBox.Show("Sửa Tổ Chức Thi Thành Công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Sửa Tổ Chức Thi Thất Bại. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một kỳ thi để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
