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
    public class TTFHomePage : TTFLoginPage
    {

        public void LanguageChecker()
        {
        	
            TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=~MySettings").Click();
            if (TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlOption>("selected=selected").Text.Contains("English"))
                CheckUserName();
            TTFDriver.myManager.ActiveBrowser.Find.ByTagIndex<HtmlSelect>("select", 0).SelectByText("English");


            TTFDriver.myManager.ActiveBrowser.GoBack();
        }

        public static void CheckUserName()
        {
            Assert.IsTrue(
                TTFDriver.myManager.ActiveBrowser.Find.ByTagIndex<HtmlContainerControl>("fieldset", 0)
                .Find.ByTagIndex<HtmlDiv>("div", 1).TextContent.Contains(UserName)
                , "account name is wrong logging failed");
        }
        // three methods are inherited derived from base class: GoToItem , IsAt , GoToByUrl
    }
}


