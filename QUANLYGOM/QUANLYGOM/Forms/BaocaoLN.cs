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
    public partial class BaocaoLN : Form
    {
        public BaocaoLN()
        {
            InitializeComponent();
            txtDoanhthu.ReadOnly = true;
            txtChiphi.ReadOnly = true;
            txtLoinhuan.ReadOnly = true;
            txtDoanhthu.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            cboManhanvien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMahang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int month = 1; month <= 12; month++)
            {
                cboThang.Items.Add(month);
            }

        }

        private void BaocaoLN_Load(object sender, EventArgs e)
        {
            Class.FunctionOanh.Connect();
            btnTimkiem.Enabled = false;

            Load_dgridBCDT();
            ResetValue();

            Class.FunctionOanh.Connect();
            btnTimkiem.Enabled = false;
            LoadMahang();
            LoadMaNV();
            Load_dgridBCDT();
            ResetValue();

        }
        private void ResetValue()
        {

            cboThang.Text = "";
            cboManhanvien.Text = "";
            cboMahang.Text = "";
            txtChiphi.Text = "";
            txtDoanhthu.Text = "";
            txtLoinhuan.Text = "";
            txtNam.Text = "";
            txtTennhanvien.Text = "";
            txtTenhang.Text = "";
            cboManhanvien.Enabled = true;
            cboMahang.Enabled = true;
            txtNam.Enabled = true;
            cboThang.Enabled = true;
            btnDong.Enabled = false;
            //btnXuat.Enabled = false;
            btnTimkiem.Enabled = false;
            //btnBDO.Enabled = false;
            //radTu.Checked = false;
            //radNgay.Checked = false;

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Class.FunctionOanh.Disconnect();
            base.OnFormClosing(e);
        }
        DataTable tblbcdt;
        private void Load_dgridBCDT()
        {
            if (IsValidInput())
            {
                if (!string.IsNullOrEmpty(cboManhanvien.Text))
                {
                    LoadDataByMaNV();
                }
                else if (!string.IsNullOrEmpty(cboMahang.Text))
                {
                    LoadDataByMahang();
                }
                else
                {
                    LoadDataByMonthAndYear();
                }

                LoadReportData();
            }
            else
            {
                MessageBox.Show("Bạn phải chọn tháng, năm muốn xem báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboThang.Focus();
            }
        }
        private bool IsValidInput()
        {
            return !string.IsNullOrEmpty(cboThang.Text) && !string.IsNullOrEmpty(txtNam.Text);
        }

        private void LoadDataByMaNV()
        {
            string query = @"
       
        SELECT  
            a.Mahang,
            c.Tenhang, 
            a.Dongia,
            d.TenNhanVien,
            SUM(a.SoLuong) AS SoLuongBan, 
            SUM(a.ThanhTien) AS TongTienBan
        FROM 
            tblChitietHDB a 
            JOIN tblHDB b ON a.MaHDB = b.MaHDB 
            JOIN tblHanghoa c ON a.Mahang = c.Mahang
            JOIN tblNhanVien d ON b.MaNhanVien = d.MaNhanVien
        WHERE 
            MONTH(b.NgayBan) = @Thang
            AND (d.MaNhanVien = @MaNV OR @MaNV IS NULL) 
        GROUP BY 
            a.Mahang, c.Tenhang, a.dongia, d.TenNhanVien ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, Class.FunctionOanh.Conn);
            adapter.SelectCommand.Parameters.AddWithValue("@Thang", cboThang.SelectedItem);
            adapter.SelectCommand.Parameters.AddWithValue("@MaNV", string.IsNullOrEmpty(cboManhanvien.Text) ? (object)DBNull.Value : cboManhanvien.Text);
            DataTable tblbcdt = new DataTable();
            adapter.Fill(tblbcdt);

            dataGridView.DataSource = tblbcdt;
            dataGridView.Columns[0].HeaderText = "Mã hàng";
            dataGridView.Columns[1].HeaderText = "Tên hàng";
            dataGridView.Columns[2].HeaderText = "Đơn giá";

            dataGridView.Columns[3].HeaderText = "Tên nhân viên";
            dataGridView.Columns[4].HeaderText = "Số lượng bán";
            dataGridView.Columns[5].HeaderText = "Tổng tiền bán được";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 70;

            dataGridView.Columns[3].Width = 140;
            dataGridView.Columns[4].Width = 60;
            dataGridView.Columns[5].Width = 90;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadDataByMahang()
        {
            string query = @"
       
        SELECT  
            a.Mahang,
            c.Tenhang, 
            a.Dongia,
           
            SUM(a.SoLuong) AS SoLuongBan, 
            SUM(a.ThanhTien) AS TongTienBan
        FROM 
            tblChitietHDB a 
            JOIN tblHDB b ON a.MaHDB = b.MaHDB 
            JOIN tblHanghoa c ON a.Mahang = c.Mahang
        WHERE 
            MONTH(b.NgayBan) = @Thang
            AND (a.Mahang = @Mahang OR @Mahang IS NULL) -- Thêm điều kiện lọc theo Mahang nếu được chọn
        GROUP BY 
            a.Mahang, c.Tenhang, a.Dongia";

            SqlDataAdapter adapter = new SqlDataAdapter(query, Class.FunctionOanh.Conn);
            adapter.SelectCommand.Parameters.AddWithValue("@Thang", cboThang.SelectedItem);
            adapter.SelectCommand.Parameters.AddWithValue("@Mahang", string.IsNullOrEmpty(cboMahang.Text) ? (object)DBNull.Value : cboMahang.Text);
            DataTable tblbcdt = new DataTable();
            adapter.Fill(tblbcdt);

            dataGridView.DataSource = tblbcdt;
            dataGridView.Columns[0].HeaderText = "Mã hàng";
            dataGridView.Columns[1].HeaderText = "Tên hàng";
            dataGridView.Columns[2].HeaderText = "Đơn giá";

            dataGridView.Columns[3].HeaderText = "Số lượng bán";
            dataGridView.Columns[4].HeaderText = "Tổng tiền bán được";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 90;

            dataGridView.Columns[3].Width = 110;
            dataGridView.Columns[4].Width = 140;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadDataByMonthAndYear()
        {
            string query = @"
        
        SELECT  
            a.Mahang,
            c.Tenhang, 
            a.Dongia,
            
            SUM(a.SoLuong) AS SoLuongBan, 
            SUM(a.ThanhTien) AS TongTienBan
        FROM 
            tblChitietHDB a 
            JOIN tblHDB b ON a.MaHDB = b.MaHDB 
            JOIN tblHanghoa c ON a.Mahang = c.Mahang
        WHERE 
            MONTH(b.NgayBan) = @Thang AND YEAR(b.NgayBan) = @Nam
        GROUP BY 
            a.Mahang, c.Tenhang, a.Dongia";

            SqlDataAdapter adapter = new SqlDataAdapter(query, Class.FunctionOanh.Conn);
            adapter.SelectCommand.Parameters.AddWithValue("@Thang", cboThang.SelectedItem);
            adapter.SelectCommand.Parameters.AddWithValue("@Nam", txtNam.Text);
            DataTable tblbcdt = new DataTable();
            adapter.Fill(tblbcdt);

            dataGridView.DataSource = tblbcdt;
            dataGridView.Columns[0].HeaderText = "Mã hàng";
            dataGridView.Columns[1].HeaderText = "Tên hàng";
            dataGridView.Columns[2].HeaderText = "Giá bán";

            dataGridView.Columns[3].HeaderText = "Số lượng bán";
            dataGridView.Columns[4].HeaderText = "Tổng tiền bán được";
            dataGridView.Columns[0].Width = 50;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 90;

            dataGridView.Columns[3].Width = 110;
            dataGridView.Columns[4].Width = 140;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadReportData()
        {
            string query = @"
        

         SELECT  
               SUM(a.ThanhTien) AS DoanhThu,
               SUM(f.Thanhtien) AS ChiPhi,
               SUM(a.ThanhTien - f.Thanhtien) AS LoiNhuan
           FROM 
               tblChitietHDB a 
               JOIN tblHDB b ON a.MaHDB = b.MaHDB 
               JOIN tblHanghoa c ON a.Mahang = c.Mahang
               JOIN tblNhanVien d ON b.MaNhanVien = d.MaNhanVien 
               JOIN tblHoadonnhapNVL e ON d.Manhanvien = e.Manhanvien
	           JOIN tblChitietnhapNVL f ON e.MaHDN = f.MaHDN
           WHERE 
               MONTH(b.NgayBan) = @Thang
               AND (d.MaNhanVien = @MaNV OR @MaNV IS NULL)";

            SqlDataAdapter adapter = new SqlDataAdapter(query, Class.FunctionOanh.Conn);
            adapter.SelectCommand.Parameters.AddWithValue("@Thang", cboThang.SelectedItem);
            adapter.SelectCommand.Parameters.AddWithValue("@MaNV", string.IsNullOrEmpty(cboManhanvien.Text) ? (object)DBNull.Value : cboManhanvien.Text);
            DataTable resultTable = new DataTable();
            adapter.Fill(resultTable);

            if (resultTable.Rows.Count > 0)
            {
                decimal doanhThu = resultTable.Rows[0]["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(resultTable.Rows[0]["DoanhThu"]) : 0;
                decimal chiPhi = resultTable.Rows[0]["ChiPhi"] != DBNull.Value ? Convert.ToDecimal(resultTable.Rows[0]["ChiPhi"]) : 0;
                decimal loiNhuan = resultTable.Rows[0]["LoiNhuan"] != DBNull.Value ? Convert.ToDecimal(resultTable.Rows[0]["LoiNhuan"]) : 0;

                txtDoanhthu.Text = doanhThu.ToString();
                txtChiphi.Text = chiPhi.ToString();
                txtLoinhuan.Text = loiNhuan.ToString();
            }
            else
            {
                txtDoanhthu.Text = "0";
                txtChiphi.Text = "0";
                txtLoinhuan.Text = "0";
            }
        }
        private void LoadMahang()
        {
            string query = "SELECT Mahang FROM tblhanghoa";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Class.FunctionOanh.Conn);
            DataTable dtMahang = new DataTable();
            adapter.Fill(dtMahang);

            cboMahang.DataSource = dtMahang;
            cboMahang.DisplayMember = "Mahang";
            cboMahang.ValueMember = "Mahang";
            cboMahang.SelectedIndex = -1; // Không chọn mục nào
        }
        private void LoadTenhang(string maSach)
        {
            string query = "SELECT Tenhang FROM tblHanghoa WHERE Mahang = @Mahang";
            SqlCommand command = new SqlCommand(query, Class.FunctionOanh.Conn);
            command.Parameters.AddWithValue("@Mahang", maSach);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtTenhang.Text = reader["Tenhang"].ToString();
            }
            reader.Close();
        }

        private void cboMahang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMahang.SelectedIndex != -1)
            {
                string selectedMaSach = cboMahang.SelectedValue.ToString();
                LoadTenhang(selectedMaSach);
                cboManhanvien.Enabled = false;
            }
            else
            {
                txtTenhang.Text = "";

            }
        }
        private void LoadMaNV()
        {
            string query = "SELECT MaNhanVien FROM tblNhanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Class.FunctionOanh.Conn);
            DataTable dtMaNV = new DataTable();
            adapter.Fill(dtMaNV);

            cboManhanvien.DataSource = dtMaNV;
            cboManhanvien.DisplayMember = "MaNhanVien";
            cboManhanvien.ValueMember = "MaNhanVien";
            cboManhanvien.SelectedIndex = -1; // Không chọn mục nào
        }
        private void LoadTenNV(string maSach)
        {
            string query = "SELECT TenNhanVien FROM tblNhanVien WHERE MaNhanVien = @MaNhanVien";
            SqlCommand command = new SqlCommand(query, Class.FunctionOanh.Conn);
            command.Parameters.AddWithValue("@MaNhanVien", maSach);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtTennhanvien.Text = reader["TenNhanVien"].ToString();
            }
            reader.Close();
        }

        private void cboManhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboManhanvien.SelectedIndex != -1)
            {
                string selectedMaNV = cboManhanvien.SelectedValue.ToString();
                LoadTenNV(selectedMaNV);
                cboMahang.Enabled = false;
            }
            else
            {
                txtTennhanvien.Text = "";
            }

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            Load_dgridBCDT();
            btnDong.Enabled = true;
            //btnXuat.Enabled = true;
            cboMahang.Enabled = false;
            cboManhanvien.Enabled = false;
            cboThang.Enabled = false;
            txtNam.Enabled = false;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            ResetValue();

        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboThang.Text) && !string.IsNullOrEmpty(txtNam.Text))
            {
                btnTimkiem.Enabled = true;
            }
            else
            {
                btnTimkiem.Enabled = false;
            }

        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboThang.Text) && !string.IsNullOrEmpty(txtNam.Text))
            {
                btnTimkiem.Enabled = true;
            }
            else
            {
                btnTimkiem.Enabled = false;
            }

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Có lỗi khi giải phóng tài nguyên: " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
