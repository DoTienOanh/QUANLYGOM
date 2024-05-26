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
    public partial class DanhmucTBSX : Form
    {
        public DanhmucTBSX()
        {
            InitializeComponent();
        }

        private void DanhmucTBSX_Load(object sender, EventArgs e)
        {
            textMaTBSX.Enabled = false;
            buttonLuu.Enabled = false;
            buttonBoqua.Enabled = false;
            load_dataGridView();
            FuncitonHue.fillcombo("select MaNCC, TenNCC from tblNhacungcap", comboMaNCC, "MaNCC", "TenNCC");
            comboMaNCC.SelectedIndex = -1;
            resetValues();
        }
        private void resetValues()
        {
            textMaTBSX.Text = "";
            textTenTBSX.Text = "";
            maskNgaymua.Text = "";
            textThoigianbaohanh.Text = "";
            comboMaNCC.Text = "";
        }
        DataTable tbltbsx;
        private void load_dataGridView()
        {
            string sql;
            sql = "select MaTBSX, TenTBSX, Ngaymua, Thoigianbaohanh, MaNCC from tblTBSX";
            tbltbsx = FuncitonHue.getdatatotable(sql);
            dataGridViewTBSX.DataSource = tbltbsx;
            dataGridViewTBSX.Columns[0].HeaderText = "Ma TBSX";
            dataGridViewTBSX.Columns[1].HeaderText = "Ten TBSX";
            dataGridViewTBSX.Columns[2].HeaderText = "Ngay mua";
            dataGridViewTBSX.Columns[3].HeaderText = "Thoi gian bao hanh";
            dataGridViewTBSX.Columns[4].HeaderText = "Ma NCC";
            dataGridViewTBSX.Columns[0].Width = 100;
            dataGridViewTBSX.Columns[1].Width = 150;
            dataGridViewTBSX.Columns[2].Width = 100;
            dataGridViewTBSX.Columns[3].Width = 150;
            dataGridViewTBSX.Columns[4].Width = 100;
            dataGridViewTBSX.AllowUserToAddRows = false;
            dataGridViewTBSX.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridViewTBSX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma;
            if (buttonThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textMaTBSX.Focus();
                return;
            }
            if (tbltbsx.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textMaTBSX.Text = dataGridViewTBSX.CurrentRow.Cells["MaTBSX"].Value.ToString();
            textTenTBSX.Text = dataGridViewTBSX.CurrentRow.Cells["TenTBSX"].Value.ToString();
            maskNgaymua.Text = dataGridViewTBSX.CurrentRow.Cells["Ngaymua"].Value.ToString().ToLower();
            textThoigianbaohanh.Text = dataGridViewTBSX.CurrentRow.Cells["Thoigianbaohanh"].Value.ToString();
            ma = dataGridViewTBSX.CurrentRow.Cells["MaNCC"].Value.ToString();
            comboMaNCC.Text = FuncitonHue.getFieldValues("select TenNCC from tblNhacungcap where MaNCC = N'" + ma + "'");
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
            textMaTBSX.Enabled = true;
            textMaTBSX.Focus();
            resetValues();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (textMaTBSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ma thiet bi san xuat", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textMaTBSX.Focus();
                return;
            }
            if (textTenTBSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ten thiet bi san xuat", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTenTBSX.Focus();
                return;
            }
            if (maskNgaymua.Text == "  /  /")
            {
                MessageBox.Show("Ban phai nhap ngay mua", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskNgaymua.Focus();
                return;
            }
            if (!Class.FuncitonHue.isdate(maskNgaymua.Text))
            {
                MessageBox.Show("Ban phai nhap lai ngay mua", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskNgaymua.Text = "";
                maskNgaymua.Focus();
            }
            if (textThoigianbaohanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap thoi gian bao hanh", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textThoigianbaohanh.Focus();
                return;
            }
            if (comboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap nha cung cap", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaNCC.Focus();
                return;
            }
            sql = "select MaTBSX from tblTBSX where MaTBSC=N'" + textMaTBSX.Text.Trim() + "'";
            if (FuncitonHue.checkey(sql))
            {
                MessageBox.Show("Ma nhan vien nay da co, ban phai nhap ma khac", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textMaTBSX.Focus();
                textMaTBSX.Text = "";
                return;
            }
            sql = "insert into tblTBSX(MaTBSX,TenTBSX,Ngaymua,Thoigianbaohanh,MaNCC) values (N'" + textMaTBSX.Text.Trim() + "',N'" + textTenTBSX.Text.Trim() + "','" + FuncitonHue.convertDateTime(maskNgaymua.Text) + "',N'" + textThoigianbaohanh.Text.Trim() + "',N'" + comboMaNCC.SelectedValue.ToString() + "')";
            FuncitonHue.runsql(sql);
            load_dataGridView();
            resetValues();
            buttonXoa.Enabled = true;
            buttonThem.Enabled = true;
            buttonSua.Enabled = true;
            buttonBoqua.Enabled = false;
            buttonLuu.Enabled = false;
            textMaTBSX.Enabled = false;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbltbsx.Rows.Count == 0)
            {
                MessageBox.Show("Khong con du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textMaTBSX.Text == "")
            {
                MessageBox.Show("Ban chua chon ban ghi nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textTenTBSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap ten thiet bi san xuat", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textTenTBSX.Focus();
                return;
            }
            if (maskNgaymua.Text == "  /  /")
            {
                MessageBox.Show("Ban phai nhap ngay mua", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskNgaymua.Focus();
                return;
            }
            if (!Class.FuncitonHue.isdate(maskNgaymua.Text))
            {
                MessageBox.Show("Ban phai nhap lai ngay mua", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskNgaymua.Text = "";
                maskNgaymua.Focus();
            }
            if (textThoigianbaohanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap thoi gian bao hanh", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textThoigianbaohanh.Focus();
                return;
            }
            if (comboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ban phai nhap nha cung cap", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaNCC.Focus();
                return;
            }



            sql = "update tblTBSX set TenTBSX=N'" + textTenTBSX.Text.Trim().ToString() + "',Ngaymua='" + FuncitonHue.convertDateTime(maskNgaymua.Text) + "',Thoigianbaohanh=N'" + textThoigianbaohanh.Text.Trim().ToString() + "',MaNCC=N'" + comboMaNCC.SelectedValue.ToString() + "' where MaTBSX=N'" + textMaTBSX.Text + "' ";
            FuncitonHue.runsql(sql);
            load_dataGridView();
            resetValues();
            buttonBoqua.Enabled = false;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbltbsx.Rows.Count == 0)
            {
                MessageBox.Show("Khong con du lieu", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textMaTBSX.Text == "")
            {
                MessageBox.Show("Ban chua con ban ghi nao", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Ban co muon xoa khong", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "delete tblTBSX where MaTBSX=N'" + textMaTBSX.Text + "'";
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
            textMaTBSX.Enabled = false;
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
