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
    public partial class frmHoaDonNhap : Form
    {
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }


        private void load()
        {
            //chứa các bước, các câu lệnh lấy dữ liệu và in ra datagreatview
            //lấy dữ liệu từ bảng hdnphutung
            string sql = "Select * from hdnPhuTung";
            SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
            DataTable tblhoadon = new DataTable();
            mydata.Fill(tblhoadon);
            dgv_HoaDonNhap.DataSource = tblhoadon;
            //lấy dữ liệu từ bảng chitiethdnphu
            string sql1 = "Select * from ChiTiethdn";
            SqlDataAdapter mydata1 = new SqlDataAdapter(sql1, DAO.con);
            DataTable tblhoadon1 = new DataTable();
            mydata1.Fill(tblhoadon1);
            dgv_ChiTiethdn.DataSource = tblhoadon1;

            btnhuy.Enabled = false;
            btnluu.Enabled = false;
            btnhuy1.Enabled = false;
            btnluu1.Enabled = false;
            txtmahoadon.Enabled = false;
            btnsua1.Enabled = false;
            btnxoa1.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            //laays ra các mã hóa đơn đã được tạo, đẩy vào combobox
            string sql2 = "select Mahdn from hdnPhuTung";
            DAO.FillCombo(sql2, cbomahoadon, "Mahdn", "Mahdn");
            cbophutung.SelectedIndex = -1;

            txtthanhtien.Enabled = false;
            txttongtien.Enabled = false;

        }
        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            try
            {
                DAO.OpenConnection();
                //lấy các mã nhân viên, đẩy vào fillcombo để lọc ra các tên nhân viên đẩy vào combobox
                string sql = "select MaNV, TenNV from NhanVien";
                cbonhanvien.DropDownStyle = ComboBoxStyle.DropDownList;
                DAO.FillCombo(sql, cbonhanvien, "MaNV", "TenNV");
                cbonhanvien.SelectedIndex = -1;

                //lấy mã phụ tùng cho vào combobox
                string sql1 = "select MaPhuTung from PhuTung";
                cbophutung.DropDownStyle = ComboBoxStyle.DropDownList;
                DAO.FillCombo(sql1, cbophutung, "MaPhuTung", "MaPhuTung");
                cbophutung.SelectedIndex = -1;

                load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "xuat hien loi");
            }
        }

        private void dgv_HoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //đẩy thiết bị ở các dòng mình click lên các text box phù hợp
            txtmahoadon.Text = dgv_HoaDonNhap.CurrentRow.Cells["Mahdn"].Value.ToString();
            txtngaynhap.Text = dgv_HoaDonNhap.CurrentRow.Cells["NgayNhap"].Value.ToString();
            txttongtien.Text = dgv_HoaDonNhap.CurrentRow.Cells["TongTien"].Value.ToString();
            string manhanvien = dgv_HoaDonNhap.CurrentRow.Cells["MaNV"].Value.ToString();
            string sql = "select TenNV from NhanVien where MaNV = N'" + manhanvien + "'";
            cbonhanvien.Text = DAO.GetFieldValues(sql); 
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            //tẩy trắng các text box để nhập
            txtmahoadon.Enabled = true;
            cbonhanvien.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
            txtngaynhap.Text = "";
            txtmahoadon.Text = "";
            txttongtien.Text = "";
            cbonhanvien.Text = "";
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            string manhanvien = cbonhanvien.SelectedValue.ToString();
            if (txtmahoadon.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống mã sản phẩm");
                txtmahoadon.Focus();
                return;
            }
            string sql = "insert into hdnPhuTung values (N'" + txtmahoadon.Text.Trim() + "','" + txtngaynhap.Text.Trim() + "',N'" + manhanvien + "',0)";
            try
            {
                MessageBox.Show(sql);
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery(); //thực thi câu lệch sql

                MessageBox.Show("Dữ liệu được thêm mới thành công");
                load();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể chèn dữ liệu do lỗi " + ex.ToString());
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string manhanvien = cbonhanvien.SelectedValue.ToString();
            string sql = "delete from hdnPhuTung where Mahdn = N'" + txtmahoadon.Text.Trim() + "'";// xóa dữ liệu trong bảng hóa đơn -- thực thi sau
            string sql1 = "delete from ChiTiethdn where Mahdn =  N'" + txtmahoadon.Text.Trim() + "'"; //xóa dữ liệu trong bảng chi tiết -- thực thi trước
            if (dgv_HoaDonNhap.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa");
                return;
            }

            if (txtmahoadon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa");
                return;
            }
            if (MessageBox.Show("bạn có muốn xóa không", "thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    SqlCommand cmd1 = new SqlCommand(sql1, DAO.con);
                    SqlCommand cmd = new SqlCommand(sql, DAO.con);
                    cmd1.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    load();
                    MessageBox.Show("xóa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa dữ liệu không thành công vì " + ex.ToString());
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string manhanvien = cbonhanvien.SelectedValue.ToString();

            string sql = "update hdnPhuTung set NgayNhap = '" + txtngaynhap.Text.Trim() + "', MaNV = N'" + manhanvien
                + "' where Mahdn = N'" + txtmahoadon.Text.Trim() + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery(); // thực thi câu lệnh sql
                load();

                MessageBox.Show(" Dữ liệu đã được sửa thành cồng");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu không được cập nhật vì " + ex.ToString());
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            cbonhanvien.Enabled = true;
            btnluu.Enabled = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            txtngaynhap.Text = "";
            txtmahoadon.Text = "";
            txttongtien.Text = "";
            cbonhanvien.Text = "";
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            if (txtthang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtthang.Focus();
                return;
            }
            if (txtnam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnam.Focus();
                return;
            }


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
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop Sửa xe";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 666666666";
            exRange.Range["C2:G2"].Font.Size = 16;
            exRange.Range["C2:G2"].Font.Bold = true;
            exRange.Range["C2:G2"].Font.ColorIndex = 3;
            exRange.Range["C2:G2"].MergeCells = true;
            exRange.Range["C2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:G2"].Value = "Báo cáo nhập hàng tháng " + txtthang.Text + " năm " + txtnam.Text;
            exRange.Range["C4:C4"].Font.Bold = true;
            exRange.Range["C4:D4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            string sql1;
            //sql1 = "select Sum(Tongtien) from tblHoadonnhap where  ((YEAR(Ngaynhap) = '" + txt_Nam.Text + "') AND (datepart(QQ,Ngaynhap) = '" + cbo_Thang.Text + "')) group by datepart(QQ,Ngaynhap)";
            sql1 = "select Sum(Tongtien) from hdnPhuTung where  ((YEAR(Ngaynhap) = '" + txtnam.Text + "') AND (MONTH(Ngaynhap) = '" + txtthang.Text + "')) ";

            string s = DAO.GetFieldValues(sql1); 
            exRange.Range["C4:C4"].Value = "Tổng tiền hàng nhập kho : ";
            exRange.Range["D4:D4"].Value = s;
            sql = "select * from hdnPhuTung  where (MONTH(Ngaynhap) = '" + txtthang.Text + "') AND (YEAR(Ngaynhap) = '" + txtnam.Text + "')";

            //sql = "select * from tblHoadonnhap  where (datepart(QQ,Ngaynhap) = '" + cbo_Thang.Text + "') AND (YEAR(Ngaynhap) = '" + txt_Nam.Text + "')";
            danhsach = DAO.GetDataToTable(sql);

            exRange.Range["B5:J5"].Font.Bold = true;
            exRange.Range["B5:J5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].ColumnWidth = 12;
            exRange.Range["C5:C5"].ColumnWidth = 20;
            exRange.Range["D5:D5"].ColumnWidth = 12;
            exRange.Range["E5:E5"].ColumnWidth = 30;
            exRange.Range["F5:F5"].ColumnWidth = 11;
            exRange.Range["G5:G5"].ColumnWidth = 20;
            exRange.Range["H5:H5"].ColumnWidth = 12;
            exRange.Range["I5:I5"].ColumnWidth = 12;
            exRange.Range["J5:J5"].ColumnWidth = 12;

            sql = "select hdnPhuTung.Mahdn, hdnPhuTung.MaNV, ChiTiethdn.MaPhuTung, ChiTiethdn.SoLuong,hdnPhuTung.NgayNhap, ChiTiethdn.DonGiaNhap, ChiTiethdn.ThanhTien from ChiTiethdn join hdnPhuTung on ChiTiethdn.Mahdn = hdnPhuTung.Mahdn where MONTH(hdnPhuTung.NgayNhap) = " + txtthang.Text;
            danhsach = DAO.GetDataToTable(sql);

            exRange.Range["E5:E5"].Font.Bold = true;
            exRange.Range["E5:E5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã hóa đơn nhập";
            exRange.Range["D5:D5"].Value = "Mã nhân viên";
            exRange.Range["E5:E5"].Value = "Mã phụ tùng";
            exRange.Range["F5:F5"].Value = "Số lượng";
            exRange.Range["G5:G5"].Value = "Ngày nhập";
            exRange.Range["H5:H5"].Value = "Đơn giá nhập";
            exRange.Range["I5:I5"].Value = "Thành tiền";



            for (hang = 0; hang < danhsach.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;
                for (cot = 0; cot < danhsach.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 6] = danhsach.Rows[hang][cot].ToString();
                }
            }


            //exRange = exSheet.Cells[2][hang + 8];
            exRange.Range["D1:F1"].MergeCells = true;
            exRange.Range["D1:F1"].Font.Italic = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:F1"].Value = "Hà Nội, Ngày " + DateTime.Now.ToShortDateString();
            exSheet.Name = "Báo cáo";
            exApp.Visible = true;
        }



        private void load2()
        {
            string sql = "select top(3) NgayNhap, ChiTiethdn.MaPhuTung, TenPhuTung, sum(ChiTiethdn.SoLuong) as Soluongban from ChiTiethdn join hdnPhuTung on hdnPhuTung.Mahdn = ChiTiethdn.Mahdn join PhuTung on PhuTung.MaPhuTung = ChiTiethdn.MaPhuTung group by NgayNhap, ChiTiethdn.MaPhuTung, PhuTung.TenPhuTung, ChiTiethdn.Mahdn having  DATEPART(quarter,hdnPhuTung.NgayNhap) = " +
             txtquy.Text + "order by sum(ChiTiethdn.SoLuong) desc";
            SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
            DataTable tblhoadon = new DataTable();
            mydata.Fill(tblhoadon);
            dgv_TimKiemQuy.DataSource = tblhoadon;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txtquy.Text != "1" && txtquy.Text != "2" && txtquy.Text != "3" && txtquy.Text != "4")
            {
                MessageBox.Show("Nhập sai quý, nhập lại");
                txtquy.Focus();
                return;
            }
            if (txtquy.Text == "")
            {
                MessageBox.Show("Chưa nhập quý");
                txtquy.Focus();
                return;
            }
            try
            {
                DAO.OpenConnection();
                load2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy dữ liệu không thành công vì " + ex.ToString());
            }
        }

        private void dgv_ChiTiethdn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbomahoadon.Text = dgv_ChiTiethdn.CurrentRow.Cells["Mahdn"].Value.ToString();
            txtsoluong.Text = dgv_ChiTiethdn.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtdongia.Text = dgv_ChiTiethdn.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtthanhtien.Text = dgv_ChiTiethdn.CurrentRow.Cells["ThanhTien"].Value.ToString();
            cbophutung.Text = dgv_ChiTiethdn.CurrentRow.Cells["MaPhuTung"].Value.ToString();
            btnsua1.Enabled = true;
            btnxoa1.Enabled = true;
        }

        private void btnthem1_Click(object sender, EventArgs e)
        {
            cbomahoadon.Enabled = true;
            cbophutung.Enabled = true;
            btnsua1.Enabled = false;
            btnxoa1.Enabled = false;
            btnhuy1.Enabled = true;
            btnluu1.Enabled = true;
            txtdongia.Text = "";
            txtmahoadon.Text = "";
            txtsoluong.Text = "";
            txtthanhtien.Text = "";
            cbophutung.Text = "";
        }

        private void btnsua1_Click(object sender, EventArgs e)
        {
            string maphutung = cbophutung.SelectedValue.ToString();
            string mahoadon = cbomahoadon.SelectedValue.ToString();
            string sql = "update ChiTiethdn set SoLuong = "
                + txtsoluong.Text.Trim() + ", DonGiaNhap = " + txtdongia.Text.Trim() + " where Mahdn = N'"
                + mahoadon + "' and MaPhuTung = N'" + maphutung + "'";
            string sql1 = "update ChiTiethdn set ThanhTien = SoLuong*DonGiaNhap where Mahdn = N'" + mahoadon + "' and MaPhuTung = N'" + maphutung + "'";


            string sql2 = "update hdnPhuTung set Tongtien = (select SUM(thanhtien) from ChiTiethdn where Mahdn = N'" + mahoadon + "') where Mahdn = N'" + mahoadon + "'";


            try
            {

                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                SqlCommand cmd1 = new SqlCommand(sql1, DAO.con);
                SqlCommand cmd2 = new SqlCommand(sql2, DAO.con);
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                load();

                MessageBox.Show("Dữ liệu đã được sửa thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu không được cập nhật vì " + ex.ToString());
            }
        }

        private void btnxoa1_Click(object sender, EventArgs e)
        {
            string maphutung = cbophutung.SelectedValue.ToString();
            string mahoadon = cbomahoadon.SelectedValue.ToString();
            string sql = "delete from ChiTiethdn where Mahdn = N'" + mahoadon + "' and MaPhuTung = N'" + maphutung + "'";
            string sql1 = "update hdnPhuTung set Tongtien = (select SUM(thanhtien) from ChiTiethdn where Mahdn = N'"
                + mahoadon + "') where Mahdn = N'" + mahoadon + "'";
            // nếu data griview ko có dữ liệu
            if (dgv_HoaDonNhap.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa");
                return;
            }

            if (cbomahoadon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa");
                return;
            }
            if (cbophutung.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa");
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, DAO.con);
                    SqlCommand cmd1 = new SqlCommand(sql1, DAO.con);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    load();

                    MessageBox.Show("Xóa thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa dữ liệu không thành công vì " + ex.ToString());
                }
            }
        }

        private void btnluu1_Click(object sender, EventArgs e)
        {
            string maphutung = cbophutung.SelectedValue.ToString();
            string mahoadon = cbomahoadon.SelectedValue.ToString();
            if (cbomahoadon.Text == "")
            {
                MessageBox.Show("Không được bỏ trống mã sản phẩm");
                cbomahoadon.Focus();
                return;
            }
            string sql = "insert into ChiTiethdn values (N'" + mahoadon + "',N'" + maphutung +
                "'," + txtsoluong.Text.Trim() + "," + txtdongia.Text.Trim() + ", 0)";

            string sql1 = "update ChiTiethdn set ThanhTien = SoLuong*DonGiaNhap where Mahdn = N'" + mahoadon + "' and MaPhuTung = N'" + maphutung + "'";


            string sql2 = "update hdnPhuTung set Tongtien = (select SUM(thanhtien) from ChiTiethdn where Mahdn = N'" + mahoadon + "') where Mahdn = N'" + mahoadon + "'";


            string sql3 = "update PhuTung set SoLuong = SoLuong +(select SoLuong from ChiTiethdn where MaPhuTung = N'"+cbophutung.Text.Trim()+"' and Mahdn = N'"+mahoadon+"') where MaPhuTung = N'"+maphutung+"'";

            string sql4 = "Update PhuTung set DonGiaNhap = (Select DonGiaNhap from ChiTiethdn where MaPhuTung = N'" + maphutung + "'and Mahdn = N'" + mahoadon + "') where MaPhuTung = N'" + maphutung + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                SqlCommand cmd1 = new SqlCommand(sql1, DAO.con);
                SqlCommand cmd2 = new SqlCommand(sql2, DAO.con);
                SqlCommand cmd3 = new SqlCommand(sql3, DAO.con);
                SqlCommand cmd4 = new SqlCommand(sql4, DAO.con);

                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                MessageBox.Show("Dữ liệu được thêm mới thành công");
                load();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể chèn được dữ liệu vào do lỗi " + ex.ToString());
            }
        }

        private void btnhuy1_Click(object sender, EventArgs e)
        {
            cbophutung.Enabled = true;
            btnluu1.Enabled = false;
            btnsua1.Enabled = false;
            btnxoa1.Enabled = false;
            txtdongia.Text = "";
            cbomahoadon.Text = "";
            txtsoluong.Text = "";
            txtthanhtien.Text = "";
            cbophutung.Text = "";
        }

        private void load3()
        {
            string manhanvien = cbonhanvien.SelectedValue.ToString();
            string sql = "select top(5) Mahdn, Tongtien from hdnPhuTung join NhanVien on hdnPhuTung.MaNV = NhanVien.MaNV where hdnPhuTung.MaNV = '" + manhanvien + "' order by Tongtien desc";
            SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con);
            DataTable tblhoadon = new DataTable();
            mydata.Fill(tblhoadon);
            dgv_TimKiemNV.DataSource = tblhoadon;
        }

        private void btntimkiem1_Click(object sender, EventArgs e)
        {
            if (cbonhanvien.Text == "")
            {
                MessageBox.Show("Chưa nhập nhân viên");
                cbonhanvien.Focus();
                return;
            }
            try
            {
                DAO.OpenConnection();
                load3();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy dữ liệu không thành công vì " + ex.ToString());
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DAO.CloseConnection();
            this.Close();
        }























    }
}
