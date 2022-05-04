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
        public virtual int MaSV { get; set; }
        public virtual int MaMon { get; set; }
        public virtual double DiemQT { get; set; }
        public virtual double DiemTP { get; set; }
        public virtual double DiemTK { get; set; }
        public virtual string DanhGia { get; set; }
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
        public virtual void Info()
        {
            Console.WriteLine(string.Format("|{0,-3}|{1,-25}|{2,-3}|{3,-3}|{4,-3}|{5,-8}|", MaMon, MaSV, DiemQT, DiemTP, DiemTK, DanhGia));
        }

        public override bool Equals(object obj)
        {
            return obj is Diem diem &&
                   MaSV == diem.MaSV &&
                   MaMon == diem.MaMon &&
                   DiemQT == diem.DiemQT &&
                   DiemTP == diem.DiemTP &&
                   DiemTK == diem.DiemTK &&
                   DanhGia == diem.DanhGia;
        }

        public override int GetHashCode()
        {
            int hashCode = 636515174;
            hashCode = hashCode * -1521134295 + MaSV.GetHashCode();
            hashCode = hashCode * -1521134295 + MaMon.GetHashCode();
            hashCode = hashCode * -1521134295 + DiemQT.GetHashCode();
            hashCode = hashCode * -1521134295 + DiemTP.GetHashCode();
            hashCode = hashCode * -1521134295 + DiemTK.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DanhGia);
            return hashCode;
        }
    }
}
