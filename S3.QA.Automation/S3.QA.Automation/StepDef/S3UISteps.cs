//-----------------------------------------------------------------------------------------------
//<project file="S3AUISteps" type="step definition file">
//<description>Contains specflow step defitions related to S3 QA Project for UI's</description>
//</project>
//-----------------------------------------------------------------------------------------------
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;

namespace S3.QA.Automation.StepDef
{
    [Binding]
    public class S3UISteps : Framework.Framework
    {
        private readonly By pageLabel = By.ClassName("curve");
        private string validationAttributeText { get; set; }
        [Given(@"the S3 (.*) is launched in (.*) browser")]
        public void GivenTheS3IsLaunchedInBrowser(string URL, string browser)
        {
            Launch(browser, URL);
        }
        
        [Given(@"The page is completely loaded")]
        public void GivenThePageIsCompletelyLoaded()
        {
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(50));            
        }
        
        [When(@"I validate the (.*) of home page")]
        public void WhenIValidateTheOfHomePage(string validationAttribute)
        {
           switch (validationAttribute)
            {
                case "title":
                    validationAttributeText = Driver.Title;
                    break;
            }
        }
        
        [Then(@"the title should contain (.*)")]
        public void ThenTheTitleShouldContain(string expectedText)
        {
            string attrText = validationAttributeText.ToString();
            Assert.IsTrue(attrText != null && attrText.Contains(expectedText.ToString()));
        }

        [Then(@"Exit the Application")]
        public void ThenExitTheApplication()
        {
            Exit();
        }

    }
}
