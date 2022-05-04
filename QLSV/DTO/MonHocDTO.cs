using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QLSV.DTO
{
    public class MonHocDTO
    {
        //ViewModel Môn học
        public virtual int MaMH { get; set; }
        public virtual string TenMH { get; set; }
        public virtual int SoTiet { get; set; }
        public virtual double DiemTP { get; set; }
        public virtual double DiemQT { get; set; }
        public virtual double DiemTK { get; set; }
        public virtual string DanhGia { get; set; }
        public MonHocDTO() { }
        public MonHocDTO(int MaMH, string TenMH, int SoTiet)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.SoTiet = SoTiet;
        }
        public MonHocDTO(int MaMH, string TenMH, int SoTiet, double DiemQT, double DiemTP, double DiemTK, string DanhGia)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.SoTiet = SoTiet;
            this.DiemQT = DiemQT;
            this.DiemTP = DiemTP;
            this.DiemTK = DiemTK;
            this.DanhGia = DanhGia;
        }
        public virtual void Info()
        {
            Console.WriteLine(string.Format(ConstParamemter.alignMH, MaMH, TenMH, SoTiet, DiemTP, DiemQT, DiemTK, DanhGia));
        }
        public virtual void NhapDiem(double DiemTP, double DiemQT)
        {
            this.DiemQT = DiemQT;
            this.DiemTP = DiemTP;
        }
    }
}
