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
        public virtual string TenSV { get; set; }
        public virtual int MaSV { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual string DOB { get; set; }
        public virtual string Lop { get; set; }
        public virtual string Khoa { get; set; }
        public virtual int SoMon { get; set; }
        public virtual List<MonHocDTO> MonHocDTOs { get; set; }
        public SinhVienDTO() { }
        public SinhVienDTO(string Ten, int MaSV, string GioiTinh, string DOB, string Lop, string Khoa)
        {
            this.TenSV = Ten;
            this.MaSV = MaSV;
            this.GioiTinh = GioiTinh;
            this.DOB = DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
        }
        public SinhVienDTO(string Ten, int MaSV, string GioiTinh, string DOB, string Lop, string Khoa, int SoMon)
        {
            this.TenSV = Ten;
            this.MaSV = MaSV;
            this.GioiTinh = GioiTinh;
            this.DOB = DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
            this.SoMon = SoMon;
        }
        public virtual void Info()
        {
            Console.WriteLine(string.Format(ConstParamemter.alignSV, MaSV, TenSV, GioiTinh, DOB, Lop, Khoa, SoMon));
        }
    }
}
