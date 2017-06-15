//-----------------------------------------------------------------------------------------------
//<project file="Framework" type="class file">
//<description>Contains framework methods related to S3 QA Project</description>
//</project>
//-----------------------------------------------------------------------------------------------
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace S3.QA.Automation.Framework
{
    public class Framework
    {
        public static IWebDriver Driver { get; private set; }

        internal Actions Actions { get; private set; }

        public static void Launch(string browser, string testURL)
        {
            Driver = CreateDriver(browser, testURL);            
            Driver.Navigate().GoToUrl(testURL);
            System.Threading.Thread.Sleep(5000);
            Driver.Manage().Window.Maximize();
        }

        public static void Exit()
        {
            Driver.Quit();
        }

        public static IWebElement TryGetElement(By by, int maxWaitSeconds = 60)
        {
            var sleepLength = 1000;
            IWebElement element = null;
            int i = 0;
            while (element == null)
            {
                element = Driver.FindElement(@by);
                if (element != null)
                {
                    return element;
                }
                if (i == maxWaitSeconds)
                {
                    break;
                }
                i++;
                System.Threading.Thread.Sleep(sleepLength);
            }
            throw new Exception("couldn't find the element : " + @by.ToString());
        }

        public static HttpClient SetupHttpClient(string userName, string password)
        {
            var client = new HttpClient();
            if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(password))
            {
                var buffer = System.Text.Encoding.ASCII.GetBytes(userName + ":" + password);
                var authHeader = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(buffer));
                client.DefaultRequestHeaders.Authorization = authHeader;
            }
            return client;
        }

        private static IWebDriver CreateDriver(string browser, string testURL)
        {
            IWebDriver driver;
            switch (browser)
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("disable-infobars");
                    driver = new ChromeDriver(options);
                    break;
                default:
                    var IEOptions = new InternetExplorerOptions();
                    IEOptions.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Accept;
                    IEOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    IEOptions.EnablePersistentHover = true;
                    driver = new InternetExplorerDriver(IEOptions);
                    break;
            }
            return driver;
        }


    }
}
