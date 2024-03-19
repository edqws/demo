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
    public partial class frmHDBanHang : Form
    {
        public frmHDBanHang(string mahd)
        {
            this.mahd = mahd;
            InitializeComponent();
        }
        private string mahd;
               private Database db;
               private string nguoithuchien = "admin";
               private string tukhoa = "";
               private void frmHDBanHang_Load(object sender, EventArgs e)
               {
                  
               }
               private void panel2_Paint(object sender, PaintEventArgs e)
               {

               }

               private void button2_Click(object sender, EventArgs e)
               {
                  
               }

               private void label18_Click(object sender, EventArgs e)
               {

               }

               private void btnThem_Click(object sender, EventArgs e)
               {
                   new frmNhomn(null).ShowDialog();
                   loadDSHD();
               }

               private void btnTimKiem_Click(object sender, EventArgs e)
               {
                   
               }
               private void loadDSHD()
               {
                   
               }

               private void dgvHDBanHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
               {
                   
               }

               private void panel3_Paint(object sender, PaintEventArgs e)
               {

               }

               private void cbbTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
               {

               }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void cbbDonGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbMaDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dgvHDBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbDienThoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbDiaChi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
        
    }
