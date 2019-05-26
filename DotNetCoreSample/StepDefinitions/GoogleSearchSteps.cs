using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace DotNetCoreSample.StepDefinitions
{
    [Binding]
    class GoogleSearchSteps
    {
        public IWebDriver driver;
        [Given(@"I have opened Chrome application")]
        public void GivenIHaveOpenedChromeApplication()
        {
            driver = new ChromeDriver("C:\\Users\\Experion\\Downloads\\chromedriver_win32");
            driver.Manage().Window.Maximize();
        }

        [Given(@"I have navigated to google web page")]
        public void GivenIHaveNavigatedToGoogleWebPage()
        {
            driver.Navigate().GoToUrl("http://www.google.co.in");

        }

        [When(@"I enter text ""(.*)""")]
        public void WhenIEnterText(string p0)
        {
            driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div/div[1]/div/div[1]/input")).SendKeys(p0);

        }

        [When(@"click google search button")]
        public void WhenClickGoogleSearchButton()
        {
            driver.FindElement(By.Name("btnK")).Click();

        }

        [Then(@"I am navigated to search result screen")]
        public void ThenIAmNavigatedToSearchResultScreen()
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='logo']/img"))));
                Console.WriteLine("Search result found");
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Search failed : "+e);
            }
            finally
            {
                driver.Quit();
            }
        }

    }
}
