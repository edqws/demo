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
    public partial class frmDSPB : Form
    {
        public frmDSPB()
        {
            InitializeComponent();
        }

        private void dgvDSPB_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var mpb = dgvDSPB.Rows[e.RowIndex].Cells["maphongban"].Value.ToString();
                new frmPhongBan(mpb).ShowDialog();
                loadDSPB();

            }
        }


        private string tukhoa = "";

        private void btnThemmoi_Click_1(object sender, EventArgs e)
        {
            new frmPhongBan(null).ShowDialog();
            loadDSPB();
        }
        private void loadDSPB()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            });
            dgvDSPB.DataSource = new Database().selectData("selectAllphongBan", lstPara);
        }

        private void frmDSPB_Load(object sender, EventArgs e)
        {
            loadDSPB();
            dgvDSPB.Columns["maphongban"].HeaderText = "Mã PB";
            dgvDSPB.Columns["tenphongban"].HeaderText = "Tên phòng ban";
            dgvDSPB.Columns["soluong"].HeaderText = "Số lượng";

        }

        private void btnTimkiem_Click_1(object sender, EventArgs e)
        {
            tukhoa = txtTimkiem.Text;
            loadDSPB();
        }

        private void dgvDSPB_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

        }

        private void dgvDSPB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var mpb = dgvDSPB.Rows[e.RowIndex].Cells["maphongban"].Value.ToString();
                new frmPhongBan(mpb).ShowDialog();
                loadDSPB();

            }
        }
    }
}
