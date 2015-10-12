using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestIndicatorsAutomation;
using ArtOfTest.WebAii.Core;

namespace UnitTestProject1
{
  


    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Admin_User_Can_Login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("testadmin")
                .WithPassword("P@ssw0rd").Login();
            Assert.IsTrue(
               HomePage.IsAt(TitlesList.EnumTitlesTopBar.Home)
                , "Failed to login");
        }
        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
