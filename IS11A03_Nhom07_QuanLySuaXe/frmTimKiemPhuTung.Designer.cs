namespace IS11A03_Nhom07_QuanLySuaXe
{
    partial class frmTimKiemPhuTung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemPhuTung));
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaLoaiXe = new System.Windows.Forms.ComboBox();
            this.btnTimLai = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.lblSoluong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenPT = new System.Windows.Forms.TextBox();
            this.lblTenPT = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgv_TimKiemPT = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TimKiemPT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(364, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Kiếm Phụ Tùng";
            // 
            // cboMaLoaiXe
            // 
            this.cboMaLoaiXe.FormattingEnabled = true;
            this.cboMaLoaiXe.Location = new System.Drawing.Point(699, 111);
            this.cboMaLoaiXe.Name = "cboMaLoaiXe";
            this.cboMaLoaiXe.Size = new System.Drawing.Size(127, 28);
            this.cboMaLoaiXe.TabIndex = 22;
            // 
            // btnTimLai
            // 
            this.btnTimLai.Location = new System.Drawing.Point(443, 413);
            this.btnTimLai.Name = "btnTimLai";
            this.btnTimLai.Size = new System.Drawing.Size(118, 35);
            this.btnTimLai.TabIndex = 21;
            this.btnTimLai.Text = "Tìm lại";
            this.btnTimLai.UseVisualStyleBackColor = true;
            this.btnTimLai.Click += new System.EventHandler(this.btnTimLai_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(229, 413);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(118, 35);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(297, 157);
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(127, 26);
            this.txtSoluong.TabIndex = 19;
            // 
            // lblSoluong
            // 
            this.lblSoluong.AutoSize = true;
            this.lblSoluong.Location = new System.Drawing.Point(159, 160);
            this.lblSoluong.Name = "lblSoluong";
            this.lblSoluong.Size = new System.Drawing.Size(76, 20);
            this.lblSoluong.TabIndex = 18;
            this.lblSoluong.Text = "Số lượng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(603, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Loại xe:";
            // 
            // txtTenPT
            // 
            this.txtTenPT.Location = new System.Drawing.Point(297, 113);
            this.txtTenPT.Name = "txtTenPT";
            this.txtTenPT.Size = new System.Drawing.Size(127, 26);
            this.txtTenPT.TabIndex = 16;
            // 
            // lblTenPT
            // 
            this.lblTenPT.AutoSize = true;
            this.lblTenPT.Location = new System.Drawing.Point(159, 116);
            this.lblTenPT.Name = "lblTenPT";
            this.lblTenPT.Size = new System.Drawing.Size(107, 20);
            this.lblTenPT.TabIndex = 15;
            this.lblTenPT.Text = "Tên phụ tùng:";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(672, 413);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(118, 35);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgv_TimKiemPT
            // 
            this.dgv_TimKiemPT.AllowUserToDeleteRows = false;
            this.dgv_TimKiemPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TimKiemPT.Location = new System.Drawing.Point(101, 222);
            this.dgv_TimKiemPT.Name = "dgv_TimKiemPT";
            this.dgv_TimKiemPT.RowTemplate.Height = 28;
            this.dgv_TimKiemPT.Size = new System.Drawing.Size(789, 172);
            this.dgv_TimKiemPT.TabIndex = 23;
            this.dgv_TimKiemPT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TimKiemPT_CellClick);
            // 
            // frmTimKiemPhuTung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(992, 489);
            this.Controls.Add(this.dgv_TimKiemPT);
            this.Controls.Add(this.cboMaLoaiXe);
            this.Controls.Add(this.btnTimLai);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtSoluong);
            this.Controls.Add(this.lblSoluong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenPT);
            this.Controls.Add(this.lblTenPT);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTimKiemPhuTung";
            this.Text = "Tìm kiếm phụ tùng";
            this.Load += new System.EventHandler(this.frmTimKiemPhuTung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TimKiemPT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMaLoaiXe;
        private System.Windows.Forms.Button btnTimLai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label lblSoluong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenPT;
        private System.Windows.Forms.Label lblTenPT;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgv_TimKiemPT;
    }
}