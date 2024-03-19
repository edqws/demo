using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sa
{
    public partial class frmupdatekh : Form
    {
        public frmupdatekh(string mkh)
        {
            this.mkh = mkh;
            InitializeComponent();
        }
        private string mkh;
        private string nguoithucthi = "admin";
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string sql = string.Empty;
           
            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (String.IsNullOrEmpty(mkh))
            {
                sql = "InsertKH";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoitao",
                    value = nguoithucthi
                });
            }
            else
            {
                sql = "UPDATEKH";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoicapnhat",
                    value = nguoithucthi
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@makhachhang",
                    value = mkh
                });
            }
            lstPara.Add(new CustomParameter()
            {
                key = "@ho",
                value = txtHo.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@tendem",
                value = txtTendem.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ten",
                value = txtTen.Text
            });
         
            lstPara.Add(new CustomParameter()
            {
                key = "@gioitinh",
                value = rbtNam.Checked ? "1" : "0"
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@email",
                value = txtEmail.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@dienthoai",
                value = txtDienthoai.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diachi",
                value = txtDiachi.Text
            });

            var rs = new Database().ExecCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(mkh))
                {
                    MessageBox.Show("Thêm mới khách hàng thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật khách hàng thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thực thi truy vấn thất bai");
            }
        }

        private void frmupdatekh_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mkh))
            {
                this.Text = "Thêm mới khách hàng";
            }
            else
            {
                this.Text = "Cập nhật khách hàng";
                var r = new Database().select("selectKH '" + int.Parse(mkh) + "'");
                txtHo.Text = r["ho"].ToString();
                txtTendem.Text = r["tendem"].ToString();
                txtTen.Text = r["ten"].ToString();
                rbtNam.Checked = r["gioitinh"].ToString() == "1" ? true : false;
                txtDiachi.Text = r["diachi"].ToString();
                txtDienthoai.Text = r["dienthoai"].ToString();
                txtEmail.Text = r["email"].ToString();

            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtHo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
