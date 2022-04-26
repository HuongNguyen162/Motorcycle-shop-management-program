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
    public partial class frmTimKiemPhuTung : Form
    {
        public frmTimKiemPhuTung()
        {
            InitializeComponent();
        }

        private DataTable tblPhutung = new DataTable();
        private void frmTimKiemPhuTung_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            frmTimKiemPhuTung f = new frmTimKiemPhuTung();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowInTaskbar = false;
            try
            {
                cboMaLoaiXe.DropDownStyle = ComboBoxStyle.DropDownList;
                DAO.FillCombo("Select distinct MaLoai from PhuTung", cboMaLoaiXe, "MaLoai", "TenLoai");
                cboMaLoaiXe.SelectedIndex = -1;
                reset_value();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Xuất hiện lỗi");
            }
        }
        private void reset_value()
        {
            cboMaLoaiXe.Text = "";
            txtTenPT.Text = "";
            txtSoluong.Text = "0";
        }

        private void LoadDtgv()
        {
            string sql = "Select * from PhuTung ";
            tblPhutung = DAO.GetDataToTable(sql);
            dgv_TimKiemPT.DataSource = tblPhutung;
            dgv_TimKiemPT.Columns[0].HeaderText = "Mã phụ tùng";
            dgv_TimKiemPT.Columns[1].HeaderText = "Tên phụ tùng";
            dgv_TimKiemPT.Columns[2].HeaderText = "Số lượng";
            dgv_TimKiemPT.Columns[3].HeaderText = "Đơn giá nhập";
            dgv_TimKiemPT.Columns[4].HeaderText = "Đơn giá bán";
            dgv_TimKiemPT.Columns[5].HeaderText = "Mã loại xe";
            dgv_TimKiemPT.Columns[0].Width = 70;
            dgv_TimKiemPT.Columns[1].Width = 70;
            dgv_TimKiemPT.Columns[2].Width = 50;
            dgv_TimKiemPT.Columns[3].Width = 100;
            dgv_TimKiemPT.Columns[4].Width = 100;
            dgv_TimKiemPT.Columns[5].Width = 80;
            dgv_TimKiemPT.AllowUserToAddRows = false;
            dgv_TimKiemPT.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgv_TimKiemPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenPT.Text = dgv_TimKiemPT.CurrentRow.Cells[1].Value.ToString();
            txtSoluong.Text = dgv_TimKiemPT.CurrentRow.Cells[2].Value.ToString();
            cboMaLoaiXe.Text = dgv_TimKiemPT.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if ((cboMaLoaiXe.Text == "") && (txtSoluong.Text == "0") && (txtTenPT.Text == ""))
            {
                MessageBox.Show("Hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "Select * from PhuTung where 1=1";
            if (txtTenPT.Text != "")
            {
                sql = sql + "and TenPhuTung = N'" + txtTenPT.Text.Trim() + "'";
                tblPhutung = DAO.GetDataToTable(sql);

            }
            if (txtSoluong.Text != "0")
            {
                sql = sql + "and SoLuong = N'" + txtSoluong.Text.Trim() + "'";
                tblPhutung = DAO.GetDataToTable(sql);

            }
            if (cboMaLoaiXe.Text != "")
            {
                sql = sql + "and MaLoai = N'" + cboMaLoaiXe.Text.Trim() + "'";
                tblPhutung = DAO.GetDataToTable(sql);

            }
            if (tblPhutung.Rows.Count == 0)
            {
                MessageBox.Show("Không có phụ tùng thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblPhutung.Rows.Count + " phụ tùng thỏa mãn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv_TimKiemPT.DataSource = tblPhutung;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            reset_value();
            dgv_TimKiemPT.DataSource = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                DAO.CloseConnection();
                this.Close();
            }
        }






        



    }
}
