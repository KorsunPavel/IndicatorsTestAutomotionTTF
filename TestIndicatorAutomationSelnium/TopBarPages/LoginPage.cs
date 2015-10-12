using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public class LoginPage
    {
        
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://test-indicators.azurewebsites.net");
            // waiting for a focus in UserName input field
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "UserName");
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
        //
        public class LoginCommand
        {
            private  string _password;
            private readonly string   _userName;
            //
            public LoginCommand(string userName)
            {
                this._userName = userName;
            }
            //
            public LoginCommand  WithPassword(string password)
            {
                this._password = password;
                return this;
            }
            //
            public void Login()
            {
                var loginInput = Driver.Instance.FindElement(By.Id("UserName"));
                loginInput.SendKeys(_userName);

                var passwordInput = Driver.Instance.FindElement(By.Id("Password"));
                passwordInput.SendKeys(_password);

                var loginButton = Driver.Instance.FindElement(By.ClassName("button"));
                loginButton.Click();


            }
        }


    }
}
