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
    public partial class frmYeuCauSuaChua : Form
    {
        public frmYeuCauSuaChua()
        {
            InitializeComponent();
        }
        
        DataTable tblSC; 
        private void Frm_YCSuaChua_Load(object sender, EventArgs e)
        {
            txtMaSC.Enabled = false;
            txtNgay.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyYC.Enabled = false;
            btnIn.Enabled = false;

            txtMaSC.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenPT.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtDongiaban.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtTenkhach.ReadOnly = true;

            txtThanhtien.Text = "0";
            txtTongTien.Text = "0";
            txtDongiaban.Text = "0";
            Load_DataGridView();
            //Đổ dữ liệu vào các ComboBox
            DAO.FillCombo("select MaGiaiPhap,TenGiaiPhap from GiaiPhap", cboGP, "MaGiaiPhap", "TenGiaiPhap");
            cboGP.SelectedIndex = -1;
            DAO.FillCombo("select MaKhach ,TenKhach from KhachHang", cboKH, "MaKhach", "MaKhach");
            cboKH.SelectedIndex = -1;
            DAO.FillCombo("select MaNgNhan ,TenNgNhan from NgNhan", cboNgN, "MaNgNhan", "TenNgNhan");
            cboNgN.SelectedIndex = -1;
            DAO.FillCombo("select MaNV ,TenNV from NhanVien", cboNV, "MaNV", "MaNV");
            cboNV.SelectedIndex = -1;
            DAO.FillCombo("select MaXe ,TenXe from XeMay", cboXe, "MaXe", "TenXe");
            cboXe.SelectedIndex = -1;
            DAO.FillCombo("SELECT MaPhuTung, TenPhuTung FROM PhuTung", cboMaPT, "MaPT", "MaPhuTung");
            cboMaPT.SelectedIndex = -1;
            DAO.FillCombo("SELECT MaSuaChua FROM YeuCauSuaChua", cboMaSC,
           "MaSuaChua", "MaSuaChua");
            cboMaSC.SelectedIndex = -1;
            if (txtMaSC.Text != "")
            {
                LoadYeuCauSuaChua();
                btnHuyYC.Enabled = true;
                btnIn.Enabled = true;
            }
            ResetValues();

        }
        private void ResetValues()
        {
            txtMaSC.Text = "";
            txtNgay.Text = "";
            cboNV.Text = "";
            cboKH.Text = "";
            cboNgN.Text = "";
            cboXe.Text = "";
            cboGP.Text = "";
            txtTenNV.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";

        }
        private void ResetValuesPT()
        {
            cboMaPT.Text = "";
            txtSoluong.Text = "";
            txtThanhtien.Text = "0";
            txtTenPT.Text = "";
            txtDongiaban.Text = "";
            txtTongTien.Text = "0";

        }
        private void Load_DataGridView()
        {
            string sql;
            //Hiển thị thông tin của bảng tbl_SCPT
            sql = "SELECT a.maphutung, b.Tenphutung, a.Soluong, b.Dongiaban, a.Thanhtien FROM Suachuaphutung AS a, PhuTung AS b WHERE a.MaSuaChua = N'" + txtMaSC.Text + "' AND a.maphutung=b.maphutung";
            tblSC = DAO.GetDataToTable(sql);
            dgYeuCauSC.DataSource = tblSC;
            dgYeuCauSC.Columns[0].HeaderText = "Mã phụ tùng";
            dgYeuCauSC.Columns[1].HeaderText = "Tên phụ tùng";
            dgYeuCauSC.Columns[2].HeaderText = "Số lượng";
            dgYeuCauSC.Columns[3].HeaderText = "Đươn giá bán";
            dgYeuCauSC.Columns[4].HeaderText = "Thành tiền";

            //Chiều rộng cột phù hợp với nội dung tát cả các ô kể cả tiêu đề
            dgYeuCauSC.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgYeuCauSC.AllowUserToAddRows = false;
            dgYeuCauSC.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        //load thông tin của 1 yêu theo mã yêu cầu 
        private void LoadYeuCauSuaChua()
        {

            string str;
            str = "SELECT NgaySua FROM YeuCauSuaChua WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
            txtNgay.Text = DAO.ConvertDateTime(DAO.GetFieldValues(str));
            str = "SELECT Manv FROM euCauSuaChua WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
            cboNV.Text = DAO.GetFieldValues(str);

            str = "SELECT Makhach FROM YeuCauSuaChua WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
            cboKH.Text = DAO.GetFieldValues(str);

            str = "SELECT TenXe FROM YeuCauSuaChua join XeMay on YeuCauSuaChua.MaXe = XeMay.MaXe WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
            cboXe.Text = DAO.GetFieldValues(str);

            str = "SELECT TenNgNhan FROM YeuCauSuaChua join NguyenNhan on YeuCauSuaChua.MaNgNhan = NguyenNhan.MaNgNhan WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
            cboNgN.Text = DAO.GetFieldValues(str);

            str = "SELECT TenGiaiPhap FROM YeuCauSuaChua join GiaiPhap on YeuCauSuaChua.MaGiaiPhap = GiaiPhap.MaGiaiPhap WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
            cboGP.Text = DAO.GetFieldValues(str);

            str = "SELECT Tongtien FROM YeuCauSuaChua WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
            txtTongTien.Text = DAO.GetFieldValues(str);

            //lblBangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(txtTongtien.Text);
            lblBangchu.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txtTongTien.Text.ToString()));

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            ResetValuesPT();
            txtNgay.Text = DateTime.Now.ToShortDateString(); //Lấy ngày tại thời điểm lập yêu cầu
            txtMaSC.Text = DAO.CreateKey("SC_"); //Tự động tạo mã SC_Ngày_Giờ => Giúp không bao giờ bị lặp khóa chính và tạo tính thống nhất của mã
            txtMaSC.Enabled = false;
            txtMaSC.Focus();
        }

        private void cboKH_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboKH.Text == "")
            {
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi kich chon mã khach thi tên khách, dia chi, dien thoai se tu dong hien ra
            str = "Select Tenkhach from Khachhang where Makhach = N'" + cboKH.SelectedValue + "'";
            txtTenkhach.Text = DAO.GetFieldValues(str);
            str = "Select Diachi from Khachhang where Makhach = N'" + cboKH.SelectedValue + "'";
            txtDiachi.Text = DAO.GetFieldValues(str);
            str = "Select Dienthoai from Khachhang where Makhach= N'" + cboKH.SelectedValue + "'";
            txtDienthoai.Text = DAO.GetFieldValues(str);
        }
        private void cboNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboNV.Text == "")
                txtTenNV.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select TenNV from Nhanvien where MaNV =N'" + cboNV.SelectedValue + "'";
            txtTenNV.Text = DAO.GetFieldValues(str);
        }

        private void cboMaPT_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaPT.Text == "")
            {
                txtTenPT.Text = "";
                txtDongiaban.Text = "";
            }
            // Khi kich chon Ma PT thi ten PT va gia ban se tu dong hien ra
            str = "SELECT Tenphutung FROM PhuTUng WHERE maphutung =N'" + cboMaPT.SelectedValue + "'";
            txtTenPT.Text = DAO.GetFieldValues(str);
            str = "SELECT Dongiaban FROM PhuTUng WHERE maphutung =N'" + cboMaPT.SelectedValue + "'";
            txtDongiaban.Text = DAO.GetFieldValues(str);
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg;
            txtThanhtien.Text = tt.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT MaSuaChua FROM YeuCauSuaChua WHERE MaSuaChua=N'" + txtMaSC.Text + "'";
            if (!DAO.CheckKey(sql))
            {

                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgay.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgay.Focus();
                    return;
                }
                if (cboNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNV.Focus();
                    return;
                }
                if (cboKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboKH.Focus();
                    return;
                }
                if (cboXe.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboXe.Focus();
                    return;
                }
                if (cboNgN.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nguyên nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNgN.Focus();
                    return;
                }
                if (cboGP.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn giải pháp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboGP.Focus();
                    return;
                }
                sql = "insert into YeuCauSuaChua(MaSuaChua,MaXe,MaKhach,NgaySua,MaNgNhan,MaGiaiPhap,MaNV,TongTien) " +
               "values('" + txtMaSC.Text.Trim() + "','" + cboXe.SelectedValue.ToString() + "','" +
               cboKH.SelectedValue.ToString() + "','" + DAO.ConvertDateTime(txtNgay.Text) + "','" +
               cboNgN.SelectedValue.ToString() + "','" + cboGP.SelectedValue.ToString() + "','" +
               cboNV.SelectedValue.ToString() + "'," + txtTongTien.Text + ")";

                DAO.RunSql(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (cboMaPT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã phụ tùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaPT.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }

            sql = "SELECT MaPhuTung FROM SuaChuaPhuTung WHERE MaPhuTung=N'" + cboMaPT.SelectedValue + "' AND MaSuaChua = N'" + txtMaSC.Text.Trim() + "'";
            if (DAO.CheckKey(sql))
            {
                MessageBox.Show("Mã phụ tùng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ResetValuesHang();
                cboMaPT.Focus();
                return;
            }

            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(DAO.GetFieldValues("SELECT Soluong FROM PhuTung WHERE MaPhuTung = N'" + cboMaPT.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng phụ tùng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO SuaChuaPhuTung(MaSuaChua,MaPhuTung,Soluong,Thanhtien) VALUES(N'" + txtMaSC.Text.Trim() + "', N'" +
                cboMaPT.SelectedValue + "'," + txtSoluong.Text + "," + txtThanhtien.Text + ")";
            DAO.RunSql(sql);
            Load_DataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE PhuTung SET Soluong =" + SLcon + " WHERE MaPhuTung= N'" + cboMaPT.SelectedValue + "'";
            DAO.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán

            tong = Convert.ToDouble(DAO.GetFieldValues("SELECT Tongtien FROM YeuCauSuaChua WHERE MaSuaChua = N'" + txtMaSC.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            txtTongTien.Text = Tongmoi.ToString();
            sql = "UPDATE YeuCauSuaChua SET TongTien =" + Tongmoi + " WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
            DAO.RunSql(sql);
            lblBangchu.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txtTongTien.Text.ToString()));
            ResetValuesPT();
            btnHuyYC.Enabled = true;
            btnIn.Enabled = true;
        }


        private void dgYeuCauSC_Click(object sender, EventArgs e)
        {
            //Hiển thị thông tin các phụ tùng trong yêu cầu khi click 1 dòng trong datagridview 
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tblSC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboMaPT.Text = dgYeuCauSC.CurrentRow.Cells["MaPhuTung"].Value.ToString();
            txtTenPT.Text = dgYeuCauSC.CurrentRow.Cells["TenPhuTung"].Value.ToString();
            txtDongiaban.Text = dgYeuCauSC.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            txtSoluong.Text = dgYeuCauSC.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtThanhtien.Text = dgYeuCauSC.CurrentRow.Cells["ThanhTien"].Value.ToString();
        }

        private void btnHuyYC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] MaPT = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT MaPhuTung FROM SuaChuaPhuTung WHERE MaSuaChua = N'" + txtMaSC.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaPT[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelPT(txtMaSC.Text, MaPT[i]);
                //Xóa hóa đơn
                sql = "DELETE YeuCauSuaChua WHERE MaSuaChua=N'" + txtMaSC.Text + "'";
                DAO.RunSqlDel(sql);
                ResetValues();
                ResetValuesPT();
                Load_DataGridView();
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                btnHuyYC.Enabled = false;
                btnIn.Enabled = false;
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAO.CloseConnection();
                this.Close();
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            //Tìm các đơn đã có trước để xem lại thông tin
            cboMaPT.Enabled = false;
            cboKH.Enabled = false;
            cboNV.Enabled = false;
            if (cboMaSC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã sửa chữa  để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSC.Focus();
                return;
            }
            txtMaSC.Text = cboMaSC.Text;
            LoadYeuCauSuaChua();
            Load_DataGridView();
            btnHuyYC.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cboMaSC.SelectedIndex = -1;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Chỉ cho nhập ký tự số
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Frm_YCSuaChua_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();

        }

        private void dgYeuCauSC_DoubleClick(object sender, EventArgs e)
        {
            string maPT;
            Double Thanhtien;
            if (tblSC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                maPT = dgYeuCauSC.CurrentRow.Cells["MaPhuTung"].Value.ToString();
                DelPT(txtMaSC.Text, maPT);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(dgYeuCauSC.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtien(txtMaSC.Text, Thanhtien);
                Load_DataGridView();
            }
        }
        private void DelPT(string MaSC, string MaPT)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Soluong FROM SuaChuaPhuTung WHERE MaSuaChua = N'" + MaSC + "' AND MaPhuTung = N'" + MaPT + "'";
            s = Convert.ToDouble(DAO.GetFieldValues(sql));
            sql = "DELETE SuaChuaPhuTung WHERE MaSuaChua=N'" + MaSC + "' AND MaPhuTung = N'" + MaPT + "'";
            DAO.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM PhuTung WHERE MaPhuTung = N'" + MaPT + "'";
            sl = Convert.ToDouble(DAO.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE PhuTung SET Soluong =" + SLcon + " WHERE MaPhuTung= N'" + MaPT + "'";
            DAO.RunSql(sql);
        }
        private void DelUpdateTongtien(string MaSC, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT TongTien FROM YeuCauSuaChua WHERE MaSuaChua = N'" + MaSC + "'";
            Tong = Convert.ToDouble(DAO.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE YeuCauSuaChua SET TongTien =" + Tongmoi + " WHERE MaSuaChua = N'" + MaSC + "'";
            DAO.RunSql(sql);
            txtTongTien.Text = Tongmoi.ToString();
            lblBangchu.Text = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(txtTongTien.Text.ToString()));
        }
        //In Phieu yeu cau sửa chữa
        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinYC, tblThongPT;
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
            exRange.Range["A1:B1"].Value = "Tiệm Sửa Xe";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 66666666";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "Phiếu yêu cầu";
            // Biểu diễn thông tin chung của Yêu cầu

            sql = "SELECT a.MaSuaChua, a.NgaySua, a.TongTien, b.Tenkhach, b.Diachi, b.Dienthoai, c.Tennv FROM YeuCauSuaChua AS a, KhachHang AS b, NhanVien AS c WHERE a.MaSuaChua = N'" +
                txtMaSC.Text + "' AND a.Makhach = b.Makhach AND a.Manv =c.Manv";
            tblThongtinYC = DAO.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã sửa chữa:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinYC.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinYC.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinYC.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C9:E9"].Value = tblThongtinYC.Rows[0][5].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenPhuTung, a.Soluong, b.Dongiaban, a.Thanhtien " +
                  "FROM SuaChuaPhuTung AS a , PhuTung AS b WHERE a.MaSuaChua = N'" +
                  txtMaSC.Text + "' AND a.MaPhuTung = b.MaPhuTung";
            tblThongPT = DAO.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên phụ tùng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongPT.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongPT.Columns.Count - 1; cot++)
                    //Điền thông tin phụ tùng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongPT.Rows[hang][cot].ToString();
            }

            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinYC.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + DAO.ChuyenSoSangChuoi(Double.Parse(tblThongtinYC.Rows[0][2].ToString()));

            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinYC.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên sửa chữa";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinYC.Rows[0][6];
            exSheet.Name = "Phiếu yêu cầu sửa chữa ";
            exApp.Visible = true;
        }
    }

}
