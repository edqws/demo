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
    public partial class frmDichVu : Form
    {

        public frmDichVu(string mdv)
        {
            this.mdv = mdv;
            InitializeComponent();
        }
        private string mdv;
        private string nguoithucthi = "admin";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mdv))
            {
                this.Text = "Thêm mới dịch vụ";
            }
            else
            {
                this.Text = "Cập nhật dịch vụ";
                var r = new Database().select("selectDV '" + int.Parse(mdv) + "'");
                txtDonGia.Text = r["DonGia"].ToString();
                txtGhiChu.Text = r["GhiChu"].ToString();
                txtSoLuong.Text = r["SoLuong"].ToString();
                txtTenHang.Text = r["TenDichVu"].ToString();
             
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string sql = string.Empty;

            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (String.IsNullOrEmpty(mdv))
            {
                sql = "InsertDV";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoitao",
                    value = nguoithucthi
                });
            }
            else
            {
                sql = "updateDV";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoicapnhat",
                    value = nguoithucthi
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@MaDichVu",
                    value = mdv
                });
            }
            lstPara.Add(new CustomParameter()
            {
                key = "@TenDichVu",
                value = txtTenHang.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@SoLuong",
                value = txtSoLuong.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@GhiChu",
                value = txtGhiChu.Text
            });

           
            lstPara.Add(new CustomParameter()
            {
                key = "@DonGia",
                value = txtDonGia.Text
            });
            

            var rs = new Database().ExecCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(mdv))
                {
                    MessageBox.Show("Thêm mới dịch vụ thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật dịch vụ thành công");
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

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
