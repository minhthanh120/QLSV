using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class MonHoc
    {
        //Model Môn học
        public int MaMon { get; set; }
        public string TenMH { get; set; }
        public int SoTiet { get; set; }
        public MonHoc()
        {
        }
        public MonHoc(int MaMon, string TenMH, int SoTiet)
        {
            this.MaMon = MaMon;
            this.TenMH = TenMH;
            this.SoTiet = SoTiet;
        }

        public void info()
        {
            Console.WriteLine(string.Format("|{0,-3}|{1,-25}|{2,-3}|", MaMon, TenMH, SoTiet));
        }
    }
}
