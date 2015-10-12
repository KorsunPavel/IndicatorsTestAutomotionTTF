using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public static class TTFRandimDropdownSelect
    {
        public static void DropDownsWorkList()
        {
            Random rnd = new Random();
            int randomNumber;
            var dropdownWrapsAll = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlSpan>("class=~dropdown-wrap");
            List<string> currentValuesOfDropdowns = new List<string>();
            List<string> defaultValuesOfDropdowns = new List<string>();
            foreach (var item in dropdownWrapsAll)
            {
                currentValuesOfDropdowns.Add(item.Find.ByTagIndex<HtmlSpan>("span", 0).TextContent);
            }
            var divWithDropdownsOptions = TTFDriver.myManager.ActiveBrowser.Find.AllByAttributes<HtmlDiv>("data-role=popup");
            foreach (var item in divWithDropdownsOptions)
            {
                defaultValuesOfDropdowns.Add(item.Find.ByTagIndex<HtmlDiv>("div", 0).TextContent);
            }

            foreach (var item in currentValuesOfDropdowns)
            {
                string el = defaultValuesOfDropdowns.Find(x => x == item); 
                if(!String.IsNullOrEmpty(el))
                {
                    int index = defaultValuesOfDropdowns.IndexOf(el);
                    int count = divWithDropdownsOptions[index].Find.AllByTagName<HtmlListItem>("li").Count;
                    randomNumber = (int)rnd.Next(0, count);
                    var a = divWithDropdownsOptions[index].Find.AllByTagName<HtmlContainerControl>("li").
                        Where(x =>x.Attributes.Single(xx => xx.Name == "data-index").Value.Contains(randomNumber.ToString())).First();
                    var  d = divWithDropdownsOptions[index].Find.ByExpression<HtmlContainerControl>("tagname=li",  "data-index=" + randomNumber.ToString());
                    d.Click();
            }
            }
        }
        }
    }



