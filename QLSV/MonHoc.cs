using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class MonHoc
    {
        public string TenMH { get; set; }
        public int SoTiet { get; set; }
        public double DiemTP { get; set; }
        public double DiemQT { get; set; }
        public double DiemTK { get; set; }


        public MonHoc(MonHoc m)
        {
            TenMH = m.TenMH;
            SoTiet = m.SoTiet;
        }
        public MonHoc(string TenMH, int SoTiet)
        {
            this.TenMH = TenMH;
            this.SoTiet = SoTiet;
        }
        public void NhapDiem(double DiemTP, double DiemQT)
        {
            this.DiemQT = DiemQT;
            this.DiemTP = DiemTP;
            this.DiemTK = (DiemTP + DiemQT) / 2;
        }
        public string DanhGia()
        {
            if (DiemTK < 4)
                return "Chua dat";
            else
                return "Dat";
        }
        public void thongtin()
        {
            Console.WriteLine(string.Format("|{0,-20}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|{5,-10}|", TenMH, SoTiet, DiemTP, DiemQT, DiemTK, DanhGia()));
        }


    }
}
