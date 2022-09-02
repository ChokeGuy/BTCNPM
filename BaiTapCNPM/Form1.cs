using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapCNPM
{
    public partial class DN : Form
    {
        AccountBus acc = new AccountBus();
        public DN()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDK2_Click(object sender, EventArgs e)
        {
            Account tk = new Account();
            tk.TaiKhoan = txtDKTK.Text;
            tk.MatKhau = txtDKMK.Text;
            tk.NLMatKhau = txtNLMK.Text;
            int status= acc.Dangky(tk);
            if (status== -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                txtDKTK.Text = "";
                txtDKMK.Text = "";
                txtNLMK.Text = "";
            }
            else if (status == -2)
            {
                MessageBox.Show("Không trùng khớp mật khẩu!");
                txtDKMK.Text = "";
                txtNLMK.Text = "";
            }
            else if (status == 1)
            {
                txtTK.Text = tk.TaiKhoan;
                txtMK.Text = tk.MatKhau;
                MessageBox.Show("Đăng ký thành công!");
                grbDK.Visible = false;
                grbDN.Visible = true;
            }
            else 
            {
                MessageBox.Show("Đã tồn tại account!");
                txtDKTK.Text = "";
                txtDKMK.Text = "";
                txtNLMK.Text = "";
            }
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            grbDK.Visible = true;
            txtDKTK.Text = "";
            txtDKMK.Text = "";
            txtNLMK.Text = "";
            //grbDN.Visible = false;            
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (acc.DangNhap(txtTK.Text, txtMK.Text))
            {
                this.Visible = false;
                Main QLSV = new Main(txtTK.Text);
                QLSV.ShowDialog();
            }
            else
            {
                if (txtTK.Text.Length == 0 || txtMK.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập tài khoản mật khẩu!");
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
                    txtMK.Text = "";
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            grbDK.Visible = false;
            grbDN.Visible= true;
        }

        private void DN_Load(object sender, EventArgs e)
        {

        }

        private void DN_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void grbDK_Enter(object sender, EventArgs e)
        {

        }
    }
}
