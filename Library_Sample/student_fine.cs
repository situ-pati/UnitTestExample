using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Library_Sample
{
    public class student_fine
    {
        string _id; double _fine;
        public string StudentID
        { get { return _id; } set { _id = value; } }
        public double FineAmount
        { get { return _fine; }set { _fine = value;  } }
        public bool AddFine(student_fine sf,string path)
        {
            DbCon con = new DbCon(path);
            int r=            con.ExecuteDDLCommand("insert into student_fine values('" + sf.StudentID + "'," + sf.FineAmount + ")");
            if (r > 0)
                return true;
            else
                return false;
        }
        public bool updateFine(student_fine sf,string path)
        {
            DbCon con = new DbCon(path);
            int r = con.ExecuteDDLCommand("update student_fine set fineamount=" + sf.FineAmount +" where studentID='" + sf.StudentID +"'");
            if (r > 0)
                return true;
            else
                return false;
        }
        public double getTotalFineAmount(string dbpath)
        {
            DbCon con = new DbCon(dbpath);
            DataRowCollection dr= con.ExecuteSelectCommand("select sum(fineamount) from student_fine");
            return Convert.ToDouble(dr[0].ItemArray[0]);
        }

    }
}
