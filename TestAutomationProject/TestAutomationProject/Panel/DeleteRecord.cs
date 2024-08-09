using NUnit.Framework;
using OpenQA.Selenium;
using TestAutomationProject.Utilities;
using System;


namespace TestAutomationProject.Panel
{
    public class DeleteRecord
    {
        String editedCode = "TestEditedCode3";
        String editedDescription = "TestEditedDescription3";
        String editedPrice = "$400.00";
       
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

            // Verify if the record was edited successfully
            VerifyDeletedCodeDescriptionAndPrice(driver, editedCode, editedDescription, editedPrice);
        }

        public void VerifyDeletedCodeDescriptionAndPrice(IWebDriver driver, string editedCode, string editedDescription, string editedPrice)
        {
            Assert.That(GetLastRecordDeletedCode(driver) != editedCode, "Actual code is not equal to expected code");
            Assert.That(GetLastRecordDeletedDescription(driver) != editedDescription, "Actual description is not equal to expected description");
            Assert.That(GetLastRecordDeletedPrice(driver) != editedPrice, "Actual price is not equal to expected price");
        }

        public string GetLastRecordDeletedCode(IWebDriver driver)
        {
            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return lastRecordCode.Text;
        }

        public string GetLastRecordDeletedDescription(IWebDriver driver)
        {
            IWebElement lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return lastRecordDescription.Text;
        }

        public string GetLastRecordDeletedPrice(IWebDriver driver)
        {
            IWebElement lastRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return lastRecordPrice.Text;
        }



    }
}
