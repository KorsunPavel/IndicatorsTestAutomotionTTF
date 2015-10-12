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
            return new LoginCommand(userName);
        }
        //
        public class LoginCommand
        {
            private string _password;
            private readonly string _userName;
            //
            public LoginCommand(string userName)
            {
                this._userName = userName;
            }
            //
            public LoginCommand WithPassword(string password)
            {
                this._password = password;
                return this;
            }
            //
            public void Login()
            {
                HtmlInputText userfield = TTFDriver.myManager.ActiveBrowser.Find.ById<HtmlInputText>("UserName");
                userfield.Text = _userName;

                var password = TTFDriver.myManager.ActiveBrowser.Find.ById<HtmlInputPassword>("Password");
                password.Text = _password;

                TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlButton>("type=submit").Click();
            }
        }


    }
}

