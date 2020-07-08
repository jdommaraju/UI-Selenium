using System;
using TechTalk.SpecFlow;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SeleniumActive
{
    public class Class1
    {
        [Test]

        public void Azuelogin() {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://dev.azure.com/F-DC/Active-Active";
            var encoded_pasword = Convert.FromBase64String("R2FsYXh5QDg1Mg==");
            string decodedpassword = Encoding.UTF8.GetString(encoded_pasword);
            driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("adeo@galaxe.com");
            driver.FindElement(By.XPath("//input[@type='email']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.FindElement(By.XPath("//input[@name='passwd']")).SendKeys(decodedpassword);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            


        }
    }
}
