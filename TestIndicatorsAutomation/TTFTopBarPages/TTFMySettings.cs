using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Controls.HtmlControls;
using TestIndicatorsAutomation;
using ArtOfTest.WebAii.Core;
using System.Threading;
using System.Drawing;
using ArtOfTest.WebAii.TestTemplates;

namespace TestIndicatorsAutomation
{
    public class TTFMySettings
    {
        public static bool VerifyCorrectLoggining(string userName)
        {
            // verifying the account name presence in the Mysseting page
            try
            {
                return TTFDriver.myManager.ActiveBrowser.Find.ByContent<HtmlSpan>(userName).InnerText.Equals(userName);
            }
            catch
            {
                throw new Exception("My settings page broken");
            }
            
        }
    }
}
