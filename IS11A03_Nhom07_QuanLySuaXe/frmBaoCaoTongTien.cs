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
using COMExcel = Microsoft.Office.Interop.Excel;
using IS11A03_Nhom07_QuanLySuaXe;

namespace IS11A03_Nhom07_QuanLySuaXe
{
    public partial class frmBaoCaoTongTien : Form
    {
        public frmBaoCaoTongTien()
        {
            InitializeComponent();
        }

        DataTable tblDSYC;

        private void BC_Tong_Tien_Load(object sender, EventArgs e)
        {
            txtTenNV.Enabled = false;
            txtTongtien.Enabled = false;

            //btnHienthi.Enabled = false;

            btn_In.Enabled = false;
            ResetValues();
            dg_DS_YC.DataSource = null;

            DAO.FillCombo("select MaNV ,TenNV from NhanVien", cboMaNV, "MaNV", "MaNV");
            cboMaNV.SelectedIndex = -1;
        }

        private void cboMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNV.Text == "")
            {

                txtTenNV.Text = "";
            }
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select TenNV from Nhanvien where MaNV =N'" + cboMaNV.SelectedValue + "'";
            txtTenNV.Text = DAO.GetFieldValues(str);
        }
        private void ResetValues()
        {
            txtTenNV.Text = "";
            cboMaNV.Text = "";
            txtTongtien.Text = "";

        }
        private void Load_DataGridView()
        {


            dg_DS_YC.Columns[0].HeaderText = "Mã yêu cầu";
            dg_DS_YC.Columns[1].HeaderText = "Mã khách hàng";
            dg_DS_YC.Columns[2].HeaderText = "Tổng tiền";
            dg_DS_YC.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_DS_YC.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_DS_YC.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dg_DS_YC.AllowUserToAddRows = false;
            dg_DS_YC.EditMode = DataGridViewEditMode.EditProgrammatically;


        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {

            if (cboMaNV.Text == "")
            {
                MessageBox.Show("Hãy chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql;
            sql = "SELECT Masuachua,MaKhach,TongTien FROM YeuCauSuaChua WHERE YeuCauSuaChua.MaNV = N'" + cboMaNV.SelectedValue + "'";
            tblDSYC = DAO.GetDataToTable(sql);


            if (tblDSYC.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblDSYC.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dg_DS_YC.DataSource = tblDSYC;

            btn_In.Enabled = true;
            btnHienthi.Enabled = false;
            //cboMaKhach.SelectedIndex = -1;
            string sql1;
            sql1 = "select Sum(TongTien) from YeuCauSuaChua where YeuCauSuaChua.MaNV = N'" + cboMaNV.Text + "'";
            txtTongtien.Text = DAO.GetFieldValues(sql1);
            Load_DataGridView();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            btnHienthi.Enabled = true;
            dg_DS_YC.DataSource = null;
            btn_In.Enabled = false;
            ResetValues();
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql, sql1;
            int hang = 0, cot = 0;
            DataTable DS;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng sửa chữa";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 6666666";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "Danh sách yêu cầu sửa chữa";
            // Biểu diễn thông tin chung của hóa đơn bán


            sql = "SELECT Masuachua,MaKhach,TongTien FROM YeuCauSuaChua WHERE YeuCauSuaChua.MaNV = N'" + cboMaNV.SelectedValue + "'";
            sql1 = "select Sum(TongTien) from YeuCauSuaChua where YeuCauSuaChua.MaNV = N'" + cboMaNV.Text + "'";

            DS = DAO.GetDataToTable(sql);

            string TT = DAO.GetFieldValues(sql1);
            //string TT = Functions.GetFieldValues(sql1);
            exRange.Range["B9:E9"].Font.Bold = true;
            exRange.Range["B9:J9"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B9:B9"].ColumnWidth = 12;
            exRange.Range["C9:C9"].ColumnWidth = 20;
            exRange.Range["D9:D9"].ColumnWidth = 12;
            exRange.Range["E9:E9"].ColumnWidth = 22;


            exRange.Range["C6:C7"].Font.Bold = true;
            exRange.Range["C6:C7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;


            exRange.Range["B9:B9"].Value = "STT";
            exRange.Range["C9:C9"].Value = "Mã YC";
            exRange.Range["D9:D9"].Value = "Mã khách";
            exRange.Range["E9:E9"].Value = "Tổng tiền";
            exRange.Range["C6:C6"].Value = "Mã nhân viên";
            exRange.Range["C7:C7"].Value = "Tên nhân viên";
            exRange.Range["D6:D6"].Value = cboMaNV.Text;
            exRange.Range["D7:D7"].Value = txtTenNV.Text;


            for (hang = 0; hang < DS.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 10] = hang + 1;
                for (cot = 0; cot < DS.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 10] = DS.Rows[hang][cot].ToString();
                }
            }
            exRange = exSheet.Cells[cot + 1][hang + 12];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng:";
            exRange = exSheet.Cells[cot + 2][hang + 12];
            exRange.Font.Bold = true;
            exRange.Value2 = txtTongtien.Text;
            exRange = exSheet.Cells[1][hang + 13]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txtTongtien.Text));
            exRange = exSheet.Cells[4][hang + 14]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:C1"].Value = "Hà Nội, Ngày " + DateTime.Now.ToShortDateString();

            exSheet.Name = "Báo cáo";
            exApp.Visible = true;
        }

    }
}
