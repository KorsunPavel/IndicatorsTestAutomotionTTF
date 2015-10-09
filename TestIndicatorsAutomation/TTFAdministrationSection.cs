using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public class TTFAdministrationSection : TTFLoginPage
    {
        public static new void IsAt(string pageNameString)
        {
            pageNameString = pageNameString.Replace('_', ' ');

            HtmlControl barElements = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=admin-left-navigation-panel").
            Find.ByContent<HtmlControl>(pageNameString);
            //var barElements = TTFDriver.myManager.ActiveBrowser.Find.AllByContent<HtmlSpan>(pageNameString);
            Assert.IsNotNull(barElements);
        }

        public static new void GoToItem(string pageNameString)
        {
            pageNameString = pageNameString.Replace('_', ' ');

            HtmlControl barElements = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=admin-left-navigation-panel").
            Find.ByContent<HtmlControl>(pageNameString);
            barElements.Click();
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
    }
}

    

  
