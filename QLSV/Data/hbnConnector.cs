using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.DTO;
using QLSV.Models;
using QLSV.Interface;

namespace QLSV.Data
{
    public class hbnConnector : IDataLoader
    {
        public void LoadSinhVienDTO( ref List<SinhVienDTO> SVs)
        {
            Console.WriteLine("Nhibernate");
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var query = session.GetNamedQuery("DANHSACHSINHVIEN");
                SVs = query.List<SinhVienDTO>().ToList();
            }
        }
        public void LoadMonHocDTO(ref List<MonHocDTO> MonHocs, int masv)
        {
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var query = session.GetNamedQuery("DANHSACHMONHOC");
                query.SetParameter("param", masv, NHibernateUtil.Int32);
                MonHocs = query.List<MonHocDTO>().ToList();
            }
        }
        public void NhapDiem(Diem diem)
        {
            using (ISession session = NhibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var query = session.CreateSQLQuery("EXECUTE NHAPDIEM @DIEMQT = :diemqt, @DIEMTP = :diemtp, @MAMON = :mamon, @MASV = :masv");
                query.SetParameter("diemqt", diem.DiemQT, NHibernateUtil.Double);
                query.SetParameter("diemtp", diem.DiemTP, NHibernateUtil.Double);
                query.SetParameter("masv", diem.MaSV, NHibernateUtil.Int32);
                query.SetParameter("mamon", diem.MaMon, NHibernateUtil.Int32);
                query.ExecuteUpdate();
            }
        }
    }
}
