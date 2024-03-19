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
    public partial class frmNhomn : Form
    {
        public frmNhomn(string manhom)
        {
            this.manhom = manhom;
            InitializeComponent();
        }
        private string manhom;
        private Database db;
        private string nguoithuchien = "admin";
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmNhomn_Load(object sender, EventArgs e)
        {
            db = new Database();
            List<CustomParameter> lst = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tukhoa",
                    value = ""
                }
            };
            // load dữ liệu cho 2 conbobox nhóm và quản lí
            cbbPhongBan.DataSource = db.selectData("selectallphongban", lst);
            cbbPhongBan.DisplayMember = "tenphongban";//thuộc tinh hiển thị conbobox
            cbbPhongBan.ValueMember = "maphongban";// giá trị key của combobox
            cbbPhongBan.SelectedIndex = -1;

            cbbQuanLi.DataSource = db.selectData("selectAllQL",lst);
            cbbQuanLi.DisplayMember = "hoten";
            cbbQuanLi.ValueMember = "maquanli";
            cbbQuanLi.SelectedIndex = -1;
            if (string.IsNullOrEmpty(manhom))
            {
                this.Text = "Thêm mới nhóm";
            }
            else
            {
                this.Text = "Cập nhật nhóm";
                var r = db.select("exec SELECTtblNhom'"+manhom+"'");
                cbbQuanLi.SelectedValue = r["maquanli"].ToString();
                cbbPhongBan.SelectedValue = r["maphongban"].ToString();
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {

            string sql = "";

            if (cbbPhongBan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phòng ban");
                return;
            }
            if (cbbQuanLi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn quản lí");
                return;
            }

            List<CustomParameter> lst = new List<CustomParameter>();

            if(string.IsNullOrEmpty(manhom))
            {
                sql = "insertNhom";
                lst.Add(new CustomParameter()
                {
                    key = "@nguoitao",
                    value = nguoithuchien
                });
            }
            else
            {
                sql = "updateNhom";
                lst.Add(new CustomParameter()
                {
                    key = "@nguoicapnhat",
                    value = nguoithuchien
                });
                lst.Add(new CustomParameter()
                {
                    key = "@manhom",
                    value = manhom
                });
            }



            lst.Add(new CustomParameter()
            {
                key = "@maphongban",
                value = cbbPhongBan.SelectedValue.ToString()
            });

            lst.Add(new CustomParameter()
            {
                key = "@maquanli",
                value = cbbQuanLi.SelectedValue.ToString()
                // lấy giá trị được chọn của conbobox quản lí
            });

            var kq=db.ExecCute(sql, lst);
            if (kq == 1)
            {
                if(string.IsNullOrEmpty(manhom))
                {
                    MessageBox.Show("Thêm mới nhóm thành công");

                }    
                else
                {
                    MessageBox.Show("câp nhật nhóm thành công");
                }    
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại");
            }

        }

        private void cbbQuanLi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
