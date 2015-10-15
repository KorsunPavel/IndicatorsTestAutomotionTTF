using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Controls.HtmlControls;
using TestIndicatorsAutomation;
using ArtOfTest.WebAii.Core;
using System.Threading;
using System.Drawing;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.Common.UnitTesting;

namespace TestIndicatorsAutomation
{
    public  class TTFMySettings
    {
        static int attempt = 0;

        public  static void VerifyCorrectLogging(string userName, string password)
        {
            TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=~MySettings").Click();
            var myProfile = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlControl>("class=my-profile");
            Assert.IsNotNull(myProfile, "Wrong link or the page broken");
            bool currentUser = myProfile.Find.ByTagIndex<HtmlDiv>("div", 1).TextContent.Contains(userName);
            if (!currentUser)
            {
                TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=~LogOff").Click();
                attempt++;
                if (attempt > 1) throw new Exception("Logging as wrong user");
                TTFLoginPage.LoginCommand.Login();
                TTFMySettings.VerifyCorrectLogging(TTFLoginPage.UserName, TTFLoginPage.Password);
            }
        }

        internal static void CheckCurrenLanguage()
        {
            bool currentLanguage = TTFDriver.myManager.ActiveBrowser.Find.ById<HtmlSelect>("CurrentLanguageId").SelectedOption.Text.Contains("English");
            if (!currentLanguage)
                TTFDriver.myManager.ActiveBrowser.Find.ById<HtmlSelect>("CurrentLanguageId").SelectByPartialText("English", true);
            TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlButton>("type=submit").Click();
        }
    }
}
