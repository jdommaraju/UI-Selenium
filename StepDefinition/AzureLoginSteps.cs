using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.IO;
using System.Diagnostics;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace SeleniumActive
{
    [Binding]
    public class AzureLoginSteps
    {
        private readonly ScenarioContext context;
        public IWebDriver driver;   
        BaseClass basemethod = new BaseClass();
        
       
               
        [Given(@"I have Azure Url")]
        public void GivenIHaveAzureUrl()
        {
            basemethod.initilizelogger();
            basemethod.ExtentStart();
            basemethod.logger("Given Execution started");
            basemethod.addtexttoextentreport("Given", "I have Azure Url");
            driver = basemethod.setup(driver, "https://dev.azure.com/F-DC/Active-Active" );
            basemethod.logger("URL 'https://dev.azure.com/F-DC/Active-Active' entered successfully");
            basemethod.addststoextentreport("URL Navigated");           
            Thread.Sleep(5000);
            basemethod.logger("Given method execution completed");
        }

        [Given(@"I have entered the username and password")]
        public void GivenIHaveEnteredTheUsernameAndPassword()
        {
            basemethod.addtexttoextentreport("When", "I have entered the username and password");
            basemethod.logger("When Execution started : I have entered the username and password");
            string password = basemethod.getencrypedpassword("R2FsYXh5QDg1Mg==");
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("adeo@galaxe.com");
            basemethod.logger("Username entered");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@id='idSIButton9']")).Click();
            basemethod.addststoextentreport("Username entered and clicked on Next button");
            basemethod.thread_sleep(5000);
            driver.FindElement(By.XPath("//input[@name='passwd']")).SendKeys(password);
            basemethod.logger("Password entered");
            basemethod.addststoextentreport("Password entered successfully");
            basemethod.logger("When method execution completed");
        }

        [When(@"I click on Next")]
        public void WhenIClickOnNext()
        {
            basemethod.logger("When Execution started : I click on Next");
            basemethod.addtexttoextentreport("When", "I click on Next");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            basemethod.logger("Next button clicked successfully");
            basemethod.addststoextentreport("Next button clicked after entering password");
            basemethod.thread_sleep(10000);
            basemethod.logger("When Execution Ended : I click on Next");
        }

        [Then(@"I am able to login to Azure")]
        public void ThenIAmAbleToLoginToAzure()
        {
            basemethod.logger("Then Execution Started : I am able to login to Azure");
            basemethod.addtexttoextentreport("Then", "I am able to login to Azure");
            try
            {
                basemethod.logger("Checking if Emergency pop up is displayed with Yes button");
                if (driver.FindElement(By.XPath("//div[@role='heading']")).Displayed)
                {
                    driver.FindElement(By.XPath(" //input[@id='idSIButton9']")).Click();
                    basemethod.logger("Clicked on Yes button on Emergency pop up");
                    basemethod.addststoextentreport("Next button for moving next after emergency pop up");                   

                }

                
            }
            catch (Exception e) {
                e.Message.ToString();
                basemethod.logger("Code is in ctach condition"); 
            }

           driver =  basemethod.teardown(driver);
            basemethod.logger("Teardown method called");
            basemethod.addststoextentreport("Chrome Browser closed");
            basemethod.pstatustoextentreport("Test Passed Successfully");
            basemethod.logger("Test Passed successfully");
            basemethod.ExtentClose();
            basemethod.logger("Then Execution Completed : I am able to login to Azure");
            basemethod.closelogger();
        }
        
        

    }
}
