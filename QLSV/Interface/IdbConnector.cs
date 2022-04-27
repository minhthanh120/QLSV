using QLSV.DTO;
using QLSV.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Interface
{
    public interface IdbConnector
    {
        DataTable ConnectorSinhVien();
        DataTable ConnectorMonhoc(int mamon, int masv);
        DataTable ConnectorMonhocDTO(int masv);
        DataTable ConnectorDiem();
        void NhapDiem(Diem diem);
        //void LoadSinhVienDTO(ref List<SinhVienDTO> SVs);
        //void LoadSinhVien(ref List<SinhVien> SVs);
        //void LoadMonHocDTO(ref List<MonHocDTO> MonHocs, int masv);

    }
}
