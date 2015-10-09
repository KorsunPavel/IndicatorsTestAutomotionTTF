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
using ArtOfTest.Common;

namespace TestIndicatorsAutomation
{
    public  class TTFIdicatorCreate
    {
        
        //interface creating
        public static EnterIndicatorsData EnterValueType(string typeOfIndicator)
        {
            return new EnterIndicatorsData(typeOfIndicator);
        }
        //
        public class EnterIndicatorsData
        {
            public List<string> allNewValuesList = new List<string>();
            public List<string> allNewValuesListInGrid = new List<string>();
            private string _aggregationType;
            private readonly string _valueTypeOfIndicator;
            //
            public EnterIndicatorsData(string typeOfIndicator)
            {
                this._valueTypeOfIndicator = typeOfIndicator;
            }
            //
            public EnterIndicatorsData AggregationType(string aggregationType)
            {
                this._aggregationType = aggregationType;
                return this;
            }
            // *********Creating of the Number type indicator**********
            public void CreateNewIndicator()
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

                newTitle[1].MouseClick();
                TTFDriver.myManager.Desktop.KeyBoard.TypeText(id);

                allNewValuesList.Add(titleString);

                //3. Description adding
                var textArea = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlTextArea>("placeholder=Enter Indicator description in  English");
                textArea.MouseClick(); 
                TTFDriver.myManager.Desktop.KeyBoard.TypeText("This indictor was created with Teleric Test Framework");

                // 4-7 dropdown selecting algoritm

                allNewValuesList.AddRange(TTFCreatingIndicatorAssistant.SelectDropdownsValue( _aggregationType, _valueTypeOfIndicator));

                //	4. Category select (n)
                //* Store the previous Category choice in the _category variable for further testing
                //int drodoownsCount = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlDiv>("data-role=popup").Count;
                //for (int i = 0; i < drodoownsCount; i++)
                //{
                //    string previousItem = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(i);
                //    TTFCreatingIndicatorAssistant.DoSelecting(i);
                //    string newItem = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(i);
                //    Assert.IsNotNull(previousItem);
                //    Assert.IsNotNull(newItem);
                //    Assert.AreNotEqual(previousItem, newItem, " Category select failed");

                //}

                //string previousCategory = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(0);
                //TTFCreatingIndicatorAssistant.DoSelecting(0);
                //string newCategory = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(0);

                ////* Verify that new value doesn't equal the previous one, 
                //Assert.AreNotEqual(newCategory, previousCategory, " Category select failed");

                ////* Store the new Category choice in the _category variable for further testing
                //allNewValuesList.Add(newCategory);

                //5. Indicator type selecting (Primary)
                //* Primary is default so make radio-button checking, must be true
                HtmlInputRadioButton radioPrimapry2 = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlControl>("Primary").
                Find.ByAttributes<HtmlInputRadioButton>("type=radio");

                HtmlInputRadioButton radioCalculated = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlControl>("Calculated").
                Find.ByAttributes<HtmlInputRadioButton>("type=radio");

                // Store the name of label in the _indicator_type variable for further tfaileesting
                HtmlContainerControl newIndicatorType;
                if (radioCalculated.Checked && !radioPrimapry2.Checked)
                {
                    newIndicatorType = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlContainerControl>("tagname =label", "innertext =~Calculated");
                    allNewValuesList.Add(newIndicatorType.InnerText);
                }
                if (!radioCalculated.Checked && radioPrimapry2.Checked)
                {
                    newIndicatorType = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlContainerControl>("tagname =label", "innertext =~Primary");
                    allNewValuesList.Add(newIndicatorType.InnerText);
                }
                else
                {
                    throw new Exception("Indicator type radiobuttons are failed");
                }


                ////6. Value type selecting (Number)
                ////* Number type is Primary and set as default so just value type checking
                //string previousValueType = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(3);//1
                //                                                                                   //var newValueType = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Number");
                //if (previousValueType != "Number")
                //{
                //    if (TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlAnchor>("Create") != null)
                //        throw new Exception("Default value type is broken");
                //    else
                //        TTFCreatingIndicatorAssistant.DoSelecting(3);
                //}
                //string newValueType = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(3);//1

                //Assert.IsNotNull(newValueType);
                ////Assert.AreNotEqual(newValueType, previousValueType, " Category select failed");
                //allNewValuesList.Add(newValueType);

                //7. Aggregation type selecting (None)
                //var previousAggregationType = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Select aggregation type");
                //var previousAggregationType = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~k-dropdown-wrap").ElementAt(2).Find.ByTagIndex<HtmlSpan>("span", 0);
                //string previousAggregationType = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(2);
                //TTFCreatingIndicatorAssistant.DoSelecting(2);
                //string newAggregationType = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(2);

                //Assert.IsNotNull(newAggregationType);
                //Assert.AreNotEqual(previousAggregationType, newAggregationType, " Aggregation type select failed");
                //allNewValuesList.Add(newAggregationType);

