using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Library_Sample
{
    public class DbCon
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataAdapter adp;
        //DataSet ds;
        public DbCon()
        {
            con= new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + Application.StartupPath + "\\lib_app.mdb");
        }
        public DbCon(string path)
        {
            con = new OleDbConnection(path);
        }
        public DataRowCollection ExecuteSelectCommand(string str)
        {
            try
            {
               
                cmd = new OleDbCommand(str, con);
                adp = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                int x = adp.Fill(ds);
                return ds.Tables[0].Rows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }
        public int  ExecuteDDLCommand(string str)
        {
            con.Open();
            cmd = new OleDbCommand(str, con);
            con.Close();
            return (cmd.ExecuteNonQuery());
            
        }
        public int SaveBooks(Books b)
        {
            try
            {
                con.Open();
                string cmdstr;
                cmdstr = "insert into books values('" + b.BookID + "','" + b.BookName + "','" + b.PublisherName + "','"
                    + b.PublisherAdd + "','" + b.AuthorName + "','" + b.AuthorAdd + "'," + b.BookPrice + "," + b.BookPafes
                    + ",'" + b.CatagoryName + "'," + b.Stock + ")";
                cmd = new OleDbCommand(cmdstr, con);
                int x = cmd.ExecuteNonQuery();
                con.Close();
                return (x);
            }
            catch (Exception ex)
            {
                return 0;
                //throw ex;
            }
            
        }
        
    }
}
