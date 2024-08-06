using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.Utilities;

namespace TestAutomationProject.Panel
{
    public class DeleteRecord
    {
        String editedCode = "TestEditedCode";
        String editedDescription = "TestEditedDescription";
        String editedPrice = "200";
       
        public void deleteRecord(IWebDriver driver)
        {
            Thread.Sleep(2000);

            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Wait for 5 seconds
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 5);

            // Identify the last record Delete button
            IWebElement lastRecordDeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));

            // Click the last record Edit button
            lastRecordDeleteButton.Click();

            // Switch to the alert
            driver.SwitchTo().Alert().Accept();
        }

        public void verifyIfRecordWasDeletedSuccessfully(IWebDriver driver)
        {
            Thread.Sleep(2000);

            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Identify the last record Code field
            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement lastRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(lastRecordCode.Text != editedCode, "Record has not been deleted. Test Failed");
            Assert.That(lastRecordDescription.Text != editedDescription, "Record has not been deleted. Test Failed");
            Assert.That(lastRecordPrice.Text != editedPrice, "Record has not been deleted. Test Failed");
        }
    }
}
