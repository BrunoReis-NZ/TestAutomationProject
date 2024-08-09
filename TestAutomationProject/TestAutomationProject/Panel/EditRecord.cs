using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.Utilities;

namespace TestAutomationProject.Panel
{
    public class EditRecord
    {
        public void editRecord(IWebDriver driver, String editedCode, String editedDescription, String editedPrice)
        {
            Thread.Sleep(2000);

            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Identify the last record Edit button
            IWebElement lastRecordEditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));

            // Click the last record Edit button
            lastRecordEditButton.Click();

            // Identify the Code field
            IWebElement toBeEditedCodeField = driver.FindElement(By.Id("Code"));

            // Clear the Code field
            toBeEditedCodeField.Clear();

            // Type code in the Code field
            toBeEditedCodeField.SendKeys(editedCode);

            // Identify the Description field
            IWebElement toBeEditedDescriptionField = driver.FindElement(By.Id("Description"));

            // Clear the Description field
            toBeEditedDescriptionField.Clear();

            // Type description in the Description field
            toBeEditedDescriptionField.SendKeys(editedDescription);

            // Identify the Price per unit field (Overlap)
            IWebElement toBeEditedPricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

            // Click the Price per unit field
            toBeEditedPricePerUnitFieldOverlap.Click();

            // Identify the Price per unit field
            IWebElement toBeEditedPricePerUnitField = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));

            // Clear the Price per unit field
            toBeEditedPricePerUnitField.Clear();

            // Identify the Price per unit field (Overlap)
            toBeEditedPricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

            // Click the Price per unit field
            toBeEditedPricePerUnitFieldOverlap.Click();

            // Type price in the Price per unit field
            toBeEditedPricePerUnitField.SendKeys(editedPrice);

            // Īdentify the Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));

            // Click the Save button
            saveButton.Click();
        }

        public void verifyIfRecordWasEditedSuccessfully(IWebDriver driver, string editedCode, string editedDescription, string editedPrice)
        {
            Thread.Sleep(3000);

            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Wait for 10 seconds
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);

            // Verify if the record was edited successfully
            VerifyEditedCodeDescriptionAndPrice(driver, editedCode, editedDescription, editedPrice);
            
        }

        public void VerifyEditedCodeDescriptionAndPrice (IWebDriver driver, string editedCode, string editedDescription, string editedPrice)
        {
            Assert.That(GetLastRecordEditedCode(driver) == editedCode, "Actual code is not equal to expected code");
            Assert.That(GetLastRecordEditedDescription(driver) == editedDescription, "Actual description is not equal to expected description");
            Assert.That(GetLastRecordEditedPrice(driver) == editedPrice, "Actual price is not equal to expected price");
        }

        public string GetLastRecordEditedCode(IWebDriver driver)
        {
            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return lastRecordCode.Text;
        }

        public string GetLastRecordEditedDescription(IWebDriver driver)
        {
            IWebElement lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return lastRecordDescription.Text;
        }

        public string GetLastRecordEditedPrice(IWebDriver driver)
        {
            IWebElement lastRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return lastRecordPrice.Text;
        }

        
    }
}
