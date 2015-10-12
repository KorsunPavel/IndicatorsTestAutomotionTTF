using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndicatorsAutomation
{
    public static  class TitlesList
    {
        static string a;
        public enum EnumTitlesTopBar
        {
            Home,
            form,
            case_reporting,
            Administration,
        }
       
            public static string SelectTopBarPages(EnumTitlesTopBar PageName)
        {
           
            
            switch (PageName)
            {
                case EnumTitlesTopBar.Home:
                a = "Home";
                break;
                case EnumTitlesTopBar.form:
                a = "Form";
                break;
                case EnumTitlesTopBar.case_reporting:
                a = "Case Reporting";
                break;
                case EnumTitlesTopBar.Administration:
                a = "Administration";
                break;
                default:
                break;
            }
            return a;
        }

        static string b;
        public enum EnumAdminLeftBar
        {
            Admin_Listing,
            Indicators,
            categories,
            indicatorValueSources,
        }
        public static string SelectAdminPages(EnumAdminLeftBar PageName)
        {
            switch (PageName)
            {
                case EnumAdminLeftBar.Admin_Listing:
                b = "Admin Listing";
                break;
                case EnumAdminLeftBar.Indicators:
                b = "Indicators";
                break;
                case EnumAdminLeftBar.categories:
                b = "Categories";
                break;
                case EnumAdminLeftBar.indicatorValueSources:
                b = "Indicator value source";
                break;
                default:
                break;
            }
            return b;
        }
    }
}
