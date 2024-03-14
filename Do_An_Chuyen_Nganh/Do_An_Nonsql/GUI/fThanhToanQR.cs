using _BLL;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace VietQRPaymentAPI
{
    public partial class fThanhToanQR : Form
    {
        public fThanhToanQR(string tongTien)
        {
            InitializeComponent();
            txtSoTien.Text = tongTien;
        }

        private  void button1_Click(object sender, EventArgs e)
        {

            var apiRequest = new ApiRequest();
            apiRequest.acqId = Convert.ToInt32( cb_nganhang.EditValue.ToString());
            apiRequest.accountNo = txtSTK.Text.Trim();
            apiRequest.accountName = txtTenTaiKhoan.Text;
            apiRequest.amount = Convert.ToInt32( txtSoTien.Text);
            apiRequest.format = "text";
            apiRequest.template = cb_template.Text;
            var jsonRequest = JsonConvert.SerializeObject(apiRequest);
            var client = new RestClient("https://api.vietqr.io/v2/generate");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            
            request.AddParameter("application/json", jsonRequest, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content; 
            var dataResult = JsonConvert.DeserializeObject<ApiResponse>(content);


            var image = Base64ToImage(dataResult.data.qrDataURL.Replace("data:image/png;base64,", ""));
            pictureBox1.Image = image;


        }

        public Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                var htmlData = client.DownloadData("https://api.vietqr.io/v2/banks");
                var bankRawJson = Encoding.UTF8.GetString(htmlData);
                var listBankData = JsonConvert.DeserializeObject<Bank>(bankRawJson);

                cb_nganhang.Properties.DataSource = listBankData.data;
                cb_nganhang.Properties.DisplayMember = "custom_name";
                cb_nganhang.Properties.ValueMember = "bin";
                cb_nganhang.EditValue = listBankData.data.FirstOrDefault().bin;
                cb_template.SelectedIndex = 0;
            }
        }
    }
}
