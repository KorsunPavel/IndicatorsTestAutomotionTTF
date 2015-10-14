using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestIndicatorsAutomation;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Text;
using System.Threading;
using System.Drawing;
using ArtOfTest.WebAii.TestTemplates;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class TTFLoginTest
    {
        [TestInitialize]
        public void Init()
        {
            TTFDriver.Initialize();
        }
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            TTFLoginPage.GoToByUrl("~"); 

            TTFLoginPage.LoginAs(TTFLoginPage.UserName="testadmin")
                .WithPassword("P@ssw0rd").Login();
            TTFHomePage.IsAt(TitlesList.EnumTitlesTopBar.Home.ToString());
            TTFLoginPage.GoToByUrl("~/MySettings");
            Assert.IsTrue(
              TTFMySettings.VerifyCorrectLoggining(TTFLoginPage.UserName)
                , "MySettings page broken");
        }
        [TestCleanup]
        public void Cleanup()
        {
            TTFDriver.Clenup();
        }
        
    }
}
