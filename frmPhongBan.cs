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
    public partial class frmPhongBan : Form
    {
        public frmPhongBan(string mpb)
        {
            this.mpb = mpb;
            InitializeComponent();
        }
        private string mpb;
        private string nguoithuchien = "admin";
        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mpb))
            {
                this.Text = "Thêm mới phòng ban";
            }
            else
            {
                this.Text = "Cập nhật phòng ban";
                var r = new Database().select("exec selectPB'"+mpb+"'");
                txtTenPB.Text = r["tenphongban"].ToString();
                txtSoL.Text = r["soluong"].ToString();
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
               var stc = int.Parse(txtSoL.Text);
                if (stc <= 0)
                {
                    MessageBox.Show("Số lượng phòng ban phải lớn hơn 0");
                    txtSoL.Select();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Số lượng phòng ban phải là số nguyên");
                txtSoL.Select();
                return;
            }

             if(string.IsNullOrEmpty(txtTenPB.Text))
            {
                MessageBox.Show(" Tên môn học không được để trống");
                txtTenPB.Select();
                return;
            }    
            string sql = "";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(mpb))
            {
                sql = "insertPB";
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoitao",
                    value = nguoithuchien
                });
            }
            else
            {
                sql = "updatePB";
                lstPara.Add(new CustomParameter()
                {
                    key = "@maphongban",
                    value = mpb
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@nguoicapnhat",
                    value = nguoithuchien
                });
                sql = "updatePB";
            }
            lstPara.Add(new CustomParameter()
            {
                key = "@tenphongban",
                value = txtTenPB.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@soluong",
                value = txtSoL.Text
            });

            var rs = new Database().ExecCute(sql,lstPara);
            if(rs == 1)
            {
                if(string.IsNullOrEmpty(mpb))
                {
                    MessageBox.Show("Thêm mới phòng ban thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin phòng ban thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thực hiện truy vấn thất bại");
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }
    }
}
