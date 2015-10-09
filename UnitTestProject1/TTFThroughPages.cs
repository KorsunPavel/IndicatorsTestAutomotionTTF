using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestIndicatorsAutomation;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class TTFThroughPages
    {
        [TestInitialize]
        public void Init()
        {
            TTFDriver.Initialize();
        }
        [TestCleanup]
        public void Cleanup()
        {
            //TTFDriver.Clenup();
        }
        static List<Object> allAvailableDropdownValue = new List<Object>();
        static List<Object> currenDropDownsValues = new List<Object>();

        
        [TestMethod]
        
        public void TestMethod1()
        {
            TTFLoginPage.GoToByUrl("~/Indicators/Edit/244");
            //TTFLoginPage.GoToByUrl("~/Indicators/Create");
            //TTFLoginPage.LoginAs(TTFLoginPage.UserName = "user40")
            // .WithPassword("111111").Login();

            TTFIdicatorCreate.EnterValueType("Number").AggregationType("NONE").CreateNewIndicator();
            
            //TTFRandimDropdownSelect.DropDownsWorkList();
            //TTFTestPage.DropDownsWork();
        }
    }
}
