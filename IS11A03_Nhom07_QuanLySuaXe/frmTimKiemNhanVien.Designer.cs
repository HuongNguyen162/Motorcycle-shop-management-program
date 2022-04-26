namespace IS11A03_Nhom07_QuanLySuaXe
{
    partial class frmTimKiemNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemNhanVien));
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblMaTrinhDo = new System.Windows.Forms.Label();
            this.lblNamSinh = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTimKiemNhanVien = new System.Windows.Forms.DataGridView();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTimLai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cboMaTrinhDo = new System.Windows.Forms.ComboBox();
            this.mskNamSinh = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Location = new System.Drawing.Point(307, 109);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(108, 20);
            this.lblTenNV.TabIndex = 0;
            this.lblTenNV.Text = "Tên nhân viên";
            // 
            // lblMaTrinhDo
            // 
            this.lblMaTrinhDo.AutoSize = true;
            this.lblMaTrinhDo.Location = new System.Drawing.Point(308, 164);
            this.lblMaTrinhDo.Name = "lblMaTrinhDo";
            this.lblMaTrinhDo.Size = new System.Drawing.Size(88, 20);
            this.lblMaTrinhDo.TabIndex = 1;
            this.lblMaTrinhDo.Text = "Mã trình độ";
            // 
            // lblNamSinh
            // 
            this.lblNamSinh.AutoSize = true;
            this.lblNamSinh.Location = new System.Drawing.Point(308, 222);
            this.lblNamSinh.Name = "lblNamSinh";
            this.lblNamSinh.Size = new System.Drawing.Size(75, 20);
            this.lblNamSinh.TabIndex = 2;
            this.lblNamSinh.Text = "Năm sinh";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(455, 103);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(136, 26);
            this.txtTenNV.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Linen;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(300, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tìm Kiếm Nhân Viên";
            // 
            // dgvTimKiemNhanVien
            // 
            this.dgvTimKiemNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemNhanVien.Location = new System.Drawing.Point(101, 278);
            this.dgvTimKiemNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTimKiemNhanVien.Name = "dgvTimKiemNhanVien";
            this.dgvTimKiemNhanVien.RowHeadersWidth = 51;
            this.dgvTimKiemNhanVien.RowTemplate.Height = 24;
            this.dgvTimKiemNhanVien.Size = new System.Drawing.Size(693, 188);
            this.dgvTimKiemNhanVien.TabIndex = 7;
            this.dgvTimKiemNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimKiemNhanVien_CellClick);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(227, 508);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(84, 40);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnTimLai
            // 
            this.btnTimLai.Location = new System.Drawing.Point(400, 508);
            this.btnTimLai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimLai.Name = "btnTimLai";
            this.btnTimLai.Size = new System.Drawing.Size(84, 40);
            this.btnTimLai.TabIndex = 9;
            this.btnTimLai.Text = "Tìm Lại";
            this.btnTimLai.UseVisualStyleBackColor = true;
            this.btnTimLai.Click += new System.EventHandler(this.btnTimLai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(550, 508);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(88, 40);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cboMaTrinhDo
            // 
            this.cboMaTrinhDo.FormattingEnabled = true;
            this.cboMaTrinhDo.Location = new System.Drawing.Point(455, 161);
            this.cboMaTrinhDo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMaTrinhDo.Name = "cboMaTrinhDo";
            this.cboMaTrinhDo.Size = new System.Drawing.Size(136, 28);
            this.cboMaTrinhDo.TabIndex = 11;
            // 
            // mskNamSinh
            // 
            this.mskNamSinh.Location = new System.Drawing.Point(455, 222);
            this.mskNamSinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mskNamSinh.Mask = "0000";
            this.mskNamSinh.Name = "mskNamSinh";
            this.mskNamSinh.Size = new System.Drawing.Size(136, 26);
            this.mskNamSinh.TabIndex = 12;
            this.mskNamSinh.ValidatingType = typeof(System.DateTime);
            // 
            // frmTimKiemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.mskNamSinh);
            this.Controls.Add(this.cboMaTrinhDo);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTimLai);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgvTimKiemNhanVien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.lblNamSinh);
            this.Controls.Add(this.lblMaTrinhDo);
            this.Controls.Add(this.lblTenNV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTimKiemNhanVien";
            this.Text = "Tìm kiếm nhân viên";
            this.Load += new System.EventHandler(this.frmTimKiemNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.Label lblMaTrinhDo;
        private System.Windows.Forms.Label lblNamSinh;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTimKiemNhanVien;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTimLai;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cboMaTrinhDo;
        private System.Windows.Forms.MaskedTextBox mskNamSinh;
    }
}