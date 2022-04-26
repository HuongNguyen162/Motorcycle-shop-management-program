namespace IS11A03_Nhom07_QuanLySuaXe
{
    partial class frmPhuTung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhuTung));
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiaban = new System.Windows.Forms.TextBox();
            this.lblGianhap = new System.Windows.Forms.Label();
            this.lblGiaban = new System.Windows.Forms.Label();
            this.lblTenPT = new System.Windows.Forms.Label();
            this.lblSoluong = new System.Windows.Forms.Label();
            this.lblMaxe = new System.Windows.Forms.Label();
            this.txtMaPT = new System.Windows.Forms.TextBox();
            this.txtTenPT = new System.Windows.Forms.TextBox();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.txtGianhap = new System.Windows.Forms.TextBox();
            this.cboMaxe = new System.Windows.Forms.ComboBox();
            this.lblMaPT = new System.Windows.Forms.Label();
            this.dgv_PhuTung = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PhuTung)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(387, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Mục Phụ Tùng";
            // 
            // txtGiaban
            // 
            this.txtGiaban.Location = new System.Drawing.Point(769, 193);
            this.txtGiaban.Name = "txtGiaban";
            this.txtGiaban.Size = new System.Drawing.Size(121, 26);
            this.txtGiaban.TabIndex = 26;
            // 
            // lblGianhap
            // 
            this.lblGianhap.AutoSize = true;
            this.lblGianhap.Location = new System.Drawing.Point(605, 153);
            this.lblGianhap.Name = "lblGianhap";
            this.lblGianhap.Size = new System.Drawing.Size(108, 20);
            this.lblGianhap.TabIndex = 25;
            this.lblGianhap.Text = "Đơn giá nhập:";
            // 
            // lblGiaban
            // 
            this.lblGiaban.AutoSize = true;
            this.lblGiaban.Location = new System.Drawing.Point(605, 196);
            this.lblGiaban.Name = "lblGiaban";
            this.lblGiaban.Size = new System.Drawing.Size(99, 20);
            this.lblGiaban.TabIndex = 24;
            this.lblGiaban.Text = "Đơn giá bán:";
            // 
            // lblTenPT
            // 
            this.lblTenPT.AutoSize = true;
            this.lblTenPT.Location = new System.Drawing.Point(175, 153);
            this.lblTenPT.Name = "lblTenPT";
            this.lblTenPT.Size = new System.Drawing.Size(107, 20);
            this.lblTenPT.TabIndex = 23;
            this.lblTenPT.Text = "Tên phụ tùng:";
            // 
            // lblSoluong
            // 
            this.lblSoluong.AutoSize = true;
            this.lblSoluong.Location = new System.Drawing.Point(175, 196);
            this.lblSoluong.Name = "lblSoluong";
            this.lblSoluong.Size = new System.Drawing.Size(76, 20);
            this.lblSoluong.TabIndex = 22;
            this.lblSoluong.Text = "Số lượng:";
            // 
            // lblMaxe
            // 
            this.lblMaxe.AutoSize = true;
            this.lblMaxe.Location = new System.Drawing.Point(605, 112);
            this.lblMaxe.Name = "lblMaxe";
            this.lblMaxe.Size = new System.Drawing.Size(83, 20);
            this.lblMaxe.TabIndex = 21;
            this.lblMaxe.Text = "Mã loại xe:";
            // 
            // txtMaPT
            // 
            this.txtMaPT.Location = new System.Drawing.Point(316, 109);
            this.txtMaPT.Name = "txtMaPT";
            this.txtMaPT.Size = new System.Drawing.Size(121, 26);
            this.txtMaPT.TabIndex = 20;
            // 
            // txtTenPT
            // 
            this.txtTenPT.Location = new System.Drawing.Point(316, 150);
            this.txtTenPT.Name = "txtTenPT";
            this.txtTenPT.Size = new System.Drawing.Size(121, 26);
            this.txtTenPT.TabIndex = 19;
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(316, 193);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(121, 26);
            this.txtSoluong.TabIndex = 18;
            // 
            // txtGianhap
            // 
            this.txtGianhap.Location = new System.Drawing.Point(769, 150);
            this.txtGianhap.Name = "txtGianhap";
            this.txtGianhap.Size = new System.Drawing.Size(121, 26);
            this.txtGianhap.TabIndex = 17;
            this.txtGianhap.TextChanged += new System.EventHandler(this.txtGianhap_TextChanged);
            // 
            // cboMaxe
            // 
            this.cboMaxe.FormattingEnabled = true;
            this.cboMaxe.Location = new System.Drawing.Point(769, 106);
            this.cboMaxe.Name = "cboMaxe";
            this.cboMaxe.Size = new System.Drawing.Size(121, 28);
            this.cboMaxe.TabIndex = 16;
            // 
            // lblMaPT
            // 
            this.lblMaPT.AutoSize = true;
            this.lblMaPT.Location = new System.Drawing.Point(175, 112);
            this.lblMaPT.Name = "lblMaPT";
            this.lblMaPT.Size = new System.Drawing.Size(102, 20);
            this.lblMaPT.TabIndex = 15;
            this.lblMaPT.Text = "Mã phụ tùng:";
            // 
            // dgv_PhuTung
            // 
            this.dgv_PhuTung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PhuTung.Location = new System.Drawing.Point(100, 257);
            this.dgv_PhuTung.Name = "dgv_PhuTung";
            this.dgv_PhuTung.RowTemplate.Height = 28;
            this.dgv_PhuTung.Size = new System.Drawing.Size(885, 201);
            this.dgv_PhuTung.TabIndex = 27;
            this.dgv_PhuTung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PhuTung_CellClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(901, 498);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(84, 29);
            this.btnThoat.TabIndex = 33;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(745, 498);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(84, 29);
            this.btnHuy.TabIndex = 32;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(416, 498);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(84, 29);
            this.btnXoa.TabIndex = 31;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(257, 498);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(84, 29);
            this.btnSua.TabIndex = 30;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(577, 498);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(84, 29);
            this.btnLuu.TabIndex = 29;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(100, 498);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(84, 29);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmPhuTung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1068, 563);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgv_PhuTung);
            this.Controls.Add(this.txtGiaban);
            this.Controls.Add(this.lblGianhap);
            this.Controls.Add(this.lblGiaban);
            this.Controls.Add(this.lblTenPT);
            this.Controls.Add(this.lblSoluong);
            this.Controls.Add(this.lblMaxe);
            this.Controls.Add(this.txtMaPT);
            this.Controls.Add(this.txtTenPT);
            this.Controls.Add(this.txtSoluong);
            this.Controls.Add(this.txtGianhap);
            this.Controls.Add(this.cboMaxe);
            this.Controls.Add(this.lblMaPT);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPhuTung";
            this.Text = "Phụ tùng";
            this.Load += new System.EventHandler(this.frmPhuTung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PhuTung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiaban;
        private System.Windows.Forms.Label lblGianhap;
        private System.Windows.Forms.Label lblGiaban;
        private System.Windows.Forms.Label lblTenPT;
        private System.Windows.Forms.Label lblSoluong;
        private System.Windows.Forms.Label lblMaxe;
        private System.Windows.Forms.TextBox txtMaPT;
        private System.Windows.Forms.TextBox txtTenPT;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.TextBox txtGianhap;
        private System.Windows.Forms.ComboBox cboMaxe;
        private System.Windows.Forms.Label lblMaPT;
        private System.Windows.Forms.DataGridView dgv_PhuTung;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
    }
}