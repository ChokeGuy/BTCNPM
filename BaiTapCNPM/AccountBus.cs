using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCNPM
{
    class AccountBus
    {
        AccountDao tk = new AccountDao();
        public bool DangNhap(string taikhoan, string matkhau)
        {
            if (tk.dangnhap(taikhoan,matkhau) == true)
                return true;
            return false;
        }
        public int Dangky(Account acc)
        {
            if(string.IsNullOrEmpty(acc.TaiKhoan) || string.IsNullOrEmpty(acc.MatKhau) || string.IsNullOrEmpty(acc.NLMatKhau))
            {
                return -1;
            }
            if (!acc.MatKhau.Equals(acc.NLMatKhau))
            {
                return -2;
            }
            else if(tk.dangky(acc) == true)
            {
                return 1;
            }
            return 0;
        }
    }
}
