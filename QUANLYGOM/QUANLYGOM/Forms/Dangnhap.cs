using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYGOM.Forms
{
    public partial class formDangnhap : Form
    {
        public formDangnhap()
        {
            InitializeComponent();
        }

        private void buttonDangnhap_Click(object sender, EventArgs e)
        {
            if(textTaikhoan.Text.Trim().Length==0 && textMatkhau.Text.Trim().Length==0)
            {
                MessageBox.Show("Hãy nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTaikhoan.Focus();
                return;
            }
            else if (textTaikhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTaikhoan.Focus();
                return;
            }
            else if (textMatkhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textMatkhau.Focus();
                return;
            }

            if (textTaikhoan.Text == "admin" && textMatkhau.Text == "admin")
            {
                this.Hide();
                formMenu f = new formMenu();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác, hãy nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTaikhoan.Clear();
                textMatkhau.Clear();
                textTaikhoan.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void textMatkhau_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonDangnhap.PerformClick();
        }

        private void checkHienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            textMatkhau.PasswordChar = checkHienmatkhau.Checked ? '\0' : '*';
        }

        private void textTaikhoan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
