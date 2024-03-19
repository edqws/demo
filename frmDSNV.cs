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
    public partial class frmDSNV : Form
    {
        public frmDSNV()
        {
            InitializeComponent();
        }
        private string TuKhoa = "";
        private void frmDSNV_Load(object sender, EventArgs e)
        {
           LoadDSNV();// gọi tới hàm load nhan viên khi form dược load
        }

        private void LoadDSNV()
        {
            // load toàn bộ danh sách sinh viên khi form được load
            
            // khai báo list customparameter 
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
               key = "@TuKhoa",
               value = TuKhoa
            });
 
            dgvNhanVien.DataSource = new Database().selectData("SelectAllNhanVien", lstPara);
            //đặt tên cột
            dgvNhanVien.Columns["manhanvien"].HeaderText = "Mã NV";
            dgvNhanVien.Columns["HOTEN"].HeaderText = "Họ Tên";
            dgvNhanVien.Columns["nsinh"].HeaderText = "Ngày sinh";
          //  dgvNhanVien.Columns[""].HeaderText = "Giới tính";
            dgvNhanVien.Columns["QUEQUAN"].HeaderText = "Quê quán";
            dgvNhanVien.Columns["DIACHI"].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns["EMAIL"].HeaderText = "Email";
            dgvNhanVien.Columns["DIENTHOAI"].HeaderText = "Điện Thoại";
        }
        private void dgvNhanVien_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // khi double click vào nhân viên trên datagridview sẽ hiện ra form để cập nhật nhân viên
            if(e.RowIndex>=0)
            {
                var mnv = dgvNhanVien.Rows[e.RowIndex].Cells["MANHANVIEN"].Value.ToString();
                new frmNhanVien(mnv).ShowDialog();
                LoadDSNV();
            }    
        }

     

        private void btnThemmoi_Click_1(object sender, EventArgs e)
        {
            new frmNhanVien(null).ShowDialog();// nếu thêm mới nhân viên -> mã nhân viên = null
            LoadDSNV();// load lại danh sách sinh viên khi thêm thành công
        }

        private void txtTukhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTiemKiem_Click_1(object sender, EventArgs e)
        {
           
            TuKhoa = txtTukhoa.Text;
                 LoadDSNV();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTiemKiem_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
