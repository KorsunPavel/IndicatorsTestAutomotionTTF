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
            // uncomment below line if you want to go to Log in page
            //TTFDriver.myManager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);

            TTFLoginPage.GoToByUrl("~"); 
            
            TTFLoginPage.LoginAs(TTFLoginPage.UserName="testadmin")
                .WithPassword("P@ssw0rd").CheckTheFirstPage();
            TTFHomePage.IsAt(TitlesList.EnumTitlesTopBar.Home.ToString());
                   }
        [TestCleanup]
        public void Cleanup()
        {
            TTFDriver.Clenup();
        }
        
    }
}
