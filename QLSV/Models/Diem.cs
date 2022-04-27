using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.DTO;

namespace QLSV.Models
{
    public class Diem
    {
        //Model Điểm
        public int MaSV { get; set; }
        public int MaMon { get; set; }
        public double DiemQT { get; set; }
        public double DiemTP { get; set; }
        public double DiemTK { get; set; }
        public string DanhGia { get; set; }
        public Diem() { }
        public Diem(int MaSV, int MaMon, double DiemQT, double DiemTP)
        {
            this.MaSV = MaSV;
            this.MaMon = MaMon;
            this.DiemQT = DiemQT;
            this.DiemTP = DiemTP;
        }
        public Diem(int MaSV, MonHocDTO mh)
        {
            this.MaSV = MaSV;
            this.MaMon = mh.MaMH;
            this.DiemQT = mh.DiemQT;
            this.DiemTP = mh.DiemTP;
        }
        public Diem(int MaSV, int MaMon, double DiemQT, double DiemTP, double DiemTK, string DanhGia)
        {
            this.MaSV = MaSV;
            this.MaMon = MaMon;
            this.DiemQT = DiemQT;
            this.DiemTP = DiemTP;
            this.DiemTK = DiemTK;
            this.DanhGia = DanhGia;
        }
        public void Info()
        {
            Console.WriteLine(string.Format("|{0,-3}|{1,-25}|{2,-3}|{3,-3}|{4,-3}|{5,-8}|", MaMon, MaSV, DiemQT, DiemTP, DiemTK, DanhGia));
        }
    }
}
