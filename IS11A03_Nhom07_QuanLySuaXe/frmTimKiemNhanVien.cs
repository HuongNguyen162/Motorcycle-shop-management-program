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
    public partial class frmTimKiemNhanVien : Form
    {
        public frmTimKiemNhanVien()
        {
            InitializeComponent();
        }

        private DataTable tblNhanVien = new DataTable();
        private void reset_value()
        {
            txtTenNV.Text = "";
            mskNamSinh.Text = "";
            cboMaTrinhDo.Text = "";
        }


        private void frmTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            frmTimKiemNhanVien f = new frmTimKiemNhanVien();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowInTaskbar = false;

            try
            {

                reset_value();
                Dodulieuvaocombo("Select Tentrinhdo, MaTrinhDo from TrinhDo", cboMaTrinhDo, "Tentrinhdo", "MaTrinhDo");

                cboMaTrinhDo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Xuất hiện lỗi");
            }
        }

        private void LoadDtgv()
        {
            string sql = "Select * from NhanVien";
            tblNhanVien = DAO.GetDataToTable(sql);
            dgvTimKiemNhanVien.DataSource = tblNhanVien;
            dgvTimKiemNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvTimKiemNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvTimKiemNhanVien.Columns[2].HeaderText = "Ngày sinh";
            dgvTimKiemNhanVien.Columns[3].HeaderText = "Mã trình độ";

            dgvTimKiemNhanVien.Columns[0].Width = 70;
            dgvTimKiemNhanVien.Columns[1].Width = 150;
            dgvTimKiemNhanVien.Columns[2].Width = 100;
            dgvTimKiemNhanVien.Columns[3].Width = 70;
            dgvTimKiemNhanVien.AllowUserToAddRows = false;
            dgvTimKiemNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvTimKiemNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenNV.Text = dgvTimKiemNhanVien.CurrentRow.Cells[1].Value.ToString();
            mskNamSinh.Text = dgvTimKiemNhanVien.CurrentRow.Cells[2].Value.ToString();
            cboMaTrinhDo.Text = dgvTimKiemNhanVien.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if ((txtTenNV.Text == "") && (mskNamSinh.Text == "0") && (cboMaTrinhDo.Text == ""))
            {
                MessageBox.Show("Hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "Select * from NhanVien where 1=1  "; // 

            if (txtTenNV.Text != "")
            {
                sql = sql + "and tennv = N'" + txtTenNV.Text.Trim() + "'";
                tblNhanVien = DAO.GetDataToTable(sql);
            }
            if (mskNamSinh.Text != " / /")
            {
                sql = sql + "and year(ngaysinh) = '" + mskNamSinh.Text.Trim() + "'";
                tblNhanVien = DAO.GetDataToTable(sql);
            }
            if (cboMaTrinhDo.Text != "")
            {
                sql = sql + "and matrinhdo = N'" + cboMaTrinhDo.Text.Trim() + "'";
                tblNhanVien = DAO.GetDataToTable(sql);
            }

            if (tblNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có nhân viên phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblNhanVien.Rows.Count + " nhân viên thỏa mãn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTimKiemNhanVien.DataSource = tblNhanVien;
            //LoadDtgv();
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            reset_value();
            dgvTimKiemNhanVien.DataSource = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                
                    this.Close();
        }
        private void Dodulieuvaocombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
            DataTable tbl = new DataTable();
            mydata.Fill(tbl);

            cbo.DataSource = tbl;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }
    }
}
