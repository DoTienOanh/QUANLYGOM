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
    public partial class TimkiemHDB : Form
    {
        public TimkiemHDB()
        {
            InitializeComponent();
        }

        private void TimkiemHDB_Load(object sender, EventArgs e)
        {
            Class.FunctionHuong.Connect();
            ResetValues();
            DataGridView.DataSource = null;
            Class.FunctionHuong.FillCombo("select manhanvien,tennhanvien from tblNhanVien WHERE machucvu IN ('CV02')", cboNhanvien, "manhanvien", "tennhanvien");
            cboNhanvien.SelectedIndex = -1;
            Class.FunctionHuong.FillCombo("select makhachhang,tenkhachhang from tblKhachhang", cboKhachhang, "makhachhang", "tenkhachhang");
            cboKhachhang.SelectedIndex = -1;
            // txtTongtien.Enabled = false;
        }
        DataTable tblTKHDB;
        private void ResetValues()
        {
            txtMahoadon.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
            txtTongtien.Text = "";
            cboNhanvien.Text = "";
            cboKhachhang.Text = "";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahoadon.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") && (txtTongtien.Text == "") && (cboKhachhang.Text == "") && (cboNhanvien.Text == ""))
            {
                MessageBox.Show("Hãy nhập ít nhất một điều kiện tìm kiếm!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = @"
                SELECT hd.mahdb, nv.tennhanvien, hd.ngayban, kh.tenkhachhang, 
                ISNULL(SUM(ct.thanhtien), 0) AS tongtien
                FROM tblHDB hd
                LEFT JOIN tblNhanVien nv ON hd.manhanvien = nv.manhanvien
                LEFT JOIN tblKhachhang kh ON hd.makhachhang = kh.makhachhang
                LEFT JOIN tblChitietHDB ct ON hd.mahdb = ct.mahdb
                WHERE 1=1";

            
            if (txtMahoadon.Text != "")
                sql = sql + " AND hd.mahdb like N'%" + txtMahoadon.Text + "%'";//%: Đại diện cho 0 hoặc nhiều ký tự bất kỳ
            if (txtThang.Text != "")
                sql = sql + " AND month(ngayban) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND year(ngayban) =" + txtNam.Text;
            if (cboNhanvien.Text != "")
                sql = sql + " AND hd.manhanvien like N'%" + cboNhanvien.SelectedValue.ToString() + "%'";
            if (cboKhachhang.Text != "")
                sql = sql + " AND HD.makhachhang like N'%" + cboKhachhang.SelectedValue.ToString() + "%'";


            sql += " GROUP BY hd.mahdb, nv.tennhanvien, hd.ngayban, kh.tenkhachhang";
            if (txtTongtien.Text != "")
                sql += " HAVING ISNULL(SUM(ct.dongia * ct.soluong), 0) LIKE N'%" + txtTongtien.Text + "%'";

            tblTKHDB = Class.FunctionHuong.GetDataToTable(sql);
            if (tblTKHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTKHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tblTKHDB;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
           /* string sql = @"
        SELECT hd.mahdb, nv.tennhanvien, hd.ngayban, kh.tenkhachhang, 
               ISNULL(SUM(ct.dongia * ct.soluong), 0) AS tongtien
        FROM tblHDB hd
        LEFT JOIN tblNhanVien nv ON hd.manhanvien = nv.manhanvien
        LEFT JOIN tblKhachhang kh ON hd.makhachhang = kh.makhachhang
        LEFT JOIN tblChitietHDB ct ON hd.mahdb = ct.mahdb
        GROUP BY hd.mahdb, nv.tennhanvien, hd.ngayban, kh.tenkhachhang";
            tblTKHDB = Class.FunctionHuong.GetDataToTable(sql);*/

            DataGridView.DataSource = tblTKHDB;
            DataGridView.Columns[0].HeaderText = "Mã hóa đơn";
            DataGridView.Columns[1].HeaderText = "Nhân viên";
            DataGridView.Columns[2].HeaderText = "Ngày bán";
            DataGridView.Columns[3].HeaderText = "Khách hàng";
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

        private void btnDong_Click(object sender, EventArgs e)
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
        //Kích đúp
        //CODE KÍCH ĐÚP ĐỂ HIỂN THỊ CHI TIẾT
    }
}
