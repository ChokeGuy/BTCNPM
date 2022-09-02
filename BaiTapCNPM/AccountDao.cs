using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCNPM
{
    internal class AccountDao:Database
    {
        public bool dangnhap(string tk, string mk)
        {
            // Kiem tra tinh trang dang nhap
            if (Execute("select * from ACCOUNT where taikhoan = '" + tk + "' and matkhau = '" + mk + "' ").Rows.Count > 0)
                return true;
            return false;
        }
        public bool dangky(Account tv)
        {
            // kiem tra tai khoan da duoc tao chua, neu chua tao thi tao moi cho user
            if (Execute("select * from ACCOUNT where taikhoan= '" + tv.TaiKhoan + "'").Rows.Count > 0)
            {
                return false;
            }
            string sql = string.Format("Insert Into ACCOUNT values('{0}','{1}',{2})", tv.TaiKhoan, tv.MatKhau, 1);
            ExecuteNonQuery(sql);
            return true;
        }
    }
}
