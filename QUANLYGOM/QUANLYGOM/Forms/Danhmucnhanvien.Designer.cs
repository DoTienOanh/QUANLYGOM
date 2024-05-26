namespace QUANLYGOM.Forms
{
    partial class formDanhmucnhanvien
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
            this.maskSodienthoai = new System.Windows.Forms.MaskedTextBox();
            this.buttonDong = new System.Windows.Forms.Button();
            this.buttonBoqua = new System.Windows.Forms.Button();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.dataGridViewNhanvien = new System.Windows.Forms.DataGridView();
            this.textTennganhang = new System.Windows.Forms.TextBox();
            this.textSotaikhoan = new System.Windows.Forms.TextBox();
            this.comboMachucvu = new System.Windows.Forms.ComboBox();
            this.textDiachi = new System.Windows.Forms.TextBox();
            this.textTennhanvien = new System.Windows.Forms.TextBox();
            this.textManhanvien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDanhmuc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhanvien)).BeginInit();
            this.SuspendLayout();
            // 
            // maskSodienthoai
            // 
            this.maskSodienthoai.Location = new System.Drawing.Point(252, 246);
            this.maskSodienthoai.Mask = "(999) 000-0000";
            this.maskSodienthoai.Name = "maskSodienthoai";
            this.maskSodienthoai.Size = new System.Drawing.Size(212, 26);
            this.maskSodienthoai.TabIndex = 44;
            // 
            // buttonDong
            // 
            this.buttonDong.Location = new System.Drawing.Point(742, 571);
            this.buttonDong.Name = "buttonDong";
            this.buttonDong.Size = new System.Drawing.Size(118, 54);
            this.buttonDong.TabIndex = 43;
            this.buttonDong.Text = "Đóng";
            this.buttonDong.UseVisualStyleBackColor = true;
            this.buttonDong.Click += new System.EventHandler(this.buttonDong_Click);
            // 
            // buttonBoqua
            // 
            this.buttonBoqua.Location = new System.Drawing.Point(618, 571);
            this.buttonBoqua.Name = "buttonBoqua";
            this.buttonBoqua.Size = new System.Drawing.Size(118, 54);
            this.buttonBoqua.TabIndex = 42;
            this.buttonBoqua.Text = "Bỏ qua";
            this.buttonBoqua.UseVisualStyleBackColor = true;
            this.buttonBoqua.Click += new System.EventHandler(this.buttonBoqua_Click);
            // 
            // buttonLuu
            // 
            this.buttonLuu.Location = new System.Drawing.Point(494, 571);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(118, 54);
            this.buttonLuu.TabIndex = 41;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Location = new System.Drawing.Point(370, 571);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(118, 54);
            this.buttonSua.TabIndex = 40;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.Location = new System.Drawing.Point(246, 571);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(118, 54);
            this.buttonXoa.TabIndex = 39;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Location = new System.Drawing.Point(122, 571);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(118, 54);
            this.buttonThem.TabIndex = 38;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // dataGridViewNhanvien
            // 
            this.dataGridViewNhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNhanvien.Location = new System.Drawing.Point(122, 311);
            this.dataGridViewNhanvien.Name = "dataGridViewNhanvien";
            this.dataGridViewNhanvien.RowHeadersWidth = 62;
            this.dataGridViewNhanvien.RowTemplate.Height = 28;
            this.dataGridViewNhanvien.Size = new System.Drawing.Size(799, 224);
            this.dataGridViewNhanvien.TabIndex = 37;
            this.dataGridViewNhanvien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNhanvien_CellContentClick);
            // 
            // textTennganhang
            // 
            this.textTennganhang.Location = new System.Drawing.Point(709, 207);
            this.textTennganhang.Name = "textTennganhang";
            this.textTennganhang.Size = new System.Drawing.Size(212, 26);
            this.textTennganhang.TabIndex = 36;
            // 
            // textSotaikhoan
            // 
            this.textSotaikhoan.Location = new System.Drawing.Point(709, 169);
            this.textSotaikhoan.Name = "textSotaikhoan";
            this.textSotaikhoan.Size = new System.Drawing.Size(212, 26);
            this.textSotaikhoan.TabIndex = 35;
            // 
            // comboMachucvu
            // 
            this.comboMachucvu.FormattingEnabled = true;
            this.comboMachucvu.Location = new System.Drawing.Point(709, 127);
            this.comboMachucvu.Name = "comboMachucvu";
            this.comboMachucvu.Size = new System.Drawing.Size(212, 28);
            this.comboMachucvu.TabIndex = 34;
            // 
            // textDiachi
            // 
            this.textDiachi.Location = new System.Drawing.Point(252, 207);
            this.textDiachi.Name = "textDiachi";
            this.textDiachi.Size = new System.Drawing.Size(212, 26);
            this.textDiachi.TabIndex = 33;
            // 
            // textTennhanvien
            // 
            this.textTennhanvien.Location = new System.Drawing.Point(252, 169);
            this.textTennhanvien.Name = "textTennhanvien";
            this.textTennhanvien.Size = new System.Drawing.Size(212, 26);
            this.textTennhanvien.TabIndex = 32;
            // 
            // textManhanvien
            // 
            this.textManhanvien.Location = new System.Drawing.Point(252, 129);
            this.textManhanvien.Name = "textManhanvien";
            this.textManhanvien.Size = new System.Drawing.Size(212, 26);
            this.textManhanvien.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Tên ngân hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(584, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Số tài khoản";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(584, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Mã chức vụ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Số điện thoại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Tên nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mã nhân viên";
            // 
            // labelDanhmuc
            // 
            this.labelDanhmuc.AutoSize = true;
            this.labelDanhmuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDanhmuc.Location = new System.Drawing.Point(295, 41);
            this.labelDanhmuc.Name = "labelDanhmuc";
            this.labelDanhmuc.Size = new System.Drawing.Size(483, 46);
            this.labelDanhmuc.TabIndex = 23;
            this.labelDanhmuc.Text = "DANH MỤC NHÂN VIÊN";
            // 
            // formDanhmucnhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 677);
            this.Controls.Add(this.maskSodienthoai);
            this.Controls.Add(this.buttonDong);
            this.Controls.Add(this.buttonBoqua);
            this.Controls.Add(this.buttonLuu);
            this.Controls.Add(this.buttonSua);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonThem);
            this.Controls.Add(this.dataGridViewNhanvien);
            this.Controls.Add(this.textTennganhang);
            this.Controls.Add(this.textSotaikhoan);
            this.Controls.Add(this.comboMachucvu);
            this.Controls.Add(this.textDiachi);
            this.Controls.Add(this.textTennhanvien);
            this.Controls.Add(this.textManhanvien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelDanhmuc);
            this.Name = "formDanhmucnhanvien";
            this.Text = "Danh muc nhan vien";
            this.Load += new System.EventHandler(this.formDanhmucnhanvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhanvien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskSodienthoai;
        private System.Windows.Forms.Button buttonDong;
        private System.Windows.Forms.Button buttonBoqua;
        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.DataGridView dataGridViewNhanvien;
        private System.Windows.Forms.TextBox textTennganhang;
        private System.Windows.Forms.TextBox textSotaikhoan;
        private System.Windows.Forms.ComboBox comboMachucvu;
        private System.Windows.Forms.TextBox textDiachi;
        private System.Windows.Forms.TextBox textTennhanvien;
        private System.Windows.Forms.TextBox textManhanvien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDanhmuc;
    }
}