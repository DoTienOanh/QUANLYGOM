using QUANLYGOM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYGOM.Forms
{
    public partial class Danhmuchanghoa : Form
    {
        public Danhmuchanghoa()
        {
            InitializeComponent();
        }

        private void Danhmuchanghoa_Load(object sender, EventArgs e)
        {
            Class.FunctionHuong.Connect();
            txtMahang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            FunctionHuong.FillCombo("SELECT Maloai, Tenloai FROM tblLoaihang", cboTenloai, "Maloai", "Tenloai"); //FillCombo ddoor vaof combobox
            cboTenloai.SelectedIndex = -1;
            ResetValues();
        }
        DataTable tblH;
        private void ResetValues()
        {
            txtMahang.Text = "";
            txtTenhang.Text = "";
            cboTenloai.Text = "";
            txtSoluong.Text = "0";
            txtKichco.Text = "0";
            txtChatluong.Text = "";
            txtDongia.Text = "0";
            txtSoluong.Enabled = true;
            txtKichco.Enabled = true;
            txtChatluong.Enabled = true;
            txtDongia.Enabled = true;
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Mahang, Tenhang, Maloai, Kichco, soluong, Chatluong, Dongia FROM tblHanghoa"; //ten trong sql
            tblH = FunctionHuong.GetDataToTable(sql);
            DataGridView.DataSource = tblH;
            DataGridView.Columns[0].HeaderText = "Mã hàng";
            DataGridView.Columns[1].HeaderText = "Tên hàng";
            DataGridView.Columns[2].HeaderText = "Tên loại";
            DataGridView.Columns[3].HeaderText = "Kích cỡ";
            DataGridView.Columns[4].HeaderText = "Số lượng";
            DataGridView.Columns[5].HeaderText = "Chất lượng";
            DataGridView.Columns[6].HeaderText = "Đơn giá";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 140;
            DataGridView.Columns[2].Width = 100;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            DataGridView.Columns[6].Width = 100;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMahang.Text = DataGridView.CurrentRow.Cells["Mahang"].Value.ToString();
            txtTenhang.Text = DataGridView.CurrentRow.Cells["Tenhang"].Value.ToString();

            ma = DataGridView.CurrentRow.Cells["Maloai"].Value.ToString();
            cboTenloai.Text = FunctionHuong.GetFieldValues("SELECT Tenloai FROM tblLoaihang WHERE Maloai = N'" + ma + "'");

            txtSoluong.Text = DataGridView.CurrentRow.Cells["Soluong"].Value.ToString();
            txtKichco.Text = DataGridView.CurrentRow.Cells["Kichco"].Value.ToString();
            txtChatluong.Text = DataGridView.CurrentRow.Cells["Chatluong"].Value.ToString();
            txtDongia.Text = DataGridView.CurrentRow.Cells["Dongia"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMahang.Enabled = true;
            txtMahang.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //kiem tra cau lenh sql
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMahang.Focus();
                return;
            }
            if (cboTenloai.Text == "")
            {
                MessageBox.Show("Bạn phải chọn loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTenloai.Focus();
                return;
            }

            //Kiem tra ma trung
            sql = "select mahang from tblHanghoa where mahang = N' " + txtMahang.Text + " '";
            if (Class.FunctionHuong.CheckKey(sql))
            {
                MessageBox.Show("Đã có mã này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMahang.Text = "";
                txtMahang.Focus();
                return;
            }
            sql = "INSERT INTO tblHanghoa(mahang,tenhang,maloai, kichco, soluong,chatluong, dongia ) VALUES(N'" + txtMahang.Text + "',N'" + txtTenhang.Text + "', N'" + cboTenloai.SelectedValue.ToString() + "',N'" + txtKichco.Text + "'," + txtSoluong.Text + ",N'" + txtChatluong.Text + "'," + txtDongia.Text + ")";
            FunctionHuong.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhang.Focus();
                return;
            }
            if (cboTenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTenloai.Focus();
                return;
            }
            if (txtChatluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất lượng hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChatluong.Focus();
                return;
            }
            if (txtKichco.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập kích cỡ hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKichco.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (txtDongia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongia.Focus();
                return;
            }


            sql = "UPDATE tblHanghoa SET  Tenhang=N'" + txtTenhang.Text.Trim().ToString() +
                "',Maloai=N'" + cboTenloai.SelectedValue.ToString() + "', Kichco=N'" + txtKichco.Text.Trim().ToString() + "', Soluong=" + txtSoluong.Text + ",Chatluong=N'" + txtChatluong.Text.Trim().ToString() + "',Dongia=" + txtDongia.Text + " WHERE mahang=N'" + txtMahang.Text + "'";
            FunctionHuong.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblHanghoa WHERE Mahang=N'" + txtMahang.Text + "'";
                FunctionHuong.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;
        }
    }
}
 

