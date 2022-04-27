using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace QLSV
{
    public class SinhVien
    {
        //Model Sinh viên
        public string Ten { get; set; }
        public int MaSV { get; set; }
        public string GioiTinh { get; set; }
        public string DOB { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }

        public SinhVien()
        {

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

        public void Info()
        {
            Console.WriteLine(string.Format("|{0,-3}|{1,-18}|{2,-5}|{3,-18}|{4,-5}|{5,-5}|", MaSV, Ten, GioiTinh, DOB, Lop, Khoa));
        }
    }
}
