using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLSV
{
    public class dbConnector
    {
        //Lớp dẫn xuất database
        string connector = @"Data Source=DESKTOP-ERKSGGI\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";

        public dbConnector() { }
        public DataTable connect_to_SinhVien()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(connector);
                conn.Open();
                SqlDataAdapter query = new SqlDataAdapter("EXECUTE DANHSACHSINHVIEN", conn);
                query.Fill(table);
                conn.Close();
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        public DataTable connect_to_MonHoc()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(connector);
                conn.Open();
                SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM MONHOC", conn);
                query.Fill(table);
                conn.Close();
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable connect_to_Monhoc(int mamon, int masv)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(connector);
                conn.Open();
                SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM MONHOC WHERE MAMON =" + mamon + " AND MASV=" + masv, conn);
                query.Fill(table);
                conn.Close();
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public DataTable connect_to_MonhocDTO(int masv)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(connector);
                conn.Open();
                SqlDataAdapter query = new SqlDataAdapter("EXECUTE DANHSACHDIEM " + masv, conn);
                query.Fill(table);
                conn.Close();
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable connect_to_Diem()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(connector);
                conn.Open();
                SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM SV_MH", conn);
                query.Fill(table);
                conn.Close();
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public void nhapdiem(Diem diem)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(connector);
                conn.Open();
                SqlCommand command = new SqlCommand("NHAPDIEM", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DiemQT", diem.DiemQT);
                command.Parameters.AddWithValue("@DiemTP", diem.DiemTP);
                command.Parameters.AddWithValue("@MaMon", diem.MaMon);
                command.Parameters.AddWithValue("@MaSV", diem.MaSV);
                command.ExecuteNonQuery();
                //SqlDataAdapter query = new SqlDataAdapter("SELECT * FROM DIEM", conn);
                //query.Fill(table);
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
