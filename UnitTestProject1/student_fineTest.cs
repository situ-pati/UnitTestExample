using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Library_Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace UnitTestLibrary_Sample
{
    /// <summary>
    /// Summary description for student_fineTest
    /// </summary>
    [TestClass]
    public class student_fineTest
    {
        public const string dbpath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\confidential Project Bisu\Nadera_Project_1.0\Sample\Library_Sample\Library_Sample\bin\x86\Debug\lib_app.mdb";
        [TestMethod]
        public void AddFineTest()
        {
            student_fine sf = new student_fine();
            sf.StudentID = "101";sf.FineAmount = 5.0;
            Student s = new Student();
            Books b = new Books();
            bool res = false;
            if (s.StudentExists(sf.StudentID, dbpath))
            {
                res = sf.AddFine(sf, dbpath);
            }
            Assert.AreEqual(res, true);
        }
        public void UpdateFIneTest()
        {
            student_fine sf = new student_fine();
            DbCon con = new DbCon();
            sf.StudentID = "101"; sf.FineAmount = 5.0;
            Student s = new Student();
            Books b = new Books();
            bool res = false;
            if (s.StudentExists(sf.StudentID, dbpath))
            {
                DataRowCollection dr= con.ExecuteSelectCommand("Select fineamount from student_fine where studentID='" + sf.StudentID + "'");
                sf.FineAmount += Convert.ToDouble(dr[0].ItemArray[0].ToString());
                res = sf.updateFine(sf, dbpath);
            }
            Assert.AreEqual(res, true);
        }
		public void GetTotalFineTest()
        {
            student_fine sf = new student_fine();
            DbCon con = new DbCon();
            sf.StudentID = "101"; sf.FineAmount = 5.0;
            Student s = new Student();
            Books b = new Books();
            bool res = false;
            if (s.StudentExists(sf.StudentID, dbpath))
            {
                DataRowCollection dr= con.ExecuteSelectCommand("Select fineamount from student_fine where studentID='" + sf.StudentID + "'");
                sf.FineAmount += Convert.ToDouble(dr[0].ItemArray[0].ToString());
                res = sf.updateFine(sf, dbpath);
            }
            Assert.AreEqual(res, true);
        }
    }
}
