using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYGOM.Class
{
    internal class FuncitonHue
    {
        public static SqlConnection Conn;
        public static string ConnString;
        public static void Connect()
        {
            //ConnString = "Data Source=DESKTOP-E1T3VV1\\HUEKIM;Initial Catalog=Quanlygom;Integrated Security=True;Encrypt=False";
            ConnString = "Data Source=ADMIN\\MSSQLSERVER03;Initial Catalog=Quanlygom;Integrated Security=True;Encrypt=True";
            Conn = new SqlConnection();
            Conn.ConnectionString = ConnString;
            Conn.Open();
            //MessageBox.Show("Ket noi thanh cong");
        }
        public static DataTable getdatatotable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, FuncitonHue.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static void Disconnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close(); //Đóng kết nối
                Conn.Dispose(); //Giải phóng tài nguyên
                Conn = null;
            }
        }
        public static bool checkey(string sql)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, FuncitonHue.Conn);
            DataTable table = new DataTable();
            mydata.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else return false;

        }
        public static void runsql(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = FuncitonHue.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception loi)
            {
                MessageBox.Show(loi.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        //-------------------
        public static bool isdate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31)
                && (Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12)
                && (Convert.ToInt32(parts[2]) >= 1900))
                return true;
            else
                return false;
        }
        public static string convertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = string.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }
        //---------------
        public static void fillcombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, FuncitonHue.Conn);
            DataTable table = new DataTable();
            mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;    // Truong gia tri
            cbo.DisplayMember = ten;    // Truong hien thi
        }
        public static string getFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, FuncitonHue.Conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }
    }
}