                //8. Active check-box checking (must be true)
                // find active checkbox>assert
                var checkboxes = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlInputCheckBox>("type=checkbox");
                checkboxes[0].ScrollToVisible();
                //* Check the check-box status if it's true put the value "active" in the  _active_staus variable 
                Assert.IsTrue(checkboxes[0].Checked, "Active checkbox is unchecked");
                string newIndicatorActiveStausString;
                if (checkboxes[0].Checked) newIndicatorActiveStausString = "Active";
                else newIndicatorActiveStausString = "Inactive";
                Assert.IsFalse(checkboxes[1].Checked);
                Assert.IsFalse(checkboxes[2].Checked);
                allNewValuesList.Add(newIndicatorActiveStausString);

                //9. Value unit selecting
                //var previousValueUnit = TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Select Value Unit");
                //var previousValueUnit = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~k-dropdown-wrap").ElementAt(3).Find.ByTagIndex<HtmlSpan>("span", 0);

                //string previousValueUnit = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(1);//3
                //TTFCreatingIndicatorAssistant.DoSelecting(1);
                //string newValueUnit = TTFCreatingIndicatorAssistant.CurrentDropdownValuGet(1);//3

                //Assert.IsNotNull(newValueUnit);
                //Assert.AreNotEqual(previousValueUnit, newValueUnit, " Value Unit select failed");
                //allNewValuesList.Add(newValueUnit);

                //10. Order number choice
                string valueOfAtributeCurrenOrder = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
                Find.ByExpression<HtmlInputText>("aria-valuenow=+").Attributes.Single(xx => xx.Name == "aria-valuenow").Value;

                string valueExpected = (int.Parse(valueOfAtributeCurrenOrder) + 1).ToString();

                var increaseOrderNumber = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info")
                .Find.ByAttributes<HtmlSpan>("title=Increase value");

                increaseOrderNumber.ScrollToVisible();
                increaseOrderNumber.MouseClick(MouseClickType.LeftClick, 0, 0, OffsetReference.AbsoluteCenter);
                
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

                TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").MouseClick();
                string valueOfAtributeNewNumberOrder = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlDiv>("ng-include=~additional-info").
                Find.ByExpression<HtmlInputText>("aria-valuenow=+").Attributes.Single(xx => xx.Name == "aria-valuenow").Value;
                
                allNewValuesList.Add(valueOfAtributeNewNumberOrder);
                //* Verify that current value doesn't equal to previous one
                Assert.AreNotEqual(valueOfAtributeNewNumberOrder, valueOfAtributeCurrenOrder, "the Previous order number equales the current");
                Assert.AreNotEqual(int.Parse(valueOfAtributeNewNumberOrder), int.Parse(valueOfAtributeCurrenOrder));

                //11. Saving
                TTFDriver.myManager.ActiveBrowser.AutoWaitUntilReady = true;
                 TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlButton>("type=submit").Click();
                
        HtmlFindExpression exp = new HtmlFindExpression("TagName=h2", "InnerText=" + titleString);
        TTFDriver.myManager.ActiveBrowser.WaitForElement(exp, 10000, false);

        var tagname = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlContainerControl>(exp);
        tagname.AssertContent().InnerText(ArtOfTest.Common.StringCompareType.Contains, titleString);
        
        var b7 = TTFDriver.myManager.ActiveBrowser.Find.ByExpression<HtmlAnchor>("InnerText=Edit");

        TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=/Indicators").Click();

        TTFDriver.myManager.ActiveBrowser.WaitUntilReady();
        TTFDriver.myManager.ActiveBrowser.WaitForAjax(5000);

        var newIndicatorRow = TTFDriver.myManager.ActiveBrowser.Find.AllByTagName<HtmlTableRow>("tr").
        Where(c => c.InnerText.Contains(titleString)).FirstOrDefault().Find.AllByTagName<HtmlTableCell>("td")
        .Where(c => c.InnerText !="");

        foreach (var item in newIndicatorRow)
        {
             allNewValuesListInGrid.Add(item.InnerText);
        }
        string activeInactiveCell = TTFDriver.myManager.ActiveBrowser.Find.AllByTagName<HtmlTableRow>("tr")
        .Where(c => c.InnerText.Contains(titleString)).FirstOrDefault().Find.ByTagIndex<HtmlSpan>("span", 0).Attributes.Single(x => x.Name == "title").Value;
        var activeInactiveCell2 = TTFDriver.myManager.ActiveBrowser.Find.AllByTagName<HtmlTableRow>("tr")
        .Where(c => c.InnerText.Contains(titleString)).FirstOrDefault().Find.ByExpression<HtmlSpan>("title=+").Attributes.Single(x => x.Name == "title").Value;

         allNewValuesListInGrid.Add(activeInactiveCell);
         Assert.IsTrue(allNewValuesList.Count == allNewValuesListInGrid.Count, "count of elements in the compared list don't match");
         foreach (var item in allNewValuesListInGrid)
              {
                    Assert.IsTrue(allNewValuesList.Contains(item),"new values in the indicator's grid don't match with the created values");
              }
        }
    }
  }
}

