using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public static class TTFTestPage
    {
        public static void DropDownsWork()
        {
            var dropdownWrapsAll = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~dropdown-wrap");

            HtmlContainerControl[] currentValuesOfDeopdowns = new HtmlContainerControl[dropdownWrapsAll.Count];
            HtmlContainerControl[] defaultValuesOfDeopdowns = new HtmlContainerControl[dropdownWrapsAll.Count];
            //string[] currentDefaultValuesOfDeopdowns = new string[dropdownnWrapAll.Count];

            var divWithDropdownsOptions = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlDiv>("data-role=popup");

            for (int i = 0; i < dropdownWrapsAll.Count; i++)
            {
                defaultValuesOfDeopdowns[i] = divWithDropdownsOptions[i].Find.ByTagIndex<HtmlDiv>("div", 0);
                currentValuesOfDeopdowns[i] = dropdownWrapsAll[i].Find.ByTagIndex<HtmlSpan>("span", 0);
            }
            int[] countOptionsInEachDropdown = new int[divWithDropdownsOptions.Count];
            HtmlContainerControl[][] arraysWithValuesOfOptions = new HtmlContainerControl[divWithDropdownsOptions.Count][];

            for (int i = 0; i < divWithDropdownsOptions.Count; i++)
            {
                countOptionsInEachDropdown[i] = divWithDropdownsOptions[i].Find.AllByTagName<HtmlContainerControl>("li").Count;
                arraysWithValuesOfOptions[i] = new HtmlContainerControl[countOptionsInEachDropdown[i]+1];
                for (int j = 0; j < countOptionsInEachDropdown[i]+1; j++)
                {
                    arraysWithValuesOfOptions[i][j] = divWithDropdownsOptions[i].Find.ByTagIndex<HtmlContainerControl>("li", j);
                    if (j == countOptionsInEachDropdown[i])
                    {
                        arraysWithValuesOfOptions[i][j] = defaultValuesOfDeopdowns[i];
                    }
                }
            }
            Random rnd = new Random();
            int randomNumber;
            for (int i = 0; i < dropdownWrapsAll.Count; i++)
            {   
                
                
                if (currentValuesOfDeopdowns[i].TextContent == defaultValuesOfDeopdowns[i].TextContent)
                {
                    //for (int j = 0; j < arraysWithValuesOfOptions[i].Count(); j++)
                    //{
                    //    var optionValueAsCurrent = Array.Find(arraysWithValuesOfOptions[i], p => p.InnerText.Contains(currentValuesOfDeopdowns[i].TextContent));
                    //    int valueOfAtribute = int.Parse(optionValueAsCurrent.Attributes.Single(xx => xx.Name == "data-index").Value);
                        //do randomNumber = (int)rnd.Next(arraysWithValuesOfOptions[i].Count());
                        //while (randomNumber == valueOfAtribute);
                        randomNumber = (int)rnd.Next(arraysWithValuesOfOptions[i].Count());
                        var newOptionValueAsCurrent = Array.Find(arraysWithValuesOfOptions[i], p => p.Attributes.Single(xx => xx.Name == "data-index").Value.Contains(randomNumber.ToString()));
                        newOptionValueAsCurrent.Click();
                    }
                    var b = arraysWithValuesOfOptions[i].Where(x => x.TextContent.Contains("dfsd"));
                }
            }
        }
    }

