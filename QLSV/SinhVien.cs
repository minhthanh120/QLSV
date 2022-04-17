using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class SinhVien
    {
        public string Ten { get; set; }
        public int MaSV { get; set; }
        public string GioiTinh { get; set; }
        public string DOB { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }

        public ICollection<MonHoc> MonHocs { get; set; }
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
            this.GioiTinh = GioiTinh;
            this.DOB = DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
        }
        public void info()
        {
            Console.WriteLine(string.Format("|{0,-12}|{1,-18}|{2,-12}|{3,-18}|{4,-12}|{5,-12}|{6,-15}|", MaSV, Ten, GioiTinh, DOB, Lop, Khoa, MonHocs.Count()));
        }
    }
}
