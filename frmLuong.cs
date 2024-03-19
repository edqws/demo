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
    public partial class frmLuong : Form
    {
        public frmLuong(string mnv) // truyền mã nhân viên
        {
            this.mnv = mnv;
            InitializeComponent();
        }
        private string mnv;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadL();
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            loadL();
            dgvL.Columns["MAPHONGBAN"].HeaderText = "Mã phòng ban";
            dgvL.Columns["TENPHONGBAN"].HeaderText = "Tên phòng ban";
            dgvL.Columns["LANLAM"].HeaderText = "lần làm";
            dgvL.Columns["qli"].HeaderText = "Quản lý";
            dgvL.Columns["LUONG1"].HeaderText = "Lương cơ bản";
            dgvL.Columns["LUONG2"].HeaderText = "Phụ cấp";
        }
        private void loadL()
        {
            
            List<CustomParameter>lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@manhanvien",
                value = mnv   // mã nhân viên đã được truyền vào from

            }
                );
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = txtTukhoa.Text   // mã nhân viên đã được truyền vào from

            }
               );
            dgvL.DataSource = new Database().selectData("tracuuluong", lstPara);
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            loadL();
        }

        private void dgvL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTukhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
