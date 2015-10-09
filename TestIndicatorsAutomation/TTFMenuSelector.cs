using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Linq;

namespace TestIndicatorsAutomation
{
    internal class TTFMenuSelector
    {
        public static void AdminMaintaince(string pageNameString, string indicatorMaintaince)
        {
            HtmlAnchor items = null;
            pageNameString = pageNameString.Replace('_', ' ');

            if (indicatorMaintaince == "Create")
            {
                items = TTFDriver.myManager.ActiveBrowser.Find.
                ByAttributes<HtmlAnchor>("href=/" + pageNameString + "/" + indicatorMaintaince);
            }
            else
            {
                items = TTFDriver.myManager.ActiveBrowser.Find.AllByTagName<HtmlTableRow>("tr").
                Where(c => c.InnerText.Contains("AgCxCx"))
                .FirstOrDefault().Find.
                ByAttributes<HtmlAnchor>("href=~/" + pageNameString + "/" + indicatorMaintaince);
                //var items = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlAnchor>("href=~/" + pageNameString + "/" + indicatorMaintaince);
            }

            Assert.IsNotNull(items);
            items.Click();
        }
    }
}