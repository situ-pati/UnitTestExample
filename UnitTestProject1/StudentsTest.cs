using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Library_Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLibrary_Sample
{
    /// <summary>
    /// Summary description for StudentsTest
    /// </summary>
    [TestClass]
    public class StudentsTest
    {
        public const string dbpath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\confidential Project Bisu\Nadera_Project_1.0\Sample\Library_Sample\Library_Sample\bin\x86\Debug\lib_app.mdb";

        [TestMethod]
        public void CheckStudentTest()
        {
            Student s = new Student();
            string Id = "1";
            Assert.AreEqual( s.StudentExists(Id, dbpath),true);
        }
        [TestMethod]
        public void AddStudentTest()
        {
            Student s = new Student();
            s.StudentID = "101";s.StudentName = "Adhyatmananda Pati";s.StudentAdd = "Choudwar";s.StudentMail = "xyz@gmail.com";s.StudentPhone = "1234567890";
            int r = s.AddStudent(s, dbpath);
            Assert.AreEqual(r > 0, true);
        }
        public void DeleteStudentTest()
        {
            string ID = "1";
            Student s = new Student();
            int r = s.DeleteStudent(ID, dbpath);
            Assert.AreEqual(r > 0, true);
        }
        public void EditStudentTest()
        {
            Student New = new Student();
            string oldID="1";
            New.StudentName = "Situ";New.StudentAdd = "Cuttack";New.StudentMail = "sasasa";New.StudentPhone = "45545466";
            int r=New.EditStudent(oldID, New, dbpath);
            Assert.AreEqual(r > 0, true);
        }
        public void SearchbyNameTest()
        {
            Student s = new Student();
            Assert.AreEqual(s.searchStudentByName("situ", dbpath), true);
        }
        public void SearchbyAddTest()
        {
            Student s = new Student();
            Assert.AreEqual(s.searchStudentByAdd("Choudwar", dbpath), true);
        }
        public void SearchbyphTest()
        {
            Student s = new Student();
            Assert.AreEqual(s.searchStudentByphone("4589750", dbpath), true);
        }
    }
}
