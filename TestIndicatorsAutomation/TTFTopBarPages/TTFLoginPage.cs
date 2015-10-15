using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestIndicatorsAutomation
{
    public class TTFLoginPage
    {
        public static  string UserName
        {
            get; set;
        }
        public static string Password
        {
            get;
            internal set;
        }

        /*private static string userName;
public static string UserName
{
   get
   {
       return userName;
   }
   set
   {
       userName = "testadmin";
   }
}*/
        public static void IsAt(string pageNameString)
        {
            pageNameString = pageNameString.Replace('_', ' ');

            HtmlControl barElements = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=topbar").
            Find.ByContent<HtmlControl>(pageNameString);
            //var barElements = TTFDriver.myManager.ActiveBrowser.Find.AllByContent<HtmlSpan>(pageNameString);
            Assert.IsNotNull(barElements);
        }

        public static void GoToItem(string pageNameString)
        {
            pageNameString = pageNameString.Replace('_', ' ');

            HtmlControl barElements = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=topbar").
            Find.ByContent<HtmlControl>(pageNameString);
            barElements.Click();
        }
        public static  void GoToByUrl(string adress)
        {
            TTFDriver.myManager.ActiveBrowser.NavigateTo(adress); ///AdminSectionListing
        }

        public static LoginCommand LoginAs(string userName)
        {
            LoginCommand loginData = new LoginCommand(userName);
            return loginData;
        }
        //
        public class LoginCommand
        {
            public LoginCommand(string userName)
            {
                UserName = userName;
            }
            //
            public LoginCommand WithPassword(string password)
            {
                Password = password;
                return this;
            }
            //
            public  void CheckTheFirstPage()
            {
                HtmlInputText id = TTFDriver.myManager.ActiveBrowser.Find.ById<HtmlInputText>("UserName");
                if (id != null)
                    Login();
                TTFMySettings.VerifyCorrectLogging(UserName, Password);
                TTFMySettings.CheckCurrenLanguage();
            }

            public  static void Login()
            {
                HtmlInputText userfield = TTFDriver.myManager.ActiveBrowser.Find.ById<HtmlInputText>("UserName");
                userfield.Text = UserName;

                var passwordfield = TTFDriver.myManager.ActiveBrowser.Find.ById<HtmlInputPassword>("Password");
                passwordfield.Text = Password;

                TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlButton>("type=submit").Click();
            }
        }
    }
}

