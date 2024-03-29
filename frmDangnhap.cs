﻿using System;
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
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
        }
        public string tendangnhap= "";
        public string loaitk;
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            #region ktra_rbuoc
            // kiểm tra ràng buộc 
            if (cbbLoaiTaiKhoan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản !");
                return;
            }
            if(string.IsNullOrEmpty(txtTendangnhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản !","Tài khoản không được để trống ");
                txtTendangnhap.Select();
                return;
            }    
            if(string.IsNullOrEmpty(txtMatkhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu !","Mật khẩu không được để trống");
            }
            #endregion


            tendangnhap = txtTendangnhap.Text;
            loaitk = "";
            #region swtk

            switch (cbbLoaiTaiKhoan.Text)
            {
                case "Quản trị viên":
                    loaitk = "admin";
                    break;
                case "Quản lý":
                    loaitk = "ql";
                    break;
                case "Nhân viên":
                    loaitk = "nv";
                    break;

            }


            #endregion



            List<CustomParameter> lst = new List<CustomParameter>()
            {

            new CustomParameter()
            {
                key = "@loaitaikhoan",
                value =loaitk
            },
             new CustomParameter()
            {
                key = "@taikhoan",
                value =txtTendangnhap.Text
            },
              new CustomParameter()
            {
                key = "@matkhau",
                value =txtMatkhau.Text
            },

            };



            var rs = new Database().selectData("dangnhap", lst);
            if (rs.Rows.Count>0)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu","Tài khoản hoặc mật khẩu không hợp lệ !");
            }
           

        }

        private void cbbLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

        }
    }
}
