namespace QUANLYGOM.Forms
{
    partial class formDangnhap
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
            this.pnlDangNhap = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkHienmatkhau = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textMatkhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textTaikhoan = new System.Windows.Forms.TextBox();
            this.buttonDangnhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pnlDangNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDangNhap
            // 
            this.pnlDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDangNhap.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDangNhap.Controls.Add(this.label1);
            this.pnlDangNhap.Controls.Add(this.checkHienmatkhau);
            this.pnlDangNhap.Controls.Add(this.label2);
            this.pnlDangNhap.Controls.Add(this.textMatkhau);
            this.pnlDangNhap.Controls.Add(this.label3);
            this.pnlDangNhap.Controls.Add(this.textTaikhoan);
            this.pnlDangNhap.Controls.Add(this.buttonDangnhap);
            this.pnlDangNhap.Controls.Add(this.btnThoat);
            this.pnlDangNhap.ForeColor = System.Drawing.SystemColors.Desktop;
            this.pnlDangNhap.Location = new System.Drawing.Point(0, -14);
            this.pnlDangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDangNhap.Name = "pnlDangNhap";
            this.pnlDangNhap.Size = new System.Drawing.Size(439, 923);
            this.pnlDangNhap.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐĂNG NHẬP";
            // 
            // checkHienmatkhau
            // 
            this.checkHienmatkhau.AutoSize = true;
            this.checkHienmatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkHienmatkhau.Location = new System.Drawing.Point(48, 416);
            this.checkHienmatkhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkHienmatkhau.Name = "checkHienmatkhau";
            this.checkHienmatkhau.Size = new System.Drawing.Size(176, 29);
            this.checkHienmatkhau.TabIndex = 6;
            this.checkHienmatkhau.Text = "Hiện mật khẩu";
            this.checkHienmatkhau.UseVisualStyleBackColor = true;
            this.checkHienmatkhau.CheckedChanged += new System.EventHandler(this.checkHienmatkhau_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tài khoản";
            // 
            // textMatkhau
            // 
            this.textMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMatkhau.Location = new System.Drawing.Point(48, 366);
            this.textMatkhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textMatkhau.Name = "textMatkhau";
            this.textMatkhau.PasswordChar = '*';
            this.textMatkhau.Size = new System.Drawing.Size(319, 31);
            this.textMatkhau.TabIndex = 5;
            this.textMatkhau.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textMatkhau_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu";
            // 
            // textTaikhoan
            // 
            this.textTaikhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTaikhoan.Location = new System.Drawing.Point(48, 271);
            this.textTaikhoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textTaikhoan.Name = "textTaikhoan";
            this.textTaikhoan.Size = new System.Drawing.Size(319, 31);
            this.textTaikhoan.TabIndex = 4;
            this.textTaikhoan.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textTaikhoan_KeyUp);
            // 
            // buttonDangnhap
            // 
            this.buttonDangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDangnhap.Location = new System.Drawing.Point(48, 461);
            this.buttonDangnhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDangnhap.Name = "buttonDangnhap";
            this.buttonDangnhap.Size = new System.Drawing.Size(320, 61);
            this.buttonDangnhap.TabIndex = 7;
            this.buttonDangnhap.Text = "Đăng nhập";
            this.buttonDangnhap.UseVisualStyleBackColor = true;
            this.buttonDangnhap.Click += new System.EventHandler(this.buttonDangnhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(48, 542);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(320, 61);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // formDangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QUANLYGOM.Properties.Resources.Background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1056, 694);
            this.Controls.Add(this.pnlDangNhap);
            this.Name = "formDangnhap";
            this.Text = "Dangnhap";
            this.pnlDangNhap.ResumeLayout(false);
            this.pnlDangNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDangNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkHienmatkhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMatkhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTaikhoan;
        private System.Windows.Forms.Button buttonDangnhap;
        private System.Windows.Forms.Button btnThoat;
    }
}