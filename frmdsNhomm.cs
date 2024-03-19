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
    public partial class frmdsNhomm : Form
    {
        public frmdsNhomm()
        {
            InitializeComponent();
        }
        private string tukhoa = "";
        private void frmdsNhomm_Load(object sender, EventArgs e)
        {
            loadDSN();
            dgvnhom.Columns["MANHOM"].HeaderText = "Mã nhóm";
            dgvnhom.Columns["ql"].HeaderText = "Quản lý";
            dgvnhom.Columns["TENPHONGBAN"].HeaderText = "Tên phòng ban";
        }
        private void loadDSN()
        {
            string sql = "allNhom";
            List<CustomParameter> lstPara = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@tukhoa",
                    value = tukhoa
                }
            };
            dgvnhom.DataSource = new Database().selectData(sql,lstPara);

        }

        private void btnTiemKiem_Click_1(object sender, EventArgs e)
        {
            tukhoa = txtTimKiem.Text;
            loadDSN();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            new frmNhomn(null).ShowDialog();
            loadDSN();
        }

        private void dgvnhom_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                new frmNhomn(dgvnhom.Rows[e.RowIndex].Cells["manhom"].Value.ToString()).ShowDialog();
                loadDSN() ;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvnhom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTiemKiem_Click(object sender, EventArgs e)
        {

        }

        private void dgvnhom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                new frmNhomn(dgvnhom.Rows[e.RowIndex].Cells["manhom"].Value.ToString()).ShowDialog();
                loadDSN();
            }
        }
    }
}
