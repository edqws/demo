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
    public partial class frmKhachhang : Form
    {
        public frmKhachhang()
        {
            InitializeComponent();
        }

         private void btnTimkiem_Click(object sender, EventArgs e)
         {
         
        }
        private string tukhoa = "";
        private void loadKhachhang()
        {
            string sql = "SelectAllKhachHang";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvKhachhang.DataSource = new Database().selectData(sql, lstPara);
        }
        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            loadKhachhang();
            dgvKhachhang.Columns["makhachhang"].HeaderText = "Mã quản lý";
            dgvKhachhang.Columns["hoten"].HeaderText = "Họ tên";
            dgvKhachhang.Columns["gt"].HeaderText = "Giới tính";
            dgvKhachhang.Columns["dienthoai"].HeaderText = "Điện thoại";
            dgvKhachhang.Columns["email"].HeaderText = "Email";
            dgvKhachhang.Columns["diachi"].HeaderText = "Địa chỉ";
        }

        private void dgvKhachhang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                var mkh = dgvKhachhang.Rows[e.RowIndex].Cells["makhachhang"].Value.ToString();
                new frmupdatekh(mkh).ShowDialog();
                loadKhachhang();
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            new frmupdatekh(null).ShowDialog();
            loadKhachhang();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            tukhoa = txtTimKiem.Text;
            loadKhachhang();
        }

        private void dgvKhachhang_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                var mkh = dgvKhachhang.Rows[e.RowIndex].Cells["makhachhang"].Value.ToString();
                new frmupdatekh(mkh).ShowDialog();
                loadKhachhang();
            }
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            tukhoa = txtTimKiem.Text;
            loadKhachhang();
        }

        private void btnThemmoi_Click_1(object sender, EventArgs e)
        {
            new frmupdatekh(null).ShowDialog();
            loadKhachhang();
        }
    }
}
