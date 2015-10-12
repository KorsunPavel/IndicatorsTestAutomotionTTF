using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIndicatorsAutomation;

namespace UnitTestProject1
{
    [TestClass]
    public class CreateNewIndicator
    {
       [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Can_add_new_indicator()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("testadmin")
                .WithPassword("P@ssw0rd").Login();

            Assert.IsTrue(
               HomePage.IsAt(TitlesList.EnumTitlesTopBar.Home)
                , "Failed to login");

            HomePage.GoToItem(
               TitlesList.EnumTitlesTopBar.Administration
               );

            Assert.IsTrue(
                AdministrationSection.IsAt(TitlesList.EnumAdminLeftBar.Admin_Listing)
                , "Didn't go to Administration Section");

            AdministrationSection.GoToItem(
                TitlesList.EnumAdminLeftBar.Indicators
                );

            Assert.IsTrue(
                Indicators.IsAt(TitlesList.EnumAdminLeftBar.Indicators)
                , "Didn't go to Indicators");

            Indicators.CreateInd(
                TitlesList.EnumAdminLeftBar.Indicators
                );
           // Indicators.KendoSelectByValue(Driver.Instance );





        }
        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }

    }
}
