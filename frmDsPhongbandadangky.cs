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
    public partial class frmDsPhongbandadangky : Form
    {
        private string manv;
        public frmDsPhongbandadangky(string manv)
        {
            this.manv = manv;
            InitializeComponent();
          
        }

        private void frmDsPhongbandadangky_Load(object sender, EventArgs e)
        {
            loadPhongDKy();
            dgvDsPBDaDKy.Columns["manhom"].HeaderText = "Mã nhóm";
            dgvDsPBDaDKy.Columns["TENPHONGBAN"].HeaderText = "Tên phòng ban";
            dgvDsPBDaDKy.Columns["SOLUONG"].HeaderText = "Số lượng";
            dgvDsPBDaDKy.Columns["qli"].HeaderText = "Quản lý";

        }
        private void loadPhongDKy()
        {
            List<CustomParameter> lst = new List<CustomParameter>()
            {
                new CustomParameter()
                {
                    key = "@manhanvien",
                    value = manv
                }
               
            };
            dgvDsPBDaDKy.DataSource = new Database().selectData("phongDaDKy", lst);
        }

        private void btnDKyMoi_Click(object sender, EventArgs e)
        {
            new frmDangkyPhongban(manv).ShowDialog();
            loadPhongDKy();
        }
    }
}
