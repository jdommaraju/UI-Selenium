using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using TechTalk.SpecFlow;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Diagnostics;
using static Io.Cucumber.Messages.GherkinDocument.Types.Feature.Types;
using Serilog;

namespace SeleniumActive
{
    public class BaseClass
    {

        public ExtentTest test = null;
        public ExtentReports extent = null;
        public IWebDriver driver;
        public  IObjectContainer _objectContainer;
        public FeatureContext featureContext;
        public ScenarioContext scenarioContext;
               
        public BaseClass(IObjectContainer objectContainer, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
            _objectContainer = objectContainer;
            
        }

        public BaseClass()
        {
            
        }
        

        [BeforeTestRun, Category("smoke testing")]
        public IWebDriver setup(IWebDriver Driver, String url ) {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://dev.azure.com/F-DC/Active-Active";
            return Driver;

        }
        [AfterTestRun, Category("smoke testing")]
        public IWebDriver teardown(IWebDriver Driver) {
            Driver.Quit();
            return Driver;
        }

        public String getencrypedpassword(String encodedpasssword) 
        {
            var encoded_pasword = Convert.FromBase64String(encodedpasssword);
            string decodedpassword = Encoding.UTF8.GetString(encoded_pasword);
            return decodedpassword;
        }

        public IWebDriver wait_low(IWebDriver Driver)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return Driver;
        }

        public IWebDriver wait_medium(IWebDriver Driver)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            return Driver;
        }

        public IWebDriver wait_high(IWebDriver Driver)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            return Driver;
        }

        public void thread_sleep(int time)
        {
            Thread.Sleep(time);
            
        }

        [OneTimeSetUpAttribute]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"D:\Project\SeleniumActive\ExtentReport\Report.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        public void addtexttoextentreport(String scenario, String text) 
        {
            test = extent.CreateTest(scenario).Info(text);
        }

        public void addststoextentreport(String text)
        {
            test.Log(Status.Info, text);
        }

        public void pstatustoextentreport(String text)
        {
            test.Log(Status.Pass, text);
        }

        public void initilizelogger() 
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("D:\\Project\\SeleniumActive\\Logs\\Logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        public void logger(String text) 
        {
          Log.Information(text);
        }

        public void closelogger()
        {
            Log.CloseAndFlush();
        }

    }
}
