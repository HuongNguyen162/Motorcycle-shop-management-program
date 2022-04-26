using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using IS11A03_Nhom07_QuanLySuaXe;

namespace IS11A03_Nhom07_QuanLySuaXe
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void loaddulieu()
        {
            try
            {
                DAO.OpenConnection();
                string sql = "select makhach, tenkhach, diachi, dienthoai from KhachHang";
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
                DataTable KhachHang = new DataTable();
                mydata.Fill(KhachHang);
                dgvKhachHang.DataSource = KhachHang;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" lỗi: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }

        private void xoatextbox()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtDienThoai.Text = dgvKhachHang.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
        }   

        private void btnThem_Click(object sender, EventArgs e)
        {
            xoatextbox();
            btnThem.Enabled = false;
            txtMaKH.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã khách hàng cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }

            if (txtDienThoai.Text.Trim() == "")
            {
                MessageBox.Show("Nhập số điện thoại cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDienThoai.Focus();
                return;

            }
            if (txtTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Nhập tên khách hàng cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;

            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Nhập địa chỉ cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;

            }
            string sql = "update KhachHang set tenkhach = N'" + txtTenKH.Text.Trim() + "', dienthoai = '" + txtDienThoai.Text.Trim() +
                "', diachi = '" + txtDiaChi.Text.Trim() + "'  where makhach = '" + txtMaKH.Text.Trim() + "'";


            try
            {
                DAO.RunSql(sql); 
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loaddulieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Thao tác không thể phục hồi, bạn chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE KhachHang where makhach = N'" + txtMaKH.Text.Trim() + "'";
                DAO.RunSql(sql); 
                loaddulieu();
                xoatextbox();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaKH.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK);
                txtMaKH.Focus();
                return;
            }

            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK);
                txtDiaChi.Focus();
                return;
            }
            if (txtDienThoai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập điện thoại!", "Thông báo", MessageBoxButtons.OK);
                txtDienThoai.Focus();
                return;
            }
            sql = "insert into KhachHang(makhach, tenkhach,  diachi, dienthoai) values (N'" + txtMaKH.Text.Trim()
               + "', N'" + txtTenKH.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "', N'" + txtDienThoai.Text.Trim() + "')";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loaddulieu();
            btnThem.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    DAO.CloseConnection();
                        this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

          
    }
}
