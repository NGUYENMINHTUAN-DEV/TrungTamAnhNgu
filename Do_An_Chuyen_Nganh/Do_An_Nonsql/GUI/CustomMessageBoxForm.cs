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
    public partial class CustomMessageBoxForm : Form
    {
        public CustomMessageBoxForm()
        {
            InitializeComponent();
        }
        public DialogResult ShowDialog(string buttonTextYes, string buttonTextNo, string message, string caption)
        {
            btnTudong.Text = buttonTextYes;
            btnBangtay.Text = buttonTextNo;
            labelMessage.Text = message;
            this.Text = caption;

            return this.ShowDialog();
        }

        private void btnTudong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnBangtay_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }

}
