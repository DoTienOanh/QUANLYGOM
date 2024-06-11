using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYGOM.Class
{
    internal class FunctionOanh
    {
        public static SqlConnection Conn;  //Khai báo đối tượng kết nối
        public static string connString;   //Khai báo biến chứa chuỗi kết nối

        public static void Connect()
        {
            connString = "Data Source=DESKTOP-E1T3VV1\\HUEKIM;Initial Catalog=Quanlygom;Integrated Security=True;Encrypt=False";
            //connString = "Data Source=ADMIN\\MSSQLSERVER03;Initial Catalog=Quanlygom1;Integrated Security=True";
            //connString = "Data Source=TIENOANH\\SQLEXPRESS;Initial Catalog=Quanlygom;Integrated Security=True;Encrypt=False"; 
            Conn = new SqlConnection();         		
            Conn.ConnectionString = connString; 		
            Conn.Open();                        		
        }

        public static void Disconnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();   	
                Conn.Dispose();     
                Conn = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter();	       
            Mydata.SelectCommand = new SqlCommand();
            Mydata.SelectCommand.Connection = Class.FunctionOanh.Conn; 	
            Mydata.SelectCommand.CommandText = sql;	
            DataTable table = new DataTable();    
            Mydata.Fill(table); 	
            return table;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Class.FunctionOanh.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static void RunSql(string sql)
        {
            SqlCommand cmd;		                // Khai báo đối tượng SqlCommand
            cmd = new SqlCommand();	         // Khởi tạo đối tượng
            cmd.Connection = Class.FunctionOanh.Conn;	  // Gán kết nối
            cmd.CommandText = sql;			  // Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();		  // Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Class.FunctionOanh.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }
    }
}
