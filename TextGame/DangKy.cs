using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace TextGame
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtDKMatKhau.Text != txtDKNhapLai.Text)
            {
                MessageBox.Show("Bạn đã nhập sai ô xác nhận mật khẩu. Xin hãy nhập lại ! ");
            }
            else
            {
                SqlConnection sqlcon = new SqlConnection("Server=LAPTOP-DGVEHGH0\\SQLEXPRESS02;Database=MyGameCaro; uid=sa; pwd=sa");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                MD5 md = MD5.Create();
                byte[] inputstr = System.Text.Encoding.ASCII.GetBytes(txtDKMatKhau.Text);
                byte[] hash = md.ComputeHash(inputstr);
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X"));
                }

                cmd.CommandText = "insert into DangNhap values (@TaiKhoan,@MatKhau)";
                cmd.Parameters.AddWithValue("@TaiKhoan", txtDKTaiKhoan.Text);
                cmd.Parameters.AddWithValue("@MatKhau", sb.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ban đã đăng ký thành công ");
                this.Close();

            }
        }
    }
}
