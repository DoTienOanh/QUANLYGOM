using QUANLYGOM.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYGOM.Forms
{
    public partial class formHoadonchitraTBSX : Form
    {
        public formHoadonchitraTBSX()
        {
            InitializeComponent();
        }

        private void formHoadonchitraTBSX_Load(object sender, EventArgs e)
        {
            buttonThemHD.Enabled = true;
            buttonLuu.Enabled = false;
            buttonHuyHD.Enabled = false;
            buttonInHD.Enabled = false;
            textMaHDC.ReadOnly = true;
            textTenNV.ReadOnly = true;
            textTenNCC.ReadOnly = true;
            textDiachi.ReadOnly = true;
            textDienthoai.ReadOnly = true;
            textTenTBSX.ReadOnly = true;
            textThanhtien.ReadOnly = true;
            textTongtien.ReadOnly = true;
            textTongtien.Text = "0";
            FuncitonHue.fillcombo("select MaNCC, TenNCC from tblNhacungcap", comboMaNCC, "MaNCC", "TenNCC");
            comboMaNCC.SelectedIndex = -1;
            FuncitonHue.fillcombo("select Manhanvien, Tennhanvien from tblNhanvien", comboMaNV, "Manhanvien", "Tennhanvien");
            comboMaNV.SelectedIndex = -1;
            FuncitonHue.fillcombo("select MaTBSX, TenTBSX from tblTBSX", comboMaTBSX, "MaTBSX", "TenTBSX");
            comboMaTBSX.SelectedIndex = -1;
            FuncitonHue.fillcombo("select MaHDC from tblHoadonchitraTBSX", comboMaHDC, "MaHDC", "MaHDC");
            comboMaHDC.SelectedIndex = -1;
            if (textMaHDC.Text != "")
            {
                Load_ThongtinHD();
                buttonHuyHD.Enabled = true;
                buttonInHD.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }
        DataTable tblHDC;

        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "select a.MaTBSX, b.TenTBSX, a.Soluong, a.Lido, a.Dongia, a.Thanhtien " +
                "from tblChitiethoadonchitraTBSX as a, tblTBSX as b " +
                "where a.MaHDC = N'" + textMaHDC.Text + "' and a.MaTBSX = b.MaTBSX";
            tblHDC = FuncitonHue.getdatatotable(sql);
            dataGridViewHDC.DataSource = tblHDC;
            dataGridViewHDC.Columns[0].HeaderText = "Ma TBSX";
            dataGridViewHDC.Columns[1].HeaderText = "Ten TBSX";
            dataGridViewHDC.Columns[2].HeaderText = "So luong";
            dataGridViewHDC.Columns[3].HeaderText = "Ly do";
            dataGridViewHDC.Columns[4].HeaderText = "Don gia";
            dataGridViewHDC.Columns[5].HeaderText = "Thanh tien";
            dataGridViewHDC.Columns[0].Width = 80;
            dataGridViewHDC.Columns[1].Width = 100;
            dataGridViewHDC.Columns[2].Width = 80;
            dataGridViewHDC.Columns[3].Width = 90;
            dataGridViewHDC.Columns[4].Width = 90;
            dataGridViewHDC.Columns[5].Width = 90;
            dataGridViewHDC.AllowUserToAddRows = false;
            dataGridViewHDC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "select Ngaychi from tblHoadonchitraTBSX where MaHDC = N'" + textMaHDC.Text + "'";
            textNgaylap.Text = FuncitonHue.convertDateTime(FuncitonHue.getFieldValues(str));
            str = "select Manhanvien from tblHoadonchitraTBSX where MaHDC = N'" + textMaHDC.Text + "'";
            comboMaNV.Text = FuncitonHue.getFieldValues(str);
            str = "select Mancc from tblHoadonchitraTBSX where MaHDC = N'" + textMaHDC.Text + "'";
            comboMaNCC.Text = FuncitonHue.getFieldValues(str);
            str = "select Tongtien from tblHoadonchitraTBSX where MaHDC = N'" + textMaHDC.Text + "'";
            textTongtien.Text = FuncitonHue.getFieldValues(str);
            labelBangchu.Text = "Bằng chữ: " + FuncitonHue.ChuyenSoSangChu(textTongtien.Text);
        }

        private void buttonThemHD_Click(object sender, EventArgs e)
        {
            buttonHuyHD.Enabled = false;
            buttonLuu.Enabled = true;
            buttonInHD.Enabled = false;
            buttonThemHD.Enabled = false;
            ResetValues();
            textMaHDC.Text = FuncitonHue.CreateKey("HDC");
            Load_DataGridViewChitiet();
        }
        private void ResetValues()
        {
            textMaHDC.Text = "";
            textNgaylap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            comboMaNV.Text = "";
            textTenNV.Text = "";
            comboMaNCC.Text = "";
            textTenNCC.Text = "";
            textDiachi.Text = "";
            textDienthoai.Text = "";
            textTongtien.Text = "0";
            labelBangchu.Text = "Bằng chữ: ";
            comboMaTBSX.Text = "";
            textSL.Text = "";
            textLydo.Text = "";
            textDongia.Text = "";
            textThanhtien.Text = "0";
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double tong, tongmoi;
            sql = "select MaHDC from tblHoadonchitraTBSX where MaHDC = N'" + textMaHDC.Text + "'";
            if (!FuncitonHue.checkey(sql))
            {
                if (textNgaylap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày lập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textNgaylap.Focus();
                    return;
                }
                if (comboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaNV.Focus();
                    return;
                }
                if (comboMaNCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaNCC.Focus();
                    return;
                }
                sql = "insert into tblHoadonchitraTBSX(MaHDC, Ngaychi, Manhanvien, Mancc, Tongtien) values(N'" + textMaHDC.Text.Trim() + "', '" + DateTime.ParseExact(textNgaylap.Text.Trim(), "dd/MM/yyyy HH:mm:ss", null).ToString("yyyy-MM-dd HH:mm:ss") + "', N'" + comboMaNV.SelectedValue + "', N'" + comboMaNCC.SelectedValue + "', " + textTongtien.Text + ")";
                FuncitonHue.runsql(sql);
            }

            if (comboMaTBSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã TBSX", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaTBSX.Focus();
                return;
            }
            if ((textSL.Text.Trim().Length == 0) || (textSL.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSL.Text = "";
                textSL.Focus();
                return;
            }
            if (textLydo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lý do", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaTBSX.Focus();
                return;
            }
            if (textDongia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDongia.Focus();
                return;
            }
            sql = "select MaTBSX from tblChitiethoadonchitraTBSX where MaTBSX = N'" + comboMaTBSX.SelectedValue + "' and MaHDC = N'" + textMaHDC.Text.Trim() + "'";
            if (FuncitonHue.checkey(sql))
            {
                MessageBox.Show("Mã TBSX này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                comboMaTBSX.Focus();
                return;
            }

            sql = "insert into tblChitiethoadonchitraTBSX(MaHDC, MaTBSX, Soluong, Lido, Dongia, Thanhtien) values(N'" + textMaHDC.Text.Trim() + "', N'" + comboMaTBSX.SelectedValue + "', " + textSL.Text + ", N'" + textLydo.Text.Trim() + "', " + textDongia.Text + ", " + textThanhtien.Text + ")";
            FuncitonHue.runsql(sql);
            Load_DataGridViewChitiet();

            tong = Convert.ToDouble(FuncitonHue.getFieldValues("select Tongtien from tblHoadonchitraTBSX where MaHDC = N'" + textMaHDC.Text + "'"));
            tongmoi = tong + Convert.ToDouble(textThanhtien.Text);
            sql = "update tblHoadonchitraTBSX set Tongtien =" + tongmoi + " where MaHDC = N'" + textMaHDC.Text + "'";
            FuncitonHue.runsql(sql);

            textTongtien.Text = tongmoi.ToString();
            labelBangchu.Text = "Bằng chữ: " + FuncitonHue.ChuyenSoSangChu(tongmoi.ToString());
            ResetValuesHang();
            buttonHuyHD.Enabled = true;
            buttonThemHD.Enabled = true;
            buttonInHD.Enabled = true;
        }
        private void ResetValuesHang()
        {
            comboMaTBSX.Text = "";
            textTenTBSX.Text = "";
            textSL.Text = "";
            textLydo.Text = "";
            textDongia.Text = "";
            textThanhtien.Text = "0";
        }

        private void dataGridViewHDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double thanhtien;
            if (tblHDC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                mahang = dataGridViewHDC.CurrentRow.Cells["MaTBSX"].Value.ToString();
                DelHang(textMaHDC.Text, mahang);
                thanhtien = Convert.ToDouble(dataGridViewHDC.CurrentRow.Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(textMaHDC.Text, thanhtien);
                Load_DataGridViewChitiet();
            }
        }
        private void DelHang(string MaHDC, string MaTBSX)
        {
            Double s;
            string sql;
            sql = "select Soluong from tblChitiethoadonchitraTBSX where MaHDC = N'" + MaHDC + "' and MaTBSX = N'" + MaTBSX + "'";
            s = Convert.ToInt32(FuncitonHue.getFieldValues(sql));
            sql = "delete tblChitiethoadonchitraTBSX where MaHDC = N'" + MaHDC + "' and MaTBSX = N'" + MaTBSX + "'";
            FuncitonHue.RunSQL_Del(sql);
        }

        private void DelUpdateTongtien(string MaHDC, double Thanhtien)
        {
            Double tong, tongmoi;
            string sql;
            sql = "select Tongtien from tblHoadonchitraTBSX where MaHDC = N'" + MaHDC + "'";
            tong = Convert.ToDouble(FuncitonHue.getFieldValues(sql));
            tongmoi = tong - Thanhtien;
            sql = "update tblHoadonchitraTBSX set Tongtien =" + tongmoi + " where MaHDC = N'" + MaHDC + "'";
            FuncitonHue.runsql(sql);
            textTongtien.Text = tongmoi.ToString();
            labelBangchu.Text = "Bằng chữ: " + FuncitonHue.ChuyenSoSangChu(tongmoi.ToString());
        }

        private void comboMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaNV.Text == "")
                textTenNV.Text = "";
            str = "select Tennhanvien from tblNhanvien where Manhanvien = N'" + comboMaNV.SelectedValue + "'";
            textTenNV.Text = FuncitonHue.getFieldValues(str);
        }

        private void comboMaNCC_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaNCC.Text == "")
            {
                textTenNCC.Text = "";
                textDiachi.Text = "";
                textDienthoai.Text = "";
            }
            str = "select TenNCC from tblNhacungcap where MaNCC = N'" + comboMaNCC.SelectedValue + "'";
            textTenNCC.Text = FuncitonHue.getFieldValues(str);
            str = "select DiaChi from tblNhacungcap where MaNCC = N'" + comboMaNCC.SelectedValue + "'";
            textDiachi.Text = FuncitonHue.getFieldValues(str);
            str = "select Sodienthoai from tblNhacungcap where MaNCC = N'" + comboMaNCC.SelectedValue + "'";
            textDienthoai.Text = FuncitonHue.getFieldValues(str);
        }

        private void comboMaTBSX_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaTBSX.Text == "")
            {
                textTenTBSX.Text = "";
            }
            str = "select TenTBSX from tblTBSX where MaTBSX =N'" + comboMaTBSX.SelectedValue + "'";
            textTenTBSX.Text = FuncitonHue.getFieldValues(str);
        }

        private void textSL_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (textSL.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSL.Text);
            if (textDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textDongia.Text);
            tt = sl * dg;
            textThanhtien.Text = tt.ToString();
        }

        private void textDongia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (textSL.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSL.Text);
            if (textDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textDongia.Text);
            tt = sl * dg;
            textThanhtien.Text = tt.ToString();
        }

        private void buttonInHD_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHDC, tblThongtinTBSX;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Gốm shop";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Ba Đình - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (09)84930223";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN CHI TRẢ TBSX";

            sql = "select a.MaHDC, a.Ngaychi, a.Tongtien, b.TenNCC, b.Diachi, b.Sodienthoai, c.Tennhanvien " +
                "from tblHoadonchitraTBSX as a, tblNhacungcap as b, tblNhanvien as c " +
                "where a.MaHDC = N'" + textMaHDC.Text + "' and a.MaNCC = b.MaNCC and a.Manhanvien = c.Manhanvien";
            tblThongtinHDC = FuncitonHue.getdatatotable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn chi:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHDC.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHDC.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHDC.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHDC.Rows[0][5].ToString();

            sql = "select b.TenTBSX, a.Soluong, a.Lido, a.Dongia, a.Thanhtien " +
                  "from tblChitiethoadonchitraTBSX as a , tblTBSX as b " +
                  "where a.MaHDC = N'" + textMaHDC.Text + "' and a.MaTBSX = b.MaTBSX";
            tblThongtinTBSX = FuncitonHue.getdatatotable(sql);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên TBSX";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Lý do";
            exRange.Range["E11:E11"].Value = "Đơn giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinTBSX.Rows.Count - 1; hang++)
            {
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinTBSX.Columns.Count - 1; cot++)
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinTBSX.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinTBSX.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + FuncitonHue.ChuyenSoSangChu(tblThongtinHDC.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHDC.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên lập hóa đơn";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHDC.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void buttonTimkiem_Click(object sender, EventArgs e)
        {
            if (comboMaHDC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaHDC.Focus();
                return;
            }
            textMaHDC.Text = comboMaHDC.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            buttonHuyHD.Enabled = true;
            buttonLuu.Enabled = true;
            buttonInHD.Enabled = true;
            comboMaHDC.SelectedIndex = -1;
        }

        private void textSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void comboMaHDC_DropDown(object sender, EventArgs e)
        {
            FuncitonHue.fillcombo("select MaHDC from tblHoadonchitraTBSX", comboMaHDC, "MaHDC", "MaHDC");
            comboMaHDC.SelectedIndex = -1;
        }

        private void formHoadonchitraTBSX_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void buttonBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            buttonThemHD.Enabled = true;
            buttonHuyHD.Enabled = false;
            buttonBoqua.Enabled = false;
            textMaHDC.Enabled = true;
            textSL.Text = "";
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHuyHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] MaTBSX = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "select MaTBSX from tblChitiethoadonchitraTBSX where MaHDC = N'" + textMaHDC.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, FuncitonHue.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaTBSX[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                for (i = 0; i <= n - 1; i++)
                    DelHang(textMaHDC.Text, MaTBSX[i]);
                sql = "delete tblHoadonchitraTBSX where MaHDC = N'" + textMaHDC.Text + "'";
                FuncitonHue.RunSQL_Del(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                buttonHuyHD.Enabled = false;
                buttonInHD.Enabled = false;
            }
        }
    }
}
