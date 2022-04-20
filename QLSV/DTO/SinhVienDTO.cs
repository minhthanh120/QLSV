using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    public class SinhVienDTO
    {
        //ViewModel Sinh viên
        public string Ten { get; set; }
        public int MaSV { get; set; }
        public string GioiTinh { get; set; }
        public string DOB { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public virtual int SoMon { get; set; }
        public virtual ICollection<MonHoc> MonHocDTOs { get; set; }
        public SinhVienDTO(string Ten, int MaSV, string GioiTinh, string DOB, string Lop, string Khoa)
        {
            this.Ten = Ten;
            this.MaSV = MaSV;
            this.GioiTinh = GioiTinh;
            this.DOB = DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
        }
        public SinhVienDTO(string Ten, int MaSV, string GioiTinh, string DOB, string Lop, string Khoa, int SoMon)
        {
            this.Ten = Ten;
            this.MaSV = MaSV;
            this.GioiTinh = GioiTinh;
            this.DOB = DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
            this.SoMon = SoMon;
        }
        public void info()
        {
            Console.WriteLine(string.Format("|{0,-12}|{1,-18}|{2,-12}|{3,-18}|{4,-12}|{5,-12}|{6,-15}|", MaSV, Ten, GioiTinh, DOB, Lop, Khoa, SoMon));
        }
    }
}
