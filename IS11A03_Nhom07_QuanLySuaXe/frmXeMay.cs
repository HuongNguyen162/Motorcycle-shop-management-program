using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;
using IS11A03_Nhom07_QuanLySuaXe;

namespace IS11A03_Nhom07_QuanLySuaXe
{
    public partial class frmXeMay : Form
    {
        public frmXeMay()
        {
            InitializeComponent();
        }

        private DataTable tblXeMay = new DataTable();

        private void frmXeMay_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            frmXeMay f = new frmXeMay();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowInTaskbar = false;
            try
            {
                loadDataToGridview();
                cboTenLoai.DropDownStyle = ComboBoxStyle.DropDownList;
                DAO.FillCombo("Select distinct MaLoai from LoaiXe", cboTenLoai, "MaLoai", "TenLoai");
                cboTenLoai.SelectedIndex = -1;
                resetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Xuất hiện lỗi");
            }
            //try
            //{
            //    //btnLuu.Enabled = false;
            //    cboTenLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            //    loadDataToGridview();
            //    String sql = "select * from LoaiXe order by maloai asc";
            //    DAO.FillCombo(sql, cboTenLoai, "maloai", "tenloai");
            //    cboTenLoai.SelectedIndex = -1;
            //    resetValues();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "xuat hien loi");
            //}
        }

        private void dgv_XeMay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaXe.Text = dgv_XeMay.CurrentRow.Cells[0].Value.ToString();
            txtTenXe.Text = dgv_XeMay.CurrentRow.Cells[1].Value.ToString();
            cboTenLoai.Text = dgv_XeMay.CurrentRow.Cells[2].Value.ToString();
            txtSoKhung.Text = dgv_XeMay.CurrentRow.Cells[3].Value.ToString();
            txtSoMay.Text = dgv_XeMay.CurrentRow.Cells[4].Value.ToString();
            txtBienSo.Text = dgv_XeMay.CurrentRow.Cells[5].Value.ToString();
            txtMaMau.Text = dgv_XeMay.CurrentRow.Cells[6].Value.ToString();
            txtMaXe.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void loadDataToGridview()
        {
            string sql = "Select * from XeMay order by maxe asc ";
            SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
            //tblXeMay.Clear();
            tblXeMay = DAO.GetDataToTable(sql);
            mydata.Fill(tblXeMay);
            dgv_XeMay.DataSource = tblXeMay;
            dgv_XeMay.AllowUserToAddRows = false;
            dgv_XeMay.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void resetValues()
        {
            txtBienSo.Text = "";
            txtMaMau.Text = "";
            txtMaXe.Text = "";
            txtSoKhung.Text = "";
            txtSoMay.Text = "";
            txtTenXe.Text = "";
            cboTenLoai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetValues();
            txtMaXe.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            cboTenLoai.SelectedIndex = -1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update XeMay set tenxe = '" + txtTenXe.Text.Trim() + "', " +
                         "maloai = '" + cboTenLoai.SelectedValue.ToString() + "', " +
                         "sokhung = '" + txtSoKhung.Text.Trim() + "', " +
                          "somay = '" + txtSoMay.Text.Trim() + "', " +
                          "bienso = '" + txtBienSo.Text.Trim() + "', " +
                          "mamau = '" + txtMaMau.Text.Trim() + "'";
            sql = sql + "where maxe = '" + txtMaXe.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, DAO.con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Dữ liệu đã được sửa thành cồng");
                loadDataToGridview();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu không được cập nhật vì " + ex.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from XeMay where maxe = '" + txtMaXe.Text + "'";
            if (dgv_XeMay.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa");
                return;
            }

            if (txtMaXe.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa");
                return;
            }

            if (MessageBox.Show("bạn có muốn xóa không", "thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, DAO.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("xóa thành công");
                    loadDataToGridview();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa dữ liệu không thành công vì " + ex.ToString());
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // insert into xemay values ('maxe', 'tenxe', N'maloai', 'sokhung', 'somay', 'bienso', 'mamau')
            string sql = "insert into xemay values ('" + txtMaXe.Text.Trim() + "', '" +
                        txtTenXe.Text.Trim() + "', N'" +
                        cboTenLoai.SelectedValue.ToString() + "', '" +
                        txtSoKhung.Text.Trim() + "', '" +
                        txtSoMay.Text.Trim() + "', '" +
                        txtBienSo.Text.Trim() + "', '" +
                        txtMaMau.Text.Trim() + "')";
            if (txtMaXe.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống mã xe");
                txtMaXe.Focus();
            }
            if (txtBienSo.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống biển số");
                txtBienSo.Focus();
            }
            if (txtTenXe.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống tên xe");
                txtTenXe.Focus();
            }
            if (txtSoKhung.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống số khung");
                txtSoKhung.Focus();
            }
            if (txtSoMay.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống số máy");
                txtSoMay.Focus();
            }
            if (txtMaMau.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống mã màu");
                txtMaMau.Focus();
            }
            if (cboTenLoai.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống mã loại");
                cboTenLoai.Focus();
            }
            if (DAO.CheckKey(sql))
            {
                MessageBox.Show("Mã xe đã tồn tại, vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaXe.Focus();
                return;
            }
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dữ liệu được thêm mới thành công");

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                loadDataToGridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể chèn dữ liệu do lỗi " + ex.ToString());
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetValues();
            txtMaXe.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            cboTenLoai.SelectedIndex = -1;
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];
            exRange = (COMExcel.Range)exSheet.Cells[1, 1];

            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C2:E2"].Value = "DANH SÁCH XE MÁY";

            exRange.Range["A6:G6"].Font.Bold = true;
            exRange.Range["A6:G6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:G6"].ColumnWidth = 12;
            exRange.Range["A6:A6"].Value = "Mã xe";
            exRange.Range["B6:B6"].Value = "Tên xe";
            exRange.Range["C6:C6"].Value = "Mã loại";
            exRange.Range["D6:D6"].Value = "Số khung";
            exRange.Range["E6:E6"].Value = "Số máy";
            exRange.Range["F6:F6"].Value = "Biển số";
            exRange.Range["G6:G6"].Value = "Mã màu";

            sql = "select * from XeMay order by maxe asc ";
            DataTable tblThongTinXeMay = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            adapter.Fill(tblThongTinXeMay);

            for (hang = 0; hang <= tblThongTinXeMay.Rows.Count - 1; hang++)
            {
                for (cot = 0; cot <= tblThongTinXeMay.Columns.Count - 1; cot++)
                {
                    exSheet.Cells[hang + 7, cot + 1] = tblThongTinXeMay.Rows[hang][cot].ToString();
                }
            }

            exSheet.Name = "Danh sách xe máy";
            exApp.Visible = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DAO.CloseConnection();
            this.Close();
        }









        




    }
}
