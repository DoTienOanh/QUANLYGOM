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
    public partial class TimkiemHDN : Form
    {
        public TimkiemHDN()
        {
            InitializeComponent();
        }

        private void TimkiemHDN_Load(object sender, EventArgs e)
        {
            Class.FunctionHuong.Connect();
            ResetValues();
            DataGridView.DataSource = null;
            Class.FunctionHuong.FillCombo("select manhanvien,tennhanvien from tblNhanVien WHERE machucvu IN ('CV01')", cboNhanvien, "manhanvien", "tennhanvien");
            cboNhanvien.SelectedIndex = -1;
            Class.FunctionHuong.FillCombo("select mancc,tenncc from tblNhaCungCap", cboNcc, "mancc", "tenncc");
            cboNcc.SelectedIndex = -1;
           // txtTongtien.Enabled = false;
        }
        DataTable tblTKHDN;
        private void ResetValues()
        {
            txtMahoadon.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtTongtien.Text = "";
            cboNhanvien.Text = "";
            cboNcc.Text = "";
        }


        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahoadon.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") && (txtTongtien.Text == "") && (cboNcc.Text == "") && (cboNhanvien.Text == ""))
            {
                MessageBox.Show("Hãy nhập ít nhất một điều kiện tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = @"
        SELECT hd.mahdn, nv.tennhanvien, hd.ngaynhap, ncc.tenncc, 
               ISNULL(SUM(ct.dongia * ct.soluongthucnhap), 0) AS tongtien
        FROM tblHoadonnhapNVL hd
        LEFT JOIN tblNhanVien nv ON hd.manhanvien = nv.manhanvien
        LEFT JOIN tblNhaCungCap ncc ON hd.mancc = ncc.mancc
        LEFT JOIN tblChitietnhapNVL ct ON hd.mahdn = ct.mahdn
        WHERE 1=1";

         //   sql = "SELECT * from tblHoadonnhapNVL where 1=1";
            if (txtMahoadon.Text != "")
                sql = sql + " AND hd.mahdn like N'%" + txtMahoadon.Text + "%'";//%: Đại diện cho 0 hoặc nhiều ký tự bất kỳ
            if (txtThang.Text != "")
                sql = sql + " AND month(ngaynhap) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND year(ngaynhap) =" + txtNam.Text;
            if (cboNhanvien.Text != "")
                sql = sql + " AND hd.manhanvien like N'%" + cboNhanvien.SelectedValue.ToString() + "%'";
            if (cboNcc.Text != "")
                sql = sql + " AND HD.mancc like N'%" + cboNcc.SelectedValue.ToString() + "%'";
            

            sql += " GROUP BY hd.mahdn, nv.tennhanvien, hd.ngaynhap, ncc.tenncc";
            if (txtTongtien.Text != "")
                sql += " HAVING ISNULL(SUM(ct.dongia * ct.soluongthucnhap), 0) LIKE N'%" + txtTongtien.Text + "%'";

            tblTKHDN = Class.FunctionHuong.GetDataToTable(sql);
            if (tblTKHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTKHDN.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblTKHDN;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
           /* string sql = @"
        SELECT hd.mahdn, nv.tennhanvien, hd.ngaynhap, ncc.tenncc, 
               ISNULL(SUM(ct.dongia * ct.soluongthucnhap), 0) AS tongtien
        FROM tblHoadonnhapNVL hd
        LEFT JOIN tblNhanVien nv ON hd.manhanvien = nv.manhanvien
        LEFT JOIN tblNhaCungCap ncc ON hd.mancc = ncc.mancc
        LEFT JOIN tblChitietnhapNVL ct ON hd.mahdn = ct.mahdn
        GROUP BY hd.mahdn, nv.tennhanvien, hd.ngaynhap, ncc.tenncc";
            tblTKHDN = Class.FunctionHuong.GetDataToTable(sql);*/

            DataGridView.DataSource = tblTKHDN;
            DataGridView.Columns[0].HeaderText = "Mã hóa đơn";
            DataGridView.Columns[1].HeaderText = "Nhân viên";
            DataGridView.Columns[2].HeaderText = "Ngày nhập";
            DataGridView.Columns[3].HeaderText = "Nhà cung cấp";
            DataGridView.Columns[4].HeaderText = "Tổng tiền";
            DataGridView.Columns[0].Width = 100;
            DataGridView.Columns[1].Width = 150;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 150;
            DataGridView.Columns[4].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false; //Nếu phím là số (0-9) hoặc phím Backspace, e.Handled được đặt thành false, cho phép phím được chấp nhận.
            else
                e.Handled = true;
        }
        
        //CODE KÍCH ĐÚP ĐỂ HIỂN THỊ CHI TIẾT
    }

}
