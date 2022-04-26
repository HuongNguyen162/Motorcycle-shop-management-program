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
    public partial class frmPhuTung : Form
    {
        public frmPhuTung()
        {
            InitializeComponent();
        }

        private DataTable tblPhutung = new DataTable();

        private void frmPhuTung_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            frmPhuTung f = new frmPhuTung();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowInTaskbar = false;
            try
            {
                LoadDtgv();
                txtMaPT.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                cboMaxe.DropDownStyle = ComboBoxStyle.DropDownList;
                DAO.FillCombo("Select MaLoai from LoaiXe", cboMaxe, "MaLoai", "TenLoai");
                cboMaxe.SelectedIndex = -1;
                reset_value();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Xuất hiện lỗi");
            }
        }

        private void LoadDtgv()
        {
            string sql = "Select * from PhuTung ";
            tblPhutung = DAO.GetDataToTable(sql);
            dgv_PhuTung.DataSource = tblPhutung;
            dgv_PhuTung.Columns[0].HeaderText = "Mã phụ tùng";
            dgv_PhuTung.Columns[1].HeaderText = "Tên phụ tùng";
            dgv_PhuTung.Columns[2].HeaderText = "Số lượng";
            dgv_PhuTung.Columns[3].HeaderText = "Đơn giá nhập";
            dgv_PhuTung.Columns[4].HeaderText = "Đơn giá bán";
            dgv_PhuTung.Columns[5].HeaderText = "Mã loại xe";
            dgv_PhuTung.Columns[0].Width = 100;
            dgv_PhuTung.Columns[1].Width = 100;
            dgv_PhuTung.Columns[2].Width = 50;
            dgv_PhuTung.Columns[3].Width = 100;
            dgv_PhuTung.Columns[4].Width = 100;
            dgv_PhuTung.Columns[5].Width = 80;
            dgv_PhuTung.AllowUserToAddRows = false;
            dgv_PhuTung.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void reset_value()
        {
            txtMaPT.Text = "";
            txtTenPT.Text = "";
            txtSoluong.Text = "0";
            txtGiaban.Text = "0";
            txtGianhap.Text = "0";
            cboMaxe.Text = "";
        }

        private void dgv_PhuTung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPT.Text = dgv_PhuTung.CurrentRow.Cells[0].Value.ToString();
            txtTenPT.Text = dgv_PhuTung.CurrentRow.Cells[1].Value.ToString();
            txtSoluong.Text = dgv_PhuTung.CurrentRow.Cells[2].Value.ToString();
            txtGianhap.Text = dgv_PhuTung.CurrentRow.Cells[3].Value.ToString();
            txtGiaban.Text = dgv_PhuTung.CurrentRow.Cells[4].Value.ToString();
            cboMaxe.Text = dgv_PhuTung.CurrentRow.Cells[5].Value.ToString();
            txtMaPT.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            reset_value();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMaPT.Enabled = true;
            txtMaPT.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            string MaPT = txtMaPT.Text.Trim();
            string TenPT = txtTenPT.Text.Trim();
            string SoLuong = txtSoluong.Text;

            if (dgv_PhuTung.RowCount == 0)
            {
                MessageBox.Show("Bảng không có dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMaPT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bản ghi muốn sửa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtTenPT.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên phụ tùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPT.Focus();
                return;
            }
            if (cboMaxe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã loại xe phù hợp với phụ tùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaxe.Focus();
                return;
            }
            sql = "Update PhuTung set TenPhuTung = N'" + TenPT + "',SoLuong = N'" + SoLuong + "',MaLoai = N'" + cboMaxe.SelectedValue.ToString() + "',DonGiaNhap = N'" + txtGianhap.Text.Trim() + "',DonGiaBan = N'" + txtGiaban.Text.Trim() + "' where MaPhuTung = N'" + MaPT + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dữ liệu được sửa thành công");
                DAO.RunSql(sql);
                LoadDtgv();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
                btnLuu.Enabled = true;
                reset_value();
                txtMaPT.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể sửa dữ liệu do lỗi" + ex.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaPT = txtMaPT.Text.Trim();
            string sql = "Delete PhuTung where MaPhuTung = N'" + MaPT + "'";
            if (dgv_PhuTung.RowCount == 0)
            {
                MessageBox.Show("Bảng không có dữ liệu để xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMaPT.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bản ghi muốn xóa", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dữ liệu được xóa thành công");
                LoadDtgv();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
                txtMaPT.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa dữ liệu do lỗi" + ex.ToString());
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaPT.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã phụ tùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPT.Focus();
                return;
            }
            if (txtTenPT.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên phụ tùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPT.Focus();
                return;
            }
            if (cboMaxe.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã loại xe phù hợp với phụ tùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaxe.Focus();
                return;
            }

            sql = "Select MaPhuTung from PhuTung where MaPhuTung = N'" + txtMaPT.Text.Trim() + "'";
            if (DAO.CheckKey(sql))
            {
                MessageBox.Show("Mã phụ tùng đã tồn tại, vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPT.Text = "PT";
                txtMaPT.Focus();
                return;
            }
            sql = "Insert into PhuTung values(N'" + txtMaPT.Text.Trim() + "',N'" + txtTenPT.Text.Trim() + "',N'" + txtSoluong.Text.Trim() + "',N'" + txtGianhap.Text + "',N'" + txtGiaban.Text + "',N'" + cboMaxe.SelectedValue.ToString() + "')";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dữ liệu được thêm mới thành công");
                LoadDtgv();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnHuy.Enabled = true;
                txtMaPT.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể chèn dữ liệu do lỗi" + ex.ToString());
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            reset_value();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                DAO.CloseConnection();
                this.Close();
            }
        }

        private void txtGianhap_TextChanged(object sender, EventArgs e)
        {
            double dgn, dgb;
            if (txtGianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(txtGianhap.Text);
            dgb = dgn * 1.1;
            txtGiaban.Text = dgb.ToString();
        }


















    }
}
