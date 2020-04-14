using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Library_Sample
{
    public class Books
    {
        string _BookID;
        string _BookName;
        string _pubname;
        string _pubadd;
        string _autname;
        string _autadd;
        double _bookprice;
        int _bookpages;
        string _catname;
        int _stock;
        public string BookID
        {
            get {return _BookID;}
            set{_BookID = value;}
        }
        public string BookName
        {
            get { return _BookName; }
            set { _BookName = value; }
        }
        public string PublisherName
        {
            get { return _pubname; }
            set { _pubname = value; }
        }
        public string PublisherAdd
        {
            get { return _pubadd; }
            set { _pubadd = value; }
        }
        public string AuthorName
        {
            get { return _autname; }
            set { _autname = value; }
        }
        public string AuthorAdd
        {
            get { return _autadd; }
            set { _autadd = value; }
        }
        public double BookPrice
        {
            get { return _bookprice; }
            set { _bookprice = value; }
        }
        public int BookPafes
        {
            get { return _bookpages; }
            set { _bookpages = value; }
        }
        public string CatagoryName
        {
            get { return _catname; }
            set { _catname = value; }
        }
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public bool BookIDExists(string ID, string dbpath)
        {
            bool res = true;
            try
            {
                DbCon con = new DbCon(dbpath);
                DataRowCollection ds;
                ds = con.ExecuteSelectCommand("select * from Books where BookID='" + ID + "'");
                if (ds.Count > 0)
                {
                    res = true;
                }
                else
                {
               
                    res = false;
                }

            }
            catch (Exception)
            {

                return false;
            }
            return res;
        }
            
        public int SaveBooks(Books b,string dbpath)
        {
            try
            {
                DbCon con = new DbCon(dbpath);
                string cmdstr;
                cmdstr = "insert into books values('" + b.BookID + "','" + b.BookName + "','" + b.PublisherName + "','"
                    + b.PublisherAdd + "','" + b.AuthorName + "','" + b.AuthorAdd + "'," + b.BookPrice + "," + b.BookPafes
                    + ",'" + b.CatagoryName + "'," + b.Stock + ")";

                int x = con.ExecuteDDLCommand(cmdstr);
                return (x);
            }
            catch (Exception ex)
            {
                return 0;
                //throw ex;
            }

        }
        public DataRowCollection SearchBooks(string search,string dbpath)
        {
            DbCon con = new DbCon(dbpath);
            return(con.ExecuteSelectCommand(search));

        }
        public int DeleteBook(string ID)
        {
            DbCon con = new DbCon();
            string cmdstr = "delete from Books where bookId='" + ID + "'";
            return( con.ExecuteDDLCommand(cmdstr));
        }
        public int DeleteBook(string ID,string path)
        {
            DbCon con = new DbCon(path);
            string cmdstr = "delete from Books where bookId='" + ID + "'";
            return (con.ExecuteDDLCommand(cmdstr));
        }
        public bool searchBookbyID(string id, string path)
        {
            bool res;
            DbCon con = new DbCon(path);
            DataRowCollection dr =
            con.ExecuteSelectCommand("select * from books where BookID='" + id + "'");
            if (dr.Count > 0)
            {
                res = true;
            }
            else
            { res = false; }
            return res;
        }
        public bool searchBookbyName(string id, string path)
        {
            bool res;
            DbCon con = new DbCon(path);
            DataRowCollection dr =
            con.ExecuteSelectCommand("select * from books where BookName Like '%" + id + "%'");
            if (dr.Count > 0)
            {
                res = true;
            }
            else
            { res = false; }
            return res;
        }
        public bool searchBookbyAuthorName(string id, string path)
        {
            bool res;
            DbCon con = new DbCon(path);
            DataRowCollection dr =
            con.ExecuteSelectCommand("select * from books where bookautname Like '%" + id + "%'");
            if (dr.Count > 0)
            {
                res = true;
            }
            else
            { res = false; }
            return res;
        }
        public bool searchBookbypubname(string id, string path)
        {
            bool res;
            DbCon con = new DbCon(path);
            DataRowCollection dr =
            con.ExecuteSelectCommand("select * from books where BookpubName Like '%" + id + "%'");
            if (dr.Count > 0)
            {
                res = true;
            }
            else
            { res = false; }
            return res;
        }
        public bool searchBookbycatagory(string id, string path)
        {
            bool res;
            DbCon con = new DbCon(path);
            DataRowCollection dr =
            con.ExecuteSelectCommand("select * from books where BookcatName Like '%" + id + "%'");
            if (dr.Count > 0)
            {
                res = true;
            }
            else
            { res = false; }
            return res;
        }
        public bool UpdateStock(string ID,string dbpath)
        {
            DbCon con = new DbCon();
            int k=con.ExecuteDDLCommand("UPDATE Books SET BookStock = BookStock + 1 WHERE (BookID = '" + ID + "')");
            if (k > 0)
                return true;
            else
                return false;
        }
    }
}
