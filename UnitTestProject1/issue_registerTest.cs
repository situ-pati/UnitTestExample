using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Library_Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLibrary_Sample
{
    /// <summary>
    /// Summary description for issue_registerTest
    /// </summary>
    [TestClass]
    public class issue_registerTest
    {
        public const string dbpath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\confidential Project Bisu\Nadera_Project_1.0\Sample\Library_Sample\Library_Sample\bin\x86\Debug\lib_app.mdb";
        [TestMethod]
        public void issuebookTest()
        {
            bool res = false;
            issue_register ir = new issue_register();
            ir.StudentID = "101";ir.BookID = "15";ir.IssueDate = DateTime.Today;ir.Status = "nr";
            Student s = new Student();
            Books b = new Books();
            if (s.StudentExists(ir.StudentID, dbpath) && b.BookIDExists(ir.BookID,dbpath) )
            {
              res=  ir.IssueBook(ir, dbpath);
            }
            Assert.AreEqual(res, true);
            
        }
        public void ReturnBookTest()
        {
            issue_register ir = new issue_register();
            bool res = false;
            string studID = "101", bookID = "15";
            Student s = new Student();
            Books b = new Books();
            if (s.StudentExists(studID, dbpath) && b.BookIDExists(bookID, dbpath))
            {
                res = ir.ReturnBook(studID,bookID, dbpath);
            }
            Assert.AreEqual(res, true);
        }

    }
}
