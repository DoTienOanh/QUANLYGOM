namespace QUANLYGOM
{
    partial class formMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDanhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHanghoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhacungcap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTBSX = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHDN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHDTBSX = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaocao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCDoanhthu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBCChiphi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChamcong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChitietCC = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTongketluong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimkiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTKHDN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTKHDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTKHDTBSX = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhmuc,
            this.mnuHoadon,
            this.mnuBaocao,
            this.mnuChamcong,
            this.mnuTimkiem,
            this.mnuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(900, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDanhmuc
            // 
            this.mnuDanhmuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHanghoa,
            this.mnuNhanvien,
            this.mnuKhachhang,
            this.mnuNhacungcap,
            this.mnuTBSX});
            this.mnuDanhmuc.Name = "mnuDanhmuc";
            this.mnuDanhmuc.Size = new System.Drawing.Size(109, 29);
            this.mnuDanhmuc.Text = "Danh mục";
            // 
            // mnuHanghoa
            // 
            this.mnuHanghoa.Name = "mnuHanghoa";
            this.mnuHanghoa.Size = new System.Drawing.Size(242, 34);
            this.mnuHanghoa.Text = "Hàng hóa";
            this.mnuHanghoa.Click += new System.EventHandler(this.mnuHanghoa_Click);
            // 
            // mnuNhanvien
            // 
            this.mnuNhanvien.Name = "mnuNhanvien";
            this.mnuNhanvien.Size = new System.Drawing.Size(242, 34);
            this.mnuNhanvien.Text = "Nhân viên";
            this.mnuNhanvien.Click += new System.EventHandler(this.mnuNhanvien_Click);
            // 
            // mnuKhachhang
            // 
            this.mnuKhachhang.Name = "mnuKhachhang";
            this.mnuKhachhang.Size = new System.Drawing.Size(242, 34);
            this.mnuKhachhang.Text = "Khách hàng";
            this.mnuKhachhang.Click += new System.EventHandler(this.mnuKhachhang_Click);
            // 
            // mnuNhacungcap
            // 
            this.mnuNhacungcap.Name = "mnuNhacungcap";
            this.mnuNhacungcap.Size = new System.Drawing.Size(242, 34);
            this.mnuNhacungcap.Text = "Nhà cung cấp";
            this.mnuNhacungcap.Click += new System.EventHandler(this.mnuNhacungcap_Click);
            // 
            // mnuTBSX
            // 
            this.mnuTBSX.Name = "mnuTBSX";
            this.mnuTBSX.Size = new System.Drawing.Size(242, 34);
            this.mnuTBSX.Text = "Thiết bị sản xuất";
            this.mnuTBSX.Click += new System.EventHandler(this.mnuTBSX_Click);
            // 
            // mnuHoadon
            // 
            this.mnuHoadon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHDN,
            this.mnuHDB,
            this.mnuHDTBSX});
            this.mnuHoadon.Name = "mnuHoadon";
            this.mnuHoadon.Size = new System.Drawing.Size(98, 29);
            this.mnuHoadon.Text = "Hóa đơn";
            // 
            // mnuHDN
            // 
            this.mnuHDN.Name = "mnuHDN";
            this.mnuHDN.Size = new System.Drawing.Size(282, 34);
            this.mnuHDN.Text = "Hóa đơn nhập NVL";
            // 
            // mnuHDB
            // 
            this.mnuHDB.Name = "mnuHDB";
            this.mnuHDB.Size = new System.Drawing.Size(282, 34);
            this.mnuHDB.Text = "Hóa đơn bán";
            // 
            // mnuHDTBSX
            // 
            this.mnuHDTBSX.Name = "mnuHDTBSX";
            this.mnuHDTBSX.Size = new System.Drawing.Size(282, 34);
            this.mnuHDTBSX.Text = "Hóa đơn chi trả TBSX";
            // 
            // mnuBaocao
            // 
            this.mnuBaocao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBCDoanhthu,
            this.mnuBCChiphi});
            this.mnuBaocao.Name = "mnuBaocao";
            this.mnuBaocao.Size = new System.Drawing.Size(94, 29);
            this.mnuBaocao.Text = "Báo Cáo";
            // 
            // mnuBCDoanhthu
            // 
            this.mnuBCDoanhthu.Name = "mnuBCDoanhthu";
            this.mnuBCDoanhthu.Size = new System.Drawing.Size(198, 34);
            this.mnuBCDoanhthu.Text = "Doanh thu";
            // 
            // mnuBCChiphi
            // 
            this.mnuBCChiphi.Name = "mnuBCChiphi";
            this.mnuBCChiphi.Size = new System.Drawing.Size(198, 34);
            this.mnuBCChiphi.Text = "Chi phí";
            // 
            // mnuChamcong
            // 
            this.mnuChamcong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChitietCC,
            this.mnuTongketluong});
            this.mnuChamcong.Name = "mnuChamcong";
            this.mnuChamcong.Size = new System.Drawing.Size(119, 29);
            this.mnuChamcong.Text = "Chấm công";
            // 
            // mnuChitietCC
            // 
            this.mnuChitietCC.Name = "mnuChitietCC";
            this.mnuChitietCC.Size = new System.Drawing.Size(262, 34);
            this.mnuChitietCC.Text = "Chi tiết chấm công";
            // 
            // mnuTongketluong
            // 
            this.mnuTongketluong.Name = "mnuTongketluong";
            this.mnuTongketluong.Size = new System.Drawing.Size(262, 34);
            this.mnuTongketluong.Text = "Tổng kết lương";
            // 
            // mnuTimkiem
            // 
            this.mnuTimkiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTKHDN,
            this.mnuTKHDB,
            this.mnuTKHDTBSX});
            this.mnuTimkiem.Name = "mnuTimkiem";
            this.mnuTimkiem.Size = new System.Drawing.Size(100, 29);
            this.mnuTimkiem.Text = "Tìm kiếm";
            // 
            // mnuTKHDN
            // 
            this.mnuTKHDN.Name = "mnuTKHDN";
            this.mnuTKHDN.Size = new System.Drawing.Size(282, 34);
            this.mnuTKHDN.Text = "Hóa đơn nhập NVL";
            this.mnuTKHDN.Click += new System.EventHandler(this.mnuTKHDN_Click);
            // 
            // mnuTKHDB
            // 
            this.mnuTKHDB.Name = "mnuTKHDB";
            this.mnuTKHDB.Size = new System.Drawing.Size(282, 34);
            this.mnuTKHDB.Text = "Hóa đơn bán";
            // 
            // mnuTKHDTBSX
            // 
            this.mnuTKHDTBSX.Name = "mnuTKHDTBSX";
            this.mnuTKHDTBSX.Size = new System.Drawing.Size(282, 34);
            this.mnuTKHDTBSX.Text = "Hóa đơn chi trả TBSX";
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(73, 29);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // formMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 563);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhmuc;
        private System.Windows.Forms.ToolStripMenuItem mnuHanghoa;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanvien;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachhang;
        private System.Windows.Forms.ToolStripMenuItem mnuNhacungcap;
        private System.Windows.Forms.ToolStripMenuItem mnuTBSX;
        private System.Windows.Forms.ToolStripMenuItem mnuHoadon;
        private System.Windows.Forms.ToolStripMenuItem mnuHDN;
        private System.Windows.Forms.ToolStripMenuItem mnuHDB;
        private System.Windows.Forms.ToolStripMenuItem mnuHDTBSX;
        private System.Windows.Forms.ToolStripMenuItem mnuBaocao;
        private System.Windows.Forms.ToolStripMenuItem mnuBCDoanhthu;
        private System.Windows.Forms.ToolStripMenuItem mnuBCChiphi;
        private System.Windows.Forms.ToolStripMenuItem mnuChamcong;
        private System.Windows.Forms.ToolStripMenuItem mnuChitietCC;
        private System.Windows.Forms.ToolStripMenuItem mnuTongketluong;
        private System.Windows.Forms.ToolStripMenuItem mnuTimkiem;
        private System.Windows.Forms.ToolStripMenuItem mnuTKHDN;
        private System.Windows.Forms.ToolStripMenuItem mnuTKHDB;
        private System.Windows.Forms.ToolStripMenuItem mnuTKHDTBSX;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
    }
}

