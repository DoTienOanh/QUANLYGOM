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
    public partial class formHoadonban : Form
    {
        public formHoadonban()
        {
            InitializeComponent();
        }

        private void formHoadonban_Load(object sender, EventArgs e)
        {
            buttonThemHD.Enabled = true;
            buttonLuu.Enabled = false;
            buttonHuyHD.Enabled = false;
            buttonInHD.Enabled = false;
            textMaHD.ReadOnly = true;
            textTenNV.ReadOnly = true;
            textTenKH.ReadOnly = true;
            textDienthoai.ReadOnly = true;
            textTenhang.ReadOnly = true;
            textDongia.ReadOnly = true;
            textThanhtien.ReadOnly = true;
            textTongtien.ReadOnly = true;
            textGiamgia.Text = "0";
            textTongtien.Text = "0";
            FuncitonHue.fillcombo("select Makhachhang, Tenkhachhang from tblKhachhang", comboMaKH, "Makhachhang", "Tenkhachhang");
            comboMaKH.SelectedIndex = -1;
            FuncitonHue.fillcombo("select Manhanvien, Tennhanvien from tblNhanvien", comboMaNV, "Manhanvien", "Tennhanvien");
            comboMaNV.SelectedIndex = -1;
            FuncitonHue.fillcombo("select Mahang, Tenhang from tblHanghoa", comboMahang, "Mahang", "Tenhang");
            comboMahang.SelectedIndex = -1;
            FuncitonHue.fillcombo("select MaHDB from tblHDB", comboMaHDB, "MaHDB", "MaHDB");
            comboMaHDB.SelectedIndex = -1;
            if (textMaHD.Text != "")
            {
                Load_ThongtinHD();
                buttonHuyHD.Enabled = true;
                buttonInHD.Enabled = true;
            }
            Load_DataGridViewChitiet();
        }
        DataTable tblHDB;

        private void Load_DataGridViewChitiet()
        {
            string sql;
            sql = "select a.Mahang, b.Tenhang, a.Soluong, b.Dongia, a.Khuyenmai, a.Thanhtien " +
                "from tblChitietHDB as a, tblHanghoa as b " +
                "where a.MaHDB = N'" + textMaHD.Text + "' and a.Mahang=b.Mahang";
            tblHDB = FuncitonHue.getdatatotable(sql);
            dataGridViewHDB.DataSource = tblHDB;
            dataGridViewHDB.Columns[0].HeaderText = "Mã hàng";
            dataGridViewHDB.Columns[1].HeaderText = "Tên hàng";
            dataGridViewHDB.Columns[2].HeaderText = "Số lượng";
            dataGridViewHDB.Columns[3].HeaderText = "Đơn giá";
            dataGridViewHDB.Columns[4].HeaderText = "Giảm giá %";
            dataGridViewHDB.Columns[5].HeaderText = "Thành tiền";
            dataGridViewHDB.Columns[0].Width = 80;
            dataGridViewHDB.Columns[1].Width = 100;
            dataGridViewHDB.Columns[2].Width = 80;
            dataGridViewHDB.Columns[3].Width = 90;
            dataGridViewHDB.Columns[4].Width = 90;
            dataGridViewHDB.Columns[5].Width = 90;
            dataGridViewHDB.AllowUserToAddRows = false;
            dataGridViewHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Load_ThongtinHD()
        {
            string str;
            str = "select Ngayban from tblHDB where MaHDB = N'" + textMaHD.Text + "'";
            textNgayban.Text = FuncitonHue.convertDateTime(FuncitonHue.getFieldValues(str));

            str = "select Manhanvien from tblHDB where MaHDB = N'" + textMaHD.Text + "'";
            comboMaNV.Text = FuncitonHue.getFieldValues(str);

            str = "select Makhachhang from tblHDB where MaHDB = N'" + textMaHD.Text + "'";
            comboMaKH.Text = FuncitonHue.getFieldValues(str);

            str = "select Tongtien from tblHDB where MaHDB = N'" + textMaHD.Text + "'";
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
            textMaHD.Text = FuncitonHue.CreateKey("HDB");
            Load_DataGridViewChitiet();
        }
        private void ResetValues()
        {
            textMaHD.Text = "";
            textNgayban.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            comboMaNV.Text = "";
            textTenNV.Text = "";
            comboMaKH.Text = "";
            textTenKH.Text = "";
            textDienthoai.Text = "";
            textTongtien.Text = "0";
            labelBangchu.Text = "Bằng chữ: ";
            comboMahang.Text = "";
            textSoluong.Text = "";
            textGiamgia.Text = "0";
            textThanhtien.Text = "0";
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, slcon, tong, tongmoi;
            sql = "select MaHDB from tblHDB where MaHDB=N'" + textMaHD.Text + "'";
            if (!FuncitonHue.checkey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (textNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textNgayban.Focus();
                    return;
                }
                if (comboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaNV.Focus();
                    return;
                }
                if (comboMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboMaKH.Focus();
                    return;
                }
                //lưu thông tin chung vào bảng tblhdban    
                sql = "insert into tblHDB(MaHDB, NgayBan, Makhachhang, Manhanvien, Tongtien) values(N'" + textMaHD.Text.Trim() + "', '" + DateTime.ParseExact(textNgayban.Text.Trim(), "dd/MM/yyyy HH:mm:ss", null).ToString("yyyy-MM-dd HH:mm:ss") + "',N'" + comboMaKH.SelectedValue + "', N'" + comboMaNV.SelectedValue + "'," + textTongtien.Text + ")";
                FuncitonHue.runsql(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (comboMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMahang.Focus();
                return;
            }
            if ((textSoluong.Text.Trim().Length == 0) || (textSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textSoluong.Text = "";
                textSoluong.Focus();
                return;
            }
            if (textGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textGiamgia.Focus();
                return;
            }
            sql = "select Mahang from tblChiTietHDB where Mahang=N'" + comboMahang.SelectedValue + "' and MaHDB = N'" + textMaHD.Text.Trim() + "'";
            if (FuncitonHue.checkey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValuesHang();
                comboMahang.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToInt32(FuncitonHue.getFieldValues("select Soluong from tblHanghoa where Mahang = N'" + comboMahang.SelectedValue + "'"));
            if (Convert.ToInt32(textSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textSoluong.Text = "";
                textSoluong.Focus();
                return;
            }
            sql = "insert into tblChitietHDB(MaHDB,Mahang,Soluong,Khuyenmai,Thanhtien) values(N'" + textMaHD.Text.Trim() + "', N'" + comboMahang.SelectedValue + "'," + textSoluong.Text + "," + textGiamgia.Text + "," + textThanhtien.Text + ")";
            FuncitonHue.runsql(sql);
            Load_DataGridViewChitiet();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            slcon = sl - Convert.ToInt32(textSoluong.Text);
            sql = "update tblHanghoa set Soluong =" + slcon + " where Mahang= N'" + comboMahang.SelectedValue + "'";
            FuncitonHue.runsql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(FuncitonHue.getFieldValues("select Tongtien from tblHDB where MaHDB = N'" + textMaHD.Text + "'"));
            tongmoi = tong + Convert.ToDouble(textThanhtien.Text);
            sql = "update tblHDB set Tongtien =" + tongmoi + " where MaHDB = N'" + textMaHD.Text + "'";
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
            comboMahang.Text = "";
            textTenhang.Text = "";
            textSoluong.Text = "";
            textDongia.Text = "";
            textGiamgia.Text = "0";
            textThanhtien.Text = "0";
        }

        private void dataGridViewHDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mahang;
            Double thanhtien;
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = dataGridViewHDB.CurrentRow.Cells["Mahang"].Value.ToString();
                DelHang(textMaHD.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                thanhtien = Convert.ToDouble(dataGridViewHDB.CurrentRow.Cells["Thanhtien"].Value.ToString());
                DelUpdateTongtien(textMaHD.Text, thanhtien);
                Load_DataGridViewChitiet();
            }
        }
        private void DelHang(string MaHD, string Mahang)
        {
            Double s, sl, slcon;
            string sql;
            sql = "select Soluong from tblChitietHDB where MaHDB = N'" + MaHD + "' and Mahang = N'" + Mahang + "'";
            s = Convert.ToInt32(FuncitonHue.getFieldValues(sql));
            sql = "delete tblChitietHDB where MaHDB=N'" + MaHD + "' and Mahang = N'" + Mahang + "'";
            FuncitonHue.RunSQL_Del(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "select Soluong from tblHanghoa where Mahang = N'" + Mahang + "'";
            sl = Convert.ToInt32(FuncitonHue.getFieldValues(sql));
            slcon = sl + s;
            sql = "update tblHanghoa set Soluong =" + slcon + " where Mahang= N'" + Mahang + "'";
            FuncitonHue.runsql(sql);
        }

        private void DelUpdateTongtien(string MaHDB, double Thanhtien)
        {
            Double tong, tongmoi;
            string sql;
            sql = "select Tongtien from tblHDB where MaHDB = N'" + MaHDB + "'";
            tong = Convert.ToDouble(FuncitonHue.getFieldValues(sql));
            tongmoi = tong - Thanhtien;
            sql = "update tblHDB set Tongtien =" + tongmoi + " where MaHDB = N'" + MaHDB + "'";
            FuncitonHue.runsql(sql);
            textTongtien.Text = tongmoi.ToString();
            labelBangchu.Text = "Bằng chữ: " + FuncitonHue.ChuyenSoSangChu(tongmoi.ToString());
        }

        private void buttonHuyHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] MaSP = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "select Mahang from tblChitietHDB where MaHDB = N'" + textMaHD.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, FuncitonHue.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MaSP[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(textMaHD.Text, MaSP[i]);
                //Xóa hóa đơn
                sql = "delete tblHDB where MaHDB=N'" + textMaHD.Text + "'";
                FuncitonHue.RunSQL_Del(sql);
                ResetValues();
                Load_DataGridViewChitiet();
                buttonHuyHD.Enabled = false;
                buttonInHD.Enabled = false;
            }
        }

        private void comboMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaNV.Text == "")
                textTenNV.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "select Tennhanvien from tblNhanvien where Manhanvien =N'" + comboMaNV.SelectedValue + "'";
            textTenNV.Text = FuncitonHue.getFieldValues(str);
        }

        private void comboMaKH_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaKH.Text == "")
            {
                textTenKH.Text = "";
                textDienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "select Tenkhachhang from tblKhachhang where Makhachhang = N'" + comboMaKH.SelectedValue + "'";
            textTenKH.Text = FuncitonHue.getFieldValues(str);
            str = "select Sodienthoai from tblKhachhang where Makhachhang= N'" + comboMaKH.SelectedValue + "'";
            textDienthoai.Text = FuncitonHue.getFieldValues(str);
        }

        private void comboMahang_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMahang.Text == "")
            {
                textTenhang.Text = "";
                textDongia.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "select Tenhang from tblHanghoa where Mahang =N'" + comboMahang.SelectedValue + "'";
            textTenhang.Text = FuncitonHue.getFieldValues(str);
            str = "select Dongia from tblHanghoa where Mahang =N'" + comboMahang.SelectedValue + "'";
            textDongia.Text = FuncitonHue.getFieldValues(str);
        }

        private void textSoluong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (textSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSoluong.Text);
            if (textGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(textGiamgia.Text);
            if (textDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textDongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            textThanhtien.Text = tt.ToString();
        }

        private void textGiamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (textSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToInt32(textSoluong.Text);
            if (textGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(textGiamgia.Text);
            if (textDongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textDongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            textThanhtien.Text = tt.ToString();
        }

        private void buttonInHD_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
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
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "select a.MaHDB, a.Ngayban, a.Tongtien, b.Tenkhachhang, b.Sodienthoai, c.Tennhanvien " +
                "from tblHDB as a, tblKhachhang as b, tblNhanvien as c " +
                "where a.MaHDB = N'" + textMaHD.Text + "' and a.Makhachhang = b.Makhachhang and a.Manhanvien = c.Manhanvien";
            tblThongtinHD = FuncitonHue.getdatatotable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Điện thoại:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "select b.Tenhang, a.Soluong, b.Dongia, a.Khuyenmai, a.Thanhtien " +
                  "from tblChitietHDB as a , tblHanghoa as b " +
                  "where a.MaHDB = N'" + textMaHD.Text + "' and a.Mahang = b.Mahang";
            tblThongtinHang = FuncitonHue.getdatatotable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A10:F10"].Font.Bold = true;
            exRange.Range["A10:F10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C10:F10"].ColumnWidth = 12;
            exRange.Range["A10:A10"].Value = "STT";
            exRange.Range["B10:B10"].Value = "Tên hàng";
            exRange.Range["C10:C10"].Value = "Số lượng";
            exRange.Range["D10:D10"].Value = "Đơn giá";
            exRange.Range["E10:E10"].Value = "Giảm giá";
            exRange.Range["F10:F10"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 11
                exSheet.Cells[1][hang + 11] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 11] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 13];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 13];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 14]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + FuncitonHue.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 16]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][5];
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;
        }

        private void buttonTimkiem_Click(object sender, EventArgs e)
        {
            if (comboMaHDB.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboMaHDB.Focus();
                return;
            }
            textMaHD.Text = comboMaHDB.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            buttonHuyHD.Enabled = true;
            buttonLuu.Enabled = true;
            buttonInHD.Enabled = true;
            comboMaHDB.SelectedIndex = -1;
        }

        private void textSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void textGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void comboMaHDB_DropDown(object sender, EventArgs e)
        {
            FuncitonHue.fillcombo("select MaHDB from tblHDB", comboMaHDB, "MaHDB", "MaHDB");
            comboMaHDB.SelectedIndex = -1;
        }

        private void formHoadonban_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
