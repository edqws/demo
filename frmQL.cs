using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace sa
{
    public partial class frmQL : Form
    {
        public frmQL(string mgv)
        {
            this.mgv = mgv;
            InitializeComponent();
        }
        private string mgv;
        private string nguoithucthi = "admin";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmQL_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mgv))
            {
                this.Text = "Thêm mới quản lý";
            }
            else
            {
                this.Text = "Cập nhật quản lý";
                var r = new Database().select("selectQL '" + int.Parse(mgv) + "'");
                txtHo.Text = r["ho"].ToString();
                txtTendem.Text = r["tendem"].ToString();
                txtTen.Text = r["ten"].ToString();
                rbtNam.Checked = r["gioitinh"].ToString() == "1" ? true : false;
                mtbNgaysinh.Text = r["ngsinh"].ToString();

                txtDiachi.Text = r["diachi"].ToString();
                txtDienthoai.Text = r["dienthoai"].ToString();
                txtEmail.Text = r["email"].ToString();

            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string sql = string.Empty;
            DateTime ngaysinh;
            List<CustomParameter> lstPara = new List<CustomParameter>();
            try
            {
                ngaysinh = DateTime.ParseExact(mtbNgaysinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                mtbNgaysinh.Select();
                return;
            }
            if (String.IsNullOrEmpty(mgv))
            {
                sql = "InsertQL";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoitao",
                    value = nguoithucthi
                });
            }
            else
            {
                sql = "updateQL";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoicapnhat",
                    value = nguoithucthi
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@maquanli",
                    value = mgv
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
                key = "@ngaysinh",
                value = ngaysinh.ToString("yyyy - MM -dd")
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
                if (string.IsNullOrEmpty(mgv))
                {
                    MessageBox.Show("Thêm mới quản lý thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật quản lý thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thực thi truy vấn thất bai");
            }
           
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
