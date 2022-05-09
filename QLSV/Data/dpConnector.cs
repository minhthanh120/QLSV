using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using QLSV.Interface;
using QLSV.DTO;
using QLSV.Models;
using System.Configuration;

namespace QLSV.Data
{
    internal class dpConnector : IDataLoader
    {
        IDbConnection db;
        public dpConnector()
        {
            this.db = new SqlConnection(ConfigurationManager.ConnectionStrings["QLSV.Properties.Settings.QLSVConnectionString"].ConnectionString);
        }

        void IDataLoader.LoadMonHocDTO(ref List<MonHocDTO> MonHocs, int masv)
        {
            Console.WriteLine("Dapper LoadMonHocDTO");
            string query = "DANHSACHDIEM";
            MonHocs = db.Query<MonHocDTO>(query, new { param1 = masv },
        commandType: CommandType.StoredProcedure).ToList();
        }

        void IDataLoader.LoadSinhVienDTO(ref List<SinhVienDTO> SVs)
        {
            Console.WriteLine("Dapper");
            string query = "EXECUTE DANHSACHSINHVIEN";
            SVs = db.Query<SinhVienDTO>(query).ToList();
        }

        void IDataLoader.NhapDiem(Diem diem)
        {
            Console.WriteLine("Nhapdiem");
            string query = "NHAPDIEM";
            db.Execute(query,
                new
                {
                    DIEMQT = diem.DiemQT,
                    DIEMTP = diem.DiemTP,
                    MAMON = diem.MaMon,
                    MASV = diem.MaSV
                },
        commandType: CommandType.StoredProcedure);
        }
    }
}
