using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library_Sample;
using System.Reflection;
using System.IO;

namespace UnitTestLibrary_Sample
{
    [TestClass]
    public class LoginTest
    {
        public const string dbpath= @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\confidential Project Bisu\Nadera_Project_1.0\Sample\Library_Sample\Library_Sample\bin\Debug\lib_app.mdb";
        [TestMethod]
        public void TestLoginStatus()
        {
            Login_CLass lc = new Login_CLass();
            Assert.AreEqual(lc.CheckLoginStatus("Situ", "Situ"), false);
        }
        [TestMethod]
        public void TestDbCheck()
        {
            Login_CLass lc = new Login_CLass();
            string db = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\confidential Project Bisu\Nadera_Project_1.0\Sample\Library_Sample\Library_Sample\bin\Debug\lib_app.mdb";
            Assert.AreEqual(lc.dbcheck(db), true);

        }
        
    }
}
