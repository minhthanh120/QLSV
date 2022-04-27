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
        public virtual List<MonHocDTO> MonHocDTOs { get; set; }
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
        public SinhVienDTO() { }
        public void Info()
        {
            Console.WriteLine(string.Format(ConstParam.alignSV, MaSV, Ten, GioiTinh, DOB, Lop, Khoa, SoMon));
        }
    }
}
