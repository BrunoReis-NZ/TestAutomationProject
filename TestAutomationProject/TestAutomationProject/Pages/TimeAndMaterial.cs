﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationProject.Pages
{
    public class TimeAndMaterial
    {
        public void OpenCreatePage(IWebDriver driver)
        {
            try
            {
                // Identify the Create New button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                
                // Click the Create New button
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create New button not found");
            }
        }        
    }
}
