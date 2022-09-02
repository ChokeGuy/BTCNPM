using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCNPM
{
    internal class SinhVienBUS
    {
       SinhVienDao svd = new SinhVienDao();
       public DataTable getList()
       {
            return svd.LoadSV();
       }
       public int Them(SinhVien sv)
        {
            if (string.IsNullOrEmpty(sv.MSSV))
                return 0;
            if (!svd.Insert(sv))
                return -1;
            return 1;
        }
        public void Xoa(string MSSV)
        {
            svd.Delete(MSSV);
        }
        public bool Sua(SinhVien sv)
        {
            if (string.IsNullOrEmpty(sv.MSSV))
                return false;
            svd.Update(sv);
            return true;
        }
    }
}
