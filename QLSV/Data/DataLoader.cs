using QLSV.DTO;
using QLSV.Interface;
using QLSV.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Data
{
    public class DataLoader: IDataLoader
    {
        IdbConnector _connector;
        public DataLoader() { }
        //Constructor injection
        public DataLoader(IdbConnector connector)=>this._connector = connector;
        // Setter injection
        void SetIdbConnector(IdbConnector connector) => this._connector = connector;

        //Load danh sách môn học
        public void LoadMonHocDTO(ref List<MonHocDTO> MonHocs, int masv)
        {
            try
            {
                DataTable dataTable1 = _connector.ConnectorMonhocDTO(masv);
                if (MonHocs.Count() > 0)
                    MonHocs.Clear();
                foreach (DataRow row in dataTable1.Rows)
                {
                    MonHocDTO d = new MonHocDTO(Convert.ToInt32(row["MAMON"]), Convert.ToString(row["TENMH"]), Convert.ToInt32(row["SOTIET"]), ConvertDiem(row["DIEMQT"]), ConvertDiem(row["DIEMTP"]), ConvertDiem(row["DIEMTK"]), ConvertDanhgia(row["DANHGIA"]));
                    MonHocs.Add(d);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }//Load danh sách sinh viên
        public void LoadSinhVienDTO( ref List<SinhVienDTO> SVs)
        {
            try
            {
                DataTable dataTable1 = _connector.ConnectorSinhVien();
                if(SVs.Count()>0)
                    SVs.Clear();
                foreach (DataRow row in dataTable1.Rows)
                {
                    SinhVienDTO sv = new SinhVienDTO(Convert.ToString(row["TENSV"]), Convert.ToInt32(row["MASV"]), Convert.ToString(row["GIOITINH"]), Convert.ToString(row["NGAYSINH"]), Convert.ToString(row["LOP"]), Convert.ToString(row["KHOA"]), Convert.ToInt32(row["Số môn học"]));
                    SVs.Add(sv);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message);}
        }
        //Convert điểm trong datatable từ object sang double
        public double ConvertDiem(object row)
        {
            double d = 0;
            try
            {
                if (row != DBNull.Value)
                    d = Convert.ToDouble(row);
                else
                    return d;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }


            return d;
        }
        //Convert object Danhgia (đánh giá) trong datatable sang string
        public string ConvertDanhgia(object row)
        {
            string d = "Chưa đạt";
            try
            {

                if (row != DBNull.Value)
                    d = Convert.ToString(row);
                else
                    return d;
                return d;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return d;
        }
        //Nhập điểm
        public void NhapDiem(Diem diem)
        {
            _connector.NhapDiem(diem);
        }
    }
}
