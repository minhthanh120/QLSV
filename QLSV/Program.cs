using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class SinhVien
    {
        public string Ten { get; set; }
        public int MaSV { get; set; }
        public string GioiTinh { get; set; }
        public string DOB { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }

        public ICollection<MonHoc> MonHocs { get; set; }
        public SinhVien(SinhVien s)
        {
            this.Ten = s.Ten;
            this.MaSV = s.MaSV;
            this.GioiTinh = s.GioiTinh;
            this.DOB = s.DOB;
            this.Lop = s.Lop;
            this.Khoa = s.Khoa;
        }

        public SinhVien(string Ten, int MaSV, string GioiTinh, string DOB, string Lop, string Khoa)
        {
            this.Ten = Ten;
            this.MaSV = MaSV;
            this.GioiTinh= GioiTinh;
            this.DOB= DOB;
            this.Lop = Lop;
            this.Khoa = Khoa;
        }
        public void info()
        {
            Console.WriteLine(string.Format("|{0,-12}|{1,-18}|{2,-12}|{3,-18}|{4,-12}|{5,-12}|{6,-15}|", MaSV , Ten , GioiTinh , DOB , Lop , Khoa, MonHocs.Count()));
        }
    }

    class MonHoc
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

            return "Chua du thong tin";
        }
        public void thongtin()
        {
            Console.WriteLine(string.Format("|{0,-20}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|{5,-10}|", TenMH,SoTiet, DiemTP,DiemQT,DiemTK, DanhGia()));
        }


    }



    
    
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Tạo danh sách sinh viên, danh sách môn học
            List<SinhVien> SVs = new List<SinhVien>();
            SinhVien sv1 = new SinhVien("La Bo", 1, "Nam", "2009 - 05 - 08", "12a1", "1920");
            SVs.Add(sv1);
            SinhVien sv2 = new SinhVien("Omen", 2, "Nam", "2009 - 05 - 08", "12a2", "1920");
            SVs.Add(sv2);
            SinhVien sv3 = new SinhVien("Jett", 3, "Nu", "2009 - 05 - 18", "12a1", "1920");
            SVs.Add(sv3);
            SinhVien sv4 = new SinhVien("Brimstone", 4, "Nam", "2009 - 12 - 28", "12a2", "1920");
            SVs.Add(sv4);
            SinhVien sv5 = new SinhVien("Sage", 5, "Nu", "2009 - 01 - 01", "12a1", "1920");
            SVs.Add(sv5);

            List<MonHoc> MHs= new List<MonHoc>();
            List<MonHoc> MHs2 = new List<MonHoc>();
            List<MonHoc> MHs3 = new List<MonHoc>();
            List<MonHoc> MHs4 = new List<MonHoc>();
            List<MonHoc> MHs5 = new List<MonHoc>();
            MonHoc mh1 = new MonHoc("Kinh doanh", 2);
            MonHoc mh2 = new MonHoc("NLP", 3);
            MonHoc mh3 = new MonHoc("Open CV", 4);          
            MonHoc mh4 = new MonHoc("Tensorflow", 2);
            MonHoc mh5 = new MonHoc("Pytorch", 1);
            MHs.Add(mh1);
            MHs2.Add(mh1);
            MHs3.Add(mh1);
            MHs4.Add(mh1);
            MHs5.Add(mh1);
            MHs.Add(mh2);
            MHs2.Add(mh2);
            MHs3.Add(mh2);
            MHs4.Add(mh2);
            MHs.Add(mh3);
            MHs2.Add(mh3);
            MHs.Add(mh4);
            MHs3.Add(mh4);
            MHs.Add(mh5);
            MHs4.Add(mh5);
            sv1.MonHocs = MHs;
            sv2.MonHocs = MHs2;
            sv3.MonHocs = MHs3;
            sv4.MonHocs = MHs4;
            sv5.MonHocs = MHs5;

            //Menu chương trình
            Console.WriteLine("___MENU___");
            Console.WriteLine("1. Danh sach sinh vien");
            Console.WriteLine("2. Thong tin sinh vien");
            Console.WriteLine("3. Nhap điem");
            
            int choose = Int32.Parse(Console.ReadLine());
            switch (choose)

            {
                case 1:
                    Console.WriteLine("Danh sach sinh vien");
                    Console.WriteLine(string.Format("|{0,-12}|{1,-18}|{2,-12}|{3,-18}|{4,-12}|{5,-12}|{6,-15}|", "Ma sinh vien", "Ten sinh vien", "Gioi tinh" , "Ngay sinh" , "Lop" , "Khoa" , "So mon dang ky"));
                    foreach (SinhVien m in SVs)
                    {
                        m.info();
                    }
                    break;
                case 2:
                    Console.WriteLine("Thong tin sinh vien");
                    Console.WriteLine("Moi nhap ma sinh vien");
                    int case2 = Int32.Parse(Console.ReadLine());
                    while (SVs.Find(s => s.MaSV == case2) == null)
                    {
                        Console.WriteLine("Khong co sinh vien nay!");
                        Console.WriteLine("Moi nhap ma sinh vien");
                        case2 = Int32.Parse(Console.ReadLine());

                    }
                    thongtinchitiet(case2, SVs);
                    break;
                case 3:
                    Console.WriteLine("Moi nhap ma sinh vien");
                    int case4 = Int32.Parse(Console.ReadLine());

                    while (SVs.Find(s => s.MaSV == case4) == null)
                    {
                        Console.WriteLine("Khong co sinh vien nay!");
                        Console.WriteLine("Moi nhap ma sinh vien");
                        case4 = Int32.Parse(Console.ReadLine());
                        
                    }
                    nhapdiem(SVs.Find(s => s.MaSV == case4));
                    break;
                default:
                    Console.WriteLine("Xin moi nhap lua chon tu 1 den 3!");
                    break;
            }

            Console.ReadKey();
        }

        //Xem danh sách sinh viên
        public static void thongtinsinhvien(List<SinhVien> SVs)
        {
            foreach (SinhVien s in SVs)
            {
                s.info();
            }
        }

        //Xem chi tiết thông tin
        public static void thongtinchitiet(int x, List<SinhVien> SVs)
        {
            SinhVien result = (from s in SVs where s.MaSV == x select s).FirstOrDefault();
            if (result != null)
            {
                Console.WriteLine(string.Format("|{0,-12}|{1,-18}|{2,-12}|{3,-18}|{4,-12}|{5,-12}|{6,-15}|", "Ma sinh vien", "Ten sinh vien", "Gioi tinh", "Ngay sinh", "Lop", "Khoa", "So mon dang ky"));
                result.info();
                if(result.MonHocs!=null)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(string.Format("|{0,-20}|{1,-10}|{2,-10}|{3,-10}|{4,-10}|{5,-10}|", "Ten mon hoc", "So Tiet", "Diem TP", "Diem QT", "Diem TK", "Danh gia"));
                    foreach (MonHoc m in result.MonHocs)
                    {
                        m.thongtin();
                    }
                }
                
            }
            else
            {
                Console.WriteLine("404");
            }
            
        }

        //Nhập điểm cho sinh viên
        public static void nhapdiem(SinhVien sv)
        {
            Console.WriteLine(string.Format("{0,2}|{1,-20}|{2,-10}|{3,-10}|{4,-10}|{5,-10}|{6,-10}|", "STT","Ten mon hoc", "So Tiet", "Diem TP", "Diem QT", "Diem TK", "Danh gia"));
            int index=monhocsv(sv);
            Console.WriteLine("Moi chon stt mon ban muon nhap diem");
            int choose = Int32.Parse(Console.ReadLine());
            if(choose>index)
                Console.WriteLine("Khong co mon nay moi nhap lai");
            else
            {
                Console.WriteLine("Nhap diem thanh phan cua mon " + sv.MonHocs.ElementAt(choose-1).TenMH);
                double DiemTP = double.Parse(Console.ReadLine());
                Console.WriteLine("Nhap diem qua trinh cua mon " + sv.MonHocs.ElementAt(choose-1).TenMH);
                double DiemQT = double.Parse(Console.ReadLine());
                sv.MonHocs.ElementAt(choose-1).NhapDiem(DiemTP, DiemQT);
                Console.WriteLine("Nhap diem thanh cong!");
                index = monhocsv(sv);
            }
        }
        public static int monhocsv(SinhVien sv)
        {
            int index = 1;
            foreach (MonHoc m in sv.MonHocs)
            {
                Console.Write(index + "  ");
                m.thongtin();
                index += 1;
            }
            return index;
        }
    }
}
