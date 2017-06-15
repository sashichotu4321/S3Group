//-----------------------------------------------------------------------------------------------
//<project file="S3APISteps" type="step definition file">
//<description>Contains specflow step defitions related to S3 QA Project for API's</description>
//</project>
//-----------------------------------------------------------------------------------------------
using TechTalk.SpecFlow;
using System.Net.Http;
using S3.QA.Automation.Framework;
using NUnit.Framework;

namespace S3.QA.Automation.StepDef
{
    [Binding]
    public class S3APISteps : Framework.Framework
    {
        private HttpClient client;
        private readonly ProjectModel _projectTestModel = new ProjectModel();
        private HttpResponseMessage _responseContent;

        [Given(@"the (.*) service is up and running")]
        public void GivenTheServiceIsUpAndRunning(string apiURL)
        {
            client = SetupHttpClient(_projectTestModel.UserName, _projectTestModel.Password);
        }
        
        [When(@"the client gets all projects for a given (.*)")]
        public void WhenTheClientGetsAllProjectsForAGiven(string apiURI)
        {
            _responseContent = client.GetAsync(apiURI).Result;

        }
        
        [Then(@"a (.*) (.*) should be returned")]
        public void ThenAShouldBeReturned(string expectedValue, string property)
        {
            var actualValue = _responseContent.GetType().GetProperty(property).GetValue(_responseContent, null);
            Assert.AreEqual(expectedValue, actualValue.ToString());
        }        
    }
}
