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
        String editedCode = "TestEditedCode";
        String editedDescription = "TestEditedDescription";
        String editedPrice = "200";

        public void editRecord(IWebDriver driver)
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

        public void verifyIfRecordWasEditedSuccessfully(IWebDriver driver)
        {
            Thread.Sleep(3000);

            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Wait for 10 seconds
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);

            // Identify the last record
            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement lastRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(lastRecordCode.Text == editedCode, "Record has not been edited. Test Failed");
            Assert.That(lastRecordDescription.Text == editedDescription, "Record has not been edited. Test Failed");
            Assert.That(lastRecordPrice.Text == "$" + editedPrice + ".00", "Record has not been edited. Test Failed");
        }
    }
}
