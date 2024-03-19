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
    public partial class frmDSQL : Form
    {
        public frmDSQL()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmQL(null).ShowDialog();
            loadDSQL();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }
        private string tukhoa = "";
        private void loadDSQL()
        {
            string sql = "selectAllQL";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvDSQL.DataSource = new Database().selectData(sql,lstPara);
        }

        private void frmDSQL_Load(object sender, EventArgs e)
        {
            loadDSQL();
            dgvDSQL.Columns["maquanli"].HeaderText = "Mã quản lý";
            dgvDSQL.Columns["hoten"].HeaderText = "Họ tên";
            dgvDSQL.Columns["gt"].HeaderText = "Giới tính";
            dgvDSQL.Columns["dienthoai"].HeaderText = "Điện thoại";
            dgvDSQL.Columns["email"].HeaderText = "Email";
            dgvDSQL.Columns["diachi"].HeaderText = "Địa chỉ";

        }

        private void dgvDSQL_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            tukhoa = txtTimKiem.Text;
            loadDSQL();
        }

        private void dgvDSQL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmQL(null).ShowDialog();
            loadDSQL();
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            tukhoa = txtTimKiem.Text;
            loadDSQL();
        }

        private void dgvDSQL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                var mgv = dgvDSQL.Rows[e.RowIndex].Cells["maquanli"].Value.ToString();
                new frmQL(mgv).ShowDialog();
                loadDSQL();
            }
        }
    }
}
