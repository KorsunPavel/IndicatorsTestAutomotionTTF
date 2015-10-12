using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestIndicatorsAutomation
{
    internal class TTFMenuSelector
    {
        public static void AdminMaintaince(string pageNameString, string indicatorMaintaince)
        {

            HtmlAnchor items;
            pageNameString = pageNameString.Replace('_', ' ');

           
            var tablebody = TTFDriver.myManager.ActiveBrowser.Find.AllByExpression<HtmlContainerControl>("tagname=tbody", "role=rowgroup").FirstOrDefault().Find.
                AllByExpression<HtmlTableRow>("innertext=~Number").FirstOrDefault();

            if (indicatorMaintaince == "Create")
            {
                items = TTFDriver.myManager.ActiveBrowser.Find.
                ByAttributes<HtmlAnchor>("href=/" + pageNameString + "/" + indicatorMaintaince);
            }
            else
            {
                 items = tablebody.Find.ByAttributes<HtmlAnchor>("href=~/" + pageNameString + "/" + indicatorMaintaince);
            }

             Assert.IsNotNull(items);
             items.Click();
            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            //* IsAtOnTePage
            var tabCreate = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlAnchor>(indicatorMaintaince);
            Assert.IsNotNull(tabCreate, "Create page is null");
            tabCreate.AssertAttribute().Value("class", ArtOfTest.Common.StringCompareType.Contains, "Edit" );
            tabCreate.AssertContent().TextContent(ArtOfTest.Common.StringCompareType.Same, indicatorMaintaince);

        }
    }
}