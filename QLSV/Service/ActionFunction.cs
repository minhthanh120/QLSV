using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Data;
using QLSV.DTO;
using QLSV.Interface;
using QLSV.Models;

namespace QLSV.Service
{
    internal class ActionFunction
    {
        public List<SinhVienDTO> _SVs = new List<SinhVienDTO>();
        List<MonHocDTO> _MHs = new List<MonHocDTO>();
        SinhVienDTO _sv = new SinhVienDTO();
        MonHocDTO _mh = new MonHocDTO();
        //public hbnConnector _dl;
        public IDataLoader _dl;
        public ActionFunction() { }
        public ActionFunction(IDataLoader dl)=>this._dl = dl;// Setter injection

        //Tìm sinh viên theo mã sinh viên
        SinhVienDTO TimkiemSV()
        {
            try
            {
            nhapma:
                int input = int.Parse(Input("Moi nhap ma sinh vien"));
                if (_SVs.Exists(s => s.MaSV == input) != true)
                {
                    Console.WriteLine("Khong co sinh vien nay!");
                    goto nhapma;
                }

                return _SVs.Find(s => s.MaSV == input);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }

        }
        //Tìm kiếm môn học theo mã môn
        MonHocDTO TimkiemMH()
        {
            try
            {
            nhapma:
                int input = int.Parse(Input("Moi nhap ma mon hoc"));
                if (_sv.MonHocDTOs.Exists(s => s.MaMH == input) != true)
                {
                    Console.WriteLine("Sinh vien Khong dang ky mon hoc nay!");
                    goto nhapma;
                }

                return _sv.MonHocDTOs.Find(s => s.MaMH == input);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
        }
        //Chức năng hiển trị danh sách sinh viên
        public bool MenuDanhsach()
        {
            try
            {
                _SVs.Clear(); //clear dữ liệu cũ
                 _dl.LoadSinhVienDTO(ref _SVs); //load dữ liệu mới
                if (_SVs.Count() > 0)
                {
                    AlignmentSinhVien();
                    foreach (SinhVienDTO s in _SVs)
                    {
                        s.Info();
                    }
                }
                else
                    Console.WriteLine("Chua khoi tao danh sach sinh vien");
                return ConstParamemter.Continue();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }


        }
        //Chức năng nhập điểm
        public bool MenuNhapDiem()
        {
            try
            {
                _SVs.Clear();////clear dữ liễu cũ
                _dl.LoadSinhVienDTO(ref _SVs);//load dữ liệu mới
                if (_sv != null)
                {
                    _sv = TimkiemSV();
                    if (_sv != null)
                    {
                        nhapdiem:
                        AlignmentSinhVien();
                        _sv.Info();
                        _dl.LoadMonHocDTO(ref _MHs, _sv.MaSV);
                        _sv.MonHocDTOs = _MHs;
                        if (_sv.MonHocDTOs.Count() == 0 || _sv.MonHocDTOs == null)
                        {
                            Console.WriteLine("Sinh vien nay chua dang ky mon hoc nao!");
                        }
                        else
                        {
                            AlignmentMonHoc();
                            foreach (MonHocDTO mh in _sv.MonHocDTOs)
                            {
                                mh.Info();
                            }

                            NhapDiemMonHocDTO();

                            _dl.LoadMonHocDTO(ref _MHs, _sv.MaSV);
                            _sv.MonHocDTOs = _MHs;
                            AlignmentMonHoc();
                            foreach (MonHocDTO mh in _sv.MonHocDTOs)
                            {
                                mh.Info();
                            }

                            if (ConstParamemter.Continue()==true)
                            {
                                Console.Clear();
                                goto nhapdiem;
                            }    
                                
                            else
                            {
                                return false;
                            }    
                        }
                    }
                }
                else
                    Console.WriteLine("Chua khoi tao danh sach sinh vien");
                return ConstParamemter.Continue();
        }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
}
        //Chức năng hiển thị thông tin chi tiết sinh viên
        public bool MenuChitietSinhVien()
        {
            try
            {
                _SVs.Clear();
                _dl.LoadSinhVienDTO(ref _SVs);
                if (_sv != null)
                {
                    _sv = TimkiemSV();
                    if (_sv != null)
                    {
                        AlignmentSinhVien();
                        _sv.Info();
                        _dl.LoadMonHocDTO(ref _MHs, _sv.MaSV);
                        _sv.MonHocDTOs = _MHs;
                        if (_sv.MonHocDTOs.Count() == 0|| _sv.MonHocDTOs == null)
                        {
                            Console.WriteLine("Sinh vien nay chua dang ky mon hoc nao!");
                        }
                        else
                        {
                            AlignmentMonHoc();
                            foreach (MonHocDTO mh in _sv.MonHocDTOs)
                            {
                                mh.Info();
                            }
                        }   
                    }
                }
                else
                Console.WriteLine("Chua khoi tao danh sach sinh vien");
                return ConstParamemter.Continue();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }

        void AlignmentSinhVien()
        {
            Console.WriteLine("Thong tin sinh vien");
            Console.WriteLine(string.Format(ConstParamemter.alignSV, "Ma sinh vien", "Ten sinh vien", "Gioi tinh", "Ngay sinh", "Lop", "Khoa", "So mon dang ky"));
        }
        void AlignmentMonHoc()
        {
            Console.WriteLine("\n");
            Console.WriteLine(string.Format(ConstParamemter.alignMH, "Ma mon", "Ten mon hoc", "So Tiet", "Diem TP", "Diem QT", "Diem TK", "Danh gia"));
        }
        //in ra màn hình và lấy thông tin nhập từ bàn phím
        string Input(string print = "Moi nhap ma mon hoc")
        {
            Console.WriteLine(print);
            return Console.ReadLine();
        }
        //Nhập điểm vào đối tượng mh
        void NhapDiemMonHocDTO()
        {
            _mh = TimkiemMH();            
            _mh.DiemTP = double.Parse(Input("Nhap diem thanh phan cua mon " + _mh.TenMH));            
            _mh.DiemQT = double.Parse(Input("Nhap diem qua trinh cua mon " + _mh.TenMH));
            Diem diem = new Diem(_sv.MaSV,_mh);
            _dl.NhapDiem(diem);
        }
    }
}
