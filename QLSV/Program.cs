using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using QLSV.DTO;
namespace QLSV
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<SinhVienDTO> SVs = new List<SinhVienDTO>();
            List<Diem> Diems = new List<Diem>();
            List<MonHocDTO> MonHocs = new List<MonHocDTO>();


        //SinhVien_load(SVs);
        //MonHoc_load(MonHocs);
        //Diem_load(Diems);

        //Menu chương trình
        menu:
            Console.WriteLine("___MENU___");
            Console.WriteLine("1. Danh sach sinh vien");
            Console.WriteLine("2. Thong tin sinh vien");
            Console.WriteLine("3. Nhap điem");

            int choose = Int32.Parse(Console.ReadLine());
            switch (choose)

            {

                case 1:
                    try
                    {
                        SinhVienDTO_load(SVs);
                        Console.WriteLine("Danh sach sinh vien");
                        Console.WriteLine(string.Format("|{0,-12}|{1,-18}|{2,-12}|{3,-18}|{4,-12}|{5,-12}|{6,-15}|", "Ma sinh vien", "Ten sinh vien", "Gioi tinh", "Ngay sinh", "Lop", "Khoa", "So mon dang ky"));
                        foreach (SinhVienDTO m in SVs)
                        {
                            m.info();
                        }
                        Console.WriteLine("Ban co muon thoat? (y/n)");
                        string key1 = Console.ReadLine();
                        if (key1 == "y")
                        {
                            Console.WriteLine("Tam biet!");
                            System.Threading.Thread.Sleep(1000);
                            Environment.Exit(0);
                        }
                        else
                            goto menu;
                        SVs.Clear();
                    }
                    catch (Exception ex1)
                    {
                        Console.WriteLine(ex1.Message);
                    }
                    break;

                case 2:
                case_2:
                    try
                    {
                        SinhVienDTO_load(SVs);
                        Console.WriteLine("Thong tin sinh vien");
                        Console.WriteLine("Moi nhap ma sinh vien");
                        int case2 = Int32.Parse(Console.ReadLine());
                        while (SVs.Find(s => s.MaSV == case2) == null)
                        {
                            Console.WriteLine("Khong co sinh vien nay!");
                            Console.WriteLine("Moi nhap ma sinh vien");
                            case2 = Int32.Parse(Console.ReadLine());

                        }
                        thongtinchitiet(case2, SVs, Diems);

                        Console.WriteLine("Ban co muon tiep tuc? (y/n)");
                        string key2 = Console.ReadLine();
                        if (key2 == "y")
                        {
                            goto case_2;
                        }
                        else
                            goto menu;
                        SVs.Clear();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine(ex2.Message);
                    }
                    break;

                case 3:
                case_3:
                    try
                    {
                        SinhVienDTO_load(SVs);
                        Console.WriteLine("Moi nhap ma sinh vien");
                        int case4 = Int32.Parse(Console.ReadLine());

                        while (SVs.Exists(x => x.MaSV == case4) != true)
                        {
                            Console.WriteLine("Khong co sinh vien nay!");
                            Console.WriteLine("Moi nhap ma sinh vien");
                            case4 = Int32.Parse(Console.ReadLine());

                        }
                        Console.WriteLine(string.Format("|{0,-12}|{1,-18}|{2,-12}|{3,-18}|{4,-12}|{5,-12}|{6,-15}|", "Ma sinh vien", "Ten sinh vien", "Gioi tinh", "Ngay sinh", "Lop", "Khoa", "So mon dang ky"));
                        SVs.Find(s => s.MaSV == case4).info();
                        MonHocDTO_load(MonHocs, SVs.Find(s => s.MaSV == case4).MaSV);
                        nhapdiem(SVs.Find(s => s.MaSV == case4));

                        Console.WriteLine("Ban co muon tro ve menu ? (y/n)");
                        string key3 = Console.ReadLine();
                        SVs.Clear();
                        MonHocs.Clear();
                        if (key3 == "y")
                        {
                            goto menu;
                        }
                        else
                            goto case_3;
                        SVs.Clear();
                        MonHocs.Clear();
                    }
                    catch (Exception ex3)
                    {
                        Console.WriteLine(ex3);
                    }

                    break;
                default:
                    Console.WriteLine("Xin moi nhap lua chon tu 1 den 3!");
                    break;
            }


            Console.ReadKey();
        }
        public static void SinhVienDTO_load(List<SinhVienDTO> SVs)
        {
            dbConnector connector = new dbConnector();
            DataTable dataTable1 = connector.connect_to_SinhVien();
            SVs.Clear();
            foreach (DataRow row in dataTable1.Rows)
            {
                SinhVienDTO sv = new SinhVienDTO(Convert.ToString(row["TENSV"]), Convert.ToInt32(row["MASV"]), Convert.ToString(row["GIOITINH"]), Convert.ToString(row["NGAYSINH"]), Convert.ToString(row["LOP"]), Convert.ToString(row["KHOA"]), Convert.ToInt32(row["Số môn học"]));
                SVs.Add(sv);
            }

        }

        public static void SinhVien_load(List<SinhVien> SVs)
        {
            dbConnector connector = new dbConnector();
            DataTable dataTable1 = connector.connect_to_SinhVien();
            SVs.Clear();
            foreach (DataRow row in dataTable1.Rows)
            {
                SinhVien sv = new SinhVien(Convert.ToString(row["TENSV"]), Convert.ToInt32(row["MASV"]), Convert.ToString(row["GIOITINH"]), Convert.ToString(row["NGAYSINH"]), Convert.ToString(row["LOP"]), Convert.ToString(row["KHOA"]));
                SVs.Add(sv);
            }

        }
        public static void Diem_load(List<Diem> Diems)
        {
            dbConnector connector = new dbConnector();
            DataTable dataTable1 = connector.connect_to_Diem();
            Diems.Clear();
            foreach (DataRow row in dataTable1.Rows)
            {
                Diem d = new Diem(Convert.ToInt32(row["MASV"]), Convert.ToInt32(row["MAMON"]), diem(row["DIEMQT"]), diem(row["DIEMTP"]), diem(row["DIEMTK"]), danhgia(row["DANHGIA"]));
                Diems.Add(d);
            }
        }



        public static double diem(object row)
        {
            double d = 0;
            if (row != DBNull.Value)
                d = Convert.ToDouble(row);
            else
                return d;
            return d;
        }

        public static string danhgia(object row)
        {
            string d = "Chưa đạt";
            if (row != DBNull.Value)
                d = Convert.ToString(row);
            else
                return d;
            return d;
        }
        public static void MonHoc_load(List<MonHoc> MonHocs)
        {
            dbConnector connector = new dbConnector();
            DataTable dataTable1 = connector.connect_to_MonHoc();
            MonHocs.Clear();
            foreach (DataRow row in dataTable1.Rows)
            {
                MonHoc d = new MonHoc(Convert.ToInt32(row["MAMON"]), Convert.ToString(row["TENMH"]), Convert.ToInt32(row["SOTIET"]));
                MonHocs.Add(d);
            }
        }

        public static void MonHocDTO_load(List<MonHocDTO> MonHocs, int masv)
        {
            dbConnector connector = new dbConnector();
            DataTable dataTable1 = connector.connect_to_MonhocDTO(masv);
            MonHocs.Clear();
            foreach (DataRow row in dataTable1.Rows)
            {
                MonHocDTO d = new MonHocDTO(Convert.ToInt32(row["MAMON"]), Convert.ToString(row["TENMH"]), Convert.ToInt32(row["SOTIET"]), diem(row["DIEMQT"]), diem(row["DIEMTP"]), diem(row["DIEMTK"]), danhgia(row["DANHGIA"]));
                MonHocs.Add(d);
            }
        }


        public static void thongtinchitiet(int x, List<SinhVienDTO> SVs, List<Diem> Diems)
        {
            SinhVienDTO result = (from sv in SVs where sv.MaSV == x select sv).FirstOrDefault();
            if (result != null)
            {
                Console.WriteLine(string.Format("|{0,-12}|{1,-18}|{2,-12}|{3,-18}|{4,-12}|{5,-12}|{6,-15}|", "Ma sinh vien", "Ten sinh vien", "Gioi tinh", "Ngay sinh", "Lop", "Khoa", "So mon dang ky"));
                result.info();
                List<MonHocDTO> monHocDTOs = new List<MonHocDTO>();
                MonHocDTO_load(monHocDTOs, result.MaSV);

                //List<Diem> diem = (from d in Diems where d.MaSV == x select d).ToList();
                //List<MonHoc> monhoc = new List<MonHoc>();
                if (monHocDTOs != null)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(string.Format("|{0,-8}|{1,-30}|{2,-10}|{3,-10}|{4,-10}|{5,-10}|{6,-10}|", "Ma mon", "Ten mon hoc", "So Tiet", "Diem TP", "Diem QT", "Diem TK", "Danh gia"));
                    foreach (MonHocDTO m in monHocDTOs)
                    {
                        m.info();
                    }
                }

            }
            else
            {
                Console.WriteLine("404");
            }

        }
        public static Boolean nhapdiem(SinhVienDTO sv)
        {
        diem:
            List<MonHocDTO> monHocDTOs = new List<MonHocDTO>();
            List<MonHoc> MonHocs = new List<MonHoc>();
            MonHocDTO_load(monHocDTOs, sv.MaSV);
            if (monHocDTOs.Count() > 0)
            {
                Console.WriteLine(string.Format("|{0,-8}|{1,-30}|{2,-10}|{3,-10}|{4,-10}|{5,-10}|{6,-10}|", "Ma mon", "Ten mon hoc", "So Tiet", "Diem TP", "Diem QT", "Diem TK", "Danh gia"));
                foreach (MonHocDTO m in monHocDTOs)
                {
                    m.info();
                }
                Console.WriteLine("Moi chon stt mon ban muon nhap diem");
                int choose = Int32.Parse(Console.ReadLine());

                if (monHocDTOs.Exists(x => x.MaMH == choose) != true)
                    Console.WriteLine("Khong co mon nay moi nhap lai");
                else
                {
                    //MonHocDTO result = monHocDTOs.Find(mh => mh.MaMH == choose);
                    Console.WriteLine("Nhap diem thanh phan cua mon " + monHocDTOs.Find(mh => mh.MaMH == choose).TenMH);
                    double DiemTP = double.Parse(Console.ReadLine());
                    Console.WriteLine("Nhap diem qua trinh cua mon " + monHocDTOs.Find(mh => mh.MaMH == choose).TenMH);
                    double DiemQT = double.Parse(Console.ReadLine());
                    Diem diem = new Diem(sv.MaSV, choose, DiemTP, DiemQT);
                    dbConnector connector = new dbConnector();
                    connector.nhapdiem(diem);
                    Console.WriteLine("Nhap diem thanh cong!");
                    Console.WriteLine("Ban co muon tiep tuc? (y/n)");
                    string key1 = Console.ReadLine();
                    if (key1 == "y")
                    {
                        goto diem;
                    }
                    else return true;

                }
            }
            else
            {
                Console.WriteLine("Sinh vien nay chua dang ky mon nao!");
            }

            return true;
        }
    }
}
