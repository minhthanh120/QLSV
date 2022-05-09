using QLSV.DTO;
using QLSV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Interface
{
    public interface IDataLoader
    {
        void LoadMonHocDTO(ref List<MonHocDTO> MonHocs, int masv);
        void LoadSinhVienDTO(ref List<SinhVienDTO> SVs);
        void NhapDiem(Diem diem);
    }
}
