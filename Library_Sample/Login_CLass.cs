using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Library_Sample
{
    public class Login_CLass
    {
        OleDbConnection con;OleDbCommand cmd; OleDbDataAdapter adp;
        public bool CheckLoginStatus(string text1, string text2)
        {
            bool res = false;
            try
            {
                cmd = new OleDbCommand("select * from user_info where user_id='" + text1 + "'", con);
                adp = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows[0].ItemArray[1].ToString() == text2)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (Exception ex)
            {

                res = false;
            }
            return res;
        }
        public bool dbcheck(string path)
        {
            try
            {
                con = new OleDbConnection(path);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
