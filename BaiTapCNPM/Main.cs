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

namespace BaiTapCNPM
{
    public partial class Main : Form
    {
        Database db = new Database();
        SinhVienBUS svb = new SinhVienBUS();
        public Main(string taikhoan)
        {
            InitializeComponent();
            DataTable dt = db.Execute("Select * from ACCOUNT where taikhoan = '" + taikhoan + "'");
            int quyen = Convert.ToInt32(dt.Rows[0]["quyen"]);
            if (quyen == 1)
            {
                txtName.Enabled = false;
                txtLop.Enabled =  false;
                cbKhoa.Enabled = false;
                dtpBirth.Enabled = false;
                txtMSSV.Enabled = false;
                txtEmail.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
        }
        public void DataGrid(DataTable dt)
        {
            dtgSV.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtgSV.Rows.Add();
                dtgSV.Rows[i].Cells[0].Value = dt.Rows[i][0];
                dtgSV.Rows[i].Cells[1].Value = dt.Rows[i][1];
                dtgSV.Rows[i].Cells[2].Value = dt.Rows[i][2];
                dtgSV.Rows[i].Cells[3].Value = dt.Rows[i][3];
                dtgSV.Rows[i].Cells[4].Value = dt.Rows[i][4];
                dtgSV.Rows[i].Cells[5].Value = DateTime.Parse(dt.Rows[i][5].ToString()).ToString("dd-MM-yyyy");
            }
        }
        private void ResetGrid()
        {
            txtName.Text = "";
            txtLop.Text = "";
            cbKhoa.Text = "";
            dtpBirth.ResetText();
            txtMSSV.Text = "";
            txtEmail.Text = "";
        }
        private void dtgSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dtgSV.Rows[e.RowIndex];
            if (row != null)
            {
                txtName.Text = row.Cells[0].Value.ToString();
                txtLop.Text = row.Cells[1].Value.ToString();
                cbKhoa.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtMSSV.Enabled = false;
                txtMSSV.Text = row.Cells[4].Value.ToString();
                DateTime namsinh = DateTime.ParseExact(row.Cells[5].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                dtpBirth.Value = namsinh;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            DataTable dt = svb.getList();
            DataGrid(dt);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv =new SinhVien();
            sv.HoTen = txtName.Text;
            sv.Lop = txtLop.Text;
            sv.Khoa = cbKhoa.SelectedItem.ToString();
            sv.MSSV = txtMSSV.Text;
            sv.Email= txtEmail.Text;
            sv.NamSinh = dtpBirth.Value.Date;
            int check = svb.Them(sv);
            if (check == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else if (check == -1)
            {
                MessageBox.Show("Đã tồn tại sinh viên!");
            }
            else MessageBox.Show("Thêm sinh viên thành công!");
            Main_Load(sender, e);
            ResetGrid();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            svb.Xoa(txtMSSV.Text);
            MessageBox.Show("Xóa sinh viên thành công!");
            Main_Load(sender, e);
            ResetGrid();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.HoTen = txtName.Text;
            sv.Lop = txtLop.Text;
            sv.Khoa = cbKhoa.SelectedItem.ToString();
            sv.Email = txtEmail.Text;
            sv.MSSV = txtMSSV.Text;
            sv.NamSinh = dtpBirth.Value.Date;
            bool check = svb.Sua(sv);
            if (!check)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else MessageBox.Show("Sửa sinh viên thành công!");
            Main_Load(sender, e);
            ResetGrid();
        }
    }
}
