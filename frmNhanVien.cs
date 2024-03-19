using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sa
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien(string mnv)
        {
            this.mnv = mnv;// truyền lại mã nhân viên khi form chạy
            InitializeComponent();
        }
        private string mnv;
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mnv))// nếu mnv không có => thêm mới nhân viên
            {
                this.Text = "Thêm nhân viên mới";
            }    
            else
            {
                this.Text = "Cập nhật thông tin nhân viên";
                // lấy thông tin chi tiết của 1 nhân viên dựa vào mnv
                // mnv là mac nhân viên đã được truyền từ form dsnv 
                var r= new Database().select("selectNV '"+mnv+"'");
                //MessageBox.Show(r[0].ToString());// load thành công
                // sét các giá trị vào component cuả from

                txtHo.Text = r["ho"].ToString();
                txtTendem.Text = r["tendem"].ToString();
                txtTen.Text = r["ten"].ToString() ;
                mtbNgaysinh.Text = r["ngsinh"].ToString();
                if (int.Parse(r["GIOITINH"].ToString())==1)
                {
                    rbtNam.Checked = true;
                }
                else
                {
                    rbtNu.Checked = true;
                }
                txtQuequan.Text = r["quequan"].ToString();
                txtDiachi.Text = r["diachi"].ToString();
                txtDienthoai.Text = r["dienthoai"].ToString();
                txtEmail.Text = r["email"].ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            // button btnLuu sẽ sử lý 1 trong 2 tình huống
            // th1 nếu nhân viên không có giá trị=> thêm mới
            // th2 nếu mã nhân viên có giá trị => cập nhật thông tin nhân viên

            string sql = "";
            string ho = txtHo.Text;
            string tendem = txtTendem.Text;
            string ten = txtTen.Text;
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(mtbNgaysinh.Text,"dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch(Exception)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                mtbNgaysinh.Select();// trỏ chuột về mtbNgaysinh
                return;// không thực hiện các caauleenhj phía dươis
            }
            string gioitinh = rbtNam.Checked? "1" : "0";
            string quequan= txtQuequan.Text;
            string diachi = txtDiachi.Text;
            string dienthoai = txtDienthoai.Text;
            string email = txtEmail.Text;

            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(mnv))// nếu thêm mới nhân viên 
            {
                sql = "ThemMoiNV"; // gọi toi procedure thêm mới nhân viên
              
            }
            else // nếu cập nhật nhân viên
            {
                sql = "updateNV";// gọi toiwsprocedure cập nhật nhân viên
                lstPara.Add(new CustomParameter()
                {
                    key = "@manhanvien",
                    value = mnv
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@ho",
                value = ho
            });
              lstPara.Add(new CustomParameter()
              {
                  key = "@tendem",
                  value = tendem
              });
            lstPara.Add(new CustomParameter()
            {
                key = "@Tem",
                  value = ten
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ngaysinh",
                  value = ngaysinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@gioitinh",
                  value = gioitinh
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@quequan",
                  value = quequan
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diachi",
                  value = diachi
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@dienthoai",
                  value = dienthoai
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@email",
                  value = email
            });


            var rs =new Database().ExecCute(sql, lstPara);
            if (rs == 1)
            {
                if (string.IsNullOrEmpty(mnv))
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thành công");
                  
                }
                this.Dispose();// dóng form sau khi thêm/ cn thành công
            }
            else
            {
                MessageBox.Show("thực thi thất bại");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.Dispose();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
