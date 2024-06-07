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
    public partial class formHDnhapNVL : Form
    {
        public formHDnhapNVL()
        {
            InitializeComponent();
        }

        private void fromHDnhapNVL_Load(object sender, EventArgs e)
        {
            buttonThemHD.Enabled = true;
            buttonLuu.Enabled = false;
            buttonHuyHD.Enabled = false;
            buttonInHD.Enabled = false;
            textMaHDNNVL.ReadOnly = true;
            textTenNV.ReadOnly = true;
            textTenNCC.ReadOnly = true;
            textDiachi.ReadOnly = true;
            textDienthoai.ReadOnly = true;
            textTenhang.ReadOnly = true;
            textThanhtien.ReadOnly = true;
            textTongtien.ReadOnly = true;
            textTongtien.Text = "0";
            FuncitonHue.fillcombo("select MaNCC, TenNCC from tblNhacungcap", comboMaNCC, "MaNCC", "TenNCC");
            comboMaNCC.SelectedIndex = -1;
            FuncitonHue.fillcombo("select Manhanvien, Tennhanvien from tblNhanvien", comboMaNV, "Manhanvien", "Manhanvien");
            comboMaNV.SelectedIndex = -1;
            FuncitonHue.fillcombo("select MaNVL, TenNVL from tblNguyenvatlieu", comboMaNVL, "MaNVL", "MaNVL");
            comboMaNVL.SelectedIndex = -1;
            FuncitonHue.fillcombo("select MaHDN from tblHoadonnhapNVL", comboMaHDN, "MaHDN", "MaHDN");
            comboMaHDN.SelectedIndex = -1;
            if (textMaHDNNVL.Text != "")
            {
                Load_ThongtinHD();
                buttonHuyHD.Enabled = true;
                buttonInHD.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }
        DataTable tblHDN;

        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "select a.MaNVL, b.TenNVL, a.Soluongthucnhap, a.Soluongdukien, a.Dongia, a.Thanhtien " +
                "from tblChitietnhapNVL as a, tblNguyenvatlieu as b " +
                "where a.MaHDN = N'" + textMaHDNNVL.Text + "' and a.MaNVL = b.MaNVL";
            tblHDN = FuncitonHue.getdatatotable(sql);
            dataGridViewHDN.DataSource = tblHDN;
            dataGridViewHDN.Columns[0].HeaderText = "Ma NVL";
            dataGridViewHDN.Columns[1].HeaderText = "Ten NVL";
            dataGridViewHDN.Columns[2].HeaderText = "SL thuc nhap";
            dataGridViewHDN.Columns[3].HeaderText = "SL du kien";
            dataGridViewHDN.Columns[4].HeaderText = "Don gia";
            dataGridViewHDN.Columns[5].HeaderText = "Thanh tien";
            dataGridViewHDN.Columns[0].Width = 80;
            dataGridViewHDN.Columns[1].Width = 100;
            dataGridViewHDN.Columns[2].Width = 80;
            dataGridViewHDN.Columns[3].Width = 90;
            dataGridViewHDN.Columns[4].Width = 90;
            dataGridViewHDN.Columns[5].Width = 90;
            dataGridViewHDN.AllowUserToAddRows = false;
            dataGridViewHDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD() 
        {
            string str;
            str = "select Ngaynhap from tblHoadonnhapNVL where MaHDN = N'" + textMaHDNNVL.Text + "'";
            textNgaynhap.Text = FuncitonHue.convertDateTime(FuncitonHue.getFieldValues(str));
            str = "select Manhanvien from tblHoadonnhapNVL where MaHDN = N'" + textMaHDNNVL.Text + "'";
            comboMaNV.Text = FuncitonHue.getFieldValues(str);
            str = "select MaNCC from tblHoadonnhapNVL where MaHDN = N'" + textMaHDNNVL.Text + "'";
            comboMaNCC.Text = FuncitonHue.getFieldValues(str);
            str = "select Tongtien from tblHoadonnhapNVL where MaHDN = N'" + textMaHDNNVL.Text + "'";
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
            textMaHDNNVL.Text = FuncitonHue.CreateKey("HDN");
            Load_DataGridViewChitiet();
        }
        private void ResetValues()
        {
            textMaHDNNVL.Text = "";
            textNgaynhap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            comboMaNV.Text = "";
            textTenNV.Text = "";
            comboMaNCC.Text = "";
            textTenNCC.Text = "";
            textDiachi.Text = "";
            textDienthoai.Text = "";
            textTongtien.Text = "0";
            labelBangchu.Text = "Bằng chữ: ";
            comboMaNVL.Text = "";
            textSLthuc.Text = "";
            textSLdukien.Text = "";
            textDongianhap.Text = "";
            textThanhtien.Text = "0";
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double tong, tongmoi;
            sql = "select MaHDN from tblHoadonnhapNVL where MaHDN = N'" + textMaHDNNVL.Text + "'";
            if (!FuncitonHue.checkey(sql))
            {
                if (textNgaynhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textNgaynhap.Focus();
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
                sql = "insert into tblHoadonnhapNVL(MaHDN, Ngaynhap, MaNCC, Manhanvien, Tongtien) values(N'" + textMaHDNNVL.Text.Trim() + "', '" + DateTime.ParseExact(textNgaynhap.Text.Trim(), "dd/MM/yyyy HH:mm:ss", null).ToString("yyyy-MM-dd HH:mm:ss") + "', N'" + comboMaNCC.SelectedValue + "', N'" + comboMaNV.SelectedValue + "', " + textTongtien.Text + ")";
                FuncitonHue.runsql(sql);
            }

            if (comboMaNVL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaNVL.Focus();
                return;
            }
            if ((textSLthuc.Text.Trim().Length == 0) || (textSLthuc.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSLthuc.Text = "";
                textSLthuc.Focus();
                return;
            }
            if ((textSLdukien.Text.Trim().Length == 0) || (textSLdukien.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng dự kiến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSLdukien.Text = "";
                textSLdukien.Focus();
                return;
            }
            if (textDongianhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textDongianhap.Focus();
                return;
            }
            sql = "select MaNVL from tblChitietnhapNVL where MaNVL = N'" + comboMaNVL.SelectedValue + "' and MaHDN = N'" + textMaHDNNVL.Text.Trim() + "'";
            if (FuncitonHue.checkey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                comboMaNVL.Focus();
                return;
            }

            sql = "insert into tblChitietnhapNVL(MaHDN, MaNVL, Dongia, Soluongthucnhap, Soluongdukien, Thanhtien) values(N'" + textMaHDNNVL.Text.Trim() + "', N'" + comboMaNVL.SelectedValue + "', " + textDongianhap.Text + ", " + textSLthuc.Text + ", "+textSLdukien.Text+", " + textThanhtien.Text + ")";
            FuncitonHue.runsql(sql);
            Load_DataGridViewChitiet();

            tong = Convert.ToDouble(FuncitonHue.getFieldValues("select Tongtien from tblHoadonnhapNVL where MaHDN = N'" + textMaHDNNVL.Text + "'"));
            tongmoi = tong + Convert.ToDouble(textThanhtien.Text);
            sql = "update tblHoadonnhapNVL set Tongtien =" + tongmoi + " where MaHDN = N'" + textMaHDNNVL.Text + "'";
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
            comboMaNVL.Text = "";
            textTenhang.Text = "";
            textSLthuc.Text = "";
            textSLdukien.Text = "";
            textDongianhap.Text = "";
            textThanhtien.Text = "0";
        }

        private void dataGridViewHDN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double thanhtien;
            if (tblHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                mahang = dataGridViewHDN.CurrentRow.Cells["MaNVL"].Value.ToString();
                DelHang(textMaHDNNVL.Text, mahang);
                thanhtien = Convert.ToDouble(dataGridViewHDN.CurrentRow.Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(textMaHDNNVL.Text, thanhtien);
                Load_DataGridViewChitiet();
            }
        }
        private void DelHang(string MaHDN, string MaNVL)
        {
            Double s;
            string sql;
            sql = "select Soluongthucnhap from tblChitietnhapNVL where MaHDN = N'" + MaHDN + "' and MaNVL = N'" + MaNVL + "'";
            s = Convert.ToInt32(FuncitonHue.getFieldValues(sql));
            sql = "delete tblChitietnhapNVL where MaHDN = N'" + MaHDN + "' and MaNVL = N'" + MaNVL + "'";
            FuncitonHue.RunSQL_Del(sql);
        }

        private void DelUpdateTongtien(string MaHDN, double Thanhtien)
        {
            Double tong, tongmoi;
            string sql;
            sql = "select Tongtien from tblHoadonnhapNVL where MaHDN = N'" + MaHDN + "'";
            tong = Convert.ToDouble(FuncitonHue.getFieldValues(sql));
            tongmoi = tong - Thanhtien;
            sql = "update tblHoadonnhapNVL set Tongtien =" + tongmoi + " where MaHDN = N'" + MaHDN + "'";
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

        private void comboMaNVL_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaNVL.Text == "")
            {
                textTenhang.Text = "";
            }
            str = "select TenNVL from tblNguyenvatlieu where MaNVL =N'" + comboMaNVL.SelectedValue + "'";
            textTenhang.Text = FuncitonHue.getFieldValues(str);
        }

        private void textSLthuc_TextChanged(object sender, EventArgs e)
        {
            double tt, slt, sldk, dgn;
            if (textSLthuc.Text == "")
                slt = 0;
            else
                slt = Convert.ToInt32(textSLthuc.Text);
            if (textSLdukien.Text == "")
                sldk = 0;
            else
                sldk = Convert.ToDouble(textSLdukien.Text);
            if (textDongianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(textDongianhap.Text);
            tt = slt * dgn;
            textThanhtien.Text = tt.ToString();
        }

        private void textDongianhap_TextChanged(object sender, EventArgs e)
        {
            double tt, slt, sldk, dgn;
            if (textSLthuc.Text == "")
                slt = 0;
            else
                slt = Convert.ToInt32(textSLthuc.Text);
            if (textSLdukien.Text == "")
                sldk = 0;
            else
                sldk = Convert.ToDouble(textSLdukien.Text);
            if (textDongianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(textDongianhap.Text);
            tt = slt * dgn;
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
            DataTable tblThongtinHDN, tblThongtinHang;
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
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";

            sql = "select a.MaHDN, a.Ngaynhap, a.Tongtien, b.TenNCC, b.Diachi, b.Sodienthoai, c.Tennhanvien " +
                "from tblHoadonnhapNVL as a, tblNhacungcap as b, tblNhanvien as c " +
                "where a.MaHDN = N'" + textMaHDNNVL.Text + "' and a.MaNCC = b.MaNCC and a.Manhanvien = c.Manhanvien";
            tblThongtinHDN = FuncitonHue.getdatatotable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn nhập:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHDN.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHDN.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHDN.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHDN.Rows[0][5].ToString();

            sql = "select b.TenNVL, a.Soluongthucnhap, a.Soluongdukien, a.Dongia, a.Thanhtien " +
                  "from tblChitietnhapNVL as a , tblNguyenvatlieu as b " +
                  "where a.MaHDN = N'" + textMaHDNNVL.Text + "' and a.MaNVL = b.MaNVL";
            tblThongtinHang = FuncitonHue.getdatatotable(sql);
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên NVL";
            exRange.Range["C11:C11"].Value = "Số lượng thực";
            exRange.Range["D11:D11"].Value = "Số lượng dự kiến";
            exRange.Range["E11:E11"].Value = "Đơn giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHDN.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15];
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + FuncitonHue.ChuyenSoSangChu(tblThongtinHDN.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHDN.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên lập hóa đơn";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHDN.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void buttonTimkiem_Click(object sender, EventArgs e)
        {
            if (comboMaHDN.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaHDN.Focus();
                return;
            }
            textMaHDNNVL.Text = comboMaHDN.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            buttonHuyHD.Enabled = true;
            buttonLuu.Enabled = true;
            buttonInHD.Enabled = true;
            comboMaHDN.SelectedIndex = -1;
        }

        private void textSLthuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textSLdukien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textDongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void comboMaHDN_DropDown(object sender, EventArgs e)
        {
            FuncitonHue.fillcombo("select MaHDN from tblHoadonnhapNVL", comboMaHDN, "MaHDN", "MaHDN");
            comboMaHDN.SelectedIndex = -1;
        }

        private void formHDnhapNVL_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void buttonBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            buttonThemHD.Enabled = true;
            buttonHuyHD.Enabled = false;
            buttonBoqua.Enabled = false;
            textMaHDNNVL.Enabled = true;
            textNgaynhap.Text = "";
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHuyHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] MaNVL = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "select MaNVL from tblChitietnhapNVL where MaHDN = N'" + textMaHDNNVL.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, FuncitonHue.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaNVL[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                for (i = 0; i <= n - 1; i++)
                    DelHang(textMaHDNNVL.Text, MaNVL[i]);
                sql = "delete tblHoadonnhapNVL where MaHDN = N'" + textMaHDNNVL.Text + "'";
                FuncitonHue.RunSQL_Del(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                buttonHuyHD.Enabled = false;
                buttonInHD.Enabled = false;
            }
        }
    }
}
