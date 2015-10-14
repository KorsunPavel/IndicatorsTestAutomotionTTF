using ArtOfTest.Common;
using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public class TTFIndicatorsGrid : TTFAdministrationSection
    {
        public static new void IsAt(string pageNameString)
        {
            pageNameString = pageNameString.Replace('_', ' ');
            HtmlAnchor AddNewButtom = TTFDriver.myManager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("href=/" + pageNameString + "/Create");

            Assert.IsNotNull(AddNewButtom);
        }
        public  class TTFnewIndicatorCreate
        {
            //interface creating
            public static EnterIndicatorsData EnterValueType(string typeOfIndicator)
            {
                return new EnterIndicatorsData(typeOfIndicator);
            }
            //
            public class EnterIndicatorsData
            {
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
                public void CreateIndicator()
                {
                    TTFMenuSelector.AdminMaintaince(TitlesList.EnumAdminLeftBar.Indicators.ToString(), "Create");
                    TTFAddNewIndicator.CreateNewIndicator(_valueTypeOfIndicator, _aggregationType);
                    //TTFAddNewIndicator.GetAllValuesInGridRow(_valueTypeOfIndicator);
                    //TTFAddNewIndicator.ComapreValues();
                }
            }
        }
        public  class EditClass
        {
            public static void CanEdit()
            {
                TTFMenuSelector.AdminMaintaince(TitlesList.EnumAdminLeftBar.Indicators.ToString(), "Edit");
                TTFAddNewIndicator.CreateNewIndicator("Number", "NONE");
            }
        }
        public class OrganizationForIndicator
        {
            public static void Select()
            {
                //MenuSelector.Select("menu-posts", "All Posts");
            }
        }
    }
    
   

    
}
    




