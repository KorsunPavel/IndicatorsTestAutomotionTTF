using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace TestIndicatorsAutomation
{
    public class Driver
    {
        public static IWebDriver Instance
        {
            get;
            internal set;
        }
        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(22));
        }
        public static void Wait(int wait)
        {
            Thread.Sleep(wait*1000);
        }


        public static void NoWait(Action action)
        {
            TurnOfWait();
            action();
            TurnOnWait();
        }

        public static void Close()
        {
            // Instance.Close();
        }

        //
        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
        //
        private static void TurnOfWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
        }
    }
}
