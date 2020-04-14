using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Library_Sample
{
   public class Student
    {
        string _ID;
        string _Name;
        string _Add;
        string _Mail;
        string _Ph;
        public string StudentID
        { get { return _ID; }set { _ID = value; } }
        public string StudentName
        { get { return _Name; } set { _Name = value; } }
        public string StudentAdd
        { get { return _Add; } set { _Add = value; } }
        public string StudentMail
        { get { return _Mail; } set { _Mail = value; } }
        public string StudentPhone
        { get { return _Ph; } set { _Ph = value; } }
        public bool StudentExists(string ID, string path)
        {
            DbCon con = new DbCon(path);
            DataRowCollection dr=
            con.ExecuteSelectCommand("select * from student where studentId='" + ID + "'");
            if (dr.Count > 0)
                return true;
            else
                return false;
        }
        public int AddStudent(Student s,string path )
        {
            int res=0;
            DbCon con = new DbCon(path);
            if (StudentExists(s.StudentID,path))
            {
                res = 0;
            }
            else
            {
                string cmdstr = "insert into student values('" + s.StudentID + "','" + s.StudentName + "','" + s.StudentAdd + "','" + s.StudentMail + "','" + s.StudentPhone + "')";
                res=con.ExecuteDDLCommand(cmdstr);
            }
            return res;
        }
        public int DeleteStudent(string ID,string path)
        {
            int res = 0;
            DbCon con = new DbCon(path);
            if (StudentExists(ID, path))
            {
                res = 0;
            }
            else
            {
                string cmdstr = "Delete from student where studentID='" + ID + "'";
                res = con.ExecuteDDLCommand(cmdstr);
            }
            return res;
        }
        public bool searchStudentByName(string name,string path)
        {
            DbCon con = new DbCon(path);
            DataRowCollection dr =
            con.ExecuteSelectCommand("select * from student where studentName like'%" + name + "%'");
            if (dr.Count > 0)
                return true;
            else
                return false;
        }
        public bool searchStudentByAdd(string name, string path)
        {
            DbCon con = new DbCon(path);
            DataRowCollection dr =
            con.ExecuteSelectCommand("select * from student where studentAdd like'%" + name + "%'");
            if (dr.Count > 0)
                return true;
            else
                return false;
        }
        public bool searchStudentByphone(string name, string path)
        {
            DbCon con = new DbCon(path);
            DataRowCollection dr =
            con.ExecuteSelectCommand("select * from student where studentph1 like '%" + name + "%'");
            if (dr.Count > 0)
                return true;
            else
                return false;
        }
        public int EditStudent(string Old,Student New,string path)
        {
            int res = 0;
            DbCon con = new DbCon(path);
            if (StudentExists(Old, path))
            {
                res = 0;
            }
            else
            {
                string cmdstr = "update student" +
                    "set " +
                    "studentName='" + New.StudentName + "'," +
                    "studentAdd='" + New.StudentAdd + "'," +
                    "studentEmail='" + New.StudentMail + "'," +
                    "studentph1='" + New.StudentPhone + "' " +
                    "where studentId='" + Old + "';";
                    res = con.ExecuteDDLCommand(cmdstr);
            }
            return res;
        }
    }
}
