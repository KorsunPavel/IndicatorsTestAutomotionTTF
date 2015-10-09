using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
   public static class AdministrationSection
    {
        static int a;
        public static bool IsAt(TitlesList.EnumAdminLeftBar pageName)
        {
            Driver.Wait(2);
            string pageNameString = pageName.ToString();
            pageNameString = pageNameString.Replace('_', ' ');

            var barElements = Driver.Instance.FindElements(By.ClassName("admin-left-navigation-panel"));
            foreach (var row in barElements)
            {
                ReadOnlyCollection<IWebElement> links = null;
                //  Driver.NoWait(() => links = row.FindElements(By.LinkText(pageName)));

                links = row.FindElements(By.LinkText(pageNameString));
                if (links.Count > 0)
                {
                    a = 5;
                }
            }
            return a == 5;
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

        /*  public static bool IsAt(string pageName )
          {
              return IsAtClass.IsAt(pageName);
          }*/

        public static void GoToItem(TitlesList.EnumAdminLeftBar pageName)
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

            var barElements = Driver.Instance.FindElements(By.ClassName("admin-left-navigation-panel"));
            int valueOfEnum = (int)pageName;
            // string pageNameString = Enum.GetName(typeof(TitlesList.EnumAdminLeftBar), valueOfEnum).ToString();
            string pageNameString = pageName.ToString();
            pageNameString = pageNameString.Replace('_',' ');

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
    

