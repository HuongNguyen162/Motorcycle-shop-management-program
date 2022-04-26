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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void loaddulieu()
        {
            try
            {
                DAO.OpenConnection();
                string sql = "select manv, tennv, matrinhdo, ngaysinh from NhanVien";
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.con); // chạy câu lệnh sql
                DataTable tblNhanVien = new DataTable(); // khai báo bảng chứa kết quả chạy
                mydata.Fill(tblNhanVien); // đổ kết quả vào bảng
                dgvNhanVien.DataSource = tblNhanVien; // đổ từ bảng nhân viên vào
            }
            catch (Exception ex)
            {
                MessageBox.Show(" lỗi: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            loaddulieu();
            Dodulieuvaocombo("Select Tentrinhdo, MaTrinhDo from TrinhDo", cboMaTrinhDo, "Tentrinhdo", "MaTrinhDo");            
            cboMaTrinhDo.SelectedIndex = -1; // bằng -1 là không hiện danh sách chọn
        }

         private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            cboMaTrinhDo.Text = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            mskNgaySinh.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
        }
        //private void dgvNhanVien_Click(object sender, EventArgs e) 
        //{
            
        //}
        private void xoatextbox()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cboMaTrinhDo.Text = "";
            mskNgaySinh.Text = "";
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


        private void btnThem_Click(object sender, EventArgs e)
        {
            xoatextbox();
            btnThem.Enabled = false;
            txtMaNV.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return;
            }

            //sql = "select manv from NhanVien where MaNV = N'" + txtMaNV.Text.Trim() + "'";

            /*
                        if (txtTenNV.Text.Trim() == "")
                        {
                            txtTenNV.Text = "Trần Thị Bảo Châm";
                        }
            */
            if (cboMaTrinhDo.Text.Trim() == "") // trim là xóa dấu cách ở đầu và cuối chuỗi
            {
                MessageBox.Show("Bạn chưa nhập mã trình độ!", "Thông báo", MessageBoxButtons.OK);
                cboMaTrinhDo.Focus();
                return;
            }
            if (mskNgaySinh.MaskCompleted == false)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaySinh.Focus();
                return;
            }

            sql = "insert into NhanVien(manv, tennv,  matrinhdo, ngaysinh) values (N'" + txtMaNV.Text.Trim()
               + "', N'" + txtTenNV.Text.Trim() + "', N'" + cboMaTrinhDo.Text.Trim() + "', N'" + DAO.ConvertDateTime(mskNgaySinh.Text.Trim()) + "')";
           

            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();//chạy lệnh 
                //MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loaddulieu();
            //xoatextbox();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã nhân viên cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }

            if (mskNgaySinh.Text == " / /")
            {
                MessageBox.Show("Nhập ngày sinh cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskNgaySinh.Focus();
                return;

            }
            if (txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Nhập tên nhân viên cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;

            }
            if (cboMaTrinhDo.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã trình độ cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaTrinhDo.Focus();
                return;

            }
            string sql = "update nhanvien set tennv = N'" + txtTenNV.Text.Trim() + "', ngaysinh = '" + DAO.ConvertDateTime(mskNgaySinh.Text) +
                "', matrinhdo = '" + cboMaTrinhDo.Text.Trim() + "'  where manv = '" + txtMaNV.Text.Trim() + "'";

            /*string sql = "update Nhanvien set tennv = N'" + txtTenNV.Text.Trim() + "', ngaysinh = '" + txtNgaySinh.Text.Trim()
                    + "', matrinhdo = '" + cboMaTrinhDo.Text.Trim() + "' where manv = '" + txtMaNV.Text.Trim() + "'";*/
            try
            {
                DAO.RunSql(sql); 
                //MessageBox.Show("Chúc mừng bạn đã cập nhật dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception loi)
            {
                MessageBox.Show("Có lỗi: " + loi.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loaddulieu();

        }

        private void dgvNhanVien_Click_1(object sender, EventArgs e)
        {
            

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Thao tác không thể phục hồi, bạn chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE nhanvien where manv = N'" + txtMaNV.Text.Trim() + "'";
                DAO.RunSql(sql); 
                loaddulieu();
                xoatextbox();
            }

        }
        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            mskNgaySinh.Text = "";
            cboMaTrinhDo.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            txtMaNV.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

       
    }
}
