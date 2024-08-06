using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject.Pages
{
    public class Home
    {
        //public void VerifyIfUserLoggedIn(IWebDriver driver)
        //{
        //    // Wait for 10 seconds
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //    // Identify the user greeting element
        //    IWebElement userGreeting = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        //    // Verify if userGreeting is equal to "Hello UserName!"

        //    if (userGreeting.Text == "Hello hari!")
        //    {
        //        Console.WriteLine("User has successfully logged in. Test Passed");
        //    }
        //    else
        //    {
        //        Console.WriteLine("User has not successfully logged in. Test Failed");
        //    }

        //}

        public void NavigateToTimeAndMaterialPage(IWebDriver driver)
        {
            // Wait for 10 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Identify the Administration tab
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));

            // Click the Administration tab
            administrationTab.Click();

            // Identify the Time & Materials option
            IWebElement timeAndMaterialsOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));

            // Click the Time & Materials option
            timeAndMaterialsOption.Click();

        }
    }
}
