using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public  class TTFCreatingIndicatorAssistant
    {
        static List<string> currentValuesOfDropdowns;
        static List<string> defaultValuesOfDropdowns;
        public static void ListsCreating()
        {
            currentValuesOfDropdowns = new List<string>();
            defaultValuesOfDropdowns = new List<string>();

            var divWithDropdownsOptions = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlDiv>("data-role=popup");
                foreach (var item in divWithDropdownsOptions)
            {
                defaultValuesOfDropdowns.Add(item.Find.ByTagIndex<HtmlDiv>("div", 0).TextContent);
                var activeListItem = item.Find.ByExpression<HtmlContainerControl>("tagname=li", "id=+");
                if (activeListItem == null)
                {
                    currentValuesOfDropdowns.Add(item.Find.ByAttributes<HtmlDiv>("class=~k-list-optionlabel").TextContent);
                }
                else
                {
                    currentValuesOfDropdowns.Add(activeListItem.TextContent);
                }
            }
        }
        //public static string CurrentDropdownValuGet1(int index)//inactive
        //{
        //    var dropdownWrapsAll = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~dropdown-wrap");

        //    return dropdownWrapsAll[index].Find.ByTagIndex<HtmlSpan>("span", 0).TextContent;
        //}

        public static string CurrentDropdownValuGet(int index)
        {
            var divWithDropdownsOptions = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlDiv>("data-role=popup");
            var activeListItem = divWithDropdownsOptions[index].Find.ByExpression<HtmlContainerControl>("tagname=li", "id=+");
            if (activeListItem == null)
            {
                return divWithDropdownsOptions[index].Find.ByAttributes<HtmlDiv>("class=~k-list-optionlabel").TextContent;
            }
            return activeListItem.TextContent;
        }
        public static List<string> SelectDropdownsValue(string aggregationType, string ValueTypes)
        {
           
            ListsCreating();
            List<string> parametrsPassed = new List<string>();
            parametrsPassed.Add(aggregationType);
            parametrsPassed.Add(ValueTypes);
            
            foreach (var item in currentValuesOfDropdowns)
            {
                bool param =  parametrsPassed.Contains(item);
                if (!param)
                {
                    int index = currentValuesOfDropdowns.IndexOf(item);
                    DoSelecting(index);
                }
            }
            NewValuesCheck(aggregationType, ValueTypes);
            currentValuesOfDropdowns.Remove(aggregationType);
            return currentValuesOfDropdowns;
        }
        
        public static void NewValuesCheck( string aggregationType, string ValueTypes)
        {
            currentValuesOfDropdowns.Clear();
            defaultValuesOfDropdowns.Clear();
            ListsCreating();
            if (currentValuesOfDropdowns.Contains(ValueTypes) &&
                currentValuesOfDropdowns.Contains(aggregationType)  )
                    {
                        foreach (var item in currentValuesOfDropdowns)
                        {
                            if (defaultValuesOfDropdowns.Contains(item))
                            throw new Exception("Creating on Number indicator was failed");
                        }
                }
            else throw new Exception("Creating on Number indicator was failed 222");
        }
        public static void DoSelecting(int index)
        {
            Random rnd = new Random();
            var divWithDropdownsOptions = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlDiv>("data-role=popup");
            int count = divWithDropdownsOptions[index].Find.AllByTagName<HtmlListItem>("li").Count;
            int randomNumber = (int)rnd.Next(0, count);
            switch (index)
            {
                case 0:
                var d = divWithDropdownsOptions[index].Find.ByExpression<HtmlContainerControl>("tagname=li", "data-index=" + randomNumber.ToString());
                d.Click();
                break;
                case 3:
                var aa = divWithDropdownsOptions[index].Find.ByExpression<HtmlContainerControl>("tagname=li", "textcontent=Number");
                aa.Click();
                break;
                case 2:
                var ss = divWithDropdownsOptions[index].Find.ByExpression<HtmlContainerControl>("tagname=li", "textcontent=NONE");
                ss.Click();
                break;
                case 1:
                var dd = divWithDropdownsOptions[index].Find.ByExpression<HtmlContainerControl>("tagname=li", "data-index=" + randomNumber.ToString());
                dd.Click();
                break;
                default:
                break;
            }
        }
    }
}
