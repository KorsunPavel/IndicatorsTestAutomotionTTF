using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.TestTemplates;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.Threading;

namespace TestIndicatorsAutomation
{
    public static  class TTFDriver
    {
        static private StringBuilder verificationErrors;
        static string baseURL;
        static private bool acceptNextAlert = true;

        static Settings mySettings;
        // Manager myManager;
        static string radioButtonIndicatorType;
        static private HtmlSpan previousValueType;
        static private string newIndicatorActiveStaus;

        public static Manager myManager
        {
            get;
            internal set;
        }
        public static void Initialize()
        {
            // Initialize the settings
            mySettings = new Settings();

            // Set the default browser
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            mySettings.Web.BaseUrl = "https://test-indicators.azurewebsites.net";
            mySettings.Web.RecycleBrowser = true;

            // Create the manager object
            myManager = new Manager(mySettings);

            // Start the manager
            myManager.Start();
            myManager.LaunchNewBrowser();

            myManager.ActiveBrowser.Window.Maximize();

            /*Instance = new FirefoxDriver();
            baseURL = "https://test-indicators.azurewebsites.net/";*/
        }
        public static void Clenup()
        {
            try
            {
                myManager.ActiveBrowser.Close();
                // BaseTest.ShutDown();
            }
            catch (Exception)
            {

                // Ignore errors if unable to close the browser
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }
        /*     public static void Wait(int wait)
               {
                   Thread.Sleep(wait * 1000);
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


               */
    }
}


