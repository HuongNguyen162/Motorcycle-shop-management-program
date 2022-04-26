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
    public partial class frmBaoCaoTopKH : Form
    {
        public frmBaoCaoTopKH()
        {
            InitializeComponent();
        }

        DataTable tbl_Top2;

        private void BC_Top_KH_Load(object sender, EventArgs e)
        {
            btn_Timlai.Enabled = false;
            btn_Dong.Enabled = true;
            btn_InBC.Enabled = false;
            btn_Hienthi.Enabled = true;
            //Đổ 4 quí vào ComboBox
            cboQui.Items.Add("1");
            cboQui.Items.Add("2");
            cboQui.Items.Add("3");
            cboQui.Items.Add("4");
        }

        private void btn_Hienthi_Click(object sender, EventArgs e)
        {

            if (cboQui.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn quí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboQui.Focus();
                return;
            }

            string sql = "select top(2) YeuCauSuaChua.MaKhach, Tenkhach, sum(tongtien)  from YeuCauSuaChua join Khachhang " +
                "on YeuCauSuaChua.makhach = KhachHang.makhach where " +
                "(datepart(QQ,NgaySua) = '" + cboQui.Text + "')" +
                 "GROUP BY YeuCauSuaChua.MaKhach, Tenkhach ORDER BY SUM(TongTien) desc";

            tbl_Top2 = DAO.GetDataToTable(sql);
            dg_Top2.DataSource = tbl_Top2;
            dg_Top2.Columns[0].HeaderText = "Mã khách";
            dg_Top2.Columns[1].HeaderText = "Tên khách";
            dg_Top2.Columns[2].HeaderText = "Tổng tiền";
            //Chiều rộng cột phù hợp với nội dung tất cả các ô kể cả tiêu đề

            dg_Top2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Top2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Top2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dg_Top2.AllowUserToAddRows = false;
            dg_Top2.EditMode = DataGridViewEditMode.EditProgrammatically;
            btn_Timlai.Enabled = true;
            btn_Hienthi.Enabled = false;
            btn_InBC.Enabled = true;

        }

        private void btn_Timlai_Click(object sender, EventArgs e)
        {
            cboQui.Enabled = true;
            btn_Hienthi.Enabled = true;
            cboQui.Text = "";
            dg_Top2.DataSource = null;
            btn_InBC.Enabled = false;
            btn_Timlai.Enabled = false;
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btn_InBC_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable danhsach;

            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Size = 11;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;//đặt màu cho chữ
            exRange.Range["A1:A1"].ColumnWidth = 10;//độ rộng cột
            exRange.Range["B1:B1"].ColumnWidth = 16;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng sửa chữa";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (05)66666666";
            exRange.Range["C2:G2"].Font.Size = 16;
            exRange.Range["C2:G2"].Font.Bold = true;
            exRange.Range["C2:G2"].Font.ColorIndex = 3;
            exRange.Range["C2:G2"].MergeCells = true;
            exRange.Range["C2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:G2"].Value = "Báo cáo danh sách 2 khách hàng sửa nhiều tiền nhất theo quí";
            exRange.Range["D3:F3"].Font.Size = 14;
            exRange.Range["D3:F3"].Font.Bold = true;
            exRange.Range["D3:F3"].Font.ColorIndex = 3;
            exRange.Range["D3:F3"].MergeCells = true;
            exRange.Range["D3:F3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D3:F3"].Value = " Quí " + cboQui.Text;

            sql = "select top(2) YeuCauSuaChua.MaKhach, Tenkhach, diachi, dienthoai, sum(tongtien)  from YeuCauSuaChua join Khachhang " +
                "on YeuCauSuaChua.makhach = KhachHang.makhach where " +
                "(datepart(QQ,NgaySua) = '" + cboQui.Text + "')" +
                 "GROUP BY YeuCauSuaChua.MaKhach, Tenkhach, diachi, dienthoai ORDER BY SUM(TongTien) desc";


            danhsach = DAO.GetDataToTable(sql);//đổ dữ liệu từ lệnh sql vào biến "danhsach"

            exRange.Range["B5:G5"].Font.Bold = true;//In đậm các chữ 
            exRange.Range["B5:G5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].ColumnWidth = 14;
            exRange.Range["C5:C5"].ColumnWidth = 15;
            exRange.Range["D5:D5"].ColumnWidth = 26;
            exRange.Range["E5:E5"].ColumnWidth = 26;
            exRange.Range["F5:F5"].ColumnWidth = 26;
            exRange.Range["G5:G5"].ColumnWidth = 26;




            exRange.Range["E5:E5"].Font.Bold = true;
            exRange.Range["E5:E5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã khách hàng";
            exRange.Range["D5:D5"].Value = "Tên khách hàng";
            exRange.Range["E5:E5"].Value = "Địa chỉ";
            exRange.Range["F5:F5"].Value = "Điện thoại";
            exRange.Range["G5:G5"].Value = "Tổng tiền";


            for (hang = 0; hang < danhsach.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;//điền số thứ tự vào cột 2 bắt đầu từ hàng 6 (mở excel ra hình dung)
                for (cot = 0; cot < danhsach.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 6] = danhsach.Rows[hang][cot].ToString();//điền thông tin các cột còn lại từ dữ liệu đã đc đổ vào từ biến "danhsach" bắt đầu từ cột 3, hàng 6
                }
            }

            exRange = exSheet.Cells[2][hang + 8];//chỗ này là đánh dấu vị trí viết cái dòng "Hà Nội, ngày..."
            exRange.Range["D1:F1"].MergeCells = true;
            exRange.Range["D1:F1"].Font.Italic = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:F1"].Value = "Hà Nội, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Name = "Báo cáo";
            exApp.Visible = true;
        }
    }
}
