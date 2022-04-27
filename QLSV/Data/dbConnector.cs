using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QLSV.DTO;
using QLSV.Models;
using QLSV.Interface;

namespace QLSV.Data
{
    public class dbConnector:IdbConnector
    {
        //Lớp dẫn xuất database
        public dbConnector() { }
        public DataTable ConnectorSinhVien()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConstParamemter.connector);
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

        public DataTable ConnectorMonhoc(int mamon, int masv)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConstParamemter.connector);
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
        public DataTable ConnectorMonhocDTO(int masv)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConstParamemter.connector);
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

        public DataTable ConnectorDiem()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConstParamemter.connector);
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
        public void NhapDiem(Diem diem)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(ConstParamemter.connector);
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

        //public void LoadMonHocDTO(ref List<MonHocDTO> MonHocs, int masv)
        //{
        //    try
        //    {
        //        DataTable dataTable1 = ConnectorMonhocDTO(masv);
        //        MonHocs.Clear();
        //        foreach (DataRow row in dataTable1.Rows)
        //        {
        //            MonHocDTO d = new MonHocDTO(Convert.ToInt32(row["MAMON"]), Convert.ToString(row["TENMH"]), Convert.ToInt32(row["SOTIET"]), ConvertDiem(row["DIEMQT"]), ConvertDiem(row["DIEMTP"]), ConvertDiem(row["DIEMTK"]), ConvertDanhgia(row["DANHGIA"]));
        //            MonHocs.Add(d);
        //        }
        //    }
        //    catch (Exception e) { Console.WriteLine(e.Message); }

        //}//Load danh sách sinh viên
        //public void LoadSinhVienDTO(ref List<SinhVienDTO> SVs)
        //{
        //    try
        //    {
        //        DataTable dataTable1 = ConnectorSinhVien();
        //        if (SVs.Count() > 0)
        //            SVs.Clear();
        //        foreach (DataRow row in dataTable1.Rows)
        //        {
        //            SinhVienDTO sv = new SinhVienDTO(Convert.ToString(row["TENSV"]), Convert.ToInt32(row["MASV"]), Convert.ToString(row["GIOITINH"]), Convert.ToString(row["NGAYSINH"]), Convert.ToString(row["LOP"]), Convert.ToString(row["KHOA"]), Convert.ToInt32(row["Số môn học"]));
        //            SVs.Add(sv);
        //        }
        //    }
        //    catch (Exception e) { Console.WriteLine(e.Message); }


        //}
        ////Load danh sách sinh viên
        //public void LoadSinhVien(ref List<SinhVien> SVs)
        //{
        //    try
        //    {
        //        DataTable table = new DataTable();
        //        SqlConnection conn = new SqlConnection(ConstParamemter.connector);
        //        conn.Open();
        //        SqlDataAdapter query = new SqlDataAdapter("EXECUTE DANHSACHSINHVIEN", conn);
        //        query.Fill(table);
        //        conn.Close();
        //        SVs.Clear();
        //        foreach (DataRow row in table.Rows)
        //        {
        //            SinhVien sv = new SinhVien(Convert.ToString(row["TENSV"]), Convert.ToInt32(row["MASV"]), Convert.ToString(row["GIOITINH"]), Convert.ToString(row["NGAYSINH"]), Convert.ToString(row["LOP"]), Convert.ToString(row["KHOA"]));
        //            SVs.Add(sv);
        //        }
        //    }
        //    catch (Exception e) { Console.WriteLine(e.Message); }
        //}
        ////Convert điểm từ object sang double
        //public double ConvertDiem(object row)
        //{
        //    double d = 0;
        //    try
        //    {
        //        if (row != DBNull.Value)
        //            d = Convert.ToDouble(row);
        //        else
        //            return d;
        //    }
        //    catch (Exception e) { Console.WriteLine(e.Message); }


        //    return d;
        //}
        ////Convert object đánh giá sang string
        //public string ConvertDanhgia(object row)
        //{
        //    string d = "Chưa đạt";
        //    try
        //    {

        //        if (row != DBNull.Value)
        //            d = Convert.ToString(row);
        //        else
        //            return d;
        //        return d;
        //    }
        //    catch (Exception e) { Console.WriteLine(e.Message); }
        //    return d;
        //}
    }
}
