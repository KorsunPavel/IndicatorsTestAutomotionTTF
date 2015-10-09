using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public static class HomePage
    {
        
        static int a;
        public static bool IsAt(TitlesList.EnumTitlesTopBar pageName)
        {
            Driver.Wait(2);
            var barElements = Driver.Instance.FindElements(By.ClassName("topbar"));
            string pageNameString = pageName.ToString();
            pageNameString = pageNameString.Replace('_', ' ');

            foreach (var row in barElements)
            {
                ReadOnlyCollection<IWebElement> links = null;
                //  Driver.NoWait(() => links = row.FindElements(By.LinkText(pageName)));

                links = row.FindElements(By.LinkText(pageNameString));
                if (links.Count > 0)
                {
                    a =5;
                }
            } return a == 5;
        }

        public static void GoToItem(TitlesList.EnumTitlesTopBar pageName)
        {
            //string pageNameTop  = TitlesList.SelectTopBarPages(pageName);
            //string pageNameLeft = TitlesList.SelectAdminPages(pageName);
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

            var barElements = Driver.Instance.FindElements(By.ClassName("topbar"));
            // int valueOfEnum = (int)pageName;
            // string pageNameString = Enum.GetName(typeof(TitlesList.EnumAdminLeftBar), valueOfEnum).ToString();
            string pageNameString = pageName.ToString();
            pageNameString = pageNameString.Replace('_', ' ');

            foreach (var row in barElements)
            {
                ReadOnlyCollection<IWebElement> links = null;
                //  Driver.NoWait(() => links = row.FindElements(By.LinkText(pageName)));

                links = row.FindElements(By.LinkText(pageNameString));
                if (links.Count > 0)
                {
                    links[0].Click();
                    /*Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    action.Click();
                    action.Perform();*/

                }

            }
        }
    }
    }
        
