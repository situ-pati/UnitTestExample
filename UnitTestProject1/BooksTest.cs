using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library_Sample;
using System.Data;

namespace UnitTestLibrary_Sample
{
    /// <summary>
    /// Summary description for BooksTest
    /// </summary>
    [TestClass]
    public class BooksTest
    {
       public const string dbpath = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\confidential Project Bisu\Nadera_Project_1.0\Sample\Library_Sample\Library_Sample\bin\x86\Debug\lib_app.mdb";

        [TestMethod]
        public void TestBookIDExist()
        {
            Books b = new Books();
            string bookid = "15";
            b.BookIDExists(bookid, dbpath);
            Assert.AreEqual(b.BookIDExists(bookid, dbpath), true);
        }
        [TestMethod]
        public void TestAddBook()
        {
            int res = 0;
            try
            {
                Books b = new Books();
                //Add_Books a =null ;
                DbCon d = new DbCon(dbpath);
                b.AuthorAdd = "Cuttack"; b.AuthorName = "Sudipta"; b.BookID = "15"; b.BookName = "Welcome to C#";
                b.BookPafes = 150; b.BookPrice = 45.25; b.CatagoryName = "Computer"; b.PublisherAdd = "Kolkata";
                b.PublisherName = "BpB"; b.Stock = 15;


                if (b.BookIDExists(b.BookID, dbpath) == false)
                {
                    res = d.SaveBooks(b);
                }
                else
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Assert.AreEqual(res > 0, true);
        }
        [TestMethod]
        public void TestDeleteBook()
        {
            string bookid = "12";
            Books b = new Books();
            int res=b.DeleteBook(bookid, dbpath);
            Assert.AreEqual(res > 0, false);
        }
        [TestMethod]
        public void testSearchbyID()
        {
            Books b = new Books();
          Assert.AreEqual(  b.searchBookbyID("15", dbpath),true);

        }
        [TestMethod]
        public void testSearchbyName()
        {
            Books b = new Books();
            Assert.AreEqual(b.searchBookbyName("Welcome", dbpath), true);

        }
        [TestMethod]
        public void testSearchbyauthor()
        {
            Books b = new Books();
            Assert.AreEqual(b.searchBookbyAuthorName("Suchitra", dbpath), true);

        }
        [TestMethod]
        public void testSearchbyPublisher()
        {
            Books b = new Books();
            Assert.AreEqual(b.searchBookbypubname("BPB", dbpath), true);

        }
        [TestMethod]
        public void testSearchbycat()
        {
            Books b = new Books();
            Assert.AreEqual(b.searchBookbycatagory("Computer", dbpath), true);

        }
    }
    }
