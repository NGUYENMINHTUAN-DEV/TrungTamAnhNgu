using _BLL;
using DevExpress.Drawing.Internal;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Data;

namespace Do_An_Chuyen_Nganh.GUI
{
    public partial class fHoaDon : Form
    {
        public fHoaDon()
        {
            InitializeComponent();
        }

        private void fHoaDon_Load(object sender, EventArgs e)
        {
            AnhNguDataContext context = new AnhNguDataContext();
            List<KhoaHoc> KH = context.KhoaHocs.ToList();

            List<XuLyHoaDon> HD = new List<XuLyHoaDon>();
            foreach(KhoaHoc kh in KH)
            {
                XuLyHoaDon t = new XuLyHoaDon();
                t.MaKhoaHoc = kh.MaKhoaHoc;
                t.TenKhoaHoc = kh.TenKhoaHoc;
                HD.Add(t);

            }
            rptMauHoaDon.LocalReport.ReportPath = "rptHoaDon.rdlc";
            var source = new ReportDataSource("DataSetHoaDon", HD);
            rptMauHoaDon.LocalReport.DataSources.Clear();
            rptMauHoaDon.LocalReport.DataSources.Add(source);
        }
    }
}
