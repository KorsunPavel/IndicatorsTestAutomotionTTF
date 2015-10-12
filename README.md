# IndicatorsTestAutomotionTTF
Test framework for Indicators 

In this solution is still available selenium project but it's been frozen for a while
So don't use IndicatorsTestAutomotionTTFSelenium project

Now the testing framework coded with Telerik Test Framework (TTF)
By this time only two tests was implemeted Log in and CreateNewIndicatorTest

For starters

Go to Telerik test framework site
1. Download framework
2. Select your project in the Solution Explorer in Visual Studio, or start a new project.
3. Right-click the References folder displayed in the solution and select 'Add Reference'.
4. Navigate to the ArtOfTest.WebAii.dll installed on your machine in your %InstallDir%\bin folder.
5. Select ArtOfTest.WebAii.dll (and ArtOfTest.Common.dll for version 2010 and older).
6. Click OK to finish adding the needed references.

Note
a) You can change your base browser in TTFDriver.cs file
    mySettings.Web.DefaultBrowser = BrowserType.Chrome; // IE, FF 
    // there is one issue with Crhome 
    // it skips logging page so if include in a test logging steps the test will fail
b) Make sure your browser has 100% default scale
c) For testing open TFFCreateNewIndictorTest.cs and in context menu click Run Test
