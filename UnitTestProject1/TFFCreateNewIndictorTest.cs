using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestIndicatorsAutomation;
using ArtOfTest.WebAii.Core;

namespace UnitTestProject1
{
    [TestClass]
    public class TFFCreateNewIndictorTest
    {
        [TestInitialize]
        public void Init()
        {
            TTFDriver.Initialize();
        }
        [TestCleanup]
        public void Cleanup()
        {
            TTFDriver.Clenup();
        }
        [TestMethod]
        public void TestMethod1()
        {
          //  TTFDriver.myManager.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);
            TTFLoginPage.GoToByUrl("~");
            TTFLoginPage.LoginAs(TTFLoginPage.UserName = "user40")
              .WithPassword("111111").CheckTheFirstPage();
             TTFHomePage.IsAt(TitlesList.EnumTitlesTopBar.Home.ToString());
            //*********ErCx
            TTFHomePage.GoToItem(
               TitlesList.EnumTitlesTopBar.Administration.ToString()
               );
            TTFAdministrationSection.IsAt(TitlesList.EnumAdminLeftBar.Admin_Listing.ToString());
            TTFAdministrationSection.GoToItem(
                TitlesList.EnumAdminLeftBar.Indicators.ToString()
                );
            TTFIndicatorsGrid.IsAt(
               TitlesList.EnumAdminLeftBar.Indicators.ToString()
               );

            TTFIndicatorsGrid.TTFnewIndicatorCreate.EnterValueType("Number").AggregationType("NONE").CreateIndicator();
            TTFIndicatorsGrid.EditClass.CanEdit();

            TTFHomePage.GoToItem(
               TitlesList.EnumTitlesTopBar.Administration.ToString()
               );
        }
    }
}
