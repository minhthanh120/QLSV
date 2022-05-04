using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    public class ConstParamemter
    {
        public static string alignMH="|{0,-8}|{1,-30}|{2,-10}|{3,-7}|{4,-7}|{5,-7}|{6,-8}|";
        public static string alignSV="|{0,-12}|{1,-18}|{2,-9}|{3,-20}|{4,-4}|{5,-5}|{6,-15}|";
        //Lựa chọn tiếp tục hay ở lại chức năng đang sử dụng
        public static bool Continue(string output = "Ban co muon tiep tuc (y/n)?")
        {
            Console.WriteLine(output);
            string result = Console.ReadLine();
            if (result == "y")
                return true;
            return false;
        }
        public static string connector = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
        public static double diemtb = 4;
    }
}

