using QUANLYGOM.Class;
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
    public partial class formDanhmucnhanvien : Form
    {
        public formDanhmucnhanvien()
        {
            InitializeComponent();
        }

        private void formDanhmucnhanvien_Load(object sender, EventArgs e)
        {
            textManhanvien.Enabled = false;
            buttonLuu.Enabled = false;
            buttonBoqua.Enabled = false;
            load_dataGridView();
            FuncitonHue.fillcombo("select Machucvu, Tenchucvu from tblChucvu", comboMachucvu, "Machucvu", "Tenchucvu");
            comboMachucvu.SelectedIndex = -1;
            resetValues();
        }
        private void resetValues()
        {
            textManhanvien.Text = "";
            textTennhanvien.Text = "";
            textDiachi.Text = "";
            maskSodienthoai.Text = "";
            comboMachucvu.Text = "";
            textSotaikhoan.Text = "";
            textTennganhang.Text = "";
        }
        DataTable tblnv;
        private void load_dataGridView()
        {
            string sql;
            sql = "select Manhanvien, Tennhanvien, Diachi, Sodienthoai, Machucvu, Stk, Tennganhang from tblNhanvien";
            tblnv = FuncitonHue.getdatatotable(sql);
            dataGridViewNhanvien.DataSource = tblnv;
            dataGridViewNhanvien.Columns[0].HeaderText = "Ma nhan vien";
            dataGridViewNhanvien.Columns[1].HeaderText = "Ten nhan vien";
            dataGridViewNhanvien.Columns[2].HeaderText = "Dia chi";
            dataGridViewNhanvien.Columns[3].HeaderText = "So dien thoai";
            dataGridViewNhanvien.Columns[4].HeaderText = "Ma chuc vu";
            dataGridViewNhanvien.Columns[5].HeaderText = "So tai khoan";
            dataGridViewNhanvien.Columns[6].HeaderText = "Ten ngan hang";
            dataGridViewNhanvien.Columns[0].Width = 100;
            dataGridViewNhanvien.Columns[1].Width = 150;
            dataGridViewNhanvien.Columns[2].Width = 200;
            dataGridViewNhanvien.Columns[3].Width = 100;
            dataGridViewNhanvien.Columns[4].Width = 100;
            dataGridViewNhanvien.Columns[5].Width = 100;
            dataGridViewNhanvien.Columns[5].Width = 150;
            dataGridViewNhanvien.AllowUserToAddRows = false;
            dataGridViewNhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridViewNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma;
            if (buttonThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textManhanvien.Focus();
                return;
            }
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textManhanvien.Text = dataGridViewNhanvien.CurrentRow.Cells["Manhanvien"].Value.ToString();
            textTennhanvien.Text = dataGridViewNhanvien.CurrentRow.Cells["Tennhanvien"].Value.ToString();
            textDiachi.Text = dataGridViewNhanvien.CurrentRow.Cells["Diachi"].Value.ToString();
            maskSodienthoai.Text = dataGridViewNhanvien.CurrentRow.Cells["Sodienthoai"].Value.ToString().ToLower();
            ma = dataGridViewNhanvien.CurrentRow.Cells["Machucvu"].Value.ToString();
            comboMachucvu.Text = FuncitonHue.getFieldValues("select Tenchucvu from tblChucvu where Machucvu = N'" + ma + "'");
            textSotaikhoan.Text = dataGridViewNhanvien.CurrentRow.Cells["Stk"].Value.ToString();
            textTennganhang.Text = dataGridViewNhanvien.CurrentRow.Cells["Tennganhang"].Value.ToString();
            buttonSua.Enabled = true;
            buttonXoa.Enabled = true;
            buttonBoqua.Enabled = true;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonBoqua.Enabled = true;
            buttonLuu.Enabled = true;
            buttonThem.Enabled = false;
            textManhanvien.Enabled = true;
            textManhanvien.Focus();
            resetValues();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (textManhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ma nhan vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textManhanvien.Focus();
                return;
            }
            if (textTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ten nhan vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTennhanvien.Focus();
                return;
            }
            if (textDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDiachi.Focus();
                return;
            }
            if (maskSodienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Ban phai nhap dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskSodienthoai.Focus();
                return;
            }
            if (comboMachucvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap chuc vu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMachucvu.Focus();
                return;
            }
            sql = "select Manhanvien from tblNhanvien where Manhanvien=N'" + textManhanvien.Text.Trim() + "'";
            if (FuncitonHue.checkey(sql))
            {
                MessageBox.Show("Ma nhan vien nay da co, ban phai nhap ma khac", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textManhanvien.Focus();
                textManhanvien.Text = "";
                return;
            }
            sql = "insert into tblNhanvien(Manhanvien,Tennhanvien,Diachi,Sodienthoai,Machucvu,Stk,Tennganhang) values (N'" + textManhanvien.Text.Trim() + "',N'" + textTennhanvien.Text.Trim() + "',N'" + textDiachi.Text.Trim() + "','" + maskSodienthoai.Text + "',N'" + comboMachucvu.SelectedValue.ToString() + "',N'" + textSotaikhoan.Text.Trim() + "',N'" + textTennganhang.Text.Trim() + "')";
            FuncitonHue.runsql(sql);
            load_dataGridView();
            resetValues();
            buttonXoa.Enabled = true;
            buttonThem.Enabled = true;
            buttonSua.Enabled = true;
            buttonBoqua.Enabled = false;
            buttonLuu.Enabled = false;
            textManhanvien.Enabled = false;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Khong con du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textManhanvien.Text == "")
            {
                MessageBox.Show("Ban chua chon ban ghi nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ten nhan vien", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTennhanvien.Focus();
                return;
            }
            if (textDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDiachi.Focus();
                return;
            }
            if (maskSodienthoai.Text == "(   )    -")
            {
                MessageBox.Show("Ban phai nhap so dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskSodienthoai.Focus();
                return;
            }
            if (comboMachucvu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap chuc vu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMachucvu.Focus();
                return;
            }

            if (textSotaikhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap so tai khoan", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSotaikhoan.Focus();
                return;
            }
            if (textTennganhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ten ngan hang", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTennganhang.Focus();
                return;
            }



            sql = "update tblNhanvien set Tennhavien=N'" + textTennhanvien.Text.Trim().ToString() + "',Diachi=N'" + textDiachi.Text.Trim().ToString() + "',Sodienthoai='" + maskSodienthoai.Text.ToString() + "',Machucvu=N'" + comboMachucvu.SelectedValue.ToString() + "',Stk=N'" + textSotaikhoan.Text.Trim().ToString() + "',Tennganhang=N'" + textTennganhang.Text.Trim().ToString() + "' where Manhanvien=N'" + textManhanvien.Text + "'";
            FuncitonHue.runsql(sql);
            load_dataGridView();
            resetValues();
            buttonBoqua.Enabled = false;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnv.Rows.Count == 0)
            {
                MessageBox.Show("Khong con du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textManhanvien.Text == "")
            {
                MessageBox.Show("Ban chua con ban ghi nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Ban co muon xoa khong", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "delete tblNhanvien where Manhanvien=N'" + textManhanvien.Text + "'";
                FuncitonHue.runsql(sql);
                load_dataGridView();
                resetValues();
            }
        }

        private void buttonBoqua_Click(object sender, EventArgs e)
        {
            resetValues();
            buttonBoqua.Enabled = false;
            buttonThem.Enabled = true;
            buttonXoa.Enabled = true;
            buttonSua.Enabled = true;
            buttonLuu.Enabled = false;
            textManhanvien.Enabled = false;
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
