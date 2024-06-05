using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYGOM
{
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Class.FuncitonHue.Connect();
            //Class.FunctionHuong.Connect();

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class.FuncitonHue.Disconnect();
            Application.Exit();
        }

        private void mnuKhachhang_Click(object sender, EventArgs e)
        {
            Forms.Danhmuckhachhang f = new Forms.Danhmuckhachhang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHanghoa_Click(object sender, EventArgs e)
        {
            Forms.Danhmuchanghoa f = new Forms.Danhmuchanghoa();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhanvien_Click(object sender, EventArgs e)
        {
            Forms.formDanhmucnhanvien f = new Forms.formDanhmucnhanvien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhacungcap_Click(object sender, EventArgs e)
        {
            Forms.DanhmucNCC f = new Forms.DanhmucNCC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTBSX_Click(object sender, EventArgs e)
        {
            Forms.DanhmucTBSX f = new Forms.DanhmucTBSX();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuTKHDN_Click(object sender, EventArgs e)
        {
            Forms.TimkiemHDN f = new Forms.TimkiemHDN();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHDN_Click(object sender, EventArgs e)
        {
            Forms.formHDnhapNVL f = new Forms.formHDnhapNVL();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuHDB_Click(object sender, EventArgs e)
        {
            Forms.formHoadonban f = new Forms.formHoadonban();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
