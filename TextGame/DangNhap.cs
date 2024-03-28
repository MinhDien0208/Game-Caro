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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection("Server=LAPTOP-DGVEHGH0\\SQLEXPRESS02;Database=MyGameCaro; uid=sa; pwd=sa");
            sqlcon.Open();
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            // Mã hóa tài khoản 
            MD5 md = MD5.Create();
            byte[] inputstr = System.Text.Encoding.ASCII.GetBytes(txtMatKhau.Text);
            byte[] hash = md.ComputeHash(inputstr);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X"));
            }
            
            if (tk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                return;
            }else if (mk.Trim() == "")
            {
                MessageBox.Show("Vui long nhập mật khẩu!");
                return; 
            } else  {
                string sql = "select * from DangNhap where TaiKhoan = '" + tk + "' and MatKhau = '" + sb.ToString() + "' ";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                SqlDataReader dta = cmd.ExecuteReader();
                try
                {
                    
                    if (dta.Read() == true)
                    {
                        ChessBoardManagerCom.getaccount = tk;
                        frmHome f = new frmHome();
                        this.Hide();
                        f.ShowDialog();

                    }
                    else MessageBox.Show("Bạn đã nhập sai tài khoản hoặc mật khẩu. Xin hãy nhập lại! ");
                }
                catch
                {
                    MessageBox.Show("Loi");
                }
            }
        }
        private void ckHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if(ckHienThi.Checked == true)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dk = new DangKy();
            dk.ShowDialog();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
