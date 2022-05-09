using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace QLSV.Models
{
    public class SinhVien
    {
        //Model Sinh viên
        public virtual string TenSV { get; set; }
        public virtual int MaSV { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual string DOB { get; set; }
        public virtual string Lop { get; set; }
        public virtual string Khoa { get; set; }

        public SinhVien()
        {

        }
        public SinhVien(string Ten, int MaSV, string GioiTinh, string DOB, string Lop, string Khoa)
        {
            this.TenSV = Ten;
            this.MaSV = MaSV;
            this.GioiTinh = GioiTinh;
            this.DOB = DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
        }

        public virtual void Info()
        {
            Console.WriteLine(string.Format("|{0,-3}|{1,-18}|{2,-5}|{3,-18}|{4,-5}|{5,-5}|", MaSV, TenSV, GioiTinh, DOB, Lop, Khoa));
        }
    }
}
