using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapCNPM
{
    internal class Database
    {
        SqlConnection sqlConn;// doi tuong ket noi co so du lieu
        SqlDataAdapter da;// Bo dieu phoi du lieu
        DataSet ds;// Doi tuong chua  co so du lieu khi giao tiep
        public Database()
        {
            string strCnn = "Data Source=(local); Database=QLSinhVien; " +
                            "user id=sa;password=123456;MultipleActiveResultSets=True;";
            sqlConn = new SqlConnection(strCnn);
        }

        //Query
        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        //NonQuery
        public void ExecuteNonQuery(string strSql)
        {
            SqlCommand sqlcmd = new SqlCommand(strSql, sqlConn);
            sqlConn.Open();
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
        }
    }
}
