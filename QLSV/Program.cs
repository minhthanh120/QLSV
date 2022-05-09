using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using QLSV.DTO;
using QLSV.Service;
using QLSV.Data;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace QLSV
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var action = container.Resolve<ActionFunction>();

        //Menu chương trình
        menu:
            Console.WriteLine("___MENU___");
            Console.WriteLine("1. Danh sach sinh vien");
            Console.WriteLine("2. Thong tin sinh vien");
            Console.WriteLine("3. Nhap điem");
            Console.WriteLine("0. Thoat");
            int choose = Int32.Parse(Console.ReadLine());
            switch (choose)

            {
                
                case 0:
                    if (ConstParamemter.Continue("Ban co muon thoat? (y/n)") == false)
                        goto menu;
                    else
                    {
                        container.Dispose();
                        Environment.Exit(1);
                    }
                    break;
                //Chức năng danh sách sinh viên
                case 1:
                    Console.Clear();
                    Console.WriteLine("Danh sach sinh vien");
                    bool result1 = action.MenuDanhsach();
                    if (result1 != true)
                    {
                        container.Dispose();
                        Environment.Exit(1);
                    }

                    else
                    {
                        Console.Clear();
                        goto menu;
                    }
                    break;
                //Chức năng hiển thị chi tiết danh sách sinh viên
                case 2:
                case2:
                    Console.Clear();
                    Console.WriteLine("Chi tiet thong tin sinh vien");
                    bool result2 = action.MenuChitietSinhVien();
                    if (result2 == true)
                    {
                        Console.Clear();
                        goto case2;
                    }

                    else
                    {
                        Console.Clear();
                        goto menu;
                    }
                //Nhập điểm
                case 3:
                case3:
                    Console.Clear();
                    Console.WriteLine("Nhap diem sinh vien");
                    bool result3 = action.MenuNhapDiem();
                    if (result3 == true)
                    {
                        Console.Clear();
                        goto case3;
                    }

                    else
                    {
                        Console.Clear();
                        goto menu;
                    }
                    break;
                default:
                    Console.WriteLine("Xin moi nhap lua chon tu 1 den 3!");
                    break;

            }
            Console.ReadKey();
        }
    }
}
