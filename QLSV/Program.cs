using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class SinhVien
    {
        public string Ten;
        public int MaSV;
        public string GioiTinh;
        public string DOB;
        public string Lop;
        public string Khoa;
        public SinhVien(SinhVien s)
        {
            this.Ten = s.Ten;
            this.MaSV = s.MaSV;
            this.GioiTinh = s.GioiTinh;
            this.DOB = s.DOB;
            this.Lop = s.Lop;
            this.Khoa = s.Khoa;
        }

        public SinhVien(string Ten, int MaSV, string GioiTinh, string DOB, string Lop, string Khoa)
        {
            this.Ten = Ten;
            this.MaSV = MaSV;
            this.GioiTinh= GioiTinh;
            this.DOB= DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
        }
        public void info()
        {
            Console.WriteLine(MaSV + " " + Ten + " " + GioiTinh + " " + DOB + " " + Lop + " " + Khoa);
        }
    }

    class MonHoc
    {
        string TenMH;
        int SoTiet;

        public MonHoc(MonHoc m)
        {
            TenMH = m.TenMH;
            SoTiet = m.SoTiet;
        }
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("1. Danh sach sinh vien");
            //Console.WriteLine("2. Thong tin sinh vien");
            //Console.WriteLine("3. Mon hoc đa đang ky");
            //Console.WriteLine("4. Nhap điem");
            //Console.WriteLine("5. Ket qua");
            //int choose = int.Parse(Console.ReadLine());
            //switch (choose)

            //{
            //    case 0:
            //        Console.WriteLine("1");
            //}

            List<SinhVien> SVs = new List<SinhVien>();
            SinhVien sv1 = new SinhVien("La Bo", 1, "Nam", "2009 - 05 - 08", "12a1", "1920");
            SVs.Add(sv1);
            SinhVien sv2 = new SinhVien("Omen", 2, "Nam", "2009 - 05 - 08", "12a2", "1920");
            SVs.Add(sv2);
            SinhVien sv3 = new SinhVien("Jett", 3, "Nu", "2009 - 05 - 18", "12a1", "1920");
            SVs.Add(sv3);
            SinhVien sv4 = new SinhVien("Brimstone", 4, "Nam", "2009 - 12 - 28", "12a2", "1920");
            SVs.Add(sv4);
            SinhVien sv5 = new SinhVien("Sage", 5, "Nu", "2009 - 01 - 01", "12a1", "1920");
            SVs.Add(sv5);

            List<MonHoc> MHs= new List<MonHoc>();
            //thongtinsinhvien(SVs);
            
        }

        public static void thongtinsinhvien(List<SinhVien> SVs)
        {
            foreach (SinhVien s in SVs)
            {
                s.info();
            }
        }

        public static void thongtinchitiet(int x, List<SinhVien> SVs)
        {
            SinhVien result = (from s in SVs where s.MaSV == x select s).FirstOrDefault();
            if (result != null)
            {
                result.info();
            }
            else
            {
                Console.WriteLine("404");
            }
            Console.ReadKey();
        }
    }
}
