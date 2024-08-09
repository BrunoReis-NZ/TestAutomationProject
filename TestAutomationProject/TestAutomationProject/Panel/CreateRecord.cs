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
    public class CreateRecord
    {
        String code = "TestCode";
        String description = "TestDescription";
        String price = "$100.00";

        public void CreateMaterialRecord (IWebDriver driver)
        {
            // Identify the Code field
            IWebElement codeField = driver.FindElement(By.Id("Code"));

            // Type code in the Code field
            codeField.SendKeys(code);

            // Identify the Description field
            IWebElement descriptionField = driver.FindElement(By.Id("Description"));

            // Type description in the Description field
            descriptionField.SendKeys(description);

            // Identify the Price per unit field (Overlap)
            IWebElement pricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

            // Click the Price per unit field
            pricePerUnitFieldOverlap.Click();

            // Identify the Price per unit field
            IWebElement pricePerUnitField = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));

            // Type price in the Price per unit field
            pricePerUnitField.SendKeys(price);

            // Īdentify the Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));

            // Click the Save button
            saveButton.Click();
        }

        public void CreateTimeRecord (IWebDriver driver)
        {
            // Select Time from dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            
            // Click the TypeCode dropdown
            typeCodeDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 3);

            // Select Time option from dropdown
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            
            // Click the Time option
            timeOption.Click();

            // Identify the Code field
            IWebElement codeField = driver.FindElement(By.Id("Code"));

            // Type code in the Code field
            codeField.SendKeys(code);

            // Identify the Description field
            IWebElement descriptionField = driver.FindElement(By.Id("Description"));

            // Type description in the Description field
            descriptionField.SendKeys(description);

            // Identify the Price per unit field (Overlap)
            IWebElement pricePerUnitFieldOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

            // Click the Price per unit field
            pricePerUnitFieldOverlap.Click();

            // Identify the Price per unit field
            IWebElement pricePerUnitField = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));

            // Type price in the Price per unit field
            pricePerUnitField.SendKeys(price);

            // Īdentify the Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));

            // Click the Save button
            saveButton.Click();
        }

        public void VerifyIfRecordWasCreatedSuccessfully(IWebDriver driver)
        {
            Thread.Sleep(2000);

            // Identify the last page button
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            // Click the last page button
            lastPageButton.Click();

            // Wait for 5 seconds
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 5);

            // Verify if the record was created successfully
            VerifyCodeDescriptionAndPrice(driver, code, description, price);
        }        

        public void VerifyCodeDescriptionAndPrice(IWebDriver driver, string code, string description, string price)
        {
            Assert.That(GetLastRecordCode(driver) == code, "Actual code is not equal to expected code");
            Assert.That(GetLastRecordDescription(driver) == description, "Actual description is not equal to expected description");
            Assert.That(GetLastRecordPrice(driver) == price, "Actual price is not equal to expected price");
        }

        public string GetLastRecordCode(IWebDriver driver)
        {
            IWebElement lastRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return lastRecordCode.Text;
        }

        public string GetLastRecordDescription(IWebDriver driver)
        {
            IWebElement lastRecordDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return lastRecordDescription.Text;
        }

        public string GetLastRecordPrice(IWebDriver driver)
        {
            IWebElement lastRecordPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return lastRecordPrice.Text;
        }

    }
}
