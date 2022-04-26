namespace IS11A03_Nhom07_QuanLySuaXe
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuYeuCauSuaChua = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXeMay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhuTung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoaDonNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.phụTùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaChữaPhụTùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(311, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(820, 108);
            this.label1.TabIndex = 2;
            this.label1.Text = "QUẢN LÝ SỬA XE";
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuYeuCauSuaChua,
            this.mnuKhachHang,
            this.mnuNhanVien,
            this.mnuXeMay,
            this.mnuPhuTung});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(105, 29);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuYeuCauSuaChua
            // 
            this.mnuYeuCauSuaChua.Name = "mnuYeuCauSuaChua";
            this.mnuYeuCauSuaChua.Size = new System.Drawing.Size(219, 30);
            this.mnuYeuCauSuaChua.Text = "Yêu cầu sửa chữa";
            this.mnuYeuCauSuaChua.Click += new System.EventHandler(this.mnuYeuCauSuaChua_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(219, 30);
            this.mnuKhachHang.Text = "Khách hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(219, 30);
            this.mnuNhanVien.Text = "Nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuXeMay
            // 
            this.mnuXeMay.Name = "mnuXeMay";
            this.mnuXeMay.Size = new System.Drawing.Size(219, 30);
            this.mnuXeMay.Text = "Xe máy";
            this.mnuXeMay.Click += new System.EventHandler(this.mnuXeMay_Click);
            // 
            // mnuPhuTung
            // 
            this.mnuPhuTung.Name = "mnuPhuTung";
            this.mnuPhuTung.Size = new System.Drawing.Size(219, 30);
            this.mnuPhuTung.Text = "Phụ tùng";
            this.mnuPhuTung.Click += new System.EventHandler(this.mnuPhuTung_Click);
            // 
            // mnuHoaDon
            // 
            this.mnuHoaDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHoaDonNhap});
            this.mnuHoaDon.Name = "mnuHoaDon";
            this.mnuHoaDon.Size = new System.Drawing.Size(94, 29);
            this.mnuHoaDon.Text = "Hóa đơn";
            // 
            // mnuHoaDonNhap
            // 
            this.mnuHoaDonNhap.Name = "mnuHoaDonNhap";
            this.mnuHoaDonNhap.Size = new System.Drawing.Size(199, 30);
            this.mnuHoaDonNhap.Text = "Hóa đơn nhập";
            this.mnuHoaDonNhap.Click += new System.EventHandler(this.mnuHoaDonNhap_Click);
            // 
            // mnuTimKiem
            // 
            this.mnuTimKiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phụTùngToolStripMenuItem,
            this.sửaChữaPhụTùngToolStripMenuItem});
            this.mnuTimKiem.Name = "mnuTimKiem";
            this.mnuTimKiem.Size = new System.Drawing.Size(96, 29);
            this.mnuTimKiem.Text = "Tìm kiếm";
            // 
            // phụTùngToolStripMenuItem
            // 
            this.phụTùngToolStripMenuItem.Name = "phụTùngToolStripMenuItem";
            this.phụTùngToolStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.phụTùngToolStripMenuItem.Text = "Phụ tùng";
            this.phụTùngToolStripMenuItem.Click += new System.EventHandler(this.phụTùngToolStripMenuItem_Click);
            // 
            // sửaChữaPhụTùngToolStripMenuItem
            // 
            this.sửaChữaPhụTùngToolStripMenuItem.Name = "sửaChữaPhụTùngToolStripMenuItem";
            this.sửaChữaPhụTùngToolStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.sửaChữaPhụTùngToolStripMenuItem.Text = "Nhân viên";
            this.sửaChữaPhụTùngToolStripMenuItem.Click += new System.EventHandler(this.sửaChữaPhụTùngToolStripMenuItem_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(69, 29);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMuc,
            this.mnuHoaDon,
            this.mnuTimKiem,
            this.mnuThoat});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(1351, 33);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IS11A03_Nhom07_QuanLySuaXe.Properties.Resources._252378026_4319601914776113_4984784534528243180_n;
            this.ClientSize = new System.Drawing.Size(1351, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "Quản lý sửa xe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuYeuCauSuaChua;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuXeMay;
        private System.Windows.Forms.ToolStripMenuItem mnuPhuTung;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnuHoaDonNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
        private System.Windows.Forms.ToolStripMenuItem phụTùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaChữaPhụTùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.MenuStrip menuStrip2;
    }
}