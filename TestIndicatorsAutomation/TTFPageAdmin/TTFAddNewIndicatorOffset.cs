using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Controls.HtmlControls;
using TestIndicatorsAutomation;
using ArtOfTest.WebAii.Core;
using ArtOfTest;
using System.Threading;
using System.Drawing;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.Common.UnitTesting;
using WiordPressFramework;
using ArtOfTest.WebAii.ObjectModel;
using System.Collections;

namespace TestIndicatorsAutomation
{
    public class TTFAddNewIndicator
    {
        static List<Object> allNewValues = new List<Object>();

        // *********Creating of the Number type indicator**********
        public static void CreateNewIndicator()
        {
            

            //* Create tab checking
            //   var tabCreate = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlAnchor>("Create");
            //    Assert.IsNotNull(tabCreate, "Create page is null");
            //  tabCreate.AssertAttribute().Value("class", ArtOfTest.Common.StringCompareType.Contains, "edit");
            //      tabCreate.AssertContent().TextContent(ArtOfTest.Common.StringCompareType.Same, "Create");


            //1. Title filling 
            var newTitle = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlInputText>("type=text");
            //var title = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlInputText>("type=text",);
            //	* Store the title in variable _title for further testing
            newTitle[0].Text = "";
            string id;
            string titleString;
            titleString = TTFPostCreator.CreatPost(out id);
            TTFDriver.myManager.Desktop.Mouse.Click(MouseClickType.LeftClick, newTitle[0].GetRectangle());
            TTFDriver.myManager.Desktop.KeyBoard.TypeText(titleString);

            newTitle[0].Text = titleString;
            newTitle[1].Text = id;
            allNewValues.Add(newTitle[0].Text);

            //3. Description adding
            var textArea = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlTextArea>("placeholder=Enter Indicator description in  English");
            textArea.Text = "This indictor was created with Teleric Test Framework";

            //	4. Category select (n)
            //* Store the previous Category choice in the _category variable for further testing

            /*            TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("k-option-label=~-- Select category --").Wait.ForCondition(
                        (a_0, a_1) => ArtOfTest.Common.CompareUtils.StringCompare(
                        a_0.InnerText,
                        "-- Select category --",
                        ArtOfTest.Common.StringCompareType.Contains),
                        false, null, 10000);*/


            var previousCategory2 = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("k-option-label=~-- Select category --")
            .Find.ByExpression<HtmlOption>("value=32");
            var aaa = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("k-option-label=~-- Select category --");
            aaa.MouseClick(MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);

            TTFDriver.myManager.ActiveBrowser.WaitForElement(2000, previousCategory2.Value);
            previousCategory2.MouseClick(MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);

            /*
                  previousCategory2.SelectByIndex(1, true);
                 TTFDriver.myManager.ActiveBrowser.RefreshDomTree();
                 previousCategory2.Click();*/

            var previousCategory = TTFDriver.myManager.ActiveBrowser.Find.ByXPath<HtmlSpan>("/ html / body / div[1] / section / div[2] / div[2] / div / form / fieldset / div[2] / div[8] / span[1] / span / span[1]");
            previousCategory.MouseClick();

            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            //Thread.Sleep(1000);


    //        var rectangle = previousValueUnit.GetRectangle();
    //        previousValueUnit.MouseClick(MouseClickType.LeftClick, 0, 0, ArtOfTest.Common.OffsetReference.AbsoluteCenter);

            int x = previousCategory.GetRectangle().X;
            int y = previousCategory.GetRectangle().Y;

            TTFDriver.myManager.Desktop.Mouse.Click(MouseClickType.LeftClick, x + 50, y + 100);
            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            TTFDriver.myManager.ActiveBrowser.RefreshDomTree();

            var newCategory = TTFDriver.myManager.ActiveBrowser.Find.ByXPath<HtmlSpan>("/html/body/div[1]/section/div[2]/div[2]/div/form/fieldset/div[2]/div[8]/span[1]/span/span[1]");

            //* Verify that new value doesn't equal the previous one, 
            //   Assert.AreNotEqual(newCategory.TextContent, previousCategory.TextContent, " Category select failed");

            //* Store the new Category choice in the _category variable for further testing
            allNewValues.Add(newCategory);

            //5. Indicator type selecting (Primary)
            //* Primary is default so make radio-button checking, must be true
            HtmlInputRadioButton radioPrimapry2 = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlControl>("Primary").
            Find.ByAttributes<HtmlInputRadioButton>("type=radio");
           // radioPrimapry2.AssertCheck().IsTrue();

            HtmlInputRadioButton radioCalculated = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlControl>("Calculated").
            Find.ByAttributes<HtmlInputRadioButton>("type=radio");
           // radioCalculated.AssertCheck().IsFalse();

            //* Store the name of label in the _indicator_type variable for further testing	
            HtmlContainerControl newIndicatorType;
            if (radioCalculated.Checked && !radioPrimapry2.Checked)
            {
                newIndicatorType = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlContainerControl>("tagname =label", "innertext =~Calculated");
                allNewValues.Add(newIndicatorType);
            }
            if (!radioCalculated.Checked && radioPrimapry2.Checked)
            {
                newIndicatorType = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlContainerControl>("tagname =label", "innertext =~Primary");
                allNewValues.Add(newIndicatorType);
            }
            else
            {
                throw new Exception("Indicator type radiobuttons are failed");
            }


            //6. Value type selecting (Number)
            //* Number type is Primary and set as default so just value type checking
            var newValueType = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Number");
            Assert.IsNotNull(newValueType);
            allNewValues.Add(newValueType);

            //7. Aggregation type selecting (None)
            //var previousAggregationType = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Select aggregation type");
            var previousAggregationType =  TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~k-dropdown-wrap").ElementAt(2).Find.ByTagIndex<HtmlSpan>("span", 0);

            allNewValues.Add(previousAggregationType);

            previousAggregationType.ScrollToVisible();
            //previousAggregationType.Capture("56482dot");

            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            
            x = previousAggregationType.GetRectangle().X;
            y = previousAggregationType.GetRectangle().Y;

            previousAggregationType.MouseClick();
            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            //Thread.Sleep(1000);

            TTFDriver.myManager.Desktop.Mouse.Click(MouseClickType.LeftClick, x + 50, y + 85);
            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            TTFDriver.myManager.ActiveBrowser.RefreshDomTree();

            //* Store the new Aggregation type (None) in the _category variable for further testing

            var newAggregationType = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~k-dropdown-wrap").ElementAt(2).Find.ByTagIndex<HtmlSpan>("span", 0); 
            var newAggregationType1 = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes("class=~k-dropdown-wrap").ElementAt(2).GetNextSibling().ChildNodes; //Find.ByTagIndex<HtmlSpan>("span", 1); ;
            allNewValues.Add(newAggregationType);


            //* Verify that new value doesn't equal the previous one, 
         //   Assert.AreNotEqual(newAggregationType.TextContent, previousAggregationType.TextContent, " Aggregation type select failed");
            //* Verify the aggregation type is None
         //   Assert.AreEqual(newAggregationType.TextContent, "NONE", "Aggregation type is note 'NONE'");

            //8. Active check-box checking (must be true)
            // find active checkbox>assert
            var checkboxes = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlInputCheckBox>("type=checkbox");
            //* Check the check-box status if it's true put the value "active" in the  _active_staus variable 
            Assert.IsTrue(checkboxes[0].Checked, "Active checkbox is unchecked");
            string newIndicatorActiveStausString = "null";
            if (checkboxes[0].Checked) newIndicatorActiveStausString = "Active";
            else newIndicatorActiveStausString = "Inactive";
            allNewValues.Add(checkboxes[0]);
            Assert.IsFalse(checkboxes[1].Checked);
            Assert.IsFalse(checkboxes[2].Checked);


            //9. Value unit selecting
            //var previousValueUnit = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Select Value Unit");
            var previousValueUnit = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~k-dropdown-wrap").ElementAt(3).Find.ByTagIndex<HtmlSpan>("span", 0);

            

            previousValueUnit.MouseClick();
            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();

            previousValueUnit.ScrollToVisible();

            


            //Thread.Sleep(1000);
            x = previousValueUnit.GetRectangle().X;
            y = previousValueUnit.GetRectangle().Y;

            TTFDriver.myManager.Desktop.Mouse.Click(MouseClickType.LeftClick, x + 50, y + 85);
            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            TTFDriver.myManager.ActiveBrowser.RefreshDomTree();

            //* Store the value unit choice in the  newValueUnit variable for further testing
            var newValueUnit = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~k-dropdown-wrap").ElementAt(3).Find.ByTagIndex<HtmlSpan>("span", 0);
            allNewValues.Add(newValueUnit);
            //* Verify that current value doesn't equal to previous one
       // Assert.AreNotEqual(newValueUnit.TextContent, previousValueUnit.TextContent, " Value unit selecting was failed");

            //10. Order number choice
            var currentOrderNumber = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
            Find.ByExpression<HtmlInputText>("aria-valuenow=+");
            string valueOfAtributeCurrenOrder = currentOrderNumber.Attributes.Single(xx => xx.Name == "aria-valuenow").Value;
            string valueExpected = (int.Parse(valueOfAtributeCurrenOrder)+1).ToString();
            /*int currentOrderNumberInt;
            bool res = int.TryParse(currentOrderNumber.Text, out currentOrderNumberInt);
            if (res == false)
            {
                throw new Exception("Order number is not a number");
            }*/
            
            var increaseOrderNumber = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
            Find.ByAttributes<HtmlSpan>("title=Increase value");
            increaseOrderNumber.MouseClick();

            //* Store the current value  in the  _order_number variable for further testing
            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
            Find.ByExpression<HtmlInputText>("aria-valuenow=+")
            .Wait.ForCondition(
                          (a_0, a_1) => ArtOfTest.Common.CompareUtils.StringCompare(
                          a_0.Attributes.Single(xx => xx.Name == "aria-valuenow").Value,
                          valueExpected,
                          ArtOfTest.Common.StringCompareType.Contains),
                          false, null, 5000);

            var newOrderNumber = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
            Find.ByExpression<HtmlInputText>("aria-valuenow=+");
            string valueOfAtributeNewNumberOrder = newOrderNumber.Attributes.Single(xx => xx.Name == "aria-valuenow").Value;

            //Find.ByAttributes<HtmlInputText>("type=text");
            allNewValues.Add(newOrderNumber);

            /*int newOrderNumberInt;
            bool res1 = int.TryParse(currentOrderNumber.Text, out newOrderNumberInt);
            if (res1 == false)
            {
                throw new Exception("Order number is not a number");
            }*/

            //* Verify that current value doesn't equal to previous one
            Assert.AreNotEqual(valueOfAtributeNewNumberOrder, valueOfAtributeCurrenOrder, "the Previous order number equales the current");
            Assert.AreNotEqual(int.Parse(valueOfAtributeNewNumberOrder), int.Parse(valueOfAtributeCurrenOrder));
            newOrderNumber.AssertAttribute().Value("aria-valuenow", ArtOfTest.Common.StringCompareType.Exact, valueExpected);
            //Assert.AreNotEqual(currentOrderNumberInt, newOrderNumberInt, "Increase order number doesn't work");

            //11. Saving
            TTFDriver.myManager.ActiveBrowser.AutoWaitUntilReady = true;
            TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlButton>("type=submit").Click();
            // TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            // TTFDriver.myManager.ActiveBrowser.WaitForAjax(5);

            //* Redirecting to the Indicator grid checking
            //Title checking in the row

            // HtmlFindExpression exp = new HtmlFindExpression("XPath=/html/body/div[1]/section/div[2]/ul/li[1]/a");
            HtmlFindExpression exp = new HtmlFindExpression("TagName=h2", "InnerText=" + titleString);
            TTFDriver.myManager.ActiveBrowser.WaitForElement(exp, 10000, false);
            var tagname = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlContainerControl>(exp);
            tagname.AssertContent().InnerText(ArtOfTest.Common.StringCompareType.Contains, titleString);


            //TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            //TTFDriver.myManager.ActiveBrowser.WaitForAjax(5000);
            
            var a1 = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlControl>("class=~nav-tabs").
              Find.ByContent<HtmlAnchor>("p:Edit");
            var b2 = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("InnerText =~Edit", "tagname = a");
            var b1 = TTFDriver.myManager.ActiveBrowser.Find.AllByContent<HtmlAnchor>("p:Edit");
            var b3 = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("href=~/Indicators/Edit");
            var b4 = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("href=/Indicators/Edit/222");
            var b7 = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("InnerText=~Edit");
            var b5 = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlAnchor>("href=/Indicators/Edit/222");
            var b6 = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlAnchor>("href=~/Indicators/Edit");



            TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=/Indicators").Click();

            TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
            TTFDriver.myManager.ActiveBrowser.WaitForAjax(5000);

            var newIndicatorRow = TTFDriver.myManager.ActiveBrowser.Find.AllByTagName<HtmlTableRow>("tr").
               Where(c => c.InnerText.Contains(titleString));

                    //Order Number checking in the row
                    var OrderNumberInRow = newIndicatorRow.FirstOrDefault().Find.ByContent<HtmlControl>(valueExpected, FindContentType.TextContent);
            Assert.IsNotNull(OrderNumberInRow, "the order numebr is wrong");

            //Value type checking in the row
            var valueTypeInRow = newIndicatorRow.FirstOrDefault().Find.ByContent<HtmlControl>(newValueType.TextContent, FindContentType.TextContent);
            Assert.IsNotNull(valueTypeInRow, "the order numebr is wrong");
            //Value unit checking in the row

            //Category checking in the row
            var CategoryInRow = newIndicatorRow.FirstOrDefault().Find.ByContent<HtmlControl>(newCategory.TextContent, FindContentType.TextContent);
            Assert.IsNotNull(CategoryInRow, "is absent");

            //Indicator type checking in the row
            HtmlContainerControl newIndicatorTypeInRow = newIndicatorRow.FirstOrDefault().Find.ByContent<HtmlContainerControl>(newIndicatorType.TextContent, FindContentType.TextContent);
            Assert.IsNotNull(newIndicatorTypeInRow, "is absent");
            //Value unit  checking in the row
            var newValueUnitInRow = newIndicatorRow.FirstOrDefault().Find.ByContent<HtmlControl>(newValueUnit.TextContent, FindContentType.TextContent);
            Assert.IsNotNull(newValueUnitInRow, "is absent");
            //Active/Inactive status  checking in the row
            var newActiveStatus1 = newIndicatorRow.FirstOrDefault().Find.ByTagIndex<HtmlSpan>("span",0).AssertAttribute().Value("title", ArtOfTest.Common.StringCompareType.Same, newIndicatorActiveStausString);
            var newActiveStatus = newIndicatorRow.FirstOrDefault().Find.ByExpression<HtmlControl>("title=" + newIndicatorActiveStausString);
            Assert.IsNotNull(newActiveStatus, "is absent");
            var b = 0; ;

        }
    }

}
