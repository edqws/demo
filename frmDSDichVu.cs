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
    public partial class frmDSDichVu : Form
    {
        public frmDSDichVu()
        {
            InitializeComponent();
        }

        private void txtTukhoa_TextChanged(object sender, EventArgs e)
        {
         
           
        }

        private void frmDSDichVu_Load(object sender, EventArgs e)
        {
            loadDichVu();
            dgvDichVu.Columns["MaDichVu"].HeaderText = "Mã dịch vụ";
            dgvDichVu.Columns["TenDichVu"].HeaderText = "Tên Dịch Vụ";
            dgvDichVu.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvDichVu.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvDichVu.Columns["GhiChu"].HeaderText = "Ghi chú";
           
        }
        private string tukhoa = "";
        private void loadDichVu()
        {
            string sql = "SelectAllDichVu";
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvDichVu.DataSource = new Database().selectData(sql, lstPara);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            new frmDichVu(null).ShowDialog();
            loadDichVu();
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            tukhoa = txtTimKiem.Text;
            loadDichVu();
        }

        private void dgvDichVu_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                var mdv = dgvDichVu.Rows[e.RowIndex].Cells["madichvu"].Value.ToString();
                new frmDichVu(mdv).ShowDialog();
                loadDichVu();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDichVu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                var mdv = dgvDichVu.Rows[e.RowIndex].Cells["madichvu"].Value.ToString();
                new frmDichVu(mdv).ShowDialog();
                loadDichVu();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            new frmDichVu(null).ShowDialog();
            loadDichVu();

        }
    }
}
