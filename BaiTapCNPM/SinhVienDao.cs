using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCNPM
{
    internal class SinhVienDao:Database
    {
        public DataTable LoadSV()
        {
            string load = "Select * from SINHVIEN";
           return Execute(load);
        }
        public bool Insert(SinhVien sv) {
            if (Execute("select * from SINHVIEN where MSSV = '" + sv.MSSV + "' ").Rows.Count > 0)
                return false;
            string sqlsv = string.Format("Insert Into SINHVIEN Values(N'{0}','{1}',N'{2}','{3}','{4}','{5}')",sv.HoTen,sv.Lop,sv.Khoa,sv.Email,sv.MSSV,sv.NamSinh);
            ExecuteNonQuery(sqlsv);
            return true;
        }
        public bool Delete(string xoasv)
        {
            string sqlsv = string.Format("Delete from SINHVIEN where MSSV = '"+ xoasv + "' ");
            ExecuteNonQuery(sqlsv);
            return true;
        }
        public void Update(SinhVien sv)
        {
            string sqlsv = string.Format("Update SINHVIEN set hoten = N'{0}', lop = '{1}', khoa = N'{2}',email = '{3}',namsinh = '{4}' where MSSV ='{5}'"
            ,sv.HoTen, sv.Lop, sv.Khoa, sv.Email, sv.NamSinh, sv.MSSV);
            ExecuteNonQuery(sqlsv);
        }
    }
}
