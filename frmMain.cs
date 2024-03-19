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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private string taikhoan;
        private string loaitk;
        private void frmMain_Load(object sender, EventArgs e)
        {
            var fn = new frmDangnhap();
            fn.ShowDialog();  // cho load from đang nhap khi formain được gọi

            // sau khi form đăng nhập được tắt, lấy tài khoản đã đăng nhập
            taikhoan = fn.tendangnhap;
            loaitk = fn.loaitk;
            if (loaitk.Equals("admin"))
            {
                // nếu la admin
                // ẩn 2 menu tính lương và đăng ký
                // chỉ để lại menu quản lý
                tinhLuongToolStripMenuItem.Visible = false;
                chucNangToolStripMenuItem.Visible = false;
            }
            else
            {
                // nếu không phải admin thì ẩn menu quản lý
                quanLiToolStripMenuItem.Visible = false;
                if (loaitk.Equals("ql"))// nếu là quản lý
                {
                    // ẩn menu đang ký phòng ban --> chỉ danh riêng cho nhân viên

                    chucNangToolStripMenuItem.Visible = false;
                }
                else // chi còn lại trường hợp là nhân viên
                {
                    tinhLuongToolStripMenuItem.Visible = false;
                    quanLyToolStripMenuItem.Visible = false;
                    // ẩn menu tính lương < chức năng của quản lý>








                }

            }


            frmWelcome f = new frmWelcome();
            AddForm(f);
        }

        private void AddForm(Form f)
        {
            this.pnlContent.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.pnlContent.Controls.Add(f);
            f.Show();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSNV f = new frmDSNV();
            AddForm(f);
        }

        private void phòngBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSPB f = new frmDSPB();
            AddForm(f);
        }

        private void quanLiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDSQL f = new frmDSQL();
            AddForm(f);
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void nhomToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void nhomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdsNhomm f = new frmdsNhomm();
            AddForm(f);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dangKyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDsPhongbandadangky(taikhoan);
            AddForm(f);
        }

        private void traCuuLuongToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var f = new frmLuong(taikhoan);
            AddForm(f);

        }

        private void khachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmKhachhang();
            AddForm(f);
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDSDichVu();
            AddForm(f);
        }

        private void tinhLuongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bảngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void traCứuLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmTimHDBan(taikhoan);
            AddForm(f);
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmHDBanHang(taikhoan);
            AddForm(f);
        }
    }
 
}
