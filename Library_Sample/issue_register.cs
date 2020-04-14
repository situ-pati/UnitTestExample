using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Sample
{
   public class issue_register
    {
        string _sid, _bid, _st;
            DateTime _idate, _rdate;
        public string StudentID
        { get { return _sid; } set { _sid = value; } }
        public string BookID
        { get { return _bid; } set { _bid = value; } }
        public DateTime IssueDate
        { get { return _idate; } set { _idate= value; } }
        public DateTime ReturnDate
        { get { return _rdate; } set { _rdate = value; } }
        public string Status
        { get { return _st; } set { _st = value; } }
        public bool IssueBook(issue_register ir,string path )
        {
            DbCon con = new DbCon(path);
            int r = con.ExecuteDDLCommand("insert into StudentIssueRegister values ('" +
                ir.StudentID + "','" + ir.BookID + "'," + ir.IssueDate + "," + ir.ReturnDate + ",'" + ir.Status + "')");
            if (r > 0)
                return true;
            else
                return false;
        }
        public bool ReturnBook(string StudID,string BookID,string path)
        {
            DbCon con = new DbCon(path);
            string cmdstr = "update StudentIssueRegister set returndate=" + DateTime.Today + ",status='return' where StudentID='" + StudID + "' and bookid='" + BookID + "'";
            int r = con.ExecuteDDLCommand(cmdstr);
            if (r > 0)
                return true;
            else
                return false;
        }
    }
}
