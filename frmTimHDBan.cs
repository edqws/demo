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
    public partial class frmTimHDBan : Form
    {
        public frmTimHDBan(string mahd)
        {
            this.mahd = mahd;
            InitializeComponent();
        }
        
        private string mahd;
        private Database db;
        private string nguoithuchien = "admin";
        private string tukhoa = "";
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmTimHDBan_Load(object sender, EventArgs e)
        {
            loadDSHDB();

            db = new Database();
            List<CustomParameter> lst = new List<CustomParameter>()
                   {
                       new CustomParameter()
                       {
                           key = "@tukhoa",
                           value = ""
                       }
                   };

            

            cbbMaNhanVien.DataSource = db.selectData("SelectAllNhanVien", lst);
            cbbMaNhanVien.DisplayMember = "MANHANVIEN";
           // cbbMaNhanVien.ValueMember = "TEN";
            cbbMaNhanVien.SelectedIndex = -1;
            cbbTenNhanVien.DataSource = db.selectData("SelectAllNhanVien", lst);
            cbbTenNhanVien.DisplayMember = "TEN";
            cbbTenNhanVien.ValueMember = "MANHANVIEN";
            cbbTenNhanVien.SelectedIndex = -1;
            //KHÁCH HÀNG


            cbbMaKhachHang.DataSource = db.selectData("SelectAllKhachHang", lst);
            cbbMaKhachHang.DisplayMember = "makhachhang";
           // cbbTenNhanVien.ValueMember = "ten";
            cbbMaKhachHang.SelectedIndex = -1;
            cbbTenKhachHang.DataSource = db.selectData("SelectAllKhachHang", lst);
            cbbTenKhachHang.DisplayMember = "ten";
            cbbTenKhachHang.ValueMember = "makhachhang";
            cbbTenKhachHang.SelectedIndex = -1;

            // dịch vụ

            cbbMaDichVu.DataSource = db.selectData("SelectAllHang", lst);
            cbbMaDichVu.DisplayMember = "madichvu";
            cbbMaDichVu.ValueMember = "TenDichVu";
            cbbMaDichVu.SelectedIndex = -1;
            cbbTenDichVu.DataSource = db.selectData("SelectAllHang", lst);
            cbbTenDichVu.DisplayMember = "TenDichVu";
            cbbTenDichVu.ValueMember = "madichvu";
            cbbTenDichVu.SelectedIndex = -1;

            

            if (string.IsNullOrEmpty(mahd))
            {
                this.Text = "Thêm Hóa Đơn Mới";
            }
            else
            {
                this.Text = "Cập nhật Hóa Đơn";
                var r = db.select("exec SELECTtblHD'" + mahd + "'");

            //    cbbMaNhanVien.SelectedValue = r["MANHANVIEN"].ToString();
               // cbbTenNhanVien.SelectedValue = r["TEN"].ToString();
//cbbMaKhachHang.SelectedValue = r["makhachhang"].ToString();
 //               cbbTenKhachHang.SelectedValue = r["ten"].ToString();
//cbbTenDichVu.SelectedValue = r["TenDichVu"].ToString();
              //  cbbMaDichVu.SelectedValue = r["madichvu"].ToString();

            }
        }

        private void loadDSHDB()
        {
            string sql = "allhd";
            List<CustomParameter> lstPara = new List<CustomParameter>()
                   {
                       new CustomParameter()
                       {
                           key = "@tukhoa",
                           value = tukhoa
                       }
                   };
            dgvHDBanHang.DataSource = new Database().selectData(sql, lstPara);
        }

        private void dgvHDBanHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void txtThKhoa_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmTimHDBan(null).ShowDialog();
            loadDSHDB();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTuKhoa.Text;
            loadDSHDB();
        }

        private void dgvHDBanHang_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                new frmHDBanHang(dgvHDBanHang.Rows[e.RowIndex].Cells["MaHDBan"].Value.ToString()).ShowDialog();
                loadDSHDB();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";

           
            if (cbbDonGia.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đơn giá");
                return;
            }
            if (cbbGiamGia.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu giảm giá");
                return;
            }
            if (cbbMaDichVu.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn mã dịch vụ");
                return;
            }
            if (cbbMaKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn mã khách hàng");
                return;
            }
            if (cbbMaNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên");
                return;
            }
            if (cbbTenDichVu.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ");
                return;
            }
            if (cbbTenKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng");
                return;
            }
            if (cbbTenNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên");
                return;
            }
          

            List<CustomParameter> lst = new List<CustomParameter>();

            if (string.IsNullOrEmpty(mahd))
            {
                sql = "insertHD";
                lst.Add(new CustomParameter()
                {
                    key = "@nguoitao",
                    value = nguoithuchien
                });
            }
            else
            {
                sql = "updateHD";
                lst.Add(new CustomParameter()
                {
                    key = "@nguoicapnhat",
                    value = nguoithuchien
                });
                lst.Add(new CustomParameter()
                {
                    key = "@MaHDBan",
                    value = mahd
                });

                lst.Add(new CustomParameter()
                {
                    key = "@SoLuong",
                    value = txtSoLuong.Text
                });

                lst.Add(new CustomParameter()
                {
                    key = "@DonGia",
                    value = cbbDonGia.Text
                    // lấy giá trị được chọn của conbobox quản lí
                });

                lst.Add(new CustomParameter()
                {
                    key = "@makhachhang",
                    value = cbbMaKhachHang.SelectedValue.ToString()
                });
                lst.Add(new CustomParameter()
                {
                    key = "@manhanvien",
                    value = cbbMaNhanVien.SelectedValue.ToString()
                });
                lst.Add(new CustomParameter()
                {
                    key = "@MaDichvu",
                    value = cbbMaDichVu.SelectedValue.ToString()
                });
                lst.Add(new CustomParameter()
                {
                    key = "@GiamGia",
                    value = cbbGiamGia.Text
                });

            }
            var kq = db.ExecCute(sql, lst);
            if (kq == 1)
            {
                if (string.IsNullOrEmpty(mahd))
                {
                    MessageBox.Show("Thêm mới hóa đơn thành công");

                }
                else
                {
                    MessageBox.Show("câp nhật hóa đơn thành công");
                }
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Lưu dữ liệu thất bại");
            }
        }
    }
}
