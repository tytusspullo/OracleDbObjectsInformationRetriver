using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test2019;
using System.Windows.Forms;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestLoginPassword()
        {
            ConnectionData cnData = new ConnectionData();
            DbColumns model = new DbColumns(cnData);
            FrmMain view = new FrmMain();
            Controller controler = new Controller(view, model, false); //we dont want spam messeges during tests

            //to long //max 30
            view.User = "0123456789012345678901234567890123456789"; 
            view.Password = "0123456789012345678901234567890123456789";
            Assert.AreEqual(false, controler.ValidateLoginPassword());
            //empty
            view.User = "";
            view.Password = "";
            Assert.AreEqual(false, controler.ValidateLoginPassword());
            //corect
            view.User = "DEV_DATA_1";
            view.Password = "P@ssw0rd";
            Assert.AreEqual(true, controler.ValidateLoginPassword());
        }

        [TestMethod]
        public void TestConnection()
        {
            ConnectionData cnData = new ConnectionData();
            DbColumns model = new DbColumns(cnData);
            FrmMain view = new FrmMain();
            Controller controler = new Controller(view, model, false);

            Assert.AreEqual(true, controler.TestConnection_Click());
        }

        [TestMethod]
        public void TestLoadData()
        {
            ConnectionData cnData = new ConnectionData();
            DbColumns model = new DbColumns(cnData);
            FrmMain view = new FrmMain();
            Controller controler = new Controller(view, model, false);

            Assert.AreEqual(true, controler.LoadData_Click());
        }

    }
}
