using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IS11A03_Nhom07_QuanLySuaXe
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DAO.CloseConnection();
            Application.Exit();
        }

        private void mnuXeMay_Click(object sender, EventArgs e)
        {
            frmXeMay f = new frmXeMay();
            f.StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            f.Show();
        }

        private void mnuYeuCauSuaChua_Click(object sender, EventArgs e)
        {
            frmYeuCauSuaChua f = new frmYeuCauSuaChua();
            f.StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            f.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            f.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            f.StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            f.Show();
        }

        private void mnuPhuTung_Click(object sender, EventArgs e)
        {
            frmPhuTung f = new frmPhuTung();
            f.StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            f.Show();
        }

        private void mnuHoaDonNhap_Click(object sender, EventArgs e)
        {
            frmHoaDonNhap f = new frmHoaDonNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            f.Show();
        }

        private void phụTùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemPhuTung f = new frmTimKiemPhuTung();
            f.StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            f.Show();
        }

        private void sửaChữaPhụTùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemNhanVien f = new frmTimKiemNhanVien();
            f.StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            f.Show();
        }
    }
}
