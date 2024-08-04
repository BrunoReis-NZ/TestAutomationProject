using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationProject.Pages
{
    public class Login
    {
        string userName = "hari";
        string passWord = "123123";
        string baseURL = "http://horse.industryconnect.io/";

        public void LoginSteps(IWebDriver driver)
        {
            // Navigate to the URL
            driver.Navigate().GoToUrl(baseURL);

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Identify the username field
            IWebElement username = driver.FindElement(By.Id("UserName"));

            // Enter the username
           
            username.SendKeys(userName);

            // Identify the password field 
            IWebElement password = driver.FindElement(By.Id("Password"));

            // Enter the password
            password.SendKeys(passWord);

            // Identify the login button
            IWebElement loginButton = driver.FindElement(By.XPath("//input[@type='submit']"));

            // Click the login button
            loginButton.Click();
        }
    }
}
