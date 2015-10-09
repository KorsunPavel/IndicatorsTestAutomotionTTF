using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public class TTFIndicatorsGrid : TTFAdministrationSection
    {
        public  class AddNew
        {
            public static void Select(string gridName)
            {
                TTFMenuSelector.AdminMaintaince(gridName, "Create");
                TTFAddNewIndicator.CreateNewIndicator();
            }
        }
        public class Edit
        {
            public static void Select(string gridName)
            {
                TTFMenuSelector.AdminMaintaince(gridName, "Edit");
                TTFAddNewIndicator.CreateNewIndicator();

                // TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlButton>("type=submit").Click();
                var title = "AgCxCx";

                HtmlFindExpression exp = new HtmlFindExpression("TagName=h2", "InnerText="+title);
                var tagname = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlContainerControl>(exp);
                tagname.AssertContent().InnerText(ArtOfTest.Common.StringCompareType.Contains, "AgCxCx");
               
                //TTFDriver.myManager.ActiveBrowser.WaitForElement(exp, 10000, false);
               


                var sbbb = TTFDriver.myManager.ActiveBrowser.Find.AllByTagName<HtmlContainerControl>("h2").
                Where(c=> c.InnerText.Contains(title)).FirstOrDefault();
     
                Assert.IsNotNull(sbbb, "Ups!! I did it again");

                /*HtmlAnchor textArea =  TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlControl>("class=~nav-tabs").
                Find.ByContent<HtmlAnchor>("p:Edit");
                
                
                
                HtmlWait textAreaWaitObj = textArea.Wait;
                // Wait 30 seconds for the HtmlTextArea element to contain the text "Now is the time"
                textArea.Wait.ForCondition(textAreaContainsStr, false, "Edit", 30000);*/

                TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=/Indicators").Click();

                TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=/Indicators").Click();
            }
                public static bool textAreaContainsStr(ArtOfTest.WebAii.Controls.Control ctl, Object obj)
                        {
                // Do some basic parameter checking
                if (false == ctl is HtmlAnchor)
                {
                    throw new ArgumentException("Passed in control is not a HtmlTextArea");
                }
                if (false == obj is string)
                {
                    throw new ArgumentException("Pass in object is not a string");
                }

                HtmlAnchor textArea = (HtmlAnchor)ctl;
                
                return textArea.AssertContent().InnerText(ArtOfTest.Common.StringCompareType.Contains, (string)obj); 
                }
        }
        
        public class OrganizationForIndicator
        {
            public static void Select()
            {
                //MenuSelector.Select("menu-posts", "All Posts");
            }
        }

        public static new void IsAt(string pageNameString)
        {
            pageNameString = pageNameString.Replace('_', ' ');
            HtmlAnchor AddNewButtom = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=/" + pageNameString + "/Create");

            Assert.IsNotNull(AddNewButtom);
        }
    }
}



