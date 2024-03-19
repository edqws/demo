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
    public partial class frmDangkyPhongban : Form
    {
        public frmDangkyPhongban(string manv)
        {
            this.manv = manv;
            InitializeComponent();
        }




        private string manv;

        private void frmDangkyPhongban_Load(object sender, EventArgs e)
        {
            loadDSN();
            dgvDSN.Columns["MANHOM"].HeaderText = "Mã nhóm";
            dgvDSN.Columns["MAPHONGBAN"].HeaderText = "Mã phòng ban";
            dgvDSN.Columns["TENPHONGBAN"].HeaderText = "Tên phòng ban";
            dgvDSN.Columns["SOLUONG"].HeaderText = "Số lượng";
            dgvDSN.Columns["qli"].HeaderText = "Quản lý";
        }
        private void loadDSN()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@manhanvien",
                value = manv
            });

            dgvDSN.DataSource = new Database().selectData("dsNhomChuaDKy",lstPara);
        }

        private void dgvDSN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSN.Rows[e.RowIndex].Index >= 0)
            {
                if (
                    DialogResult.Yes == MessageBox.Show(
                    "Bạn muốn đăng ký phòng: " + dgvDSN.Rows[e.RowIndex].Cells["tenphongban"].Value.ToString(),
                    "Xác nhận đăng ký",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  )
                {
                    List<CustomParameter> lstPara = new List<CustomParameter>();
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@manhanvien",
                        value = manv
                    });
                    lstPara.Add(new CustomParameter()
                    {
                        key = "@manhom",
                        value = dgvDSN.Rows[e.RowIndex].Cells["MANHOM"].Value.ToString()
                    });
                    var rs = new Database().ExecCute("[dylam]", lstPara);
                    if (rs == -1)
                    {
                        MessageBox.Show("Phòng ban này bạn đã đăng ký");
                        return;
                    }
                    if (rs == -1)
                    {
                        MessageBox.Show("Đã đăng ký phòng ban thành công!");
                        loadDSN();
                    }

                }
            }
        }
    }
}
