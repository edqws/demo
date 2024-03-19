using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sa
{
    public class Database
    {
        private string connetionString = @"Data Source=LAPTOP-UHR0L3LQ;Initial Catalog=QLNV;User ID=sa;Password=12";
        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;
        public Database()
        {
            try
            {
                conn = new SqlConnection(connetionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("connected failed: " + ex.Message);
            }
        }
        public DataTable selectData(string sql, List<CustomParameter>lstPara)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);// nội dung sql được chuyền vào 
                cmd.CommandType = CommandType.StoredProcedure;// set command type cho cmd
                foreach(var para in lstPara)// gán các tham số cho cmd
                {
                    cmd.Parameters.AddWithValue(para.key, para.value);
                }    
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("LOI LOAD DU LIEU:  " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataRow select(string sql)
        {
            try
            {
                conn.Open ();
                cmd = new SqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi load thông tin chi tiết: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public int ExecCute(string sql,List<CustomParameter>lstPara)
        {
            try
            {
                conn.Open();    // mở kết nối
                cmd = new SqlCommand(sql, conn);//thực thi câu lệnh sql
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in lstPara) // gán các tham số cmd
                {
                    cmd.Parameters.AddWithValue(p.key,p.value);
                }
                var rs = cmd.ExecuteNonQuery(); // lấy kết quả thực thi chuy vấn
                return (int)rs;    // trả về kết quả
            }
            catch(Exception ex)
            {
             MessageBox.Show("Lỗi thực thi câu lệnh: "+ex.Message);
            return -100;
            }
            finally
            {
            conn.Close();// đóng kết nối
            }

        }
    }
}
