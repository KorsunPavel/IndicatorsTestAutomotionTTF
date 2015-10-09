using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public static class Indicators
    {
        static int a;
        public static bool IsAt(TitlesList.EnumAdminLeftBar pageName)
        {
            Driver.Wait(2);
            string pageNameString = pageName.ToString();
            pageNameString = pageNameString.Replace('_', ' ');

            var barElements = Driver.Instance.FindElements(By.ClassName("admin-inner-page-content"));
            foreach (var row in barElements)
            {
                ReadOnlyCollection<IWebElement> links = null;
                //  Driver.NoWait(() => links = row.FindElements(By.LinkText(pageName)));

                links = row.FindElements(By.PartialLinkText("Add new"));
                if (links.Count > 0)
                {
                    a = 5;
                }
            }
            return a == 5;
        }

        public static void CreateInd(TitlesList.EnumAdminLeftBar pageName)
        {
            // ReadOnlyCollection<IWebElement> topBarElements;
            Driver.Wait(2);
            /*Array enumNamesTopBar = Enum.GetNames(typeof(TitlesList.EnumTitlesTopBar));
            int pos = Array.IndexOf(enumNamesTopBar, pageName);
            if (pos > -1)
            {
                topBarElements = Driver.Instance.FindElements(By.ClassName("topbar"));
            }
            else
            {
                topBarElements = Driver.Instance.FindElements(By.ClassName("admin-left-navigation-panel"));
            }*/
     /*  var barElements = Driver.Instance.FindElements(By.ClassName("admin-inner-page-content"));
            int valueOfEnum = (int)pageName;
            // string pageNameString = Enum.GetName(typeof(TitlesList.EnumAdminLeftBar), valueOfEnum).ToString();
            string pageNameString = pageName.ToString();
            pageNameString = pageNameString.Replace('_', ' ');

            foreach (var row in barElements)
            {
                ReadOnlyCollection<IWebElement> links = null;
                //  Driver.NoWait(() => links = row.FindElements(By.LinkText(pageName)));

                links = row.FindElements(By.PartialLinkText("Add new"));
                if (links.Count > 0)
                {
                    links[0].Click();
                }

            }*/
            var link1 = Driver.Instance.FindElement(By.LinkText("Add new"));
            link1.Click();
            Driver.Wait(2);
            var inputs = Driver.Instance.FindElements(By.TagName("input"));
            inputs[0].SendKeys("Test Title");
            inputs[1].SendKeys("Test Id");
            var inputs1 = Driver.Instance.FindElement(By.CssSelector("body>div:nth-child(1)>section >div.admin-pages-content>div.admin-inner-page-content>div>form>fieldset>div:nth-child(2)>div:nth-child(8)>span.k-widget.k-dropdown.k-header.ng-pristine.ng-valid.ng-touched>span>span.k-input.ng-scope"));

            Actions action = new Actions(Driver.Instance);
                   action.MoveToElement(inputs1);
                   action.Perform();
                   action.Click();
            action.Perform();



        }
        public static void KendoSelectByValue(this IWebDriver driver, IWebElement select, string value)
        {
            var selectElement = new SelectElement(select);
            for (int i = 0; i < selectElement.Options.Count; i++)
            {
                if (selectElement.Options[i].GetAttribute("value") == value || selectElement.Options[i].GetAttribute("UFO") == value)
                {
                    var id = select.GetAttribute("id");
                    ((IJavaScriptExecutor)driver).ExecuteScript(String.Format("$('#{0}').data('kendoDropDownList').select({1});", id, i));
                    break;
                }
            }
        }

        /*  public class LeftNavigation
           {
               public class Posts
               {
                   public class AddNew
                   {
                       public static void Select()
                       {
                           MenuSelector.Select("menu-posts", "Add New");
                       }
                   }
                   public class AllPosts
                   {
                       public static void Select()
                       {
                           MenuSelector.Select("menu-posts", "All Posts");
                       }
                   }
               }
               public class Pages
               {
                   public class AddNew
                   {
                       public static void Select()
                       {
                           MenuSelector.Select("menu-pages", "Add New");
                       }
                   }
               }
          }*/



    }
}



