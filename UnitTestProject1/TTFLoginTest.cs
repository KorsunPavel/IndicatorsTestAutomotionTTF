using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestIndicatorsAutomation;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Text;
using System.Threading;
using System.Drawing;
using ArtOfTest.WebAii.TestTemplates;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class TTFLoginTest
    {
        [TestInitialize]
        public void Init()
        {
            TTFDriver.Initialize();
        }
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            TTFLoginPage.GoToByUrl("~"); 
            TTFLoginPage.LoginAs(TTFLoginPage.UserName="testadmin")
                .WithPassword("P@ssw0rd").Login();
            TTFHomePage.IsAt(TitlesList.EnumTitlesTopBar.Home.ToString());
            TTFLoginPage.GoToByUrl("~/MySettings");
            Assert.IsTrue(
              TTFMySettings.VerifyCorrectLoggining(TTFLoginPage.UserName)
                , "MySettings page broken");
            //***************************************************

            /*

                        Assert.AreEqual("Home", TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("l:Home").InnerText);
                        TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("l:Administration").Click();
                        TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=/Indicators").Click();

                        // *********Creating of the Number type indicator**********
                        //  Go to a new indicator page 
                        TTFDriver.myManager.ActiveBrowser.Find.ByXPath<HtmlControl>("//p/a/span[2]").Click();

                        //* Create tab checking
                        TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlAnchor>("TextContent=Create");
                        //1. Title filling 
                        var title = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlInputText>("type=text");
                        title[0].Text = "Title1";

                        //	* Store the title in variable _title for further testing
                        //2. Id adding
                        title[1].Text = "IDDD";

                        //3. Description adding
                        var textArea = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlTextArea>("placeholder=Enter Indicator description in  English");
                        textArea.Text = "This indictor was created with Teleric Test Framework";

                        //	4. Category select (Zn emission)
                        //* Store the previous Category choice in the _category variable for further testing
                        var previousCategory = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Select category");
                        previousCategory.Click();

                        Thread.Sleep(1000);
                        int x = previousCategory.GetRectangle().X;
                        int y = previousCategory.GetRectangle().Y;

                        TTFDriver.myManager.Desktop.Mouse.Click(MouseClickType.LeftClick, x + 50, y + 100);
                        TTFDriver.myManager.ActiveBrowser.RefreshDomTree();

                        //* Store the new Category choice in the _category variable for further testing
                        var newCategory = TTFDriver.myManager.ActiveBrowser.Find.ByXPath<HtmlSpan>("/html/body/div[1]/section/div[2]/div[2]/div/form/fieldset/div[2]/div[8]/span[1]/span/span[1]");

                        //* Verify that new value doesn't equal the previous one, 
                        Assert.AreNotEqual(newCategory.TextContent, previousCategory.TextContent, " Category select failed");

                        //5. Indicator type selecting (Primary)
                        //* Primary is default so make radio-button checking, must be true
                        HtmlInputRadioButton radioPrimapry2 = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlControl>("Primary").
                        Find.ByAttributes<HtmlInputRadioButton>("type=radio");

                        HtmlInputRadioButton radioCalculated = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlControl>("Calculated").
                        Find.ByAttributes<HtmlInputRadioButton>("type=radio");

                        //* Store the name of label in the _indicator_type variable for further testing	
                        try
                        {
                            if (radioPrimapry2.Checked && !radioCalculated.Checked)
                            {
                                radioButtonIndicatorType = "Primary";
                            }
                            else
                            {
                                radioButtonIndicatorType = "Calculated";
                            }
                        }
                        catch
                        {
                            throw new Exception("Indicator type radiobuttons are failed");
                        }

                        //6. Value type selecting (Number)
                        //* Number type is Primary and set as default so just value type checking
                        try
                        {
                            previousValueType = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Number");
                        }
                        catch
                        {
                            throw new Exception("default value type is not a number or value type dropdown damaged");
                        }

                        //7. Aggregation type selecting (None)
                        var previousAggregationType = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Select aggregation type");
                        previousAggregationType.ScrollToVisible();
                        //previousAggregationType.Capture("56482dot");

                        TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
                        previousAggregationType.Click();
                        Thread.Sleep(1000);
                        x = previousAggregationType.GetRectangle().X;
                        y = previousAggregationType.GetRectangle().Y;

                        TTFDriver.myManager.Desktop.Mouse.Click(MouseClickType.LeftClick, x + 50, y + 85);
                        TTFDriver.myManager.ActiveBrowser.RefreshDomTree();

                        //* Store the new Aggregation type (None) in the _category variable for further testing
                        var newAggregationType = TTFDriver.myManager.ActiveBrowser.Find.ByXPath<HtmlSpan>("/html/body/div[1]/section/div[2]/div[2]/div/form/fieldset/div[3]/div[2]/span[1]/span/span[1]");

                        //* Verify that new value doesn't equal the previous one, 
                        Assert.AreNotEqual(newAggregationType, previousAggregationType.TextContent, " Aggregation type select failed");
                        //* Verify the aggregation type is None
                        Assert.AreEqual(newAggregationType.TextContent, "NONE", "Aggregation type is note 'NONE'");

                        //8. Active check-box checking (must be true)
                        // find active checkbox>assert
                        var checkboxes = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlInputCheckBox>("type=checkbox");
                        //* Check the check-box status if it's true put the value "active" in the  _active_staus variable 
                        Assert.IsTrue(checkboxes[0].Checked, "Active checkbox is unchecked");
                        if (checkboxes[0].Checked) newIndicatorActiveStaus = "active";
                        Assert.IsFalse(checkboxes[1].Checked);
                        Assert.IsFalse(checkboxes[2].Checked);


                        //9. Value unit selecting
                        var previousValueUnit = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Select Value Unit");
                        previousValueUnit.ScrollToVisible();

                        previousValueUnit.Click();
                        Thread.Sleep(1000);
                        x = previousValueUnit.GetRectangle().X;
                        y = previousValueUnit.GetRectangle().Y;

                        TTFDriver.myManager.Desktop.Mouse.Click(MouseClickType.LeftClick, x + 50, y + 85);
                        TTFDriver.myManager.ActiveBrowser.RefreshDomTree();

                        //* Store the value unit choice in the  newValueUnit variable for further testing
                        var newValueUnit = TTFDriver.myManager.ActiveBrowser.Find.ByXPath<HtmlSpan>("/html/body/div[1]/section/div[2]/div[2]/div/form/fieldset/div[4]/div[4]/span[1]/span/span[1]");

                        //* Verify that current value doesn't equal to previous one
                        Assert.AreNotEqual(newValueUnit.TextContent, previousValueUnit.TextContent, " Value unit selecting was failed");

                        //10. Order number choice
                        var currentOrderNumber = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
                        //HTMLFindExpression expr = new HTMLFindExpression("id=bar", "|", "tagindex=td:0", "|", "tagname=img", "src=~png");
                        Find.ByAttributes<HtmlInputText>("type=text");

                        int currentOrderNumberInt;
                        bool res = int.TryParse(currentOrderNumber.Text, out currentOrderNumberInt);
                        if (res == false)
                        {
                            throw new Exception("Order number is not a number");
                        }

                        var increaseOrderNumber = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
                        Find.ByAttributes<HtmlSpan>("title=Increase value");
                        //var increaseOrderNumber = TTFDriver.myManager.ActiveBrowser.Find.ByXPath<HtmlSpan>("/html/body/div[1]/section/div[2]/div[2]/div/form/fieldset/div[4]/div[6]/span[1]/span/span/span[1]/span");
                        /*x = increaseOrderNumber.GetRectangle().X;
                        y = increaseOrderNumber.GetRectangle().Y;
                        TTFDriver.myManager.Desktop.Mouse.Click(MouseClickType.LeftClick, x,y*/
            /*        increaseOrderNumber.MouseClick();

                      //* Store the current value  in the  _order_number variable for further testing
                      var newOrderNumber = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
                      Find.ByAttributes<HtmlInputText>("type=text");
                      int newOrderNumberInt;
                      bool res1 = int.TryParse(currentOrderNumber.Text, out newOrderNumberInt);
                      if (res1 == false)
                      {
                          throw new Exception("Order number is not a number");
                      }

                      //* Verify that current value doesn't equal to previous one
                      Assert.AreNotEqual(currentOrderNumberInt, newOrderNumberInt, "Increase order number doesn't work");

                      //11. Saving
                      TTFDriver.myManager.ActiveBrowser.AutoWaitUntilReady = true;
                      TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlButton>("type=submit").Click();

                      //* Redirecting to the Indicator grid checking
                      TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=/Indicators").Click();

                      var newIndicatorRow = TTFDriver.myManager.ActiveBrowser.Find.AllByTagName<HtmlTableRow>("tr").
                          Where(c => c.InnerText.Contains("Title1"));
                      var bz1 = newIndicatorRow.FirstOrDefault().Find.ByContent<HtmlControl>("Number", FindContentType.TextContent);
                      Assert.IsNotNull(bz1, "is absent");
                      var bz2 = newIndicatorRow.FirstOrDefault().Find.ByContent<HtmlControl>("Zn emission", FindContentType.TextContent);
                      Assert.IsNotNull(bz2, "is absent");*/
        }
        [TestCleanup]
        public void Cleanup()
        {
            TTFDriver.Clenup();
        }
        
    }
}
