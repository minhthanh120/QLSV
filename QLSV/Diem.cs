using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
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
        public Diem(int MaSV, int MaMon, double DiemQT, double DiemTP, double DiemTK, string DanhGia)
        {
            this.MaSV = MaSV;
            this.MaMon = MaMon;
            this.DiemQT = DiemQT;
            this.DiemTP = DiemTP;
            this.DiemTK = DiemTK;
            this.DanhGia = DanhGia;
        }
        public void info()
        {
            Console.WriteLine(string.Format("|{0,-3}|{1,-25}|{2,-3}|{3,-3}|{4,-3}|{5,-8}|", MaMon, MaSV, DiemQT, DiemTP, DiemTK, DanhGia));
        }
        public void nhapdiem(int MaSV, int MaMon, double DiemQT, double DiemTP)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
