using OpenQA.Selenium;
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
            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Identify the last record Delete button
            IWebElement lastRecordDeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));

            // Click the last record Edit button
            lastRecordDeleteButton.Click();

            // Switch to the alert
            driver.SwitchTo().Alert().Accept();

            // Wait for 1 second
            Thread.Sleep(1000);
        }

        public void verifyIfRecordWasDeletedSuccessfully(IWebDriver driver)
        {
            // Wait for 10 seconds
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);
           
            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Wait for 10 seconds
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);

            // Identify the last record Code field
            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement lastRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            // Verify if lastRecordCodeField is not equal to "TestEditedCode"
            if (lastRecordCode.Text != editedCode
                || lastRecordDescription.Text != editedDescription
                || lastRecordPrice.Text != "$" + editedPrice + ".00")
            {
                Console.WriteLine("Record was deleted successfully. Test Passed");
            }
            else 
            {
                Console.WriteLine("Record was not deleted successfully. Test Failed");
            }
        }
    }
}
